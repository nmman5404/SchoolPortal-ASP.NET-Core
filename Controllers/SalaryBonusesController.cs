using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize]
public class SalaryBonusesController : Controller
{
    private readonly ISalaryBonusService _salaryBonusService;
    private readonly UserManager<ApplicationUser> _userManager;

    public SalaryBonusesController(ISalaryBonusService salaryBonusService, UserManager<ApplicationUser> userManager)
    {
        _salaryBonusService = salaryBonusService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? roleFilter, int? facultyId, int? majorId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var data = await _salaryBonusService.GetIndexAsync(user.Id, isAdmin, roleFilter, facultyId, majorId);
        ViewBag.Faculties = data.Faculties;
        ViewBag.Majors = data.Majors;
        ViewBag.IsAdmin = data.IsAdmin;
        ViewData["RoleFilter"] = roleFilter;
        ViewData["FacultyId"] = facultyId;
        ViewData["MajorId"] = majorId;
        return View(data.Bonuses);
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Users = await _salaryBonusService.GetEligibleUsersAsync();
        return View(new SalaryBonusCreateViewModel());
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SalaryBonusCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Users = await _salaryBonusService.GetEligibleUsersAsync();
            return View(model);
        }

        var result = await _salaryBonusService.CreateAsync(model);
        TempData[result.Success ? "SuccessMessage" : "ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }
}
