using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public interface IUserService
{
    Task<List<UserListItemViewModel>> GetUsersAsync(string? keyword, string? roleFilter, bool showDeleted);
    Task<(List<Faculty> Faculties, List<Major> Majors)> GetUserFormLookupsAsync();
    Task<UserEditViewModel?> GetEditModelAsync(string id);
    Task<(ServiceResult Result, List<string> Errors)> CreateUserAsync(UserCreateViewModel model);
    Task<ServiceResult> UpdateUserAsync(string id, UserEditViewModel model);
    Task<ServiceResult> ToggleDeleteUserAsync(string id, bool restore);
}
