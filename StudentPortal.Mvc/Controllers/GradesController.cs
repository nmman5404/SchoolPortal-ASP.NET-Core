using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class GradesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public GradesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // 1. Danh sách các lớp (Của riêng giảng viên này hoặc toàn bộ nếu là Admin)
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        bool isAdmin = await _userManager.IsInRoleAsync(user!, "Admin");

        var classesQuery = _context.CourseClasses.Include(c => c.Subject).AsNoTracking();

        if (!isAdmin) // Giảng viên chỉ thấy lớp của mình
        {
            var myClassIds = await _context.ClassProfessors.Where(cp => cp.ProfessorId == user!.Id).Select(cp => cp.CourseClassId).ToListAsync();
            classesQuery = classesQuery.Where(c => myClassIds.Contains(c.Id));
        }

        return View(await classesQuery.ToListAsync());
    }

    // 2. Vào chi tiết 1 Lớp để lấy danh sách sinh viên
    [HttpGet]
    public async Task<IActionResult> ClassGrades(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        if (!isAdmin)
        {
            var isAssigned = await _context.ClassProfessors.AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == user.Id);
            if (!isAssigned) return RedirectToAction("AccessDenied", "Account");
        }

        var courseClass = await _context.CourseClasses.Include(c => c.Subject).FirstOrDefaultAsync(c => c.Id == classId);
        if (courseClass == null) return NotFound();

        ViewBag.ClassName = courseClass.Subject?.Name;
        ViewBag.Room = courseClass.Room;
        
        var grades = await _context.Grades
            .Include(g => g.Student).ThenInclude(s => s!.User)
            .Where(g => g.CourseClassId == classId)
            .ToListAsync(); // Không dùng AsNoTracking vì ta sẽ dùng List này để map trực tiếp lên View

        return View(grades);
    }

    // 3. Submit Lưu điểm của 1 sinh viên (Dùng AJAX hoặc Submit Form)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateSingleGrade(int gradeId, float? score, string? note, string rowVersion, int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        if (!isAdmin)
        {
            var isAssigned = await _context.ClassProfessors.AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == user.Id);
            if (!isAssigned) return RedirectToAction("AccessDenied", "Account");
        }

        var grade = await _context.Grades.FirstOrDefaultAsync(g => g.Id == gradeId);
        if (grade == null) return NotFound();

        grade.Score = score;
        grade.Note = note;
        grade.RowVersion = Guid.NewGuid().ToByteArray(); // SQLite Concurrency
        
        _context.Entry(grade).Property(g => g.RowVersion).OriginalValue = Convert.FromBase64String(rowVersion);

        try {
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Lưu điểm thành công!";
        } catch(DbUpdateConcurrencyException) {
            TempData["ErrorMessage"] = "Lỗi đụng độ: Giảng viên khác vừa sửa điểm này!";
        }

        return RedirectToAction(nameof(ClassGrades), new { classId = classId });
    }
}
