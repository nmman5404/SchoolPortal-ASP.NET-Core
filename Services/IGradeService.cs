using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Services;

public interface IGradeService
{
    Task<List<CourseClass>> GetClassesAsync(string userId, bool isAdmin);
    Task<GradeClassData?> GetClassGradesAsync(int classId, string userId, bool isAdmin);
    Task<ServiceResult> UpdateSingleGradeAsync(int gradeId, float? score, string? note, string? rowVersion, int classId, string userId, bool isAdmin);
}
