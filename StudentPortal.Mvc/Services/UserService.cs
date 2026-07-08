using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _users;
    private readonly IMajorRepository _majors;
    private readonly IAuditLogService _auditLogService;

    public UserService(IUserRepository users, IMajorRepository majors, IAuditLogService auditLogService)
    {
        _users = users;
        _majors = majors;
        _auditLogService = auditLogService;
    }

    public async Task<List<UserListItemViewModel>> GetUsersAsync(string? keyword, string? roleFilter, bool showDeleted)
    {
        var query = _users.QueryUsers(includeDeleted: true).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(u => u.FullName.Contains(keyword) || (u.Email != null && u.Email.Contains(keyword)));

        query = showDeleted ? query.Where(u => u.IsDeleted) : query.Where(u => !u.IsDeleted);
        var users = await query.ToListAsync();
        var model = new List<UserListItemViewModel>();

        foreach (var user in users)
        {
            var roleName = (await _users.GetRolesAsync(user)).FirstOrDefault() ?? "Chưa có vai trò";
            if (!string.IsNullOrEmpty(roleFilter) && roleName != roleFilter) continue;

            var profileInfo = "N/A";
            if (roleName == "Student")
            {
                var profile = await _users.GetStudentProfileAsync(user.Id, includeLookups: true);
                profileInfo = profile?.Major?.Name ?? "Chưa có ngành";
            }
            else if (roleName == "Professor")
            {
                var profile = await _users.GetProfessorProfileAsync(user.Id, includeLookups: true);
                profileInfo = profile?.Faculty?.Name ?? "Chưa có khoa";
            }
            else if (roleName == "Worker")
            {
                var profile = await _users.GetWorkerProfileAsync(user.Id);
                profileInfo = profile?.Department ?? "Chưa có phòng ban";
            }

            model.Add(new UserListItemViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email ?? "",
                RoleName = roleName,
                ProfileInfo = profileInfo,
                IsDeleted = user.IsDeleted
            });
        }

        return model;
    }

    public async Task<(List<Faculty> Faculties, List<Major> Majors)> GetUserFormLookupsAsync()
    {
        var faculties = await _majors.QueryFaculties().AsNoTracking().OrderBy(f => f.Name).ToListAsync();
        var majors = await _majors.Query().AsNoTracking().OrderBy(m => m.Name).ToListAsync();
        return (faculties, majors);
    }

    public async Task<UserEditViewModel?> GetEditModelAsync(string id)
    {
        var user = await _users.FindByIdAsync(id);
        if (user == null) return null;

        var role = (await _users.GetRolesAsync(user)).FirstOrDefault() ?? "";
        var model = new UserEditViewModel
        {
            Id = user.Id,
            Email = user.Email ?? "",
            FullName = user.FullName,
            PID = user.PID ?? "",
            Dob = user.Dob ?? DateTime.Now,
            Role = role
        };

        if (role == "Student")
        {
            var profile = await _users.GetStudentProfileAsync(id);
            model.FacultyId = profile?.FacultyId;
            model.MajorId = profile?.MajorId;
        }
        else if (role == "Professor")
        {
            var profile = await _users.GetProfessorProfileAsync(id);
            model.FacultyId = profile?.FacultyId;
        }
        else if (role == "Worker")
        {
            var profile = await _users.GetWorkerProfileAsync(id);
            model.Department = profile?.Department;
            model.JobDescription = profile?.JobDescription;
        }

        return model;
    }

    public async Task<(ServiceResult Result, List<string> Errors)> CreateUserAsync(UserCreateViewModel model)
    {
        var errors = new List<string>();

        if (await _users.QueryUsers(includeDeleted: true).AnyAsync(u => u.PID == model.PID))
            errors.Add("PID|Mã định danh (PID) này đã tồn tại trong hệ thống!");

        if (await _users.QueryUsers(includeDeleted: true).AnyAsync(u => u.Email == model.Email))
            errors.Add("Email|Email này đã được sử dụng!");

        if (errors.Any()) return (ServiceResult.Fail("Validation failed."), errors);

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FullName = model.FullName,
            PID = model.PID,
            Dob = model.Dob,
            EntryDate = DateTime.Now,
            EmailConfirmed = true
        };

        var result = await _users.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return (ServiceResult.Fail("Identity failed."), result.Errors.Select(e => "|" + e.Description).ToList());

        await _users.AddToRoleAsync(user, model.Role);
        SyncProfileForCreate(user.Id, model);
        await _users.SaveChangesAsync();
        await _auditLogService.LogAsync("CreateUser", "ApplicationUser", user.Id, "Success", $"Tạo tài khoản {GetRoleDisplayName(model.Role)} cho email: {model.Email}");

        return (ServiceResult.Ok($"Đã tạo tài khoản {model.FullName} thành công!"), errors);
    }

    public async Task<ServiceResult> UpdateUserAsync(string id, UserEditViewModel model)
    {
        if (id != model.Id) return ServiceResult.Missing();

        if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue)
        {
            var major = await _majors.Query().AsNoTracking().FirstOrDefaultAsync(m => m.Id == model.MajorId.Value);
            if (major == null || major.FacultyId != model.FacultyId.Value)
                return ServiceResult.Fail("MajorId|Lỗi nghiệp vụ: Ngành học này không thuộc Khoa đã chọn!");
        }

        var user = await _users.FindByIdAsync(id);
        if (user == null) return ServiceResult.Missing();

        user.FullName = model.FullName;
        user.PID = model.PID;
        user.Dob = model.Dob;
        await _users.UpdateAsync(user);
        await SyncProfileForUpdateAsync(id, model);
        await _users.SaveChangesAsync();
        await _auditLogService.LogAsync("EditUser", "ApplicationUser", user.Id, "Success", $"Cập nhật hồ sơ của: {user.Email}");

        return ServiceResult.Ok("Cập nhật tài khoản thành công!");
    }

    public async Task<ServiceResult> ToggleDeleteUserAsync(string id, bool restore)
    {
        var user = restore ? await _users.FindByIdIncludingDeletedAsync(id) : await _users.FindByIdAsync(id);
        if (user == null) return ServiceResult.Missing();

        user.IsDeleted = !restore;
        await _users.SetLockoutEndDateAsync(user, restore ? null : DateTimeOffset.MaxValue);
        await _users.UpdateAsync(user);

        var action = restore ? "Restore" : "SoftDelete";
        await _auditLogService.LogAsync(action, "ApplicationUser", id, "Success", restore ? $"Đã mở khóa tài khoản: {user.Email}" : $"Đã khóa tài khoản: {user.Email}");

        return ServiceResult.Ok(restore ? "Đã khôi phục tài khoản thành công!" : "Đã khóa và đưa tài khoản vào thùng rác.");
    }

    private void SyncProfileForCreate(string userId, UserCreateViewModel model)
    {
        if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue)
        {
            _users.AddStudentProfile(new StudentProfile { UserId = userId, FacultyId = model.FacultyId.Value, MajorId = model.MajorId.Value });
        }
        else if (model.Role == "Professor" && model.FacultyId.HasValue)
        {
            _users.AddProfessorProfile(new ProfessorProfile { UserId = userId, FacultyId = model.FacultyId.Value });
        }
        else if (model.Role == "Worker")
        {
            _users.AddWorkerProfile(new WorkerProfile
            {
                UserId = userId,
                Department = model.Department ?? "N/A",
                JobDescription = model.JobDescription ?? "Chưa có mô tả"
            });
        }
    }

    private async Task SyncProfileForUpdateAsync(string userId, UserEditViewModel model)
    {
        if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue)
        {
            var profile = await _users.GetStudentProfileAsync(userId);
            if (profile != null)
            {
                profile.FacultyId = model.FacultyId.Value;
                profile.MajorId = model.MajorId.Value;
            }
            else
            {
                _users.AddStudentProfile(new StudentProfile { UserId = userId, FacultyId = model.FacultyId.Value, MajorId = model.MajorId.Value });
            }
        }
        else if (model.Role == "Professor" && model.FacultyId.HasValue)
        {
            var profile = await _users.GetProfessorProfileAsync(userId);
            if (profile != null) profile.FacultyId = model.FacultyId.Value;
            else _users.AddProfessorProfile(new ProfessorProfile { UserId = userId, FacultyId = model.FacultyId.Value });
        }
        else if (model.Role == "Worker")
        {
            var profile = await _users.GetWorkerProfileAsync(userId);
            if (profile != null)
            {
                profile.Department = model.Department ?? "N/A";
                profile.JobDescription = model.JobDescription ?? "";
            }
            else
            {
                _users.AddWorkerProfile(new WorkerProfile { UserId = userId, Department = model.Department ?? "N/A", JobDescription = model.JobDescription ?? "" });
            }
        }
    }

    private static string GetRoleDisplayName(string role) => role switch
    {
        "Admin" => "Quản trị viên",
        "Professor" => "Giảng viên",
        "Student" => "Học sinh",
        "Worker" => "Nhân sự",
        _ => role
    };
}
