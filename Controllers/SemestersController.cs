using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Services;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")]
public class SemestersController : Controller
{
    private readonly ISemesterService _semesterService;

    public SemestersController(ISemesterService semesterService) => _semesterService = semesterService;

    [HttpGet]
    public async Task<IActionResult> Index() => View(await _semesterService.GetSemestersAsync());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string Name, DateTime StartDate, DateTime EndDate)
    {
        var result = await _semesterService.CreateAsync(Name, StartDate, EndDate);
        if (result.Success) TempData["SuccessMessage"] = result.Message;
        else TempData["ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleRegistration(int id)
    {
        var result = await _semesterService.ToggleRegistrationAsync(id);
        if (result.Success) TempData["SuccessMessage"] = result.Message;
        else TempData["ErrorMessage"] = result.Message;
        return RedirectToAction(nameof(Index));
    }
}
