using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly ApplicationDbContext _context;
    private readonly IAuditLogService _auditLogService;

    public EnrollmentService(ApplicationDbContext context, IAuditLogService auditLogService)
    {
        _context = context;
        _auditLogService = auditLogService;
    }

    public async Task<List<EnrollmentClassViewModel>> GetAvailableClassesAsync(string studentId)
    {
        var studentProfile = await _context.StudentProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.UserId == studentId);
        if (studentProfile == null) return new List<EnrollmentClassViewModel>();

        var openSemester = await _context.Semesters
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.IsRegistrationOpen);
        if (openSemester == null) return new List<EnrollmentClassViewModel>();

        var classes = await _context.CourseClasses
            .Include(c => c.Subject)
            .Where(c =>
                c.SemesterId == openSemester.Id &&
                !c.IsDeleted &&
                c.Subject != null &&
                c.Subject.MajorId == studentProfile.MajorId)
            .AsNoTracking()
            .OrderBy(c => c.Subject!.Name)
            .ThenBy(c => c.DayOfWeek)
            .ThenBy(c => c.StartPeriod)
            .ToListAsync();

        var enrolledClassIds = await _context.Grades
            .Where(g => g.StudentId == studentId)
            .Select(g => g.CourseClassId)
            .ToListAsync();

        return classes.Select(c => new EnrollmentClassViewModel
        {
            ClassId = c.Id,
            SubjectName = c.Subject?.Name ?? "N/A",
            Credits = c.Subject?.Credits ?? 0,
            Room = c.Room,
            DayOfWeek = c.DayOfWeek,
            StartPeriod = c.StartPeriod,
            EndPeriod = c.EndPeriod,
            Capacity = c.Capacity,
            EnrolledCount = c.EnrolledCount,
            RowVersion = Convert.ToBase64String(c.RowVersion),
            IsEnrolled = enrolledClassIds.Contains(c.Id)
        }).ToList();
    }

    public async Task<bool> EnrollClassAsync(string studentId, int classId, string rowVersion)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var studentProfile = await _context.StudentProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == studentId);
            if (studentProfile == null) throw new Exception("Không tìm thấy hồ sơ sinh viên.");

            var courseClass = await _context.CourseClasses
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(c => c.Id == classId);
            if (courseClass == null || courseClass.IsDeleted)
                throw new Exception("Lớp học không tồn tại hoặc đã bị hủy.");

            var openSemester = await _context.Semesters
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == courseClass.SemesterId && s.IsRegistrationOpen);
            if (openSemester == null)
                throw new Exception("Lớp học này không thuộc học kỳ đang mở đăng ký.");

            if (courseClass.Subject?.MajorId != studentProfile.MajorId)
                throw new Exception("Bạn chỉ được đăng ký lớp học thuộc ngành của mình.");

            bool alreadyEnrolled = await _context.Grades
                .AnyAsync(g => g.StudentId == studentId && g.CourseClassId == classId);
            if (alreadyEnrolled)
                throw new Exception("Bạn đã đăng ký lớp học này rồi.");

            if (courseClass.EnrolledCount >= courseClass.Capacity)
                throw new Exception("Lớp học này đã hết chỗ.");

            var myEnrolledClasses = await _context.Grades
                .Include(g => g.CourseClass)
                .Where(g => g.StudentId == studentId && g.CourseClass!.SemesterId == courseClass.SemesterId)
                .Select(g => g.CourseClass)
                .ToListAsync();

            bool isConflict = myEnrolledClasses.Any(c =>
                c!.DayOfWeek == courseClass.DayOfWeek &&
                !(c.EndPeriod < courseClass.StartPeriod || c.StartPeriod > courseClass.EndPeriod));

            if (isConflict)
                throw new Exception("Bạn đã đăng ký một môn học khác trùng lịch với lớp này.");

            var prerequisites = await _context.PrerequisiteSubjects
                .Where(p => p.SubjectId == courseClass.SubjectId)
                .Select(p => new
                {
                    p.RequiredSubjectId,
                    RequiredSubjectName = p.RequiredSubject != null ? p.RequiredSubject.Name : "N/A"
                })
                .ToListAsync();

            if (prerequisites.Any())
            {
                var passedSubjects = await _context.Grades
                    .Include(g => g.CourseClass)
                    .Where(g => g.StudentId == studentId && g.Score > 5.0f)
                    .Select(g => g.CourseClass!.SubjectId)
                    .ToListAsync();

                var missing = prerequisites
                    .Where(p => !passedSubjects.Contains(p.RequiredSubjectId))
                    .Select(p => p.RequiredSubjectName)
                    .Distinct()
                    .OrderBy(name => name)
                    .ToList();
                if (missing.Any())
                    throw new Exception("Bạn chưa hoàn thành các môn học tiên quyết bắt buộc với điểm trên 5: " + string.Join(", ", missing) + ".");
            }

            _context.Grades.Add(new Grade
            {
                StudentId = studentId,
                CourseClassId = classId,
                RowVersion = Guid.NewGuid().ToByteArray()
            });

            courseClass.EnrolledCount += 1;
            courseClass.RowVersion = Guid.NewGuid().ToByteArray();

            if (string.IsNullOrWhiteSpace(rowVersion))
                throw new Exception("Phiên bản lớp học không hợp lệ. Vui lòng tải lại trang.");

            _context.Entry(courseClass).Property(c => c.RowVersion).OriginalValue =
                Convert.FromBase64String(rowVersion);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            await _auditLogService.LogAsync("EnrollClass", "CourseClass", classId.ToString(), "Success", $"Sinh viên {studentId} đăng ký thành công");
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            await transaction.RollbackAsync();
            await _auditLogService.LogAsync("EnrollClass", "CourseClass", classId.ToString(), "Failed", "Lỗi đụng độ slot cuối");
            throw new Exception("LỖI ĐỤNG ĐỘ: Có sinh viên khác vừa giành mất slot cuối cùng. Vui lòng tải lại trang.");
        }
        catch (FormatException)
        {
            await transaction.RollbackAsync();
            await _auditLogService.LogAsync("EnrollClass", "CourseClass", classId.ToString(), "Failed", "RowVersion không hợp lệ");
            throw new Exception("Phiên bản lớp học không hợp lệ. Vui lòng tải lại trang.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            await _auditLogService.LogAsync("EnrollClass", "CourseClass", classId.ToString(), "Failed", ex.Message);
            throw;
        }
    }

    public async Task<bool> UnenrollClassAsync(string studentId, int classId)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var grade = await _context.Grades
                .FirstOrDefaultAsync(g => g.StudentId == studentId && g.CourseClassId == classId);
            if (grade == null) throw new Exception("Bạn chưa đăng ký lớp học này.");

            if (grade.Score.HasValue)
                throw new Exception("Không thể hủy lớp học đã có điểm số.");

            var courseClass = await _context.CourseClasses.FirstOrDefaultAsync(c => c.Id == classId);
            if (courseClass != null)
            {
                courseClass.EnrolledCount = Math.Max(0, courseClass.EnrolledCount - 1);
                courseClass.RowVersion = Guid.NewGuid().ToByteArray();
            }

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            await _auditLogService.LogAsync("UnenrollClass", "CourseClass", classId.ToString(), "Success", $"Sinh viên {studentId} hủy đăng ký");
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            await _auditLogService.LogAsync("UnenrollClass", "CourseClass", classId.ToString(), "Failed", ex.Message);
            throw;
        }
    }
}
