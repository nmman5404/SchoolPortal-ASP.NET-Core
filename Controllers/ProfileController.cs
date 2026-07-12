using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;

namespace StudentPortal.Mvc.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IFileUploadService _fileUploadService;
    private readonly IAuditLogService _auditLogService;

    public ProfileController(UserManager<ApplicationUser> userManager, IFileUploadService fileUploadService, IAuditLogService auditLogService)
    {
        _userManager = userManager;
        _fileUploadService = fileUploadService;
        _auditLogService = auditLogService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UploadAvatar(IFormFile avatarFile)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound();

        try
        {
            string newPath = await _fileUploadService.SaveImageAsync(avatarFile, "avatars");
            string oldPath = user.AvatarUrl ?? "";

            user.AvatarUrl = newPath;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _fileUploadService.DeleteFile(oldPath); // Xóa ảnh cũ
                await _auditLogService.LogAsync("UploadAvatar", "User", user.Id, "Success", "Đổi ảnh đại diện");
                TempData["SuccessMessage"] = "Cập nhật ảnh đại diện thành công!";
            }
            else
            {
                _fileUploadService.DeleteFile(newPath); // Rollback file nếu DB lỗi
                TempData["ErrorMessage"] = "Lỗi khi lưu vào hệ thống.";
            }
        }
        catch (Exception ex)
        {
            await _auditLogService.LogAsync("UploadAvatar", "User", user.Id, "Failed", ex.Message);
            TempData["ErrorMessage"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }
}