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
            ModelState.AddModelError("keyword", "Từ khóa tìm kiếm phải dài ít nhất 3 ký tự.");
            return ValidationProblem(ModelState);
        }

        var results = await _courseClassService.SearchAsync(keyword);
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
