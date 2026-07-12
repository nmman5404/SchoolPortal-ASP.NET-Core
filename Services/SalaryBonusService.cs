using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public class SalaryBonusService : ISalaryBonusService
{
    private readonly ISalaryBonusRepository _bonuses;
    private readonly IUserRepository _users;
    private readonly IMajorRepository _majors;
    private readonly IAuditLogService _auditLogService;

    public SalaryBonusService(ISalaryBonusRepository bonuses, IUserRepository users, IMajorRepository majors, IAuditLogService auditLogService)
    {
        _bonuses = bonuses;
        _users = users;
        _majors = majors;
        _auditLogService = auditLogService;
    }

    public async Task<SalaryBonusIndexData> GetIndexAsync(string userId, bool isAdmin, string? roleFilter, int? facultyId, int? majorId)
    {
        var query = _bonuses.Query().Include(s => s.User).AsNoTracking();
        if (!isAdmin) query = query.Where(s => s.UserId == userId);

        var faculties = await _majors.QueryFaculties().AsNoTracking().Where(f => !f.IsDeleted).OrderBy(f => f.Name).ToListAsync();
        var majors = await _majors.Query().AsNoTracking()
            .Where(m => !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
            .OrderBy(m => m.Name)
            .ToListAsync();

        var bonuses = await query.OrderByDescending(s => s.CreatedAt).ToListAsync();
        var model = new List<SalaryBonusListItemViewModel>();

        foreach (var bonus in bonuses)
        {
            if (bonus.User == null) continue;
            var roleName = (await _users.GetRolesAsync(bonus.User)).FirstOrDefault() ?? "";
            int? userFacultyId = null;
            int? userMajorId = null;
            string facultyName = "";
            string majorName = "";

            if (roleName == "Student")
            {
                var profile = await _users.GetStudentProfileAsync(bonus.UserId, includeLookups: true);
                userFacultyId = profile?.FacultyId;
                userMajorId = profile?.MajorId;
                facultyName = profile?.Faculty?.Name ?? "";
                majorName = profile?.Major?.Name ?? "";
            }
            else if (roleName == "Professor")
            {
                var profile = await _users.GetProfessorProfileAsync(bonus.UserId, includeLookups: true);
                userFacultyId = profile?.FacultyId;
                facultyName = profile?.Faculty?.Name ?? "";
            }

            if (!string.IsNullOrWhiteSpace(roleFilter) && roleName != roleFilter) continue;
            if (facultyId.HasValue && userFacultyId != facultyId.Value) continue;
            if (majorId.HasValue && userMajorId != majorId.Value) continue;

            model.Add(new SalaryBonusListItemViewModel
            {
                Id = bonus.Id,
                FullName = bonus.User.FullName,
                RoleName = roleName,
                FacultyName = facultyName,
                MajorName = majorName,
                StartDate = bonus.StartDate,
                EndDate = bonus.EndDate,
                Amount = bonus.Amount,
                Note = bonus.Note,
                CreatedAtText = bonus.CreatedAt.ToString("dd/MM/yyyy HH:mm")
            });
        }

        return new SalaryBonusIndexData(model, faculties, majors, isAdmin);
    }

    public Task<List<ApplicationUser>> GetEligibleUsersAsync() =>
        _users.QueryUsers().Where(u => !u.IsDeleted).AsNoTracking().OrderBy(u => u.FullName).ToListAsync();

    public async Task<ServiceResult> CreateAsync(SalaryBonusCreateViewModel model)
    {
        var bonus = new SalaryBonus
        {
            UserId = model.UserId,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            Amount = model.Amount,
            Note = model.Note,
            CreatedAt = DateTime.UtcNow
        };

        _bonuses.Add(bonus);
        await _bonuses.SaveChangesAsync();
        await _auditLogService.LogAsync("CreateSalaryBonus", "SalaryBonus", bonus.Id.ToString(), "Success", $"Cấp {model.Amount:N0} cho người dùng {model.UserId}");

        return ServiceResult.Ok("Đã ghi nhận lương / học bổng thành công!");
    }
}
