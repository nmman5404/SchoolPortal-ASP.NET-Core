using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")] // CHỈ ADMIN MỚI ĐƯỢC QUẢN LÝ USER
public class UsersController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly IAuditLogService _auditLogService;

    public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IAuditLogService auditLogService)
    {
        _userManager = userManager;
        _context = context;
        _auditLogService = auditLogService;
    }

    // 1. DANH SÁCH & TÌM KIẾM
    // 1. DANH SÁCH & TÌM KIẾM CÓ BỘ LỌC ROLE
    [HttpGet]
    public async Task<IActionResult> Index(string? keyword, string? roleFilter, bool showDeleted = false)
    {
        var query = _context.Users.IgnoreQueryFilters().AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(u => u.FullName.Contains(keyword) || u.Email.Contains(keyword));

        if (showDeleted) query = query.Where(u => u.IsDeleted);
        else query = query.Where(u => !u.IsDeleted);

        var users = await query.ToListAsync();
        var model = new List<UserListItemViewModel>();

        foreach (var u in users)
        {
            var roles = await _userManager.GetRolesAsync(u);
            string roleName = roles.FirstOrDefault() ?? "No Role";
            
            // Nếu có chọn lọc theo Role mà Role không khớp thì bỏ qua
            if (!string.IsNullOrEmpty(roleFilter) && roleName != roleFilter) continue;

            string profileInfo = "N/A";
            if (roleName == "Student") {
                var p = await _context.StudentProfiles.Include(x => x.Major).FirstOrDefaultAsync(x => x.UserId == u.Id);
                profileInfo = p?.Major?.Name ?? "Chưa có ngành";
            } else if (roleName == "Professor") {
                var p = await _context.ProfessorProfiles.Include(x => x.Faculty).FirstOrDefaultAsync(x => x.UserId == u.Id);
                profileInfo = p?.Faculty?.Name ?? "Chưa có khoa";
            } else if (roleName == "Worker") {
                var p = await _context.WorkerProfiles.FirstOrDefaultAsync(x => x.UserId == u.Id);
                profileInfo = p?.Department ?? "Chưa có phòng ban";
            }

            model.Add(new UserListItemViewModel {
                Id = u.Id, FullName = u.FullName, Email = u.Email,
                RoleName = roleName, ProfileInfo = profileInfo, IsDeleted = u.IsDeleted
            });
        }

        ViewData["Keyword"] = keyword;
        ViewData["RoleFilter"] = roleFilter;
        ViewData["ShowDeleted"] = showDeleted;
        return View(model);
    }

    // 2. TẠO MỚI USER
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
        return View(new UserCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserCreateViewModel model)
    {
        if (!ModelState.IsValid) return await ReloadCreateView(model);
        
        // FIX: KIỂM TRA TRÙNG PID VÀ EMAIL Ở DATABASE TRƯỚC KHI TẠO
        bool isPidExists = await _context.Users.AnyAsync(u => u.PID == model.PID);
        if (isPidExists) ModelState.AddModelError("PID", "Mã định danh (PID) này đã tồn tại trong hệ thống!");

        bool isEmailExists = await _context.Users.AnyAsync(u => u.Email == model.Email);
        if (isEmailExists) ModelState.AddModelError("Email", "Email này đã được sử dụng!");

        if (!ModelState.IsValid) return await ReloadCreateView(model);

        // 1. NHẬN THÊM THÔNG TIN CÁ NHÂN (PID, Dob, EntryDate)
        var user = new ApplicationUser 
        { 
            UserName = model.Email, 
            Email = model.Email, 
            FullName = model.FullName, 
            PID = model.PID,              // Bổ sung PID
            Dob = model.Dob,              // Bổ sung Ngày sinh
            EntryDate = DateTime.Now,     // Tự động gán ngày gia nhập là hôm nay
            EmailConfirmed = true 
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, model.Role);

            if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue)
            {
                _context.StudentProfiles.Add(new StudentProfile { UserId = user.Id, FacultyId = model.FacultyId.Value, MajorId = model.MajorId.Value });
            }
            else if (model.Role == "Professor" && model.FacultyId.HasValue)
            {
                _context.ProfessorProfiles.Add(new ProfessorProfile { UserId = user.Id, FacultyId = model.FacultyId.Value });
            }
            else if (model.Role == "Worker")
            {
                // 2. NHẬN THÊM MÔ TẢ CÔNG VIỆC CHO WORKER THAY VÌ FIX CỨNG
                _context.WorkerProfiles.Add(new WorkerProfile { 
                    UserId = user.Id, 
                    Department = model.Department ?? "N/A", 
                    JobDescription = model.JobDescription ?? "Chưa có mô tả" // Bổ sung JobDescription
                });
            }

            await _context.SaveChangesAsync();
            await _auditLogService.LogAsync("CreateUser", "ApplicationUser", user.Id, "Success", $"Tạo tài khoản {model.Role} cho email: {model.Email}");
            TempData["SuccessMessage"] = $"Đã tạo tài khoản {model.FullName} thành công!";
            return RedirectToAction(nameof(Index));
        }

        foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
        return await ReloadCreateView(model);
    }

    private async Task<IActionResult> ReloadCreateView(UserCreateViewModel model)
    {
        ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
        return View(model);
    }

    // ==========================================
    // CẬP NHẬT THÔNG TIN \& PROFILE TÀI KHOẢN
    // ==========================================
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault() ?? "";

        var model = new UserEditViewModel
        {
            Id = user.Id, Email = user.Email ?? "", FullName = user.FullName, 
            PID = user.PID ?? "", Dob = user.Dob ?? DateTime.Now, Role = role
        };

        // Lấy Profile hiện tại để hiển thị lên Form
        if (role == "Student") {
            var p = await _context.StudentProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            model.FacultyId = p?.FacultyId; model.MajorId = p?.MajorId;
        } else if (role == "Professor") {
            var p = await _context.ProfessorProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            model.FacultyId = p?.FacultyId;
        } else if (role == "Worker") {
            var p = await _context.WorkerProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            model.Department = p?.Department; model.JobDescription = p?.JobDescription;
        }

        ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, UserEditViewModel model)
    {
        if (id != model.Id) return NotFound();
        
        // KIỂM TRA NGHIỆP VỤ BẢO VỆ TOÀN VẸN DỮ LIỆU
        if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue)
        {
            var major = await _context.Majors.AsNoTracking().FirstOrDefaultAsync(m => m.Id == model.MajorId.Value);
            // Nếu ngành không tồn tại, HOẶC ngành đó không thuộc về Khoa đã chọn -> Báo lỗi!
            if (major == null || major.FacultyId != model.FacultyId.Value)
            {
                ModelState.AddModelError("MajorId", "Lỗi nghiệp vụ: Ngành học này không thuộc Khoa đã chọn!");
            }
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
            ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
            return View(model);
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        user.FullName = model.FullName;
        user.PID = model.PID;
        user.Dob = model.Dob;
        await _userManager.UpdateAsync(user);

        if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue) {
            var p = await _context.StudentProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            if (p != null) { p.FacultyId = model.FacultyId.Value; p.MajorId = model.MajorId.Value; }
            else _context.StudentProfiles.Add(new StudentProfile { UserId = id, FacultyId = model.FacultyId.Value, MajorId = model.MajorId.Value });
        } 
        else if (model.Role == "Professor" && model.FacultyId.HasValue) {
            var p = await _context.ProfessorProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            if (p != null) { p.FacultyId = model.FacultyId.Value; }
            else _context.ProfessorProfiles.Add(new ProfessorProfile { UserId = id, FacultyId = model.FacultyId.Value });
        }
        else if (model.Role == "Worker") {
            var p = await _context.WorkerProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            if (p != null) { p.Department = model.Department ?? "N/A"; p.JobDescription = model.JobDescription ?? ""; }
            else _context.WorkerProfiles.Add(new WorkerProfile { UserId = id, Department = model.Department ?? "N/A", JobDescription = model.JobDescription ?? "" });
        }

        await _context.SaveChangesAsync();
        await _auditLogService.LogAsync("EditUser", "ApplicationUser", user.Id, "Success", $"Cập nhật hồ sơ của: {user.Email}");

        TempData["SuccessMessage"] = "Cập nhật tài khoản thành công!";
        return RedirectToAction(nameof(Index));
    }

    // 3. XÓA MỀM (SOFT DELETE) & KHÓA TÀI KHOẢN
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        user.IsDeleted = true;
        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue); // Khóa không cho đăng nhập
        await _userManager.UpdateAsync(user);

        await _auditLogService.LogAsync("SoftDelete", "ApplicationUser", id, "Success", $"Đã khóa tài khoản: {user.Email}");
        TempData["SuccessMessage"] = "Đã khóa và đưa tài khoản vào thùng rác.";
        return RedirectToAction(nameof(Index));
    }

    // 4. KHÔI PHỤC (RESTORE)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Restore(string id)
    {
        var user = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) return NotFound();

        user.IsDeleted = false;
        await _userManager.SetLockoutEndDateAsync(user, null); // Mở khóa đăng nhập
        await _userManager.UpdateAsync(user);

        await _auditLogService.LogAsync("Restore", "ApplicationUser", id, "Success", $"Đã mở khóa tài khoản: {user.Email}");
        TempData["SuccessMessage"] = "Đã khôi phục tài khoản thành công!";
        return RedirectToAction(nameof(Index), new { showDeleted = true });
    }
}