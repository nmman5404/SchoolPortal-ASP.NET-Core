using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class SubjectsController : Controller
{
    private readonly ISubjectService _subjectService;
    private readonly UserManager<ApplicationUser> _userManager;

    public SubjectsController(ISubjectService subjectService, UserManager<ApplicationUser> userManager)
    {
        _subjectService = subjectService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? keyword, int? facultyId, int? majorId, bool showDeleted = false)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var data = await _subjectService.GetSubjectsAsync(user.Id, isAdmin, keyword, facultyId, majorId, showDeleted);
        ViewBag.Faculties = data.Faculties;
        ViewBag.Majors = data.Majors;
        ViewBag.CanCreateSubject = data.CanCreateSubject;
        ViewData["Keyword"] = keyword;
        ViewData["FacultyId"] = facultyId;
        ViewData["MajorId"] = majorId;
        ViewData["ShowDeleted"] = showDeleted;
        return View(data.Subjects);
    }

    [HttpGet]
    public async Task<IActionResult> CreateEdit(int? id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        await ReloadFormListsAsync(user.Id, isAdmin, id);
        if (id == null)
        {
            if (!((IEnumerable<LookupOption>)ViewBag.Majors).Any())
            {
                TempData["ErrorMessage"] = "Bạn không có quyền tạo môn học cho ngành nào.";
                return RedirectToAction(nameof(Index));
            }

            return View(new SubjectCreateEditViewModel());
        }

        var model = await _subjectService.GetSubjectForEditAsync(id.Value, user.Id, isAdmin);
        if (model == null) return RedirectToAction("AccessDenied", "Account");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEdit(SubjectCreateEditViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        if (!ModelState.IsValid)
        {
            await ReloadFormListsAsync(user.Id, isAdmin, model.Id == 0 ? null : model.Id);
            return View(model);
        }

        var save = await _subjectService.SaveSubjectAsync(model, user.Id, isAdmin);
        if (save.Result.AccessDenied) return RedirectToAction("AccessDenied", "Account");
        if (!save.Result.Success)
        {
            AddServiceModelError(save.Result.Message);
            await ReloadFormListsAsync(user.Id, isAdmin, model.Id == 0 ? null : model.Id, save.FormLists);
            return View(model);
        }

        TempData["SuccessMessage"] = save.Result.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleDelete(int id, bool restore = false)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var result = await _subjectService.ToggleDeleteAsync(id, restore, user.Id, isAdmin);
        if (result.NotFound) return NotFound();
        if (result.AccessDenied) return RedirectToAction("AccessDenied", "Account");

        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index), new { showDeleted = restore });
    }

    private async Task ReloadFormListsAsync(string userId, bool isAdmin, int? currentSubjectId, SubjectFormLists? lists = null)
    {
        lists ??= await _subjectService.GetFormListsAsync(userId, isAdmin, currentSubjectId);
        ViewBag.Majors = lists.Majors;
        ViewBag.PrerequisiteSubjects = lists.PrerequisiteSubjects;
    }

    private void AddServiceModelError(string? encodedError)
    {
        if (string.IsNullOrWhiteSpace(encodedError)) return;
        var parts = encodedError.Split('|', 2);
        if (parts.Length == 2) ModelState.AddModelError(parts[0], parts[1]);
        else ModelState.AddModelError(string.Empty, encodedError);
    }
}
