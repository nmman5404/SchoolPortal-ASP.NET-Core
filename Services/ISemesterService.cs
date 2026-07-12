using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Services;

public interface ISemesterService
{
    Task<List<Semester>> GetSemestersAsync();
    Task<ServiceResult> CreateAsync(string name, DateTime startDate, DateTime endDate);
    Task<ServiceResult> ToggleRegistrationAsync(int id);
}
