using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")]
public class NotificationsController : Controller
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService) => _notificationService = notificationService;

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await ReloadFormListsAsync();
        return View(new Notification());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Notification model)
    {
        if (!ModelState.IsValid)
        {
            await ReloadFormListsAsync();
            return View(model);
        }

        var result = await _notificationService.CreateAsync(model);
        if (!result.Success)
        {
            AddServiceModelError(result.Message);
            await ReloadFormListsAsync();
            return View(model);
        }

        TempData["SuccessMessage"] = result.Message;
        return RedirectToAction("Index", "Home");
    }

    private async Task ReloadFormListsAsync()
    {
        var lists = await _notificationService.GetFormListsAsync();
        ViewBag.Faculties = lists.Faculties;
        ViewBag.Majors = lists.Majors;
        ViewBag.Users = lists.Users;
    }

    private void AddServiceModelError(string? encodedError)
    {
        if (string.IsNullOrWhiteSpace(encodedError)) return;
        var parts = encodedError.Split('|', 2);
        if (parts.Length == 2) ModelState.AddModelError(parts[0], parts[1]);
        else ModelState.AddModelError(string.Empty, encodedError);
    }
}
