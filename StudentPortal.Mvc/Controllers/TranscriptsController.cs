using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Roles = "Student")] // CHỈ SINH VIÊN
public class TranscriptsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TranscriptsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var profile = await _context.StudentProfiles
            .Include(s => s.Major)
            .FirstOrDefaultAsync(s => s.UserId == user.Id);

        var grades = await _context.Grades
            .Include(g => g.CourseClass).ThenInclude(c => c!.Subject)
            .Include(g => g.CourseClass).ThenInclude(c => c!.Semester)
            .Where(g => g.StudentId == user.Id)
            .AsNoTracking()
            .ToListAsync();

        var viewModel = new TranscriptViewModel
        {
            StudentName = user.FullName,
            StudentId = user.Id,
            MajorName = profile?.Major?.Name ?? "Chưa có chuyên ngành",
            Grades = grades.Select(g => new GradeItemViewModel
            {
                GradeId = g.Id,
                SubjectName = g.CourseClass?.Subject?.Name ?? "N/A",
                Credits = g.CourseClass?.Subject?.Credits ?? 0,
                Score = g.Score,
                Note = g.Note,
                SemesterName = g.CourseClass?.Semester?.Name ?? "N/A"
            }).OrderBy(g => g.SemesterName).ToList()
        };

        return View(viewModel);
    }
}