using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Services;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet]
    public async Task<IActionResult> Index(string? keyword, string? roleFilter, bool showDeleted = false)
    {
        var model = await _userService.GetUsersAsync(keyword, roleFilter, showDeleted);
        ViewData["Keyword"] = keyword;
        ViewData["RoleFilter"] = roleFilter;
        ViewData["ShowDeleted"] = showDeleted;
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await ReloadCreateViewBagsAsync();
        return View(new UserCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserCreateViewModel model)
    {
        if (!ModelState.IsValid) return await ReloadCreateView(model);

        var (result, errors) = await _userService.CreateUserAsync(model);
        foreach (var error in errors) AddServiceModelError(error);
        if (!result.Success) return await ReloadCreateView(model);

        TempData["SuccessMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var model = await _userService.GetEditModelAsync(id);
        if (model == null) return NotFound();
        await ReloadCreateViewBagsAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, UserEditViewModel model)
    {
        if (id != model.Id) return NotFound();
        if (!ModelState.IsValid) return await ReloadEditView(model);

        var result = await _userService.UpdateUserAsync(id, model);
        if (result.NotFound) return NotFound();
        if (!result.Success)
        {
            AddServiceModelError(result.Message);
            return await ReloadEditView(model);
        }

        TempData["SuccessMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _userService.ToggleDeleteUserAsync(id, restore: false);
        if (result.NotFound) return NotFound();
        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Restore(string id)
    {
        var result = await _userService.ToggleDeleteUserAsync(id, restore: true);
        if (result.NotFound) return NotFound();
        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index), new { showDeleted = true });
    }

    private async Task<IActionResult> ReloadCreateView(UserCreateViewModel model)
    {
        await ReloadCreateViewBagsAsync();
        return View(model);
    }

    private async Task<IActionResult> ReloadEditView(UserEditViewModel model)
    {
        await ReloadCreateViewBagsAsync();
        return View(model);
    }

    private async Task ReloadCreateViewBagsAsync()
    {
        var lookups = await _userService.GetUserFormLookupsAsync();
        ViewBag.Faculties = lookups.Faculties;
        ViewBag.Majors = lookups.Majors;
    }

    private void AddServiceModelError(string? encodedError)
    {
        if (string.IsNullOrWhiteSpace(encodedError)) return;
        var parts = encodedError.Split('|', 2);
        if (parts.Length == 2) ModelState.AddModelError(parts[0], parts[1]);
        else ModelState.AddModelError(string.Empty, encodedError);
    }
}
