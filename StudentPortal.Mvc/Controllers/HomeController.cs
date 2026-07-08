using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;

namespace StudentPortal.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly IDashboardService _dashboardService;
    private readonly INotificationService _notificationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(IDashboardService dashboardService, INotificationService notificationService, UserManager<ApplicationUser> userManager)
    {
        _dashboardService = dashboardService;
        _notificationService = notificationService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (!User.Identity?.IsAuthenticated ?? true) return View("LandingPage");

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return View("LandingPage");

        var roles = await _userManager.GetRolesAsync(user);
        var data = await _dashboardService.GetDashboardAsync(user, roles);

        ViewBag.Notifications = data.Notifications;
        ViewBag.IsFacultyHeadMaster = data.IsFacultyHeadMaster;
        ViewBag.IsMajorHeadMaster = data.IsMajorHeadMaster;
        ViewBag.TotalStudents = data.TotalStudents;
        ViewBag.TotalProfs = data.TotalProfs;
        ViewBag.TotalClasses = data.TotalClasses;
        ViewBag.MyClasses = data.MyClasses;
        ViewBag.GPA = data.GPA;
        ViewBag.TeachingClasses = data.TeachingClasses;
        ViewBag.MyBonuses = data.MyBonuses;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DismissNotification(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        await _notificationService.DismissAsync(id, user.Id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy() => View();
}
