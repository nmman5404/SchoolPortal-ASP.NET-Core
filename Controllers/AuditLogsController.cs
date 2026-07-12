using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")] // CHỈ ADMIN MỚI ĐƯỢC VÀO
public class AuditLogsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuditLogsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? keyword, string? result)
    {
        var query = _context.AuditLogs.AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(a => a.UserName!.Contains(keyword) || a.Action.Contains(keyword));

        if (!string.IsNullOrEmpty(result))
            query = query.Where(a => a.Result == result);

        ViewData["Keyword"] = keyword;
        ViewData["Result"] = result;

        var logs = await query.OrderByDescending(a => a.CreatedAt).Take(100).ToListAsync();
        return View(logs);
    }
}