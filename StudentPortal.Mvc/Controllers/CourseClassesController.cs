using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class CourseClassesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CourseClassesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private IQueryable<Subject> GetManageableSubjectsQuery(ApplicationUser user, bool isAdmin)
    {
        var query = _context.Subjects
            .Include(s => s.Major).ThenInclude(m => m!.Faculty)
            .AsQueryable();

        if (isAdmin) return query;

        return query.Where(s =>
            s.Major != null &&
            (s.Major.HeadMasterId == user.Id ||
             (s.Major.Faculty != null && s.Major.Faculty.HeadMasterId == user.Id)));
    }

    private async Task<bool> CheckCanManageClassAsync(int subjectId, ApplicationUser user, bool isAdmin)
    {
        if (isAdmin) return true;

        return await _context.Subjects
            .Include(s => s.Major).ThenInclude(m => m!.Faculty)
            .AsNoTracking()
            .AnyAsync(s =>
                s.Id == subjectId &&
                s.Major != null &&
                (s.Major.HeadMasterId == user.Id ||
                 (s.Major.Faculty != null && s.Major.Faculty.HeadMasterId == user.Id)));
    }

    private async Task<int?> GetProfessorFacultyIdAsync(string userId)
    {
        return await _context.ProfessorProfiles
            .AsNoTracking()
            .Where(p => p.UserId == userId)
            .Select(p => (int?)p.FacultyId)
            .FirstOrDefaultAsync();
    }

    private async Task<bool> CheckCanTeachClassAsync(int subjectId, string professorId)
    {
        var facultyId = await GetProfessorFacultyIdAsync(professorId);
        if (facultyId == null) return false;

        return await _context.Subjects
            .Include(s => s.Major)
            .AsNoTracking()
            .AnyAsync(s => s.Id == subjectId && s.Major != null && s.Major.FacultyId == facultyId.Value);
    }

    private async Task LoadCreateEditListsAsync(ApplicationUser user, bool isAdmin)
    {
        ViewBag.Subjects = await GetManageableSubjectsQuery(user, isAdmin)
            .AsNoTracking()
            .OrderBy(s => s.Major!.Faculty!.Name)
            .ThenBy(s => s.Major!.Name)
            .ThenBy(s => s.Name)
            .Select(s => new { s.Id, Name = $"{s.Name} ({s.Major!.Name} - {s.Major.Faculty!.Name})" })
            .ToListAsync();

        ViewBag.Semesters = await _context.Semesters
            .AsNoTracking()
            .OrderByDescending(s => s.StartDate)
            .ToListAsync();
    }

    private async Task LoadIndexFiltersAsync(ApplicationUser user, bool isAdmin, int? facultyId, int? majorId)
    {
        if (isAdmin)
        {
            ViewBag.Faculties = await _context.Faculties
                .AsNoTracking()
                .Where(f => !f.IsDeleted)
                .OrderBy(f => f.Name)
                .ToListAsync();
            ViewBag.Majors = await _context.Majors
                .Include(m => m.Faculty)
                .AsNoTracking()
                .Where(m => !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
                .OrderBy(m => m.Faculty!.Name)
                .ThenBy(m => m.Name)
                .ToListAsync();
        }
        else
        {
            var facultyIds = await _context.ProfessorProfiles
                .Where(p => p.UserId == user.Id)
                .Select(p => p.FacultyId)
                .ToListAsync();

            ViewBag.Faculties = await _context.Faculties
                .AsNoTracking()
                .Where(f => facultyIds.Contains(f.Id) && !f.IsDeleted)
                .OrderBy(f => f.Name)
                .ToListAsync();
            ViewBag.Majors = await _context.Majors
                .Include(m => m.Faculty)
                .AsNoTracking()
                .Where(m => facultyIds.Contains(m.FacultyId) && !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        ViewData["FacultyId"] = facultyId;
        ViewData["MajorId"] = majorId;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? facultyId, int? majorId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        bool isProfessor = await _userManager.IsInRoleAsync(user, "Professor");
        var professorFacultyId = isProfessor ? await GetProfessorFacultyIdAsync(user.Id) : null;
        await LoadIndexFiltersAsync(user, isAdmin, facultyId, majorId);

        var classesQuery = _context.CourseClasses.IgnoreQueryFilters()
            .Include(c => c.Subject).ThenInclude(s => s!.Major).ThenInclude(m => m!.Faculty)
            .Include(c => c.Semester)
            .Include(c => c.ClassProfessors)
            .AsNoTracking()
            .AsQueryable();

        if (!isAdmin)
        {
            if (professorFacultyId == null)
            {
                classesQuery = classesQuery.Where(c => false);
            }
            else
            {
                classesQuery = classesQuery.Where(c =>
                    c.Subject != null &&
                    c.Subject.Major != null &&
                    c.Subject.Major.FacultyId == professorFacultyId.Value);
            }
        }

        if (facultyId.HasValue)
        {
            classesQuery = classesQuery.Where(c =>
                c.Subject != null &&
                c.Subject.Major != null &&
                c.Subject.Major.FacultyId == facultyId.Value);
        }

        if (majorId.HasValue)
        {
            classesQuery = classesQuery.Where(c => c.Subject != null && c.Subject.MajorId == majorId.Value);
        }

        var classes = await classesQuery
            .OrderBy(c => c.Semester!.StartDate)
            .ThenBy(c => c.Subject!.Name)
            .ToListAsync();

        var model = new List<CourseClassListItemViewModel>();
        foreach (var c in classes)
        {
            var canManage = await CheckCanManageClassAsync(c.SubjectId, user, isAdmin);
            var canTeach = isProfessor &&
                           !c.IsDeleted &&
                           professorFacultyId != null &&
                           c.Subject?.Major?.FacultyId == professorFacultyId.Value;

            model.Add(new CourseClassListItemViewModel
            {
                Id = c.Id,
                SubjectName = c.Subject?.Name ?? "N/A",
                SemesterName = c.Semester?.Name ?? "N/A",
                Room = c.Room,
                DayOfWeek = c.DayOfWeek,
                StartPeriod = c.StartPeriod,
                EndPeriod = c.EndPeriod,
                Capacity = c.Capacity,
                EnrolledCount = c.EnrolledCount,
                IsDeleted = c.IsDeleted,
                CanManage = canManage,
                CanTeach = canTeach,
                IsAssignedProfessor = c.ClassProfessors.Any(cp => cp.ProfessorId == user.Id)
            });
        }

        ViewBag.CanCreateClass = isAdmin || await GetManageableSubjectsQuery(user, isAdmin).AnyAsync();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> CreateEdit(int? id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        await LoadCreateEditListsAsync(user, isAdmin);

        if (id == null)
        {
            if (!((IEnumerable<object>)ViewBag.Subjects).Any())
            {
                TempData["ErrorMessage"] = "Bạn không có quyền mở lớp cho môn học nào.";
                return RedirectToAction(nameof(Index));
            }

            return View(new CourseClassEditViewModel
            {
                DayOfWeek = DayOfWeek.Monday,
                StartPeriod = 1,
                EndPeriod = 3,
                Capacity = 40
            });
        }

        var courseClass = await _context.CourseClasses.FirstOrDefaultAsync(c => c.Id == id.Value);
        if (courseClass == null) return NotFound();

        if (!await CheckCanManageClassAsync(courseClass.SubjectId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        return View(new CourseClassEditViewModel
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
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEdit(CourseClassEditViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        if (model.EndPeriod < model.StartPeriod)
            ModelState.AddModelError(nameof(model.EndPeriod), "Tiết kết thúc phải lớn hơn hoặc bằng tiết bắt đầu.");

        if (!ModelState.IsValid)
        {
            await LoadCreateEditListsAsync(user, isAdmin);
            return View(model);
        }

        if (!await CheckCanManageClassAsync(model.SubjectId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        try
        {
            if (model.Id == 0)
            {
                var newClass = new CourseClass
                {
                    SubjectId = model.SubjectId,
                    SemesterId = model.SemesterId,
                    Room = model.Room,
                    DayOfWeek = model.DayOfWeek,
                    StartPeriod = model.StartPeriod,
                    EndPeriod = model.EndPeriod,
                    Capacity = model.Capacity,
                    RowVersion = Guid.NewGuid().ToByteArray()
                };
                _context.CourseClasses.Add(newClass);
                TempData["SuccessMessage"] = "Đã mở lớp học mới thành công!";
            }
            else
            {
                var courseClass = await _context.CourseClasses.FirstOrDefaultAsync(c => c.Id == model.Id);
                if (courseClass == null) return NotFound();

                if (!await CheckCanManageClassAsync(courseClass.SubjectId, user, isAdmin))
                    return RedirectToAction("AccessDenied", "Account");

                courseClass.SubjectId = model.SubjectId;
                courseClass.SemesterId = model.SemesterId;
                courseClass.Room = model.Room;
                courseClass.DayOfWeek = model.DayOfWeek;
                courseClass.StartPeriod = model.StartPeriod;
                courseClass.EndPeriod = model.EndPeriod;
                courseClass.Capacity = model.Capacity;
                courseClass.RowVersion = Guid.NewGuid().ToByteArray();

                if (!string.IsNullOrWhiteSpace(model.RowVersion))
                {
                    _context.Entry(courseClass).Property(c => c.RowVersion).OriginalValue =
                        Convert.FromBase64String(model.RowVersion);
                }

                TempData["SuccessMessage"] = "Cập nhật lớp học thành công!";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            TempData["ErrorMessage"] = "LỖI ĐỤNG ĐỘ: Lớp học vừa bị thay đổi bởi người khác. Tải lại trang!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi: " + (ex.InnerException?.Message ?? ex.Message));
            await LoadCreateEditListsAsync(user, isAdmin);
            return View(model);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleDelete(int id, bool restore = false)
    {
        var courseClass = await _context.CourseClasses.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == id);
        if (courseClass == null) return NotFound();

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        if (!await CheckCanManageClassAsync(courseClass.SubjectId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        courseClass.IsDeleted = !restore;
        courseClass.RowVersion = Guid.NewGuid().ToByteArray();
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = restore ? "Đã khôi phục Lớp học!" : "Đã đưa Lớp học vào thùng rác!";
        return RedirectToAction(nameof(Index), new { showDeleted = restore });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignProfessor(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        if (!await _userManager.IsInRoleAsync(user, "Professor"))
            return RedirectToAction("AccessDenied", "Account");

        var courseClass = await _context.CourseClasses
            .Include(c => c.Subject).ThenInclude(s => s!.Major)
            .FirstOrDefaultAsync(c => c.Id == classId);
        if (courseClass == null) return NotFound();

        if (courseClass.IsDeleted)
        {
            TempData["ErrorMessage"] = "Không thể nhận dạy lớp đã bị xóa.";
            return RedirectToAction(nameof(Index));
        }

        if (!await CheckCanTeachClassAsync(courseClass.SubjectId, user.Id))
        {
            TempData["ErrorMessage"] = "Bạn chỉ được nhận dạy các lớp thuộc khoa của mình.";
            return RedirectToAction(nameof(Index));
        }

        bool alreadyAssigned = await _context.ClassProfessors
            .AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == user.Id);

        if (alreadyAssigned)
        {
            TempData["ErrorMessage"] = "Bạn đã nhận lớp này rồi!";
            return RedirectToAction(nameof(Index));
        }

        bool hasScheduleConflict = await _context.ClassProfessors
            .Include(cp => cp.CourseClass)
            .Where(cp =>
                cp.ProfessorId == user.Id &&
                cp.CourseClass != null &&
                !cp.CourseClass.IsDeleted &&
                cp.CourseClass.SemesterId == courseClass.SemesterId &&
                cp.CourseClass.DayOfWeek == courseClass.DayOfWeek)
            .AnyAsync(cp =>
                !(cp.CourseClass!.EndPeriod < courseClass.StartPeriod ||
                  cp.CourseClass.StartPeriod > courseClass.EndPeriod));

        if (hasScheduleConflict)
        {
            TempData["ErrorMessage"] = "Bạn đang dạy một lớp khác trùng thời gian với lớp này.";
            return RedirectToAction(nameof(Index));
        }

        _context.ClassProfessors.Add(new ClassProfessor { CourseClassId = classId, ProfessorId = user.Id });
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Bạn đã nhận giảng dạy lớp này thành công!";

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UnassignProfessor(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var assignment = await _context.ClassProfessors
            .FirstOrDefaultAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == user.Id);
        if (assignment == null)
        {
            TempData["ErrorMessage"] = "Bạn chưa nhận dạy lớp này.";
            return RedirectToAction(nameof(Index));
        }

        _context.ClassProfessors.Remove(assignment);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Đã hủy nhận giảng dạy lớp này.";

        return RedirectToAction(nameof(Index));
    }
}
