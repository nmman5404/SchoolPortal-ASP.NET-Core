using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;

namespace StudentPortal.Mvc.Controllers;

[Route("api/classes")]
[ApiController]
public class ApiClassesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ApiClassesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string? keyword)
    {
        // 1. Demo trả lỗi ValidationProblemDetails (Mã 400)
        if (string.IsNullOrWhiteSpace(keyword) || keyword.Length < 3)
        {
            ModelState.AddModelError("keyword", "Từ khóa tìm kiếm phải dài ít nhất 3 ký tự.");
            return ValidationProblem(ModelState);
        }

        // 2. Query an toàn bằng LINQ (Chống SQL Injection)
        var results = await _context.CourseClasses
            .Include(c => c.Subject)
            .AsNoTracking()
            .Where(c => c.Room.Contains(keyword) || (c.Subject != null && c.Subject.Name.Contains(keyword)))
            .Select(c => new { c.Id, c.Room, Subject = c.Subject!.Name })
            .ToListAsync();

        // 3. Demo trả lỗi ProblemDetails Not Found (Mã 404)
        if (!results.Any())
        {
            return NotFound(new ProblemDetails
            {
                Type = "/problems/class-not-found",
                Title = "Không tìm thấy lớp học",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Không có lớp học nào khớp với từ khóa '{keyword}'.",
                Instance = HttpContext.Request.Path,
                Extensions = { { "errorCode", "CLASS_NOT_FOUND" } }
            });
        }

        return Ok(results);
    }
}