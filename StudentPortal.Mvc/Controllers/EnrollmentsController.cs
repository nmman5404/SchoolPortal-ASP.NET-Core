using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanEnrollClasses")] // CHỈ STUDENT MỚI ĐƯỢC VÀO
public class EnrollmentsController : Controller
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly UserManager<ApplicationUser> _userManager;

    public EnrollmentsController(IEnrollmentService enrollmentService, UserManager<ApplicationUser> userManager)
    {
        _enrollmentService = enrollmentService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var classes = await _enrollmentService.GetAvailableClassesAsync(user.Id);
        return View(classes);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Enroll(int classId, string rowVersion)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        try
        {
            await _enrollmentService.EnrollClassAsync(user.Id, classId, rowVersion);
            TempData["SuccessMessage"] = "Đăng ký lớp học thành công!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message; // Nhận lỗi từ Service truyền ra
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Unenroll(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        try
        {
            await _enrollmentService.UnenrollClassAsync(user.Id, classId);
            TempData["SuccessMessage"] = "Đã hủy đăng ký môn học thành công!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
        }
        return RedirectToAction(nameof(Index));
    }
}