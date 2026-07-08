using StudentPortal.Mvc.ViewModels;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Services;

public interface IMajorService
{
    Task<(ServiceResult Result, List<Major> ManagedMajors, int? SelectedMajorId, string? MajorName, List<MajorManagementRowViewModel> Rows)> GetManagementAsync(string userId, int? majorId);
}
