using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Services;

namespace StudentPortal.Mvc.Controllers;

[Route("api/classes")]
[ApiController]
public class ApiClassesController : ControllerBase
{
    private readonly ICourseClassService _courseClassService;

    public ApiClassesController(ICourseClassService courseClassService) => _courseClassService = courseClassService;

    [HttpGet("search")]
    public async Task<IActionResult> Search(string? keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword) || keyword.Length < 3)
        {
            ModelState.AddModelError("keyword", "Tu khoa tim kiem phai dai it nhat 3 ky tu.");
            return ValidationProblem(ModelState);
        }

        var results = await _courseClassService.SearchAsync(keyword);
        if (!results.Any())
        {
            return NotFound(new ProblemDetails
            {
                Type = "/problems/class-not-found",
                Title = "Khong tim thay lop hoc",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Khong co lop hoc nao khop voi tu khoa '{keyword}'.",
                Instance = HttpContext.Request.Path,
                Extensions = { { "errorCode", "CLASS_NOT_FOUND" } }
            });
        }

        return Ok(results);
    }
}
