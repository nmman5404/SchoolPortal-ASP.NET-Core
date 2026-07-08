using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class CourseClassesController : Controller
{
    private readonly ICourseClassService _courseClassService;
    private readonly UserManager<ApplicationUser> _userManager;

    public CourseClassesController(ICourseClassService courseClassService, UserManager<ApplicationUser> userManager)
    {
        _courseClassService = courseClassService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? facultyId, int? majorId, int? semesterId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        var isProfessor = await _userManager.IsInRoleAsync(user, "Professor");

        var data = await _courseClassService.GetClassesAsync(user.Id, isAdmin, isProfessor, facultyId, majorId, semesterId);
        ViewBag.Faculties = data.Faculties;
        ViewBag.Majors = data.Majors;
        ViewBag.Semesters = data.Semesters;
        ViewBag.CanCreateClass = data.CanCreateClass;
        ViewData["FacultyId"] = facultyId;
        ViewData["MajorId"] = majorId;
        ViewData["SemesterId"] = semesterId;
        return View(data.Classes);
    }

    [HttpGet]
    public async Task<IActionResult> CreateEdit(int? id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        await ReloadFormListsAsync(user.Id, isAdmin);
        if (id == null)
        {
            if (!((IEnumerable<LookupOption>)ViewBag.Subjects).Any())
            {
                TempData["ErrorMessage"] = "Ban khong co quyen mo lop cho mon hoc nao.";
                return RedirectToAction(nameof(Index));
            }

            return View(new CourseClassEditViewModel { DayOfWeek = DayOfWeek.Monday, StartPeriod = 1, EndPeriod = 3, Capacity = 40 });
        }

        var model = await _courseClassService.GetClassForEditAsync(id.Value, user.Id, isAdmin);
        if (model == null) return RedirectToAction("AccessDenied", "Account");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEdit(CourseClassEditViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        if (!ModelState.IsValid)
        {
            await ReloadFormListsAsync(user.Id, isAdmin);
            return View(model);
        }

        var save = await _courseClassService.SaveClassAsync(model, user.Id, isAdmin);
        if (save.Result.NotFound) return NotFound();
        if (save.Result.AccessDenied) return RedirectToAction("AccessDenied", "Account");
        if (save.Result.ConcurrencyConflict)
        {
            TempData["ErrorMessage"] = save.Result.Message;
            return RedirectToAction(nameof(Index));
        }
        if (!save.Result.Success)
        {
            AddServiceModelError(save.Result.Message);
            await ReloadFormListsAsync(user.Id, isAdmin, save.FormLists);
            return View(model);
        }

        TempData["SuccessMessage"] = save.Result.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Students(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var model = await _courseClassService.GetStudentsAsync(classId, user.Id, isAdmin);
        if (model == null) return RedirectToAction("AccessDenied", "Account");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddStudent(int classId, string studentId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var result = await _courseClassService.AddStudentAsync(classId, studentId, isAdmin);
        if (result.NotFound) return NotFound();
        if (result.AccessDenied) return RedirectToAction("AccessDenied", "Account");
        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Students), new { classId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveStudent(int classId, string studentId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var result = await _courseClassService.RemoveStudentAsync(classId, studentId, isAdmin);
        if (result.AccessDenied) return RedirectToAction("AccessDenied", "Account");
        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Students), new { classId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleDelete(int id, bool restore = false)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var result = await _courseClassService.ToggleDeleteAsync(id, restore, user.Id, isAdmin);
        if (result.NotFound) return NotFound();
        if (result.AccessDenied) return RedirectToAction("AccessDenied", "Account");
        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index), new { showDeleted = restore });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignProfessor(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        if (!await _userManager.IsInRoleAsync(user, "Professor"))
            return RedirectToAction("AccessDenied", "Account");

        var result = await _courseClassService.AssignProfessorAsync(classId, user.Id);
        if (result.NotFound) return NotFound();
        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UnassignProfessor(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var result = await _courseClassService.UnassignProfessorAsync(classId, user.Id);
        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }

    private async Task ReloadFormListsAsync(string userId, bool isAdmin, CourseClassFormLists? lists = null)
    {
        lists ??= await _courseClassService.GetFormListsAsync(userId, isAdmin);
        ViewBag.Subjects = lists.Subjects;
        ViewBag.Semesters = lists.Semesters;
    }

    private void AddServiceModelError(string? encodedError)
    {
        if (string.IsNullOrWhiteSpace(encodedError)) return;
        var parts = encodedError.Split('|', 2);
        if (parts.Length == 2) ModelState.AddModelError(parts[0], parts[1]);
        else ModelState.AddModelError(string.Empty, encodedError);
    }
}
