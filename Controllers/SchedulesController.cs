using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize]
public class SchedulesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SchedulesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? semesterId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isStudent = await _userManager.IsInRoleAsync(user, "Student");
        var isProfessor = await _userManager.IsInRoleAsync(user, "Professor");
        if (!isStudent && !isProfessor) return RedirectToAction("AccessDenied", "Account");

        ViewBag.Semesters = await _context.Semesters
            .AsNoTracking()
            .OrderByDescending(s => s.StartDate)
            .ToListAsync();
        ViewData["SemesterId"] = semesterId;

        List<ScheduleClassViewModel> model;
        if (isStudent)
        {
            var query = _context.Grades
                .Include(g => g.CourseClass).ThenInclude(c => c!.Subject)
                .Include(g => g.CourseClass).ThenInclude(c => c!.Semester)
                .Include(g => g.CourseClass).ThenInclude(c => c!.ClassProfessors).ThenInclude(cp => cp.Professor).ThenInclude(p => p!.User)
                .Where(g => g.StudentId == user.Id && g.CourseClass != null && !g.CourseClass.IsDeleted);

            if (semesterId.HasValue)
                query = query.Where(g => g.CourseClass!.SemesterId == semesterId.Value);

            var grades = await query.AsNoTracking().ToListAsync();
            model = grades.Select(g => new ScheduleClassViewModel
            {
                ClassId = g.CourseClassId,
                SemesterName = g.CourseClass?.Semester?.Name ?? "N/A",
                SubjectName = g.CourseClass?.Subject?.Name ?? "N/A",
                Room = g.CourseClass?.Room ?? "",
                DayOfWeek = g.CourseClass?.DayOfWeek ?? DayOfWeek.Monday,
                StartPeriod = g.CourseClass?.StartPeriod ?? 0,
                EndPeriod = g.CourseClass?.EndPeriod ?? 0,
                PeopleText = string.Join(", ", g.CourseClass?.ClassProfessors.Select(cp => cp.Professor?.User?.FullName).Where(n => !string.IsNullOrWhiteSpace(n)) ?? Enumerable.Empty<string>())
            }).ToList();
        }
        else
        {
            var query = _context.ClassProfessors
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Subject)
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Semester)
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Grades)
                .Where(cp => cp.ProfessorId == user.Id && cp.CourseClass != null && !cp.CourseClass.IsDeleted);

            if (semesterId.HasValue)
                query = query.Where(cp => cp.CourseClass!.SemesterId == semesterId.Value);

            var assignments = await query.AsNoTracking().ToListAsync();
            model = assignments.Select(cp => new ScheduleClassViewModel
            {
                ClassId = cp.CourseClassId,
                SemesterName = cp.CourseClass?.Semester?.Name ?? "N/A",
                SubjectName = cp.CourseClass?.Subject?.Name ?? "N/A",
                Room = cp.CourseClass?.Room ?? "",
                DayOfWeek = cp.CourseClass?.DayOfWeek ?? DayOfWeek.Monday,
                StartPeriod = cp.CourseClass?.StartPeriod ?? 0,
                EndPeriod = cp.CourseClass?.EndPeriod ?? 0,
                PeopleText = $"{cp.CourseClass?.Grades.Count ?? 0} sinh viên"
            }).ToList();
        }

        model = model
            .OrderBy(m => m.DayOfWeek)
            .ThenBy(m => m.StartPeriod)
            .ThenBy(m => m.SubjectName)
            .ToList();

        ViewBag.IsProfessor = isProfessor;
        return View(model);
    }
}
