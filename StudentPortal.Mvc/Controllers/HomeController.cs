using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // 1. Kiểm tra đăng nhập
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            return View("LandingPage");
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return View("LandingPage");

        var roles = await _userManager.GetRolesAsync(user);
        string userRole = roles.FirstOrDefault() ?? "";

        // ========================================================
        // 2. LOGIC LỌC VÀ LẤY THÔNG BÁO CHO USER HIỆN TẠI
        // ========================================================
        int? myFacultyId = null;
        int? myMajorId = null;

        // Lấy Profile để biết user thuộc Khoa/Ngành nào
        if (userRole == "Student") {
            var profile = await _context.StudentProfiles.AsNoTracking().FirstOrDefaultAsync(p => p.UserId == user.Id);
            myFacultyId = profile?.FacultyId;
            myMajorId = profile?.MajorId;
        } else if (userRole == "Professor") {
            var profile = await _context.ProfessorProfiles.AsNoTracking().FirstOrDefaultAsync(p => p.UserId == user.Id);
            myFacultyId = profile?.FacultyId;
            ViewBag.IsFacultyHeadMaster = await _context.Faculties.AnyAsync(f => f.HeadMasterId == user.Id && !f.IsDeleted);
            ViewBag.IsMajorHeadMaster = await _context.Majors.AnyAsync(m => m.HeadMasterId == user.Id && !m.IsDeleted);
        }

        // Lấy danh sách ID thông báo mà User này ĐÃ BẤM ẨN/XÓA
        var dismissedIds = await _context.UserNotifications
            .Where(un => un.UserId == user.Id && un.IsDismissed)
            .Select(un => un.NotificationId)
            .ToListAsync();

        // Mỗi tiêu chí đã chọn đều phải khớp. Null/chuỗi rỗng nghĩa là không lọc theo tiêu chí đó.
        var notifications = await _context.Notifications
            .AsNoTracking()
            .Where(n => !dismissedIds.Contains(n.Id))
            .Where(n =>
                (!string.IsNullOrEmpty(n.TargetUserId) && n.TargetUserId == user.Id) ||
                (string.IsNullOrEmpty(n.TargetUserId) &&
                 (string.IsNullOrEmpty(n.TargetRole) || roles.Contains(n.TargetRole)) &&
                 (n.TargetFacultyId == null || n.TargetFacultyId == myFacultyId) &&
                 (n.TargetMajorId == null || n.TargetMajorId == myMajorId)))
            .OrderByDescending(n => n.CreatedAt)
            .Take(5) // Chỉ lấy 5 thông báo mới nhất
            .ToListAsync();

        ViewBag.Notifications = notifications;

        // ========================================================
        // 3. LOGIC LẤY SỐ LIỆU DASHBOARD THEO ROLE
        // ========================================================
        if (userRole == "Admin")
        {
            ViewBag.TotalStudents = await _userManager.GetUsersInRoleAsync("Student").ContinueWith(t => t.Result.Count);
            ViewBag.TotalProfs = await _userManager.GetUsersInRoleAsync("Professor").ContinueWith(t => t.Result.Count);
            ViewBag.TotalClasses = await _context.CourseClasses.CountAsync(c => !c.IsDeleted);
        }
        else if (userRole == "Student")
        {
            var myGrades = await _context.Grades
                .Include(g => g.CourseClass).ThenInclude(c => c!.Subject)
                .Where(g => g.StudentId == user.Id)
                .AsNoTracking().ToListAsync();
            ViewBag.MyClasses = myGrades;
            
            // Demo tính GPA nhanh cho Dashboard
            var graded = myGrades.Where(g => g.Score.HasValue).ToList();
            double gpa = graded.Any() ? Math.Round(graded.Average(g => g.Score!.Value), 2) : 0;
            ViewBag.GPA = gpa;
        }
        else if (userRole == "Professor")
        {
            var myClasses = await _context.ClassProfessors
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Subject)
                .Where(cp => cp.ProfessorId == user.Id)
                .AsNoTracking().ToListAsync();
            ViewBag.TeachingClasses = myClasses;
        }
        else if (userRole == "Worker")
        {
            var myBonuses = await _context.SalaryBonuses
                .Where(sb => sb.UserId == user.Id)
                .OrderByDescending(sb => sb.CreatedAt)
                .AsNoTracking().ToListAsync();
            ViewBag.MyBonuses = myBonuses;
        }

        return View();
    }

    // ========================================================
    // 4. ACTION XỬ LÝ KHI USER BẤM "TẮT/XÓA" THÔNG BÁO
    // ========================================================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DismissNotification(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        // Đánh dấu đã xóa vào bảng UserNotification
        bool exists = await _context.UserNotifications.AnyAsync(un => un.NotificationId == id && un.UserId == user.Id);
        if (!exists)
        {
            _context.UserNotifications.Add(new UserNotification
            {
                NotificationId = id,
                UserId = user.Id,
                IsDismissed = true
            });
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index)); // Load lại trang chủ
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
