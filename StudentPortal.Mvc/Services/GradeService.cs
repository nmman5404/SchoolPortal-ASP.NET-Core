using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;

namespace StudentPortal.Mvc.Services;

public class GradeService : IGradeService
{
    private readonly ICourseClassRepository _classes;
    private readonly IGradeRepository _grades;

    public GradeService(ICourseClassRepository classes, IGradeRepository grades)
    {
        _classes = classes;
        _grades = grades;
    }

    public async Task<List<CourseClass>> GetClassesAsync(string userId, bool isAdmin)
    {
        var query = _classes.Query().Include(c => c.Subject).AsNoTracking();
        if (!isAdmin)
        {
            var myClassIds = await _classes.QueryClassProfessors().Where(cp => cp.ProfessorId == userId).Select(cp => cp.CourseClassId).ToListAsync();
            query = query.Where(c => myClassIds.Contains(c.Id));
        }

        return await query.ToListAsync();
    }

    public async Task<GradeClassData?> GetClassGradesAsync(int classId, string userId, bool isAdmin)
    {
        if (!isAdmin && !await _classes.QueryClassProfessors().AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == userId))
            return null;

        var courseClass = await _classes.Query().Include(c => c.Subject).FirstOrDefaultAsync(c => c.Id == classId);
        if (courseClass == null) return null;

        var grades = await _grades.Query()
            .Include(g => g.Student).ThenInclude(s => s!.User)
            .Where(g => g.CourseClassId == classId)
            .ToListAsync();

        return new GradeClassData(courseClass, grades);
    }

    public async Task<ServiceResult> UpdateSingleGradeAsync(int gradeId, float? score, string? note, string? rowVersion, int classId, string userId, bool isAdmin)
    {
        if (!isAdmin && !await _classes.QueryClassProfessors().AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == userId))
            return ServiceResult.Denied();

        var grade = await _grades.GetByIdAsync(gradeId);
        if (grade == null) return ServiceResult.Missing();

        try
        {
            grade.Score = score;
            grade.Note = note;
            grade.RowVersion = Guid.NewGuid().ToByteArray();
            _grades.SetOriginalRowVersion(grade, Convert.FromBase64String(rowVersion ?? ""));
            await _grades.SaveChangesAsync();
            return ServiceResult.Ok("Luu diem thanh cong!");
        }
        catch (FormatException)
        {
            return ServiceResult.Fail("RowVersion khong hop le, vui long tai lai trang.");
        }
        catch (DbUpdateConcurrencyException)
        {
            return ServiceResult.Concurrency("Loi dung do: Giang vien khac vua sua diem nay!");
        }
    }
}
