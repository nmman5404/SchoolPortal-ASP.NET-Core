using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Roles = "Professor")]
public class MajorsController : Controller
{
    private readonly IMajorService _majorService;
    private readonly UserManager<ApplicationUser> _userManager;

    public MajorsController(IMajorService majorService, UserManager<ApplicationUser> userManager)
    {
        _majorService = majorService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? majorId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var data = await _majorService.GetManagementAsync(user.Id, majorId);
        if (data.Result.AccessDenied) return RedirectToAction("AccessDenied", "Account");

        ViewBag.ManagedMajors = data.ManagedMajors;
        ViewData["MajorId"] = data.SelectedMajorId;
        ViewBag.MajorName = data.MajorName;
        return View(data.Rows);
    }
}
