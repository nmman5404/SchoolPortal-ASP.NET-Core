using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public interface IEnrollmentService
{
    Task<List<EnrollmentClassViewModel>> GetAvailableClassesAsync(string studentId);
    Task<bool> EnrollClassAsync(string studentId, int classId, string rowVersion);
    Task<bool> UnenrollClassAsync(string studentId, int classId);
}