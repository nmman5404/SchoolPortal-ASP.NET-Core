using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public interface ISalaryBonusService
{
    Task<SalaryBonusIndexData> GetIndexAsync(string userId, bool isAdmin, string? roleFilter, int? facultyId, int? majorId);
    Task<List<ApplicationUser>> GetEligibleUsersAsync();
    Task<ServiceResult> CreateAsync(SalaryBonusCreateViewModel model);
}
