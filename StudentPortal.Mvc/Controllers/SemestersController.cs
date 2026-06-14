using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")] // CHỈ ADMIN
public class SemestersController : Controller
{
    private readonly ApplicationDbContext _context;

    public SemestersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var semesters = await _context.Semesters.AsNoTracking().OrderByDescending(s => s.StartDate).ToListAsync();
        return View(semesters);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string Name, DateTime StartDate, DateTime EndDate)
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            _context.Semesters.Add(new Semester { Name = Name, StartDate = StartDate, EndDate = EndDate, IsRegistrationOpen = false });
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Đã thêm Học kỳ mới thành công!";
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleRegistration(int id)
    {
        var semester = await _context.Semesters.FindAsync(id);
        if (semester != null)
        {
            semester.IsRegistrationOpen = !semester.IsRegistrationOpen;
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = semester.IsRegistrationOpen ? $"Đã MỞ đăng ký cho {semester.Name}" : $"Đã ĐÓNG đăng ký cho {semester.Name}";
        }
        return RedirectToAction(nameof(Index));
    }
}