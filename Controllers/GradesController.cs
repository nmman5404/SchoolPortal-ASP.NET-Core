using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class GradesController : Controller
{
    private readonly IGradeService _gradeService;
    private readonly UserManager<ApplicationUser> _userManager;

    public GradesController(IGradeService gradeService, UserManager<ApplicationUser> userManager)
    {
        _gradeService = gradeService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        return View(await _gradeService.GetClassesAsync(user.Id, isAdmin));
    }

    [HttpGet]
    public async Task<IActionResult> ClassGrades(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var data = await _gradeService.GetClassGradesAsync(classId, user.Id, isAdmin);
        if (data == null) return RedirectToAction("AccessDenied", "Account");

        ViewBag.ClassName = data.CourseClass.Subject?.Name;
        ViewBag.Room = data.CourseClass.Room;
        return View(data.Grades);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateSingleGrade(int gradeId, float? score, string? note, string rowVersion, int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var result = await _gradeService.UpdateSingleGradeAsync(gradeId, score, note, rowVersion, classId, user.Id, isAdmin);
        if (result.NotFound) return NotFound();
        if (result.AccessDenied) return RedirectToAction("AccessDenied", "Account");

        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(ClassGrades), new { classId });
    }
}
