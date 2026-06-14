using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize] // Ai cũng vào được, nhưng sẽ lọc dữ liệu theo Role
public class SalaryBonusesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAuditLogService _auditLogService;

    public SalaryBonusesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuditLogService auditLogService)
    {
        _context = context;
        _userManager = userManager;
        _auditLogService = auditLogService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? roleFilter, int? facultyId, int? majorId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var query = _context.SalaryBonuses.Include(s => s.User).AsNoTracking();

        // LOGIC PHÂN QUYỀN: Nếu không phải Admin, chỉ được xem của chính mình!
        if (!isAdmin)
        {
            query = query.Where(s => s.UserId == user.Id);
        }

        ViewBag.Faculties = await _context.Faculties.AsNoTracking().Where(f => !f.IsDeleted).OrderBy(f => f.Name).ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking()
            .Where(m => !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
            .OrderBy(m => m.Name)
            .ToListAsync();
        ViewData["RoleFilter"] = roleFilter;
        ViewData["FacultyId"] = facultyId;
        ViewData["MajorId"] = majorId;

        var bonuses = await query.OrderByDescending(s => s.CreatedAt).ToListAsync();
        var model = new List<SalaryBonusListItemViewModel>();

        foreach (var b in bonuses)
        {
            if (b.User == null) continue;

            var roles = await _userManager.GetRolesAsync(b.User);
            var roleName = roles.FirstOrDefault() ?? "";
            int? userFacultyId = null;
            int? userMajorId = null;
            string facultyName = "";
            string majorName = "";

            if (roleName == "Student")
            {
                var profile = await _context.StudentProfiles
                    .Include(p => p.Faculty)
                    .Include(p => p.Major)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.UserId == b.UserId);
                userFacultyId = profile?.FacultyId;
                userMajorId = profile?.MajorId;
                facultyName = profile?.Faculty?.Name ?? "";
                majorName = profile?.Major?.Name ?? "";
            }
            else if (roleName == "Professor")
            {
                var profile = await _context.ProfessorProfiles
                    .Include(p => p.Faculty)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.UserId == b.UserId);
                userFacultyId = profile?.FacultyId;
                facultyName = profile?.Faculty?.Name ?? "";
            }

            if (!string.IsNullOrWhiteSpace(roleFilter) && roleName != roleFilter) continue;
            if (facultyId.HasValue && userFacultyId != facultyId.Value) continue;
            if (majorId.HasValue && userMajorId != majorId.Value) continue;

            model.Add(new SalaryBonusListItemViewModel
            {
                Id = b.Id,
                FullName = b.User.FullName,
                RoleName = roleName,
                FacultyName = facultyName,
                MajorName = majorName,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                Amount = b.Amount,
                Note = b.Note,
                CreatedAtText = b.CreatedAt.ToString("dd/MM/yyyy HH:mm")
            });
        }

        ViewBag.IsAdmin = isAdmin;
        return View(model);
    }

    // CHỈ ADMIN MỚI CÓ QUYỀN TẠO LƯƠNG/HỌC BỔNG
    [Authorize(Policy = "RequireAdmin")]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Users = await _context.Users.Where(u => !u.IsDeleted).AsNoTracking().ToListAsync();
        return View(new SalaryBonusCreateViewModel());
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SalaryBonusCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Users = await _context.Users.Where(u => !u.IsDeleted).AsNoTracking().ToListAsync();
            return View(model);
        }

        var bonus = new SalaryBonus
        {
            UserId = model.UserId,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            Amount = model.Amount,
            Note = model.Note,
            CreatedAt = DateTime.UtcNow
        };

        _context.SalaryBonuses.Add(bonus);
        await _context.SaveChangesAsync();

        // Ghi Audit Log hành vi liên quan đến Tài chính
        await _auditLogService.LogAsync("CreateSalaryBonus", "SalaryBonus", bonus.Id.ToString(), "Success", $"Cấp {model.Amount:N0} cho User {model.UserId}");

        TempData["SuccessMessage"] = "Đã ghi nhận Lương / Học bổng thành công!";
        return RedirectToAction(nameof(Index));
    }
}
