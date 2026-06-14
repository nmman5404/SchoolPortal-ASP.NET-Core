using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")] // CHỈ ADMIN
public class NotificationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public NotificationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
        ViewBag.Users = await _context.Users.AsNoTracking().ToListAsync();
        return View(new Notification());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Notification model)
    {
        model.TargetRole = string.IsNullOrWhiteSpace(model.TargetRole) ? null : model.TargetRole;
        model.TargetUserId = string.IsNullOrWhiteSpace(model.TargetUserId) ? null : model.TargetUserId;

        if (model.TargetFacultyId.HasValue && model.TargetMajorId.HasValue)
        {
            var majorBelongsToFaculty = await _context.Majors
                .AnyAsync(m => m.Id == model.TargetMajorId.Value && m.FacultyId == model.TargetFacultyId.Value);
            if (!majorBelongsToFaculty)
                ModelState.AddModelError(nameof(model.TargetMajorId), "Ngành nhận thông báo phải thuộc khoa đã chọn.");
        }

        // Kiểm tra xem Form có hợp lệ không
        if (ModelState.IsValid)
        {
            model.CreatedAt = DateTime.Now;
            _context.Notifications.Add(model);
            await _context.SaveChangesAsync();
            
            TempData["SuccessMessage"] = "Đã gửi thông báo thành công!";
            return RedirectToAction("Index", "Home");
        }

        // NẾU FORM LỖI: PHẢI LOAD LẠI VIEWBAG TRƯỚC KHI RETURN VIEW (ĐÂY CHÍNH LÀ NGUYÊN NHÂN LỖI SẬP VIEW)
        ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
        ViewBag.Users = await _context.Users.AsNoTracking().ToListAsync();
        
        return View(model);
    }
}
