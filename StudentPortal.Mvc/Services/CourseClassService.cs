using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public class CourseClassService : ICourseClassService
{
    private readonly ICourseClassRepository _classes;
    private readonly ISubjectRepository _subjects;
    private readonly IGradeRepository _grades;
    private readonly IMajorRepository _majors;
    private readonly IUserRepository _users;
    private readonly ISemesterRepository _semesters;

    public CourseClassService(ICourseClassRepository classes, ISubjectRepository subjects, IGradeRepository grades, IMajorRepository majors, IUserRepository users, ISemesterRepository semesters)
    {
        _classes = classes;
        _subjects = subjects;
        _grades = grades;
        _majors = majors;
        _users = users;
        _semesters = semesters;
    }

    public async Task<CourseClassIndexData> GetClassesAsync(string userId, bool isAdmin, bool isProfessor, int? facultyId, int? majorId, int? semesterId)
    {
        var (faculties, majors, semesters) = await GetIndexFiltersAsync(userId, isAdmin, facultyId);
        var professorFacultyId = isProfessor ? await GetProfessorFacultyIdAsync(userId) : null;

        var query = _classes.Query(includeDeleted: true)
            .Include(c => c.Subject).ThenInclude(s => s!.Major).ThenInclude(m => m!.Faculty)
            .Include(c => c.Semester)
            .Include(c => c.ClassProfessors)
            .AsNoTracking();

        if (!isAdmin)
        {
            query = professorFacultyId == null
                ? query.Where(c => false)
                : query.Where(c => c.Subject != null && c.Subject.Major != null && c.Subject.Major.FacultyId == professorFacultyId.Value);
        }

        if (facultyId.HasValue)
            query = query.Where(c => c.Subject != null && c.Subject.Major != null && c.Subject.Major.FacultyId == facultyId.Value);
        if (majorId.HasValue)
            query = query.Where(c => c.Subject != null && c.Subject.MajorId == majorId.Value);
        if (semesterId.HasValue)
            query = query.Where(c => c.SemesterId == semesterId.Value);

        var list = await query.OrderBy(c => c.Semester!.StartDate).ThenBy(c => c.Subject!.Name).ToListAsync();
        var model = new List<CourseClassListItemViewModel>();

        foreach (var courseClass in list)
        {
            model.Add(new CourseClassListItemViewModel
            {
                Id = courseClass.Id,
                SubjectName = courseClass.Subject?.Name ?? "N/A",
                SemesterName = courseClass.Semester?.Name ?? "N/A",
                Room = courseClass.Room,
                DayOfWeek = courseClass.DayOfWeek,
                StartPeriod = courseClass.StartPeriod,
                EndPeriod = courseClass.EndPeriod,
                Capacity = courseClass.Capacity,
                EnrolledCount = courseClass.EnrolledCount,
                IsDeleted = courseClass.IsDeleted,
                CanManage = await CheckCanManageClassAsync(courseClass.SubjectId, userId, isAdmin),
                CanTeach = isProfessor && !courseClass.IsDeleted && professorFacultyId != null && courseClass.Subject != null && !courseClass.Subject.IsDeleted && courseClass.Subject.Major?.FacultyId == professorFacultyId.Value,
                IsAssignedProfessor = courseClass.ClassProfessors.Any(cp => cp.ProfessorId == userId)
            });
        }

        return new CourseClassIndexData(model, faculties, majors, semesters, isAdmin || await GetManageableSubjectsQuery(userId, isAdmin).AnyAsync());
    }

    public async Task<CourseClassFormLists> GetFormListsAsync(string userId, bool isAdmin)
    {
        var subjects = await GetManageableSubjectsQuery(userId, isAdmin)
            .AsNoTracking()
            .OrderBy(s => s.Major!.Faculty!.Name)
            .ThenBy(s => s.Major!.Name)
            .ThenBy(s => s.Name)
            .Select(s => new LookupOption(s.Id, $"{s.Name} ({s.Major!.Name} - {s.Major.Faculty!.Name})"))
            .ToListAsync();

        var semesters = await _semesters.Query().AsNoTracking().OrderByDescending(s => s.StartDate).ToListAsync();
        return new CourseClassFormLists(subjects, semesters);
    }

    public async Task<CourseClassEditViewModel?> GetClassForEditAsync(int id, string userId, bool isAdmin)
    {
        var courseClass = await _classes.GetByIdAsync(id);
        if (courseClass == null) return null;
        if (!await CheckCanManageClassAsync(courseClass.SubjectId, userId, isAdmin)) return null;

        return new CourseClassEditViewModel
        {
            Id = courseClass.Id,
            SubjectId = courseClass.SubjectId,
            SemesterId = courseClass.SemesterId,
            Room = courseClass.Room,
            DayOfWeek = courseClass.DayOfWeek,
            StartPeriod = courseClass.StartPeriod,
            EndPeriod = courseClass.EndPeriod,
            Capacity = courseClass.Capacity,
            RowVersion = Convert.ToBase64String(courseClass.RowVersion)
        };
    }

    public async Task<bool> CheckCanManageClassAsync(int subjectId, string userId, bool isAdmin)
    {
        if (isAdmin) return true;

        return await _subjects.Query()
            .Include(s => s.Major).ThenInclude(m => m!.Faculty)
            .AsNoTracking()
            .AnyAsync(s => s.Id == subjectId && s.Major != null && (s.Major.HeadMasterId == userId || (s.Major.Faculty != null && s.Major.Faculty.HeadMasterId == userId)));
    }

    public async Task<CourseClassSaveResult> SaveClassAsync(CourseClassEditViewModel model, string userId, bool isAdmin)
    {
        var validationMessage = await ValidateClassModelAsync(model);
        if (validationMessage != null)
            return new CourseClassSaveResult(ServiceResult.Fail(validationMessage), await GetFormListsAsync(userId, isAdmin));

        if (!await CheckCanManageClassAsync(model.SubjectId, userId, isAdmin))
            return new CourseClassSaveResult(ServiceResult.Denied(), null);

        try
        {
            if (model.Id == 0)
            {
                _classes.Add(new CourseClass
                {
                    SubjectId = model.SubjectId,
                    SemesterId = model.SemesterId,
                    Room = model.Room,
                    DayOfWeek = model.DayOfWeek,
                    StartPeriod = model.StartPeriod,
                    EndPeriod = model.EndPeriod,
                    Capacity = model.Capacity,
                    RowVersion = Guid.NewGuid().ToByteArray()
                });
                await _classes.SaveChangesAsync();
                return new CourseClassSaveResult(ServiceResult.Ok("Da mo lop hoc moi thanh cong!"), null);
            }

            var courseClass = await _classes.GetByIdAsync(model.Id);
            if (courseClass == null) return new CourseClassSaveResult(ServiceResult.Missing(), null);
            if (!await CheckCanManageClassAsync(courseClass.SubjectId, userId, isAdmin))
                return new CourseClassSaveResult(ServiceResult.Denied(), null);

            var originalRowVersion = ParseRowVersion(model.RowVersion);
            courseClass.SubjectId = model.SubjectId;
            courseClass.SemesterId = model.SemesterId;
            courseClass.Room = model.Room;
            courseClass.DayOfWeek = model.DayOfWeek;
            courseClass.StartPeriod = model.StartPeriod;
            courseClass.EndPeriod = model.EndPeriod;
            courseClass.Capacity = model.Capacity;
            courseClass.RowVersion = Guid.NewGuid().ToByteArray();
            _classes.SetOriginalRowVersion(courseClass, originalRowVersion);

            await _classes.SaveChangesAsync();
            return new CourseClassSaveResult(ServiceResult.Ok("Cap nhat lop hoc thanh cong!"), null);
        }
        catch (FormatException)
        {
            return new CourseClassSaveResult(ServiceResult.Fail("RowVersion khong hop le, vui long tai lai trang."), await GetFormListsAsync(userId, isAdmin));
        }
        catch (DbUpdateConcurrencyException)
        {
            return new CourseClassSaveResult(ServiceResult.Concurrency("LOI DUNG DO: Lop hoc vua bi thay doi boi nguoi khac. Tai lai trang!"), null);
        }
        catch (Exception ex)
        {
            return new CourseClassSaveResult(ServiceResult.Fail("Da xay ra loi: " + (ex.InnerException?.Message ?? ex.Message)), await GetFormListsAsync(userId, isAdmin));
        }
    }

    public async Task<CourseClassStudentsViewModel?> GetStudentsAsync(int classId, string userId, bool isAdmin)
    {
        var courseClass = await _classes.GetForStudentManagementAsync(classId);
        if (courseClass == null) return null;
        if (!await CheckCanViewClassAsync(courseClass, userId, isAdmin)) return null;
        return await BuildClassStudentsViewModelAsync(courseClass, isAdmin);
    }

    public async Task<ServiceResult> AddStudentAsync(int classId, string studentId, bool isAdmin)
    {
        if (!isAdmin) return ServiceResult.Denied();
        if (string.IsNullOrWhiteSpace(studentId)) return ServiceResult.Fail("Vui long chon sinh vien can them.");

        await using var transaction = await _classes.BeginTransactionAsync();
        try
        {
            var courseClass = await _classes.Query(includeDeleted: true).Include(c => c.Subject).FirstOrDefaultAsync(c => c.Id == classId);
            if (courseClass == null) return ServiceResult.Missing();
            if (courseClass.IsDeleted) throw new Exception("Khong the them sinh vien vao lop da bi huy.");
            if (courseClass.Subject == null || courseClass.Subject.IsDeleted) throw new Exception("Mon hoc cua lop da bi xoa, khong the them sinh vien.");

            var studentProfile = await _users.GetStudentProfileAsync(studentId, includeLookups: false);
            if (studentProfile == null) throw new Exception("Sinh vien khong ton tai hoac da bi khoa.");
            var studentUser = await _users.FindByIdAsync(studentId);
            if (studentUser == null || studentUser.IsDeleted) throw new Exception("Sinh vien khong ton tai hoac da bi khoa.");
            if (studentProfile.MajorId != courseClass.Subject.MajorId) throw new Exception("Sinh vien khong thuoc nganh cua mon hoc nay.");
            if (await _grades.Query().AnyAsync(g => g.StudentId == studentId && g.CourseClassId == classId)) throw new Exception("Sinh vien da co trong lop nay.");
            if (courseClass.EnrolledCount >= courseClass.Capacity) throw new Exception("Lop hoc da day slot.");

            var hasScheduleConflict = await _grades.Query()
                .Include(g => g.CourseClass)
                .Where(g => g.StudentId == studentId && g.CourseClass != null && !g.CourseClass.IsDeleted && g.CourseClass.SemesterId == courseClass.SemesterId && g.CourseClass.DayOfWeek == courseClass.DayOfWeek)
                .AnyAsync(g => !(g.CourseClass!.EndPeriod < courseClass.StartPeriod || g.CourseClass.StartPeriod > courseClass.EndPeriod));
            if (hasScheduleConflict) throw new Exception("Sinh vien dang co lop khac trung lich.");

            var missingPrerequisites = await GetMissingPrerequisiteNamesAsync(studentId, courseClass.SubjectId);
            if (missingPrerequisites.Any()) throw new Exception("Sinh vien chua hoan thanh cac mon hoc tien quyet voi diem tren 5: " + string.Join(", ", missingPrerequisites) + ".");

            _grades.Add(new Grade { StudentId = studentId, CourseClassId = classId, RowVersion = Guid.NewGuid().ToByteArray() });
            courseClass.EnrolledCount += 1;
            courseClass.RowVersion = Guid.NewGuid().ToByteArray();
            await _classes.SaveChangesAsync();
            await transaction.CommitAsync();
            return ServiceResult.Ok("Da them sinh vien vao lop.");
        }
        catch (DbUpdateConcurrencyException)
        {
            await transaction.RollbackAsync();
            return ServiceResult.Concurrency("Lop vua duoc thay doi boi nguoi khac. Vui long tai lai trang.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return ServiceResult.Fail(ex.Message);
        }
    }

    public async Task<ServiceResult> RemoveStudentAsync(int classId, string studentId, bool isAdmin)
    {
        if (!isAdmin) return ServiceResult.Denied();
        await using var transaction = await _classes.BeginTransactionAsync();
        try
        {
            var grade = await _grades.Query().FirstOrDefaultAsync(g => g.StudentId == studentId && g.CourseClassId == classId);
            if (grade == null) throw new Exception("Sinh vien khong co trong lop nay.");
            var courseClass = await _classes.GetByIdAsync(classId, includeDeleted: true);
            _grades.Remove(grade);
            if (courseClass != null)
            {
                courseClass.EnrolledCount = Math.Max(0, courseClass.EnrolledCount - 1);
                courseClass.RowVersion = Guid.NewGuid().ToByteArray();
            }

            await _classes.SaveChangesAsync();
            await transaction.CommitAsync();
            return ServiceResult.Ok("Da bo sinh vien khoi lop.");
        }
        catch (DbUpdateConcurrencyException)
        {
            await transaction.RollbackAsync();
            return ServiceResult.Concurrency("Lop vua duoc thay doi boi nguoi khac. Vui long tai lai trang.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return ServiceResult.Fail(ex.Message);
        }
    }

    public async Task<ServiceResult> ToggleDeleteAsync(int id, bool restore, string userId, bool isAdmin)
    {
        var courseClass = await _classes.GetByIdAsync(id, includeDeleted: true);
        if (courseClass == null) return ServiceResult.Missing();
        if (!await CheckCanManageClassAsync(courseClass.SubjectId, userId, isAdmin)) return ServiceResult.Denied();

        courseClass.IsDeleted = !restore;
        courseClass.RowVersion = Guid.NewGuid().ToByteArray();
        await _classes.SaveChangesAsync();
        return ServiceResult.Ok(restore ? "Da khoi phuc Lop hoc!" : "Da dua Lop hoc vao thung rac!");
    }

    public async Task<ServiceResult> AssignProfessorAsync(int classId, string professorId)
    {
        var courseClass = await _classes.Query().Include(c => c.Subject).ThenInclude(s => s!.Major).FirstOrDefaultAsync(c => c.Id == classId);
        if (courseClass == null) return ServiceResult.Missing();
        if (courseClass.IsDeleted) return ServiceResult.Fail("Khong the nhan day lop da bi xoa.");
        if (!await CheckCanTeachClassAsync(courseClass.SubjectId, professorId)) return ServiceResult.Fail("Ban chi duoc nhan day cac lop thuoc khoa cua minh.");
        if (await _classes.QueryClassProfessors().AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == professorId)) return ServiceResult.Fail("Ban da nhan lop nay roi!");

        var hasScheduleConflict = await _classes.QueryClassProfessors()
            .Include(cp => cp.CourseClass)
            .Where(cp => cp.ProfessorId == professorId && cp.CourseClass != null && !cp.CourseClass.IsDeleted && cp.CourseClass.SemesterId == courseClass.SemesterId && cp.CourseClass.DayOfWeek == courseClass.DayOfWeek)
            .AnyAsync(cp => !(cp.CourseClass!.EndPeriod < courseClass.StartPeriod || cp.CourseClass.StartPeriod > courseClass.EndPeriod));
        if (hasScheduleConflict) return ServiceResult.Fail("Ban dang day mot lop khac trung thoi gian voi lop nay.");

        _classes.AddClassProfessor(new ClassProfessor { CourseClassId = classId, ProfessorId = professorId });
        await _classes.SaveChangesAsync();
        return ServiceResult.Ok("Ban da nhan giang day lop nay thanh cong!");
    }

    public async Task<ServiceResult> UnassignProfessorAsync(int classId, string professorId)
    {
        var assignment = await _classes.QueryClassProfessors().FirstOrDefaultAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == professorId);
        if (assignment == null) return ServiceResult.Fail("Ban chua nhan day lop nay.");
        _classes.RemoveClassProfessor(assignment);
        await _classes.SaveChangesAsync();
        return ServiceResult.Ok("Da huy nhan giang day lop nay.");
    }

    public async Task<List<object>> SearchAsync(string keyword)
    {
        var rows = await _classes.Query()
            .Include(c => c.Subject)
            .AsNoTracking()
            .Where(c => c.Room.Contains(keyword) || (c.Subject != null && c.Subject.Name.Contains(keyword)))
            .Select(c => new { c.Id, c.Room, Subject = c.Subject!.Name })
            .ToListAsync();
        return rows.Cast<object>().ToList();
    }

    private IQueryable<Subject> GetManageableSubjectsQuery(string userId, bool isAdmin)
    {
        var query = _subjects.Query().Include(s => s.Major).ThenInclude(m => m!.Faculty).AsQueryable();
        if (isAdmin) return query;
        return query.Where(s => s.Major != null && (s.Major.HeadMasterId == userId || (s.Major.Faculty != null && s.Major.Faculty.HeadMasterId == userId)));
    }

    private async Task<int?> GetProfessorFacultyIdAsync(string userId) => (await _users.GetProfessorProfileAsync(userId))?.FacultyId;

    private async Task<bool> CheckCanTeachClassAsync(int subjectId, string professorId)
    {
        var facultyId = await GetProfessorFacultyIdAsync(professorId);
        if (facultyId == null) return false;
        return await _subjects.Query().Include(s => s.Major).AsNoTracking().AnyAsync(s => s.Id == subjectId && s.Major != null && s.Major.FacultyId == facultyId.Value);
    }

    private async Task<bool> CheckCanViewClassAsync(CourseClass courseClass, string userId, bool isAdmin)
    {
        if (isAdmin) return true;
        var professorFacultyId = await GetProfessorFacultyIdAsync(userId);
        return professorFacultyId.HasValue && courseClass.Subject?.Major?.FacultyId == professorFacultyId.Value;
    }

    private async Task<(List<Faculty> Faculties, List<Major> Majors, List<Semester> Semesters)> GetIndexFiltersAsync(string userId, bool isAdmin, int? facultyId)
    {
        List<int> facultyIds = new();
        if (!isAdmin)
        {
            var facultyIdForProfessor = await GetProfessorFacultyIdAsync(userId);
            if (facultyIdForProfessor.HasValue) facultyIds.Add(facultyIdForProfessor.Value);
        }

        var faculties = await _majors.QueryFaculties().AsNoTracking()
            .Where(f => !f.IsDeleted && (isAdmin || facultyIds.Contains(f.Id)))
            .OrderBy(f => f.Name).ToListAsync();

        var majors = await _majors.Query().Include(m => m.Faculty).AsNoTracking()
            .Where(m => !m.IsDeleted && (isAdmin || facultyIds.Contains(m.FacultyId)) && (facultyId == null || m.FacultyId == facultyId.Value))
            .OrderBy(m => isAdmin ? m.Faculty!.Name : m.Name).ThenBy(m => m.Name).ToListAsync();

        var semesters = await _semesters.Query().AsNoTracking().OrderByDescending(s => s.StartDate).ToListAsync();
        return (faculties, majors, semesters);
    }

    private async Task<string?> ValidateClassModelAsync(CourseClassEditViewModel model)
    {
        if (model.EndPeriod < model.StartPeriod) return "EndPeriod|Tiet ket thuc phai lon hon hoac bang tiet bat dau.";

        var selectedSubject = await _subjects.Query(includeDeleted: true).AsNoTracking().FirstOrDefaultAsync(s => s.Id == model.SubjectId);
        if (model.SubjectId > 0 && (selectedSubject == null || selectedSubject.IsDeleted))
            return "SubjectId|Mon hoc da bi xoa hoac khong con ton tai, khong the mo/cap nhat lop.";

        if (model.SemesterId > 0 && !await _semesters.Query().AsNoTracking().AnyAsync(s => s.Id == model.SemesterId))
            return "SemesterId|Hoc ky khong con ton tai, vui long chon lai.";

        return null;
    }

    private async Task<CourseClassStudentsViewModel> BuildClassStudentsViewModelAsync(CourseClass courseClass, bool isAdmin)
    {
        var grades = await _grades.Query()
            .Include(g => g.Student).ThenInclude(s => s!.User)
            .Include(g => g.Student).ThenInclude(s => s!.Major)
            .Where(g => g.CourseClassId == courseClass.Id)
            .AsNoTracking()
            .OrderBy(g => g.Student!.User!.FullName)
            .ToListAsync();

        var enrolledStudentIds = grades.Select(g => g.StudentId).ToHashSet();
        var candidateStudents = new List<CourseClassStudentOptionViewModel>();

        if (isAdmin && !courseClass.IsDeleted && courseClass.Subject != null && !courseClass.Subject.IsDeleted && courseClass.EnrolledCount < courseClass.Capacity)
        {
            candidateStudents = await _users.QueryUsers()
                .Where(u => !u.IsDeleted && u.StudentProfile != null && u.StudentProfile.MajorId == courseClass.Subject.MajorId && !enrolledStudentIds.Contains(u.Id))
                .OrderBy(u => u.FullName)
                .Select(u => new CourseClassStudentOptionViewModel { StudentId = u.Id, FullName = u.FullName, Email = u.Email ?? "", PID = u.PID ?? "" })
                .ToListAsync();
        }

        return new CourseClassStudentsViewModel
        {
            ClassId = courseClass.Id,
            SubjectName = courseClass.Subject?.Name ?? "N/A",
            SemesterName = courseClass.Semester?.Name ?? "N/A",
            Room = courseClass.Room,
            DayOfWeek = courseClass.DayOfWeek,
            StartPeriod = courseClass.StartPeriod,
            EndPeriod = courseClass.EndPeriod,
            Capacity = courseClass.Capacity,
            EnrolledCount = courseClass.EnrolledCount,
            IsDeleted = courseClass.IsDeleted,
            IsAdmin = isAdmin,
            Students = grades.Select(g => new CourseClassStudentItemViewModel
            {
                StudentId = g.StudentId,
                FullName = g.Student?.User?.FullName ?? "N/A",
                Email = g.Student?.User?.Email ?? "",
                PID = g.Student?.User?.PID ?? "",
                MajorName = g.Student?.Major?.Name ?? "N/A",
                Score = g.Score
            }).ToList(),
            CandidateStudents = candidateStudents
        };
    }

    private async Task<List<string>> GetMissingPrerequisiteNamesAsync(string studentId, int subjectId)
    {
        var prerequisites = await _subjects.QueryPrerequisites()
            .Where(p => p.SubjectId == subjectId)
            .Select(p => new { p.RequiredSubjectId, RequiredSubjectName = p.RequiredSubject != null ? p.RequiredSubject.Name : "N/A" })
            .ToListAsync();
        if (!prerequisites.Any()) return new List<string>();

        var passedSubjects = await _grades.Query()
            .Include(g => g.CourseClass)
            .Where(g => g.StudentId == studentId && g.Score > 5.0f)
            .Select(g => g.CourseClass!.SubjectId)
            .ToListAsync();

        return prerequisites.Where(p => !passedSubjects.Contains(p.RequiredSubjectId)).Select(p => p.RequiredSubjectName).Distinct().OrderBy(name => name).ToList();
    }

    private static byte[] ParseRowVersion(string? rowVersion) => Convert.FromBase64String(rowVersion ?? "");
}
