# StudentPortal.Mvc - Tong hop code chinh

Generated: 2026-06-14 15:26:44 +07:00

## Pham vi

- File nay tong hop cau truc cay cua du an va nhung nguyen van cac file code/config chinh.
- Cac artifact build, dependency vendored, database SQLite, anh upload, favicon va key runtime duoc ghi ro trong cay/summary nhung khong nhung noi dung nhi phan.
- Tong file code/config duoc nhung: 109
- Tong artifact/file khong nhung noi dung: 415

## Kien truc nhanh

- `Program.cs`: composition root cau hinh EF Core SQLite, Identity, authorization, DataProtection, health checks, middleware va route MVC.
- `Data/`: `ApplicationDbContext` va seed data ban dau.
- `Models/`: entity domain cho user/profile, khoa/nganh/mon/lop, dang ky/diem, thong bao, tai chinh va audit.
- `Controllers/`: luong MVC theo nghiep vu: account, user, khoa/nganh/mon/lop, dang ky, diem, thoi khoa bieu, thong bao, tai chinh.
- `Services/`: cac service dung chung nhu audit, upload file, dang ky lop.
- `ViewModels/`: model trung gian cho Razor views va form.
- `Views/`: UI Razor theo controller, shared layout va partial validation.
- `Migrations/`: migration EF Core sinh schema SQLite.
- `wwwroot/css`, `wwwroot/js`: static assets tu viet; `wwwroot/lib` la dependency client vendored.

## Cay thu muc du an

```text
.
|-- StudentPortal.Mvc/
|   |-- App_Data/
|   |   `-- DataProtectionKeys/ [omitted: Runtime data-protection key]
|   |-- bin/ [omitted: Build output]
|   |-- Controllers/
|   |   |-- AccountController.cs
|   |   |-- ApiClassesController.cs
|   |   |-- AuditLogsController.cs
|   |   |-- CourseClassesController.cs
|   |   |-- EnrollmentsController.cs
|   |   |-- FacultiesController.cs
|   |   |-- GradesController.cs
|   |   |-- HomeController.cs
|   |   |-- MajorsController.cs
|   |   |-- NotificationsController.cs
|   |   |-- ProfileController.cs
|   |   |-- SalaryBonusesController.cs
|   |   |-- SchedulesController.cs
|   |   |-- SemestersController.cs
|   |   |-- SubjectsController.cs
|   |   |-- TranscriptsController.cs
|   |   `-- UsersController.cs
|   |-- Data/
|   |   |-- ApplicationDbContext.cs
|   |   `-- DbInitializer.cs
|   |-- Migrations/
|   |   |-- 20260613070555_InitialCreateLab06.cs
|   |   |-- 20260613070555_InitialCreateLab06.Designer.cs
|   |   |-- 20260613081804_AddSalaryBonusTable.cs
|   |   |-- 20260613081804_AddSalaryBonusTable.Designer.cs
|   |   |-- 20260613082008_InitialStudentPortalDB.cs
|   |   |-- 20260613082008_InitialStudentPortalDB.Designer.cs
|   |   |-- 20260613121412_AddNotificationTable.cs
|   |   |-- 20260613121412_AddNotificationTable.Designer.cs
|   |   |-- 20260613123454_AddPIDToUser.cs
|   |   |-- 20260613123454_AddPIDToUser.Designer.cs
|   |   |-- 20260614061719_AddUserNotification.cs
|   |   |-- 20260614061719_AddUserNotification.Designer.cs
|   |   `-- ApplicationDbContextModelSnapshot.cs
|   |-- Models/
|   |   |-- ApplicationUser.cs
|   |   |-- AuditLog.cs
|   |   |-- ClassProfessor.cs
|   |   |-- CourseClass.cs
|   |   |-- ErrorViewModel.cs
|   |   |-- Faculty.cs
|   |   |-- Grade.cs
|   |   |-- Major.cs
|   |   |-- Notification.cs
|   |   |-- PrerequisiteSubject.cs
|   |   |-- ProfessorProfile.cs
|   |   |-- SalaryBonus.cs
|   |   |-- Semester.cs
|   |   |-- StudentProfile.cs
|   |   |-- Subject.cs
|   |   |-- UserNotification.cs
|   |   `-- WorkerProfile.cs
|   |-- obj/ [omitted: Build intermediate/generated output]
|   |-- Properties/
|   |   `-- launchSettings.json
|   |-- Services/
|   |   |-- AuditLogService.cs
|   |   |-- EnrollmentService.cs
|   |   |-- FileUploadService.cs
|   |   |-- IAuditLogService.cs
|   |   |-- IEnrollmentService.cs
|   |   `-- IFileUploadService.cs
|   |-- ViewModels/
|   |   |-- CourseClassEditViewModel.cs
|   |   |-- CourseClassListItemViewModel.cs
|   |   |-- EnrollmentClassViewModel.cs
|   |   |-- FacultyViewModels.cs
|   |   |-- LoginViewModel.cs
|   |   |-- MajorManagementViewModels.cs
|   |   |-- SalaryBonusCreateViewModel.cs
|   |   |-- SalaryBonusListItemViewModel.cs
|   |   |-- ScheduleViewModels.cs
|   |   |-- SubjectViewModels.cs
|   |   |-- TranscriptViewModel.cs
|   |   |-- UserCreateViewModel.cs
|   |   |-- UserEditViewModel.cs
|   |   `-- UserListItemViewModel.cs
|   |-- Views/
|   |   |-- Account/
|   |   |   |-- AccessDenied.cshtml
|   |   |   `-- Login.cshtml
|   |   |-- AuditLogs/
|   |   |   `-- Index.cshtml
|   |   |-- CourseClasses/
|   |   |   |-- CreateEdit.cshtml
|   |   |   `-- Index.cshtml
|   |   |-- Enrollments/
|   |   |   `-- Index.cshtml
|   |   |-- Faculties/
|   |   |   |-- CreateEdit.cshtml
|   |   |   `-- Index.cshtml
|   |   |-- Grades/
|   |   |   |-- ClassGrades.cshtml
|   |   |   `-- Index.cshtml
|   |   |-- Home/
|   |   |   |-- Index.cshtml
|   |   |   |-- LandingPage.cshtml
|   |   |   `-- Privacy.cshtml
|   |   |-- Majors/
|   |   |   `-- Index.cshtml
|   |   |-- Notifications/
|   |   |   `-- Create.cshtml
|   |   |-- Profile/
|   |   |   `-- Index.cshtml
|   |   |-- SalaryBonuses/
|   |   |   |-- Create.cshtml
|   |   |   `-- Index.cshtml
|   |   |-- Schedules/
|   |   |   `-- Index.cshtml
|   |   |-- Semesters/
|   |   |   `-- Index.cshtml
|   |   |-- Shared/
|   |   |   |-- _Layout.cshtml
|   |   |   |-- _Layout.cshtml.css
|   |   |   |-- _ValidationScriptsPartial.cshtml
|   |   |   `-- Error.cshtml
|   |   |-- Subjects/
|   |   |   |-- CreateEdit.cshtml
|   |   |   `-- Index.cshtml
|   |   |-- Transcripts/
|   |   |   `-- Index.cshtml
|   |   |-- Users/
|   |   |   |-- Create.cshtml
|   |   |   |-- Edit.cshtml
|   |   |   `-- Index.cshtml
|   |   |-- _ViewImports.cshtml
|   |   `-- _ViewStart.cshtml
|   |-- wwwroot/
|   |   |-- css/
|   |   |   `-- site.css
|   |   |-- js/
|   |   |   `-- site.js
|   |   |-- lib/ [omitted: Vendored client library]
|   |   |-- uploads/ [omitted: Uploaded binary asset]
|   |   `-- favicon.ico [omitted: Binary image asset]
|   |-- appsettings.Development.json
|   |-- appsettings.json
|   |-- Program.cs
|   |-- StudentPortal.db [omitted: SQLite database/runtime file]
|   `-- StudentPortal.Mvc.csproj
|-- StudentPortal.Mvc.sln
|-- studentportal-run.err.log [omitted: Unsupported or binary file type]
`-- studentportal-run.log [omitted: Unsupported or binary file type]
```

## Artifact khong nhung noi dung

- Binary image asset: 1 file, 5430 bytes
- Build intermediate/generated output: 164 file, 7438828 bytes
- Build output: 182 file, 71259589 bytes
- Runtime data-protection key: 1 file, 1016 bytes
- SQLite database/runtime file: 1 file, 270336 bytes
- Unsupported or binary file type: 2 file, 44753 bytes
- Uploaded binary asset: 4 file, 2935850 bytes
- Vendored client library: 60 file, 9784362 bytes

## Danh sach file code/config duoc nhung

- `StudentPortal.Mvc.sln`
- `StudentPortal.Mvc\appsettings.Development.json`
- `StudentPortal.Mvc\appsettings.json`
- `StudentPortal.Mvc\Controllers\AccountController.cs`
- `StudentPortal.Mvc\Controllers\ApiClassesController.cs`
- `StudentPortal.Mvc\Controllers\AuditLogsController.cs`
- `StudentPortal.Mvc\Controllers\CourseClassesController.cs`
- `StudentPortal.Mvc\Controllers\EnrollmentsController.cs`
- `StudentPortal.Mvc\Controllers\FacultiesController.cs`
- `StudentPortal.Mvc\Controllers\GradesController.cs`
- `StudentPortal.Mvc\Controllers\HomeController.cs`
- `StudentPortal.Mvc\Controllers\MajorsController.cs`
- `StudentPortal.Mvc\Controllers\NotificationsController.cs`
- `StudentPortal.Mvc\Controllers\ProfileController.cs`
- `StudentPortal.Mvc\Controllers\SalaryBonusesController.cs`
- `StudentPortal.Mvc\Controllers\SchedulesController.cs`
- `StudentPortal.Mvc\Controllers\SemestersController.cs`
- `StudentPortal.Mvc\Controllers\SubjectsController.cs`
- `StudentPortal.Mvc\Controllers\TranscriptsController.cs`
- `StudentPortal.Mvc\Controllers\UsersController.cs`
- `StudentPortal.Mvc\Data\ApplicationDbContext.cs`
- `StudentPortal.Mvc\Data\DbInitializer.cs`
- `StudentPortal.Mvc\Migrations\20260613070555_InitialCreateLab06.cs`
- `StudentPortal.Mvc\Migrations\20260613070555_InitialCreateLab06.Designer.cs`
- `StudentPortal.Mvc\Migrations\20260613081804_AddSalaryBonusTable.cs`
- `StudentPortal.Mvc\Migrations\20260613081804_AddSalaryBonusTable.Designer.cs`
- `StudentPortal.Mvc\Migrations\20260613082008_InitialStudentPortalDB.cs`
- `StudentPortal.Mvc\Migrations\20260613082008_InitialStudentPortalDB.Designer.cs`
- `StudentPortal.Mvc\Migrations\20260613121412_AddNotificationTable.cs`
- `StudentPortal.Mvc\Migrations\20260613121412_AddNotificationTable.Designer.cs`
- `StudentPortal.Mvc\Migrations\20260613123454_AddPIDToUser.cs`
- `StudentPortal.Mvc\Migrations\20260613123454_AddPIDToUser.Designer.cs`
- `StudentPortal.Mvc\Migrations\20260614061719_AddUserNotification.cs`
- `StudentPortal.Mvc\Migrations\20260614061719_AddUserNotification.Designer.cs`
- `StudentPortal.Mvc\Migrations\ApplicationDbContextModelSnapshot.cs`
- `StudentPortal.Mvc\Models\ApplicationUser.cs`
- `StudentPortal.Mvc\Models\AuditLog.cs`
- `StudentPortal.Mvc\Models\ClassProfessor.cs`
- `StudentPortal.Mvc\Models\CourseClass.cs`
- `StudentPortal.Mvc\Models\ErrorViewModel.cs`
- `StudentPortal.Mvc\Models\Faculty.cs`
- `StudentPortal.Mvc\Models\Grade.cs`
- `StudentPortal.Mvc\Models\Major.cs`
- `StudentPortal.Mvc\Models\Notification.cs`
- `StudentPortal.Mvc\Models\PrerequisiteSubject.cs`
- `StudentPortal.Mvc\Models\ProfessorProfile.cs`
- `StudentPortal.Mvc\Models\SalaryBonus.cs`
- `StudentPortal.Mvc\Models\Semester.cs`
- `StudentPortal.Mvc\Models\StudentProfile.cs`
- `StudentPortal.Mvc\Models\Subject.cs`
- `StudentPortal.Mvc\Models\UserNotification.cs`
- `StudentPortal.Mvc\Models\WorkerProfile.cs`
- `StudentPortal.Mvc\Program.cs`
- `StudentPortal.Mvc\Properties\launchSettings.json`
- `StudentPortal.Mvc\Services\AuditLogService.cs`
- `StudentPortal.Mvc\Services\EnrollmentService.cs`
- `StudentPortal.Mvc\Services\FileUploadService.cs`
- `StudentPortal.Mvc\Services\IAuditLogService.cs`
- `StudentPortal.Mvc\Services\IEnrollmentService.cs`
- `StudentPortal.Mvc\Services\IFileUploadService.cs`
- `StudentPortal.Mvc\StudentPortal.Mvc.csproj`
- `StudentPortal.Mvc\ViewModels\CourseClassEditViewModel.cs`
- `StudentPortal.Mvc\ViewModels\CourseClassListItemViewModel.cs`
- `StudentPortal.Mvc\ViewModels\EnrollmentClassViewModel.cs`
- `StudentPortal.Mvc\ViewModels\FacultyViewModels.cs`
- `StudentPortal.Mvc\ViewModels\LoginViewModel.cs`
- `StudentPortal.Mvc\ViewModels\MajorManagementViewModels.cs`
- `StudentPortal.Mvc\ViewModels\SalaryBonusCreateViewModel.cs`
- `StudentPortal.Mvc\ViewModels\SalaryBonusListItemViewModel.cs`
- `StudentPortal.Mvc\ViewModels\ScheduleViewModels.cs`
- `StudentPortal.Mvc\ViewModels\SubjectViewModels.cs`
- `StudentPortal.Mvc\ViewModels\TranscriptViewModel.cs`
- `StudentPortal.Mvc\ViewModels\UserCreateViewModel.cs`
- `StudentPortal.Mvc\ViewModels\UserEditViewModel.cs`
- `StudentPortal.Mvc\ViewModels\UserListItemViewModel.cs`
- `StudentPortal.Mvc\Views\_ViewImports.cshtml`
- `StudentPortal.Mvc\Views\_ViewStart.cshtml`
- `StudentPortal.Mvc\Views\Account\AccessDenied.cshtml`
- `StudentPortal.Mvc\Views\Account\Login.cshtml`
- `StudentPortal.Mvc\Views\AuditLogs\Index.cshtml`
- `StudentPortal.Mvc\Views\CourseClasses\CreateEdit.cshtml`
- `StudentPortal.Mvc\Views\CourseClasses\Index.cshtml`
- `StudentPortal.Mvc\Views\Enrollments\Index.cshtml`
- `StudentPortal.Mvc\Views\Faculties\CreateEdit.cshtml`
- `StudentPortal.Mvc\Views\Faculties\Index.cshtml`
- `StudentPortal.Mvc\Views\Grades\ClassGrades.cshtml`
- `StudentPortal.Mvc\Views\Grades\Index.cshtml`
- `StudentPortal.Mvc\Views\Home\Index.cshtml`
- `StudentPortal.Mvc\Views\Home\LandingPage.cshtml`
- `StudentPortal.Mvc\Views\Home\Privacy.cshtml`
- `StudentPortal.Mvc\Views\Majors\Index.cshtml`
- `StudentPortal.Mvc\Views\Notifications\Create.cshtml`
- `StudentPortal.Mvc\Views\Profile\Index.cshtml`
- `StudentPortal.Mvc\Views\SalaryBonuses\Create.cshtml`
- `StudentPortal.Mvc\Views\SalaryBonuses\Index.cshtml`
- `StudentPortal.Mvc\Views\Schedules\Index.cshtml`
- `StudentPortal.Mvc\Views\Semesters\Index.cshtml`
- `StudentPortal.Mvc\Views\Shared\_Layout.cshtml`
- `StudentPortal.Mvc\Views\Shared\_Layout.cshtml.css`
- `StudentPortal.Mvc\Views\Shared\_ValidationScriptsPartial.cshtml`
- `StudentPortal.Mvc\Views\Shared\Error.cshtml`
- `StudentPortal.Mvc\Views\Subjects\CreateEdit.cshtml`
- `StudentPortal.Mvc\Views\Subjects\Index.cshtml`
- `StudentPortal.Mvc\Views\Transcripts\Index.cshtml`
- `StudentPortal.Mvc\Views\Users\Create.cshtml`
- `StudentPortal.Mvc\Views\Users\Edit.cshtml`
- `StudentPortal.Mvc\Views\Users\Index.cshtml`
- `StudentPortal.Mvc\wwwroot\css\site.css`
- `StudentPortal.Mvc\wwwroot\js\site.js`

## Noi dung code

### `StudentPortal.Mvc.sln`

- Size: 1146 bytes
- Lines: 25

````text
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.5.2.0
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "StudentPortal.Mvc", "StudentPortal.Mvc\StudentPortal.Mvc.csproj", "{0997C2A9-351B-4D76-DD9A-27E160AF96D3}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{0997C2A9-351B-4D76-DD9A-27E160AF96D3}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{0997C2A9-351B-4D76-DD9A-27E160AF96D3}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{0997C2A9-351B-4D76-DD9A-27E160AF96D3}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{0997C2A9-351B-4D76-DD9A-27E160AF96D3}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {7A5E7EEB-C242-4DAB-AD57-3BC89FAB272F}
	EndGlobalSection
EndGlobal
````

### `StudentPortal.Mvc\appsettings.Development.json`

- Size: 127 bytes
- Lines: 9

````json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
````

### `StudentPortal.Mvc\appsettings.json`

- Size: 238 bytes
- Lines: 12

````json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=StudentPortal.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
````

### `StudentPortal.Mvc\Controllers\AccountController.cs`

- Size: 2828 bytes
- Lines: 82

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize] // Mặc định khóa toàn bộ, ngoại trừ những chỗ có [AllowAnonymous]
public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login(string? returnUrl = null)
    {
        // Nếu user đã login rồi mà cố tình vào trang login -> đẩy về Home
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home");
        }
        
        ViewData["ReturnUrl"] = returnUrl;
        return View(new LoginViewModel());
    }

    [AllowAnonymous]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (!ModelState.IsValid) return View(model);

        // Thực hiện đăng nhập qua Identity
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            // TODO: Ở Chặng sau, chúng ta sẽ thêm AuditLog ghi nhận Login Success ở đây
            
            // Redirect an toàn tránh Open Redirect Attack
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        if (result.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "Tài khoản này đã bị Khóa hoặc Xóa khỏi hệ thống. Vui lòng liên hệ Ban Giám Hiệu.");
            return View(model);
        }

        // Báo lỗi chung chung để bảo mật (không báo chi tiết sai email hay sai pass)
        ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không chính xác.");
        return View(model);
    }

    // Lab 06 Yêu cầu BẮT BUỘC Logout phải là POST để chặn CSRF
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
}
````

### `StudentPortal.Mvc\Controllers\ApiClassesController.cs`

- Size: 1850 bytes
- Lines: 52

````csharp
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
````

### `StudentPortal.Mvc\Controllers\AuditLogsController.cs`

- Size: 1108 bytes
- Lines: 35

````csharp
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
````

### `StudentPortal.Mvc\Controllers\CourseClassesController.cs`

- Size: 16874 bytes
- Lines: 442

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class CourseClassesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CourseClassesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private IQueryable<Subject> GetManageableSubjectsQuery(ApplicationUser user, bool isAdmin)
    {
        var query = _context.Subjects
            .Include(s => s.Major).ThenInclude(m => m!.Faculty)
            .AsQueryable();

        if (isAdmin) return query;

        return query.Where(s =>
            s.Major != null &&
            (s.Major.HeadMasterId == user.Id ||
             (s.Major.Faculty != null && s.Major.Faculty.HeadMasterId == user.Id)));
    }

    private async Task<bool> CheckCanManageClassAsync(int subjectId, ApplicationUser user, bool isAdmin)
    {
        if (isAdmin) return true;

        return await _context.Subjects
            .Include(s => s.Major).ThenInclude(m => m!.Faculty)
            .AsNoTracking()
            .AnyAsync(s =>
                s.Id == subjectId &&
                s.Major != null &&
                (s.Major.HeadMasterId == user.Id ||
                 (s.Major.Faculty != null && s.Major.Faculty.HeadMasterId == user.Id)));
    }

    private async Task<int?> GetProfessorFacultyIdAsync(string userId)
    {
        return await _context.ProfessorProfiles
            .AsNoTracking()
            .Where(p => p.UserId == userId)
            .Select(p => (int?)p.FacultyId)
            .FirstOrDefaultAsync();
    }

    private async Task<bool> CheckCanTeachClassAsync(int subjectId, string professorId)
    {
        var facultyId = await GetProfessorFacultyIdAsync(professorId);
        if (facultyId == null) return false;

        return await _context.Subjects
            .Include(s => s.Major)
            .AsNoTracking()
            .AnyAsync(s => s.Id == subjectId && s.Major != null && s.Major.FacultyId == facultyId.Value);
    }

    private async Task LoadCreateEditListsAsync(ApplicationUser user, bool isAdmin)
    {
        ViewBag.Subjects = await GetManageableSubjectsQuery(user, isAdmin)
            .AsNoTracking()
            .OrderBy(s => s.Major!.Faculty!.Name)
            .ThenBy(s => s.Major!.Name)
            .ThenBy(s => s.Name)
            .Select(s => new { s.Id, Name = $"{s.Name} ({s.Major!.Name} - {s.Major.Faculty!.Name})" })
            .ToListAsync();

        ViewBag.Semesters = await _context.Semesters
            .AsNoTracking()
            .OrderByDescending(s => s.StartDate)
            .ToListAsync();
    }

    private async Task LoadIndexFiltersAsync(ApplicationUser user, bool isAdmin, int? facultyId, int? majorId)
    {
        if (isAdmin)
        {
            ViewBag.Faculties = await _context.Faculties
                .AsNoTracking()
                .Where(f => !f.IsDeleted)
                .OrderBy(f => f.Name)
                .ToListAsync();
            ViewBag.Majors = await _context.Majors
                .Include(m => m.Faculty)
                .AsNoTracking()
                .Where(m => !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
                .OrderBy(m => m.Faculty!.Name)
                .ThenBy(m => m.Name)
                .ToListAsync();
        }
        else
        {
            var facultyIds = await _context.ProfessorProfiles
                .Where(p => p.UserId == user.Id)
                .Select(p => p.FacultyId)
                .ToListAsync();

            ViewBag.Faculties = await _context.Faculties
                .AsNoTracking()
                .Where(f => facultyIds.Contains(f.Id) && !f.IsDeleted)
                .OrderBy(f => f.Name)
                .ToListAsync();
            ViewBag.Majors = await _context.Majors
                .Include(m => m.Faculty)
                .AsNoTracking()
                .Where(m => facultyIds.Contains(m.FacultyId) && !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        ViewData["FacultyId"] = facultyId;
        ViewData["MajorId"] = majorId;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? facultyId, int? majorId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        bool isProfessor = await _userManager.IsInRoleAsync(user, "Professor");
        var professorFacultyId = isProfessor ? await GetProfessorFacultyIdAsync(user.Id) : null;
        await LoadIndexFiltersAsync(user, isAdmin, facultyId, majorId);

        var classesQuery = _context.CourseClasses.IgnoreQueryFilters()
            .Include(c => c.Subject).ThenInclude(s => s!.Major).ThenInclude(m => m!.Faculty)
            .Include(c => c.Semester)
            .Include(c => c.ClassProfessors)
            .AsNoTracking()
            .AsQueryable();

        if (!isAdmin)
        {
            if (professorFacultyId == null)
            {
                classesQuery = classesQuery.Where(c => false);
            }
            else
            {
                classesQuery = classesQuery.Where(c =>
                    c.Subject != null &&
                    c.Subject.Major != null &&
                    c.Subject.Major.FacultyId == professorFacultyId.Value);
            }
        }

        if (facultyId.HasValue)
        {
            classesQuery = classesQuery.Where(c =>
                c.Subject != null &&
                c.Subject.Major != null &&
                c.Subject.Major.FacultyId == facultyId.Value);
        }

        if (majorId.HasValue)
        {
            classesQuery = classesQuery.Where(c => c.Subject != null && c.Subject.MajorId == majorId.Value);
        }

        var classes = await classesQuery
            .OrderBy(c => c.Semester!.StartDate)
            .ThenBy(c => c.Subject!.Name)
            .ToListAsync();

        var model = new List<CourseClassListItemViewModel>();
        foreach (var c in classes)
        {
            var canManage = await CheckCanManageClassAsync(c.SubjectId, user, isAdmin);
            var canTeach = isProfessor &&
                           !c.IsDeleted &&
                           professorFacultyId != null &&
                           c.Subject?.Major?.FacultyId == professorFacultyId.Value;

            model.Add(new CourseClassListItemViewModel
            {
                Id = c.Id,
                SubjectName = c.Subject?.Name ?? "N/A",
                SemesterName = c.Semester?.Name ?? "N/A",
                Room = c.Room,
                DayOfWeek = c.DayOfWeek,
                StartPeriod = c.StartPeriod,
                EndPeriod = c.EndPeriod,
                Capacity = c.Capacity,
                EnrolledCount = c.EnrolledCount,
                IsDeleted = c.IsDeleted,
                CanManage = canManage,
                CanTeach = canTeach,
                IsAssignedProfessor = c.ClassProfessors.Any(cp => cp.ProfessorId == user.Id)
            });
        }

        ViewBag.CanCreateClass = isAdmin || await GetManageableSubjectsQuery(user, isAdmin).AnyAsync();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> CreateEdit(int? id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        await LoadCreateEditListsAsync(user, isAdmin);

        if (id == null)
        {
            if (!((IEnumerable<object>)ViewBag.Subjects).Any())
            {
                TempData["ErrorMessage"] = "Bạn không có quyền mở lớp cho môn học nào.";
                return RedirectToAction(nameof(Index));
            }

            return View(new CourseClassEditViewModel
            {
                DayOfWeek = DayOfWeek.Monday,
                StartPeriod = 1,
                EndPeriod = 3,
                Capacity = 40
            });
        }

        var courseClass = await _context.CourseClasses.FirstOrDefaultAsync(c => c.Id == id.Value);
        if (courseClass == null) return NotFound();

        if (!await CheckCanManageClassAsync(courseClass.SubjectId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        return View(new CourseClassEditViewModel
        {
            Id = courseClass.Id,
            SubjectId = courseClass.SubjectId,
            SemesterId = courseClass.SemesterId,
            Room = courseClass.Room,
            DayOfWeek = courseClass.DayOfWeek,
            StartPeriod = courseClass.StartPeriod,
            EndPeriod = courseClass.EndPeriod,
            Capacity = courseClass.Capacity,
            RowVersion = Convert.ToBase64String(courseClass.RowVersion)
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEdit(CourseClassEditViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        if (model.EndPeriod < model.StartPeriod)
            ModelState.AddModelError(nameof(model.EndPeriod), "Tiết kết thúc phải lớn hơn hoặc bằng tiết bắt đầu.");

        if (!ModelState.IsValid)
        {
            await LoadCreateEditListsAsync(user, isAdmin);
            return View(model);
        }

        if (!await CheckCanManageClassAsync(model.SubjectId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        try
        {
            if (model.Id == 0)
            {
                var newClass = new CourseClass
                {
                    SubjectId = model.SubjectId,
                    SemesterId = model.SemesterId,
                    Room = model.Room,
                    DayOfWeek = model.DayOfWeek,
                    StartPeriod = model.StartPeriod,
                    EndPeriod = model.EndPeriod,
                    Capacity = model.Capacity,
                    RowVersion = Guid.NewGuid().ToByteArray()
                };
                _context.CourseClasses.Add(newClass);
                TempData["SuccessMessage"] = "Đã mở lớp học mới thành công!";
            }
            else
            {
                var courseClass = await _context.CourseClasses.FirstOrDefaultAsync(c => c.Id == model.Id);
                if (courseClass == null) return NotFound();

                if (!await CheckCanManageClassAsync(courseClass.SubjectId, user, isAdmin))
                    return RedirectToAction("AccessDenied", "Account");

                courseClass.SubjectId = model.SubjectId;
                courseClass.SemesterId = model.SemesterId;
                courseClass.Room = model.Room;
                courseClass.DayOfWeek = model.DayOfWeek;
                courseClass.StartPeriod = model.StartPeriod;
                courseClass.EndPeriod = model.EndPeriod;
                courseClass.Capacity = model.Capacity;
                courseClass.RowVersion = Guid.NewGuid().ToByteArray();

                if (!string.IsNullOrWhiteSpace(model.RowVersion))
                {
                    _context.Entry(courseClass).Property(c => c.RowVersion).OriginalValue =
                        Convert.FromBase64String(model.RowVersion);
                }

                TempData["SuccessMessage"] = "Cập nhật lớp học thành công!";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            TempData["ErrorMessage"] = "LỖI ĐỤNG ĐỘ: Lớp học vừa bị thay đổi bởi người khác. Tải lại trang!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi: " + (ex.InnerException?.Message ?? ex.Message));
            await LoadCreateEditListsAsync(user, isAdmin);
            return View(model);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleDelete(int id, bool restore = false)
    {
        var courseClass = await _context.CourseClasses.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id == id);
        if (courseClass == null) return NotFound();

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        if (!await CheckCanManageClassAsync(courseClass.SubjectId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        courseClass.IsDeleted = !restore;
        courseClass.RowVersion = Guid.NewGuid().ToByteArray();
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = restore ? "Đã khôi phục Lớp học!" : "Đã đưa Lớp học vào thùng rác!";
        return RedirectToAction(nameof(Index), new { showDeleted = restore });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignProfessor(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        if (!await _userManager.IsInRoleAsync(user, "Professor"))
            return RedirectToAction("AccessDenied", "Account");

        var courseClass = await _context.CourseClasses
            .Include(c => c.Subject).ThenInclude(s => s!.Major)
            .FirstOrDefaultAsync(c => c.Id == classId);
        if (courseClass == null) return NotFound();

        if (courseClass.IsDeleted)
        {
            TempData["ErrorMessage"] = "Không thể nhận dạy lớp đã bị xóa.";
            return RedirectToAction(nameof(Index));
        }

        if (!await CheckCanTeachClassAsync(courseClass.SubjectId, user.Id))
        {
            TempData["ErrorMessage"] = "Bạn chỉ được nhận dạy các lớp thuộc khoa của mình.";
            return RedirectToAction(nameof(Index));
        }

        bool alreadyAssigned = await _context.ClassProfessors
            .AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == user.Id);

        if (alreadyAssigned)
        {
            TempData["ErrorMessage"] = "Bạn đã nhận lớp này rồi!";
            return RedirectToAction(nameof(Index));
        }

        bool hasScheduleConflict = await _context.ClassProfessors
            .Include(cp => cp.CourseClass)
            .Where(cp =>
                cp.ProfessorId == user.Id &&
                cp.CourseClass != null &&
                !cp.CourseClass.IsDeleted &&
                cp.CourseClass.SemesterId == courseClass.SemesterId &&
                cp.CourseClass.DayOfWeek == courseClass.DayOfWeek)
            .AnyAsync(cp =>
                !(cp.CourseClass!.EndPeriod < courseClass.StartPeriod ||
                  cp.CourseClass.StartPeriod > courseClass.EndPeriod));

        if (hasScheduleConflict)
        {
            TempData["ErrorMessage"] = "Bạn đang dạy một lớp khác trùng thời gian với lớp này.";
            return RedirectToAction(nameof(Index));
        }

        _context.ClassProfessors.Add(new ClassProfessor { CourseClassId = classId, ProfessorId = user.Id });
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Bạn đã nhận giảng dạy lớp này thành công!";

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UnassignProfessor(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var assignment = await _context.ClassProfessors
            .FirstOrDefaultAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == user.Id);
        if (assignment == null)
        {
            TempData["ErrorMessage"] = "Bạn chưa nhận dạy lớp này.";
            return RedirectToAction(nameof(Index));
        }

        _context.ClassProfessors.Remove(assignment);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Đã hủy nhận giảng dạy lớp này.";

        return RedirectToAction(nameof(Index));
    }
}
````

### `StudentPortal.Mvc\Controllers\EnrollmentsController.cs`

- Size: 2237 bytes
- Lines: 69

````csharp
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
````

### `StudentPortal.Mvc\Controllers\FacultiesController.cs`

- Size: 8019 bytes
- Lines: 225

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class FacultiesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public FacultiesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private async Task<bool> IsFacultyHeadAsync(string userId, int facultyId)
    {
        return await _context.Faculties
            .IgnoreQueryFilters()
            .AnyAsync(f => f.Id == facultyId && f.HeadMasterId == userId);
    }

    private async Task LoadProfessorListAsync(int? facultyId)
    {
        if (facultyId == null)
        {
            ViewBag.Professors = new List<object>();
            return;
        }

        ViewBag.Professors = await _context.ProfessorProfiles
            .Include(p => p.User)
            .Where(p => !p.User!.IsDeleted && p.FacultyId == facultyId.Value)
            .Select(p => new { Id = p.UserId, FullName = p.User!.FullName })
            .AsNoTracking()
            .ToListAsync();
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? keyword, bool showDeleted = false)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        ViewBag.IsAdmin = isAdmin;

        var query = _context.Faculties.IgnoreQueryFilters()
            .Include(f => f.HeadMaster).ThenInclude(h => h!.User)
            .Include(f => f.Majors)
            .AsNoTracking()
            .AsQueryable();

        if (!isAdmin)
            query = query.Where(f => f.HeadMasterId == user.Id);

        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(f => f.Name.Contains(keyword));

        query = showDeleted ? query.Where(f => f.IsDeleted) : query.Where(f => !f.IsDeleted);

        var faculties = await query.ToListAsync();
        if (!isAdmin && faculties.Count == 0)
            return RedirectToAction("AccessDenied", "Account");

        var model = faculties.Select(f => new FacultyListItemViewModel
        {
            Id = f.Id,
            Name = f.Name,
            HeadMasterName = f.HeadMaster?.User?.FullName ?? "Chưa bổ nhiệm",
            FoundDateText = f.FoundDate.ToString("dd/MM/yyyy"),
            TotalMajors = f.Majors.Count(m => !m.IsDeleted),
            IsDeleted = f.IsDeleted
        }).ToList();

        ViewData["Keyword"] = keyword;
        ViewData["ShowDeleted"] = showDeleted;
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> CreateEdit(int? id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        ViewBag.IsAdmin = isAdmin;

        if (id == null)
        {
            if (!isAdmin) return RedirectToAction("AccessDenied", "Account");
            await LoadProfessorListAsync(null);
            return View(new FacultyCreateEditViewModel { Majors = { new MajorInlineViewModel() } });
        }

        if (!isAdmin && !await IsFacultyHeadAsync(user.Id, id.Value))
            return RedirectToAction("AccessDenied", "Account");

        var faculty = await _context.Faculties
            .IgnoreQueryFilters()
            .Include(f => f.Majors)
            .FirstOrDefaultAsync(f => f.Id == id.Value);
        if (faculty == null) return NotFound();

        await LoadProfessorListAsync(faculty.Id);

        var model = new FacultyCreateEditViewModel
        {
            Id = faculty.Id,
            Name = faculty.Name,
            FoundDate = faculty.FoundDate,
            HeadMasterId = faculty.HeadMasterId,
            Majors = faculty.Majors
                .Where(m => !m.IsDeleted)
                .Select(m => new MajorInlineViewModel { Id = m.Id, Name = m.Name, HeadMasterId = m.HeadMasterId })
                .ToList()
        };

        if (!model.Majors.Any()) model.Majors.Add(new MajorInlineViewModel());
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEdit(FacultyCreateEditViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        ViewBag.IsAdmin = isAdmin;

        if (!isAdmin && (model.Id == 0 || !await IsFacultyHeadAsync(user.Id, model.Id)))
            return RedirectToAction("AccessDenied", "Account");

        if (!ModelState.IsValid)
        {
            await LoadProfessorListAsync(model.Id == 0 ? null : model.Id);
            return View(model);
        }

        Faculty faculty;
        if (model.Id == 0)
        {
            if (!isAdmin) return RedirectToAction("AccessDenied", "Account");

            faculty = new Faculty
            {
                Name = model.Name,
                FoundDate = model.FoundDate,
                HeadMasterId = string.IsNullOrWhiteSpace(model.HeadMasterId) ? null : model.HeadMasterId
            };
            _context.Faculties.Add(faculty);
        }
        else
        {
            faculty = await _context.Faculties.Include(f => f.Majors).FirstOrDefaultAsync(f => f.Id == model.Id)
                ?? throw new InvalidOperationException("Không tìm thấy khoa.");

            faculty.Name = model.Name;
            faculty.FoundDate = model.FoundDate;
            if (isAdmin)
                faculty.HeadMasterId = string.IsNullOrWhiteSpace(model.HeadMasterId) ? null : model.HeadMasterId;
        }

        var submittedMajorIds = new HashSet<int>();
        foreach (var majorModel in model.Majors.Where(m => !string.IsNullOrWhiteSpace(m.Name)))
        {
            var safeMajorHeadMasterId = string.IsNullOrWhiteSpace(majorModel.HeadMasterId) ? null : majorModel.HeadMasterId;

            if (majorModel.Id == 0)
            {
                faculty.Majors.Add(new Major
                {
                    Name = majorModel.Name,
                    FoundDate = DateTime.Now,
                    HeadMasterId = safeMajorHeadMasterId
                });
                continue;
            }

            var existingMajor = faculty.Majors.FirstOrDefault(m => m.Id == majorModel.Id);
            if (existingMajor == null) continue;

            existingMajor.Name = majorModel.Name;
            existingMajor.HeadMasterId = safeMajorHeadMasterId;
            existingMajor.IsDeleted = false;
            submittedMajorIds.Add(existingMajor.Id);
        }

        if (model.Id > 0)
        {
            foreach (var deletedMajor in faculty.Majors.Where(m => m.Id > 0 && !submittedMajorIds.Contains(m.Id)))
                deletedMajor.IsDeleted = true;
        }

        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Đã lưu thông tin Khoa và các Ngành học thành công!";
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleDelete(int id, bool restore = false)
    {
        var faculty = await _context.Faculties.IgnoreQueryFilters().FirstOrDefaultAsync(f => f.Id == id);
        if (faculty == null) return NotFound();

        faculty.IsDeleted = !restore;
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = restore ? "Đã khôi phục Khoa!" : "Đã đưa Khoa vào Thùng rác!";
        return RedirectToAction(nameof(Index), new { showDeleted = restore });
    }
}
````

### `StudentPortal.Mvc\Controllers\GradesController.cs`

- Size: 4120 bytes
- Lines: 102

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class GradesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public GradesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // 1. Danh sách các lớp (Của riêng giảng viên này hoặc toàn bộ nếu là Admin)
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        bool isAdmin = await _userManager.IsInRoleAsync(user!, "Admin");

        var classesQuery = _context.CourseClasses.Include(c => c.Subject).AsNoTracking();

        if (!isAdmin) // Giảng viên chỉ thấy lớp của mình
        {
            var myClassIds = await _context.ClassProfessors.Where(cp => cp.ProfessorId == user!.Id).Select(cp => cp.CourseClassId).ToListAsync();
            classesQuery = classesQuery.Where(c => myClassIds.Contains(c.Id));
        }

        return View(await classesQuery.ToListAsync());
    }

    // 2. Vào chi tiết 1 Lớp để lấy danh sách sinh viên
    [HttpGet]
    public async Task<IActionResult> ClassGrades(int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        if (!isAdmin)
        {
            var isAssigned = await _context.ClassProfessors.AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == user.Id);
            if (!isAssigned) return RedirectToAction("AccessDenied", "Account");
        }

        var courseClass = await _context.CourseClasses.Include(c => c.Subject).FirstOrDefaultAsync(c => c.Id == classId);
        if (courseClass == null) return NotFound();

        ViewBag.ClassName = courseClass.Subject?.Name;
        ViewBag.Room = courseClass.Room;
        
        var grades = await _context.Grades
            .Include(g => g.Student).ThenInclude(s => s!.User)
            .Where(g => g.CourseClassId == classId)
            .ToListAsync(); // Không dùng AsNoTracking vì ta sẽ dùng List này để map trực tiếp lên View

        return View(grades);
    }

    // 3. Submit Lưu điểm của 1 sinh viên (Dùng AJAX hoặc Submit Form)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateSingleGrade(int gradeId, float? score, string? note, string rowVersion, int classId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        if (!isAdmin)
        {
            var isAssigned = await _context.ClassProfessors.AnyAsync(cp => cp.CourseClassId == classId && cp.ProfessorId == user.Id);
            if (!isAssigned) return RedirectToAction("AccessDenied", "Account");
        }

        var grade = await _context.Grades.FirstOrDefaultAsync(g => g.Id == gradeId);
        if (grade == null) return NotFound();

        grade.Score = score;
        grade.Note = note;
        grade.RowVersion = Guid.NewGuid().ToByteArray(); // SQLite Concurrency
        
        _context.Entry(grade).Property(g => g.RowVersion).OriginalValue = Convert.FromBase64String(rowVersion);

        try {
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Lưu điểm thành công!";
        } catch(DbUpdateConcurrencyException) {
            TempData["ErrorMessage"] = "Lỗi đụng độ: Giảng viên khác vừa sửa điểm này!";
        }

        return RedirectToAction(nameof(ClassGrades), new { classId = classId });
    }
}
````

### `StudentPortal.Mvc\Controllers\HomeController.cs`

- Size: 6230 bytes
- Lines: 148

````csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // 1. Kiểm tra đăng nhập
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            return View("LandingPage");
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return View("LandingPage");

        var roles = await _userManager.GetRolesAsync(user);
        string userRole = roles.FirstOrDefault() ?? "";

        // ========================================================
        // 2. LOGIC LỌC VÀ LẤY THÔNG BÁO CHO USER HIỆN TẠI
        // ========================================================
        int? myFacultyId = null;
        int? myMajorId = null;

        // Lấy Profile để biết user thuộc Khoa/Ngành nào
        if (userRole == "Student") {
            var profile = await _context.StudentProfiles.AsNoTracking().FirstOrDefaultAsync(p => p.UserId == user.Id);
            myFacultyId = profile?.FacultyId;
            myMajorId = profile?.MajorId;
        } else if (userRole == "Professor") {
            var profile = await _context.ProfessorProfiles.AsNoTracking().FirstOrDefaultAsync(p => p.UserId == user.Id);
            myFacultyId = profile?.FacultyId;
            ViewBag.IsFacultyHeadMaster = await _context.Faculties.AnyAsync(f => f.HeadMasterId == user.Id && !f.IsDeleted);
            ViewBag.IsMajorHeadMaster = await _context.Majors.AnyAsync(m => m.HeadMasterId == user.Id && !m.IsDeleted);
        }

        // Lấy danh sách ID thông báo mà User này ĐÃ BẤM ẨN/XÓA
        var dismissedIds = await _context.UserNotifications
            .Where(un => un.UserId == user.Id && un.IsDismissed)
            .Select(un => un.NotificationId)
            .ToListAsync();

        // Mỗi tiêu chí đã chọn đều phải khớp. Null/chuỗi rỗng nghĩa là không lọc theo tiêu chí đó.
        var notifications = await _context.Notifications
            .AsNoTracking()
            .Where(n => !dismissedIds.Contains(n.Id))
            .Where(n =>
                (!string.IsNullOrEmpty(n.TargetUserId) && n.TargetUserId == user.Id) ||
                (string.IsNullOrEmpty(n.TargetUserId) &&
                 (string.IsNullOrEmpty(n.TargetRole) || roles.Contains(n.TargetRole)) &&
                 (n.TargetFacultyId == null || n.TargetFacultyId == myFacultyId) &&
                 (n.TargetMajorId == null || n.TargetMajorId == myMajorId)))
            .OrderByDescending(n => n.CreatedAt)
            .Take(5) // Chỉ lấy 5 thông báo mới nhất
            .ToListAsync();

        ViewBag.Notifications = notifications;

        // ========================================================
        // 3. LOGIC LẤY SỐ LIỆU DASHBOARD THEO ROLE
        // ========================================================
        if (userRole == "Admin")
        {
            ViewBag.TotalStudents = await _userManager.GetUsersInRoleAsync("Student").ContinueWith(t => t.Result.Count);
            ViewBag.TotalProfs = await _userManager.GetUsersInRoleAsync("Professor").ContinueWith(t => t.Result.Count);
            ViewBag.TotalClasses = await _context.CourseClasses.CountAsync(c => !c.IsDeleted);
        }
        else if (userRole == "Student")
        {
            var myGrades = await _context.Grades
                .Include(g => g.CourseClass).ThenInclude(c => c!.Subject)
                .Where(g => g.StudentId == user.Id)
                .AsNoTracking().ToListAsync();
            ViewBag.MyClasses = myGrades;
            
            // Demo tính GPA nhanh cho Dashboard
            var graded = myGrades.Where(g => g.Score.HasValue).ToList();
            double gpa = graded.Any() ? Math.Round(graded.Average(g => g.Score!.Value), 2) : 0;
            ViewBag.GPA = gpa;
        }
        else if (userRole == "Professor")
        {
            var myClasses = await _context.ClassProfessors
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Subject)
                .Where(cp => cp.ProfessorId == user.Id)
                .AsNoTracking().ToListAsync();
            ViewBag.TeachingClasses = myClasses;
        }
        else if (userRole == "Worker")
        {
            var myBonuses = await _context.SalaryBonuses
                .Where(sb => sb.UserId == user.Id)
                .OrderByDescending(sb => sb.CreatedAt)
                .AsNoTracking().ToListAsync();
            ViewBag.MyBonuses = myBonuses;
        }

        return View();
    }

    // ========================================================
    // 4. ACTION XỬ LÝ KHI USER BẤM "TẮT/XÓA" THÔNG BÁO
    // ========================================================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DismissNotification(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        // Đánh dấu đã xóa vào bảng UserNotification
        bool exists = await _context.UserNotifications.AnyAsync(un => un.NotificationId == id && un.UserId == user.Id);
        if (!exists)
        {
            _context.UserNotifications.Add(new UserNotification
            {
                NotificationId = id,
                UserId = user.Id,
                IsDismissed = true
            });
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index)); // Load lại trang chủ
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
````

### `StudentPortal.Mvc\Controllers\MajorsController.cs`

- Size: 3818 bytes
- Lines: 93

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Roles = "Professor")]
public class MajorsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public MajorsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? majorId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var managedMajors = await _context.Majors
            .Include(m => m.Faculty)
            .AsNoTracking()
            .Where(m => m.HeadMasterId == user.Id && !m.IsDeleted)
            .OrderBy(m => m.Name)
            .ToListAsync();

        if (!managedMajors.Any()) return RedirectToAction("AccessDenied", "Account");

        var selectedMajorId = majorId.HasValue && managedMajors.Any(m => m.Id == majorId.Value)
            ? majorId.Value
            : managedMajors.First().Id;

        ViewBag.ManagedMajors = managedMajors;
        ViewData["MajorId"] = selectedMajorId;
        ViewBag.MajorName = managedMajors.First(m => m.Id == selectedMajorId).Name;

        var subjects = await _context.Subjects
            .Include(s => s.CourseClasses).ThenInclude(c => c.Semester)
            .Include(s => s.CourseClasses).ThenInclude(c => c.ClassProfessors).ThenInclude(cp => cp.Professor).ThenInclude(p => p!.User)
            .Include(s => s.CourseClasses).ThenInclude(c => c.Grades).ThenInclude(g => g.Student).ThenInclude(s => s!.User)
            .AsNoTracking()
            .Where(s => s.MajorId == selectedMajorId && !s.IsDeleted)
            .OrderBy(s => s.Name)
            .ToListAsync();

        var rows = new List<MajorManagementRowViewModel>();
        foreach (var subject in subjects)
        {
            var activeClasses = subject.CourseClasses.Where(c => !c.IsDeleted).OrderBy(c => c.Semester?.StartDate).ThenBy(c => c.DayOfWeek).ToList();
            if (!activeClasses.Any())
            {
                rows.Add(new MajorManagementRowViewModel
                {
                    SubjectId = subject.Id,
                    SubjectName = subject.Name,
                    Credits = subject.Credits,
                    ClassCount = 0
                });
                continue;
            }

            foreach (var courseClass in activeClasses)
            {
                rows.Add(new MajorManagementRowViewModel
                {
                    SubjectId = subject.Id,
                    SubjectName = subject.Name,
                    Credits = subject.Credits,
                    ClassCount = activeClasses.Count,
                    ClassId = courseClass.Id,
                    SemesterName = courseClass.Semester?.Name ?? "N/A",
                    Room = courseClass.Room,
                    Schedule = $"Thứ {(int)courseClass.DayOfWeek + 1}, Tiết {courseClass.StartPeriod} - {courseClass.EndPeriod}",
                    ProfessorsText = string.Join(", ", courseClass.ClassProfessors.Select(cp => cp.Professor?.User?.FullName).Where(n => !string.IsNullOrWhiteSpace(n))),
                    StudentCount = courseClass.Grades.Count,
                    StudentsText = string.Join("; ", courseClass.Grades.Select(g => $"{g.Student?.User?.FullName}: {(g.Score.HasValue ? g.Score.Value.ToString("0.0") : "Chưa điểm")}"))
                });
            }
        }

        return View(rows);
    }
}
````

### `StudentPortal.Mvc\Controllers\NotificationsController.cs`

- Size: 2482 bytes
- Lines: 63

````csharp
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
````

### `StudentPortal.Mvc\Controllers\ProfileController.cs`

- Size: 2340 bytes
- Lines: 66

````csharp
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
````

### `StudentPortal.Mvc\Controllers\SalaryBonusesController.cs`

- Size: 5722 bytes
- Lines: 150

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize] // Ai cũng vào được, nhưng sẽ lọc dữ liệu theo Role
public class SalaryBonusesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IAuditLogService _auditLogService;

    public SalaryBonusesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuditLogService auditLogService)
    {
        _context = context;
        _userManager = userManager;
        _auditLogService = auditLogService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? roleFilter, int? facultyId, int? majorId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        var query = _context.SalaryBonuses.Include(s => s.User).AsNoTracking();

        // LOGIC PHÂN QUYỀN: Nếu không phải Admin, chỉ được xem của chính mình!
        if (!isAdmin)
        {
            query = query.Where(s => s.UserId == user.Id);
        }

        ViewBag.Faculties = await _context.Faculties.AsNoTracking().Where(f => !f.IsDeleted).OrderBy(f => f.Name).ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking()
            .Where(m => !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
            .OrderBy(m => m.Name)
            .ToListAsync();
        ViewData["RoleFilter"] = roleFilter;
        ViewData["FacultyId"] = facultyId;
        ViewData["MajorId"] = majorId;

        var bonuses = await query.OrderByDescending(s => s.CreatedAt).ToListAsync();
        var model = new List<SalaryBonusListItemViewModel>();

        foreach (var b in bonuses)
        {
            if (b.User == null) continue;

            var roles = await _userManager.GetRolesAsync(b.User);
            var roleName = roles.FirstOrDefault() ?? "";
            int? userFacultyId = null;
            int? userMajorId = null;
            string facultyName = "";
            string majorName = "";

            if (roleName == "Student")
            {
                var profile = await _context.StudentProfiles
                    .Include(p => p.Faculty)
                    .Include(p => p.Major)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.UserId == b.UserId);
                userFacultyId = profile?.FacultyId;
                userMajorId = profile?.MajorId;
                facultyName = profile?.Faculty?.Name ?? "";
                majorName = profile?.Major?.Name ?? "";
            }
            else if (roleName == "Professor")
            {
                var profile = await _context.ProfessorProfiles
                    .Include(p => p.Faculty)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.UserId == b.UserId);
                userFacultyId = profile?.FacultyId;
                facultyName = profile?.Faculty?.Name ?? "";
            }

            if (!string.IsNullOrWhiteSpace(roleFilter) && roleName != roleFilter) continue;
            if (facultyId.HasValue && userFacultyId != facultyId.Value) continue;
            if (majorId.HasValue && userMajorId != majorId.Value) continue;

            model.Add(new SalaryBonusListItemViewModel
            {
                Id = b.Id,
                FullName = b.User.FullName,
                RoleName = roleName,
                FacultyName = facultyName,
                MajorName = majorName,
                StartDate = b.StartDate,
                EndDate = b.EndDate,
                Amount = b.Amount,
                Note = b.Note,
                CreatedAtText = b.CreatedAt.ToString("dd/MM/yyyy HH:mm")
            });
        }

        ViewBag.IsAdmin = isAdmin;
        return View(model);
    }

    // CHỈ ADMIN MỚI CÓ QUYỀN TẠO LƯƠNG/HỌC BỔNG
    [Authorize(Policy = "RequireAdmin")]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Users = await _context.Users.Where(u => !u.IsDeleted).AsNoTracking().ToListAsync();
        return View(new SalaryBonusCreateViewModel());
    }

    [Authorize(Policy = "RequireAdmin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SalaryBonusCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Users = await _context.Users.Where(u => !u.IsDeleted).AsNoTracking().ToListAsync();
            return View(model);
        }

        var bonus = new SalaryBonus
        {
            UserId = model.UserId,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            Amount = model.Amount,
            Note = model.Note,
            CreatedAt = DateTime.UtcNow
        };

        _context.SalaryBonuses.Add(bonus);
        await _context.SaveChangesAsync();

        // Ghi Audit Log hành vi liên quan đến Tài chính
        await _auditLogService.LogAsync("CreateSalaryBonus", "SalaryBonus", bonus.Id.ToString(), "Success", $"Cấp {model.Amount:N0} cho User {model.UserId}");

        TempData["SuccessMessage"] = "Đã ghi nhận Lương / Học bổng thành công!";
        return RedirectToAction(nameof(Index));
    }
}
````

### `StudentPortal.Mvc\Controllers\SchedulesController.cs`

- Size: 4222 bytes
- Lines: 99

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize]
public class SchedulesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SchedulesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? semesterId)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var isStudent = await _userManager.IsInRoleAsync(user, "Student");
        var isProfessor = await _userManager.IsInRoleAsync(user, "Professor");
        if (!isStudent && !isProfessor) return RedirectToAction("AccessDenied", "Account");

        ViewBag.Semesters = await _context.Semesters
            .AsNoTracking()
            .OrderByDescending(s => s.StartDate)
            .ToListAsync();
        ViewData["SemesterId"] = semesterId;

        List<ScheduleClassViewModel> model;
        if (isStudent)
        {
            var query = _context.Grades
                .Include(g => g.CourseClass).ThenInclude(c => c!.Subject)
                .Include(g => g.CourseClass).ThenInclude(c => c!.Semester)
                .Include(g => g.CourseClass).ThenInclude(c => c!.ClassProfessors).ThenInclude(cp => cp.Professor).ThenInclude(p => p!.User)
                .Where(g => g.StudentId == user.Id && g.CourseClass != null && !g.CourseClass.IsDeleted);

            if (semesterId.HasValue)
                query = query.Where(g => g.CourseClass!.SemesterId == semesterId.Value);

            var grades = await query.AsNoTracking().ToListAsync();
            model = grades.Select(g => new ScheduleClassViewModel
            {
                ClassId = g.CourseClassId,
                SemesterName = g.CourseClass?.Semester?.Name ?? "N/A",
                SubjectName = g.CourseClass?.Subject?.Name ?? "N/A",
                Room = g.CourseClass?.Room ?? "",
                DayOfWeek = g.CourseClass?.DayOfWeek ?? DayOfWeek.Monday,
                StartPeriod = g.CourseClass?.StartPeriod ?? 0,
                EndPeriod = g.CourseClass?.EndPeriod ?? 0,
                PeopleText = string.Join(", ", g.CourseClass?.ClassProfessors.Select(cp => cp.Professor?.User?.FullName).Where(n => !string.IsNullOrWhiteSpace(n)) ?? Enumerable.Empty<string>())
            }).ToList();
        }
        else
        {
            var query = _context.ClassProfessors
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Subject)
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Semester)
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Grades)
                .Where(cp => cp.ProfessorId == user.Id && cp.CourseClass != null && !cp.CourseClass.IsDeleted);

            if (semesterId.HasValue)
                query = query.Where(cp => cp.CourseClass!.SemesterId == semesterId.Value);

            var assignments = await query.AsNoTracking().ToListAsync();
            model = assignments.Select(cp => new ScheduleClassViewModel
            {
                ClassId = cp.CourseClassId,
                SemesterName = cp.CourseClass?.Semester?.Name ?? "N/A",
                SubjectName = cp.CourseClass?.Subject?.Name ?? "N/A",
                Room = cp.CourseClass?.Room ?? "",
                DayOfWeek = cp.CourseClass?.DayOfWeek ?? DayOfWeek.Monday,
                StartPeriod = cp.CourseClass?.StartPeriod ?? 0,
                EndPeriod = cp.CourseClass?.EndPeriod ?? 0,
                PeopleText = $"{cp.CourseClass?.Grades.Count ?? 0} sinh viên"
            }).ToList();
        }

        model = model
            .OrderBy(m => m.DayOfWeek)
            .ThenBy(m => m.StartPeriod)
            .ThenBy(m => m.SubjectName)
            .ToList();

        ViewBag.IsProfessor = isProfessor;
        return View(model);
    }
}
````

### `StudentPortal.Mvc\Controllers\SemestersController.cs`

- Size: 1845 bytes
- Lines: 52

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")] // CHỈ ADMIN
public class SemestersController : Controller
{
    private readonly ApplicationDbContext _context;

    public SemestersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var semesters = await _context.Semesters.AsNoTracking().OrderByDescending(s => s.StartDate).ToListAsync();
        return View(semesters);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(string Name, DateTime StartDate, DateTime EndDate)
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            _context.Semesters.Add(new Semester { Name = Name, StartDate = StartDate, EndDate = EndDate, IsRegistrationOpen = false });
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Đã thêm Học kỳ mới thành công!";
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleRegistration(int id)
    {
        var semester = await _context.Semesters.FindAsync(id);
        if (semester != null)
        {
            semester.IsRegistrationOpen = !semester.IsRegistrationOpen;
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = semester.IsRegistrationOpen ? $"Đã MỞ đăng ký cho {semester.Name}" : $"Đã ĐÓNG đăng ký cho {semester.Name}";
        }
        return RedirectToAction(nameof(Index));
    }
}
````

### `StudentPortal.Mvc\Controllers\SubjectsController.cs`

- Size: 12658 bytes
- Lines: 335

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "CanManageAcademics")]
public class SubjectsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SubjectsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    private IQueryable<Major> GetManageableMajorsQuery(ApplicationUser user, bool isAdmin)
    {
        var query = _context.Majors
            .Include(m => m.Faculty)
            .AsQueryable();

        if (isAdmin) return query;

        return query.Where(m =>
            m.HeadMasterId == user.Id ||
            (m.Faculty != null && m.Faculty.HeadMasterId == user.Id));
    }

    private async Task<bool> CheckCanManageAsync(int majorId, ApplicationUser user, bool isAdmin)
    {
        if (isAdmin) return true;

        return await _context.Majors
            .Include(m => m.Faculty)
            .AsNoTracking()
            .AnyAsync(m =>
                m.Id == majorId &&
                (m.HeadMasterId == user.Id ||
                 (m.Faculty != null && m.Faculty.HeadMasterId == user.Id)));
    }

    private async Task<IQueryable<Subject>> GetVisibleSubjectsQueryAsync(ApplicationUser user, bool isAdmin)
    {
        var query = _context.Subjects
            .Include(s => s.Major).ThenInclude(m => m!.Faculty)
            .AsQueryable();

        if (isAdmin) return query;

        var profProfile = await _context.ProfessorProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.UserId == user.Id);

        if (profProfile == null) return query.Where(s => false);

        return query.Where(s => s.Major != null && s.Major.FacultyId == profProfile.FacultyId);
    }

    private async Task LoadCreateEditListsAsync(ApplicationUser user, bool isAdmin, int? currentSubjectId = null)
    {
        ViewBag.Majors = await GetManageableMajorsQuery(user, isAdmin)
            .AsNoTracking()
            .OrderBy(m => m.Faculty!.Name)
            .ThenBy(m => m.Name)
            .Select(m => new { m.Id, Name = $"{m.Name} ({m.Faculty!.Name})" })
            .ToListAsync();

        var prerequisiteQuery = await GetVisibleSubjectsQueryAsync(user, isAdmin);
        if (currentSubjectId.HasValue)
            prerequisiteQuery = prerequisiteQuery.Where(s => s.Id != currentSubjectId.Value);

        ViewBag.PrerequisiteSubjects = await prerequisiteQuery
            .AsNoTracking()
            .Where(s => !s.IsDeleted)
            .OrderBy(s => s.Major!.Name)
            .ThenBy(s => s.Name)
            .Select(s => new { s.Id, Name = $"{s.Name} ({s.Major!.Name})" })
            .ToListAsync();
    }

    private async Task LoadIndexFiltersAsync(ApplicationUser user, bool isAdmin, int? facultyId, int? majorId)
    {
        if (isAdmin)
        {
            ViewBag.Faculties = await _context.Faculties
                .AsNoTracking()
                .Where(f => !f.IsDeleted)
                .OrderBy(f => f.Name)
                .ToListAsync();
            ViewBag.Majors = await _context.Majors
                .Include(m => m.Faculty)
                .AsNoTracking()
                .Where(m => !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
                .OrderBy(m => m.Faculty!.Name)
                .ThenBy(m => m.Name)
                .ToListAsync();
        }
        else
        {
            var visibleSubjectQuery = await GetVisibleSubjectsQueryAsync(user, isAdmin);
            var facultyIds = await visibleSubjectQuery
                .Where(s => s.Major != null)
                .Select(s => s.Major!.FacultyId)
                .Distinct()
                .ToListAsync();

            ViewBag.Faculties = await _context.Faculties
                .AsNoTracking()
                .Where(f => facultyIds.Contains(f.Id) && !f.IsDeleted)
                .OrderBy(f => f.Name)
                .ToListAsync();
            ViewBag.Majors = await _context.Majors
                .Include(m => m.Faculty)
                .AsNoTracking()
                .Where(m => facultyIds.Contains(m.FacultyId) && !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        ViewData["FacultyId"] = facultyId;
        ViewData["MajorId"] = majorId;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? keyword, int? facultyId, int? majorId, bool showDeleted = false)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        await LoadIndexFiltersAsync(user, isAdmin, facultyId, majorId);

        var query = await GetVisibleSubjectsQueryAsync(user, isAdmin);
        query = query.IgnoreQueryFilters()
            .Include(s => s.Prerequisites).ThenInclude(p => p.RequiredSubject)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(s => s.Name.Contains(keyword));

        if (facultyId.HasValue)
            query = query.Where(s => s.Major != null && s.Major.FacultyId == facultyId.Value);

        if (majorId.HasValue)
            query = query.Where(s => s.MajorId == majorId.Value);

        query = showDeleted ? query.Where(s => s.IsDeleted) : query.Where(s => !s.IsDeleted);

        var subjects = await query
            .OrderBy(s => s.Major!.Faculty!.Name)
            .ThenBy(s => s.Major!.Name)
            .ThenBy(s => s.Name)
            .ToListAsync();

        var model = new List<SubjectListItemViewModel>();
        foreach (var s in subjects)
        {
            model.Add(new SubjectListItemViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Credits = s.Credits,
                MajorName = s.Major?.Name ?? "N/A",
                FacultyName = s.Major?.Faculty?.Name ?? "N/A",
                PrerequisitesText = string.Join(", ", s.Prerequisites.Select(p => p.RequiredSubject?.Name).Where(n => !string.IsNullOrWhiteSpace(n))),
                IsDeleted = s.IsDeleted,
                CanManage = await CheckCanManageAsync(s.MajorId, user, isAdmin)
            });
        }

        ViewData["Keyword"] = keyword;
        ViewData["ShowDeleted"] = showDeleted;
        ViewBag.CanCreateSubject = isAdmin || await GetManageableMajorsQuery(user, isAdmin).AnyAsync();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> CreateEdit(int? id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        await LoadCreateEditListsAsync(user, isAdmin, id);

        if (id == null)
        {
            if (!((IEnumerable<object>)ViewBag.Majors).Any())
            {
                TempData["ErrorMessage"] = "Bạn không có quyền tạo môn học cho ngành nào.";
                return RedirectToAction(nameof(Index));
            }

            return View(new SubjectCreateEditViewModel());
        }

        var subject = await _context.Subjects
            .Include(s => s.Prerequisites)
            .FirstOrDefaultAsync(s => s.Id == id.Value);
        if (subject == null) return NotFound();

        if (!await CheckCanManageAsync(subject.MajorId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        return View(new SubjectCreateEditViewModel
        {
            Id = subject.Id,
            Name = subject.Name,
            Credits = subject.Credits,
            MajorId = subject.MajorId,
            Prerequisites = subject.Prerequisites
                .Select(p => new PrerequisiteInlineViewModel { RequiredSubjectId = p.RequiredSubjectId })
                .ToList()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEdit(SubjectCreateEditViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

        if (!ModelState.IsValid)
        {
            await LoadCreateEditListsAsync(user, isAdmin, model.Id == 0 ? null : model.Id);
            return View(model);
        }

        if (!await CheckCanManageAsync(model.MajorId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            Subject subject;
            if (model.Id == 0)
            {
                subject = new Subject { Name = model.Name, Credits = model.Credits, MajorId = model.MajorId };
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Đã thêm môn học mới!";
            }
            else
            {
                subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Id == model.Id)
                    ?? throw new InvalidOperationException("Không tìm thấy môn học.");

                if (!await CheckCanManageAsync(subject.MajorId, user, isAdmin))
                    return RedirectToAction("AccessDenied", "Account");

                subject.Name = model.Name;
                subject.Credits = model.Credits;
                subject.MajorId = model.MajorId;
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Đã cập nhật môn học!";
            }

            await SyncPrerequisitesAsync(subject.Id, model.Prerequisites);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi: " + (ex.InnerException?.Message ?? ex.Message));
            await LoadCreateEditListsAsync(user, isAdmin, model.Id == 0 ? null : model.Id);
            return View(model);
        }
    }

    private async Task SyncPrerequisitesAsync(int subjectId, List<PrerequisiteInlineViewModel> prerequisites)
    {
        var selectedIds = prerequisites
            .Select(p => p.RequiredSubjectId)
            .Where(id => id > 0 && id != subjectId)
            .Distinct()
            .ToList();

        selectedIds = await _context.Subjects
            .Where(s => selectedIds.Contains(s.Id) && !s.IsDeleted)
            .Select(s => s.Id)
            .ToListAsync();

        var existing = await _context.PrerequisiteSubjects
            .Where(p => p.SubjectId == subjectId)
            .ToListAsync();

        foreach (var prerequisite in existing.Where(p => !selectedIds.Contains(p.RequiredSubjectId)))
            _context.PrerequisiteSubjects.Remove(prerequisite);

        var existingIds = existing.Select(p => p.RequiredSubjectId).ToHashSet();
        foreach (var requiredSubjectId in selectedIds.Where(id => !existingIds.Contains(id)))
        {
            _context.PrerequisiteSubjects.Add(new PrerequisiteSubject
            {
                SubjectId = subjectId,
                RequiredSubjectId = requiredSubjectId
            });
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleDelete(int id, bool restore = false)
    {
        var subject = await _context.Subjects.IgnoreQueryFilters().FirstOrDefaultAsync(s => s.Id == id);
        if (subject == null) return NotFound();

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        if (!await CheckCanManageAsync(subject.MajorId, user, isAdmin))
            return RedirectToAction("AccessDenied", "Account");

        subject.IsDeleted = !restore;
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = restore ? "Đã khôi phục Môn học!" : "Đã đưa Môn học vào thùng rác!";
        return RedirectToAction(nameof(Index), new { showDeleted = restore });
    }
}
````

### `StudentPortal.Mvc\Controllers\TranscriptsController.cs`

- Size: 2027 bytes
- Lines: 57

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Roles = "Student")] // CHỈ SINH VIÊN
public class TranscriptsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TranscriptsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Challenge();

        var profile = await _context.StudentProfiles
            .Include(s => s.Major)
            .FirstOrDefaultAsync(s => s.UserId == user.Id);

        var grades = await _context.Grades
            .Include(g => g.CourseClass).ThenInclude(c => c!.Subject)
            .Include(g => g.CourseClass).ThenInclude(c => c!.Semester)
            .Where(g => g.StudentId == user.Id)
            .AsNoTracking()
            .ToListAsync();

        var viewModel = new TranscriptViewModel
        {
            StudentName = user.FullName,
            StudentId = user.Id,
            MajorName = profile?.Major?.Name ?? "Chưa có chuyên ngành",
            Grades = grades.Select(g => new GradeItemViewModel
            {
                GradeId = g.Id,
                SubjectName = g.CourseClass?.Subject?.Name ?? "N/A",
                Credits = g.CourseClass?.Subject?.Credits ?? 0,
                Score = g.Score,
                Note = g.Note,
                SemesterName = g.CourseClass?.Semester?.Name ?? "N/A"
            }).OrderBy(g => g.SemesterName).ToList()
        };

        return View(viewModel);
    }
}
````

### `StudentPortal.Mvc\Controllers\UsersController.cs`

- Size: 12772 bytes
- Lines: 274

````csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Controllers;

[Authorize(Policy = "RequireAdmin")] // CHỈ ADMIN MỚI ĐƯỢC QUẢN LÝ USER
public class UsersController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly IAuditLogService _auditLogService;

    public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IAuditLogService auditLogService)
    {
        _userManager = userManager;
        _context = context;
        _auditLogService = auditLogService;
    }

    // 1. DANH SÁCH & TÌM KIẾM
    // 1. DANH SÁCH & TÌM KIẾM CÓ BỘ LỌC ROLE
    [HttpGet]
    public async Task<IActionResult> Index(string? keyword, string? roleFilter, bool showDeleted = false)
    {
        var query = _context.Users.IgnoreQueryFilters().AsNoTracking().AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
            query = query.Where(u => u.FullName.Contains(keyword) || u.Email.Contains(keyword));

        if (showDeleted) query = query.Where(u => u.IsDeleted);
        else query = query.Where(u => !u.IsDeleted);

        var users = await query.ToListAsync();
        var model = new List<UserListItemViewModel>();

        foreach (var u in users)
        {
            var roles = await _userManager.GetRolesAsync(u);
            string roleName = roles.FirstOrDefault() ?? "No Role";
            
            // Nếu có chọn lọc theo Role mà Role không khớp thì bỏ qua
            if (!string.IsNullOrEmpty(roleFilter) && roleName != roleFilter) continue;

            string profileInfo = "N/A";
            if (roleName == "Student") {
                var p = await _context.StudentProfiles.Include(x => x.Major).FirstOrDefaultAsync(x => x.UserId == u.Id);
                profileInfo = p?.Major?.Name ?? "Chưa có ngành";
            } else if (roleName == "Professor") {
                var p = await _context.ProfessorProfiles.Include(x => x.Faculty).FirstOrDefaultAsync(x => x.UserId == u.Id);
                profileInfo = p?.Faculty?.Name ?? "Chưa có khoa";
            } else if (roleName == "Worker") {
                var p = await _context.WorkerProfiles.FirstOrDefaultAsync(x => x.UserId == u.Id);
                profileInfo = p?.Department ?? "Chưa có phòng ban";
            }

            model.Add(new UserListItemViewModel {
                Id = u.Id, FullName = u.FullName, Email = u.Email,
                RoleName = roleName, ProfileInfo = profileInfo, IsDeleted = u.IsDeleted
            });
        }

        ViewData["Keyword"] = keyword;
        ViewData["RoleFilter"] = roleFilter;
        ViewData["ShowDeleted"] = showDeleted;
        return View(model);
    }

    // 2. TẠO MỚI USER
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
        return View(new UserCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserCreateViewModel model)
    {
        if (!ModelState.IsValid) return await ReloadCreateView(model);
        
        // FIX: KIỂM TRA TRÙNG PID VÀ EMAIL Ở DATABASE TRƯỚC KHI TẠO
        bool isPidExists = await _context.Users.AnyAsync(u => u.PID == model.PID);
        if (isPidExists) ModelState.AddModelError("PID", "Mã định danh (PID) này đã tồn tại trong hệ thống!");

        bool isEmailExists = await _context.Users.AnyAsync(u => u.Email == model.Email);
        if (isEmailExists) ModelState.AddModelError("Email", "Email này đã được sử dụng!");

        if (!ModelState.IsValid) return await ReloadCreateView(model);

        // 1. NHẬN THÊM THÔNG TIN CÁ NHÂN (PID, Dob, EntryDate)
        var user = new ApplicationUser 
        { 
            UserName = model.Email, 
            Email = model.Email, 
            FullName = model.FullName, 
            PID = model.PID,              // Bổ sung PID
            Dob = model.Dob,              // Bổ sung Ngày sinh
            EntryDate = DateTime.Now,     // Tự động gán ngày gia nhập là hôm nay
            EmailConfirmed = true 
        };
        
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, model.Role);

            if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue)
            {
                _context.StudentProfiles.Add(new StudentProfile { UserId = user.Id, FacultyId = model.FacultyId.Value, MajorId = model.MajorId.Value });
            }
            else if (model.Role == "Professor" && model.FacultyId.HasValue)
            {
                _context.ProfessorProfiles.Add(new ProfessorProfile { UserId = user.Id, FacultyId = model.FacultyId.Value });
            }
            else if (model.Role == "Worker")
            {
                // 2. NHẬN THÊM MÔ TẢ CÔNG VIỆC CHO WORKER THAY VÌ FIX CỨNG
                _context.WorkerProfiles.Add(new WorkerProfile { 
                    UserId = user.Id, 
                    Department = model.Department ?? "N/A", 
                    JobDescription = model.JobDescription ?? "Chưa có mô tả" // Bổ sung JobDescription
                });
            }

            await _context.SaveChangesAsync();
            await _auditLogService.LogAsync("CreateUser", "ApplicationUser", user.Id, "Success", $"Tạo tài khoản {model.Role} cho email: {model.Email}");
            TempData["SuccessMessage"] = $"Đã tạo tài khoản {model.FullName} thành công!";
            return RedirectToAction(nameof(Index));
        }

        foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
        return await ReloadCreateView(model);
    }

    private async Task<IActionResult> ReloadCreateView(UserCreateViewModel model)
    {
        ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
        return View(model);
    }

    // ==========================================
    // CẬP NHẬT THÔNG TIN \& PROFILE TÀI KHOẢN
    // ==========================================
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault() ?? "";

        var model = new UserEditViewModel
        {
            Id = user.Id, Email = user.Email ?? "", FullName = user.FullName, 
            PID = user.PID ?? "", Dob = user.Dob ?? DateTime.Now, Role = role
        };

        // Lấy Profile hiện tại để hiển thị lên Form
        if (role == "Student") {
            var p = await _context.StudentProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            model.FacultyId = p?.FacultyId; model.MajorId = p?.MajorId;
        } else if (role == "Professor") {
            var p = await _context.ProfessorProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            model.FacultyId = p?.FacultyId;
        } else if (role == "Worker") {
            var p = await _context.WorkerProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            model.Department = p?.Department; model.JobDescription = p?.JobDescription;
        }

        ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
        ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, UserEditViewModel model)
    {
        if (id != model.Id) return NotFound();
        
        // KIỂM TRA NGHIỆP VỤ BẢO VỆ TOÀN VẸN DỮ LIỆU
        if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue)
        {
            var major = await _context.Majors.AsNoTracking().FirstOrDefaultAsync(m => m.Id == model.MajorId.Value);
            // Nếu ngành không tồn tại, HOẶC ngành đó không thuộc về Khoa đã chọn -> Báo lỗi!
            if (major == null || major.FacultyId != model.FacultyId.Value)
            {
                ModelState.AddModelError("MajorId", "Lỗi nghiệp vụ: Ngành học này không thuộc Khoa đã chọn!");
            }
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Faculties = await _context.Faculties.AsNoTracking().ToListAsync();
            ViewBag.Majors = await _context.Majors.AsNoTracking().ToListAsync();
            return View(model);
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        user.FullName = model.FullName;
        user.PID = model.PID;
        user.Dob = model.Dob;
        await _userManager.UpdateAsync(user);

        if (model.Role == "Student" && model.FacultyId.HasValue && model.MajorId.HasValue) {
            var p = await _context.StudentProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            if (p != null) { p.FacultyId = model.FacultyId.Value; p.MajorId = model.MajorId.Value; }
            else _context.StudentProfiles.Add(new StudentProfile { UserId = id, FacultyId = model.FacultyId.Value, MajorId = model.MajorId.Value });
        } 
        else if (model.Role == "Professor" && model.FacultyId.HasValue) {
            var p = await _context.ProfessorProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            if (p != null) { p.FacultyId = model.FacultyId.Value; }
            else _context.ProfessorProfiles.Add(new ProfessorProfile { UserId = id, FacultyId = model.FacultyId.Value });
        }
        else if (model.Role == "Worker") {
            var p = await _context.WorkerProfiles.FirstOrDefaultAsync(x => x.UserId == id);
            if (p != null) { p.Department = model.Department ?? "N/A"; p.JobDescription = model.JobDescription ?? ""; }
            else _context.WorkerProfiles.Add(new WorkerProfile { UserId = id, Department = model.Department ?? "N/A", JobDescription = model.JobDescription ?? "" });
        }

        await _context.SaveChangesAsync();
        await _auditLogService.LogAsync("EditUser", "ApplicationUser", user.Id, "Success", $"Cập nhật hồ sơ của: {user.Email}");

        TempData["SuccessMessage"] = "Cập nhật tài khoản thành công!";
        return RedirectToAction(nameof(Index));
    }

    // 3. XÓA MỀM (SOFT DELETE) & KHÓA TÀI KHOẢN
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        user.IsDeleted = true;
        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue); // Khóa không cho đăng nhập
        await _userManager.UpdateAsync(user);

        await _auditLogService.LogAsync("SoftDelete", "ApplicationUser", id, "Success", $"Đã khóa tài khoản: {user.Email}");
        TempData["SuccessMessage"] = "Đã khóa và đưa tài khoản vào thùng rác.";
        return RedirectToAction(nameof(Index));
    }

    // 4. KHÔI PHỤC (RESTORE)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Restore(string id)
    {
        var user = await _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) return NotFound();

        user.IsDeleted = false;
        await _userManager.SetLockoutEndDateAsync(user, null); // Mở khóa đăng nhập
        await _userManager.UpdateAsync(user);

        await _auditLogService.LogAsync("Restore", "ApplicationUser", id, "Success", $"Đã mở khóa tài khoản: {user.Email}");
        TempData["SuccessMessage"] = "Đã khôi phục tài khoản thành công!";
        return RedirectToAction(nameof(Index), new { showDeleted = true });
    }
}
````

### `StudentPortal.Mvc\Data\ApplicationDbContext.cs`

- Size: 4402 bytes
- Lines: 80

````csharp
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<ProfessorProfile> ProfessorProfiles => Set<ProfessorProfile>();
    public DbSet<WorkerProfile> WorkerProfiles => Set<WorkerProfile>();
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Major> Majors => Set<Major>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Semester> Semesters => Set<Semester>();
    public DbSet<CourseClass> CourseClasses => Set<CourseClass>();
    public DbSet<ClassProfessor> ClassProfessors => Set<ClassProfessor>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<PrerequisiteSubject> PrerequisiteSubjects => Set<PrerequisiteSubject>();
    public DbSet<SalaryBonus> SalaryBonuses => Set<SalaryBonus>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<UserNotification> UserNotifications => Set<UserNotification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // 1. Cấu hình Profile 1-1 với ApplicationUser
        builder.Entity<StudentProfile>().HasOne(s => s.User).WithOne(u => u.StudentProfile).HasForeignKey<StudentProfile>(s => s.UserId);
        builder.Entity<ProfessorProfile>().HasOne(p => p.User).WithOne(u => u.ProfessorProfile).HasForeignKey<ProfessorProfile>(p => p.UserId);
        builder.Entity<WorkerProfile>().HasOne(w => w.User).WithOne(u => u.WorkerProfile).HasForeignKey<WorkerProfile>(w => w.UserId);

        // 2. Chống lỗi Cascade Delete (Khóa ngoại vòng lặp) khi Trưởng khoa/Trưởng ngành bị xóa
        builder.Entity<Faculty>().HasOne(f => f.HeadMaster).WithMany().HasForeignKey(f => f.HeadMasterId).OnDelete(DeleteBehavior.SetNull);
        builder.Entity<Major>().HasOne(m => m.HeadMaster).WithMany().HasForeignKey(m => m.HeadMasterId).OnDelete(DeleteBehavior.SetNull);

        // 3. Khóa chính Composite cho các bảng trung gian (M-N)
        builder.Entity<ClassProfessor>().HasKey(cp => new { cp.CourseClassId, cp.ProfessorId });
        builder.Entity<PrerequisiteSubject>().HasKey(ps => new { ps.SubjectId, ps.RequiredSubjectId });
        builder.Entity<UserNotification>().HasKey(un => new { un.NotificationId, un.UserId });

        // Cấu hình bảng Đệ quy (Môn học Tiên quyết)
        builder.Entity<PrerequisiteSubject>()
            .HasOne(ps => ps.Subject)
            .WithMany(s => s.Prerequisites)
            .HasForeignKey(ps => ps.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Entity<PrerequisiteSubject>()
            .HasOne(ps => ps.RequiredSubject)
            .WithMany()
            .HasForeignKey(ps => ps.RequiredSubjectId)
            .OnDelete(DeleteBehavior.Restrict); // Không được phép xóa môn A nếu môn B đang bắt buộc học môn A

        // 4. Đảm bảo 1 Học sinh chỉ có 1 điểm duy nhất cho 1 Lớp
        builder.Entity<Grade>().HasIndex(g => new { g.StudentId, g.CourseClassId }).IsUnique();

        // 5. Cấu hình Concurrency cho SQLite
        builder.Entity<CourseClass>().Property(c => c.RowVersion)
            .IsRequired()
            .IsConcurrencyToken()
            .ValueGeneratedNever();
        builder.Entity<Grade>().Property(g => g.RowVersion)
            .IsRequired()
            .IsConcurrencyToken()
            .ValueGeneratedNever();

        // 6. Global Query Filters (Soft Delete)
        builder.Entity<ApplicationUser>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<Faculty>().HasQueryFilter(f => !f.IsDeleted);
        builder.Entity<Major>().HasQueryFilter(m => !m.IsDeleted);
        builder.Entity<Subject>().HasQueryFilter(s => !s.IsDeleted);
        builder.Entity<CourseClass>().HasQueryFilter(c => !c.IsDeleted);
        builder.Entity<SalaryBonus>().HasQueryFilter(s => !s.IsDeleted);
    }
}
````

### `StudentPortal.Mvc\Data\DbInitializer.cs`

- Size: 5280 bytes
- Lines: 103

````csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Data;

public static class DbInitializer
{
    public static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        await EnsureConcurrencyTokensAsync(context);

        // 1. Tạo các Vai trò (Roles)
        string[] roles = { "Admin", "Professor", "Student", "Worker" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // 2. Tạo Tài khoản mẫu
        await SeedUserAsync(userManager, "admin@portal.com", "Admin@123", "Admin", "Nguyễn Quản Trị");
        await SeedUserAsync(userManager, "prof@portal.com", "Prof@123", "Professor", "PGS.TS. Trần Giảng Viên");
        await SeedUserAsync(userManager, "student@portal.com", "Student@123", "Student", "Lê Học Sinh");
        await SeedUserAsync(userManager, "worker@portal.com", "Worker@123", "Worker", "Phạm Giáo Vụ");

        // 3. Tạo Dữ liệu Cấu trúc đào tạo (Khoa, Ngành, Profile, Môn học, Lớp học)
        if (!context.Faculties.Any())
        {
            var adminUser = await userManager.FindByEmailAsync("admin@portal.com");
            var profUser = await userManager.FindByEmailAsync("prof@portal.com");
            var studentUser = await userManager.FindByEmailAsync("student@portal.com");
            var workerUser = await userManager.FindByEmailAsync("worker@portal.com");

            // Tạo Khoa và Ngành
            var faculty = new Faculty { Name = "Khoa Công nghệ Thông tin", HeadMasterId = profUser?.Id, FoundDate = new DateTime(2000, 1, 1) };
            context.Faculties.Add(faculty);
            await context.SaveChangesAsync();

            var major = new Major { Name = "Kỹ thuật Phần mềm", FacultyId = faculty.Id, HeadMasterId = profUser?.Id };
            context.Majors.Add(major);
            await context.SaveChangesAsync();

            // Tạo Hồ sơ (Profile) cho từng User liên kết với Khoa/Ngành
            if (!context.ProfessorProfiles.Any(p => p.UserId == profUser!.Id))
            {
                context.ProfessorProfiles.Add(new ProfessorProfile { UserId = profUser!.Id, FacultyId = faculty.Id });
                context.StudentProfiles.Add(new StudentProfile { UserId = studentUser!.Id, FacultyId = faculty.Id, MajorId = major.Id });
                context.WorkerProfiles.Add(new WorkerProfile { UserId = workerUser!.Id, Department = "Phòng Đào tạo", JobDescription = "Giáo vụ khoa" });
                await context.SaveChangesAsync();
            }

            // Tạo Môn học & Học kỳ
            var subject = new Subject { Name = "Lập trình Web ASP.NET Core MVC", Credits = 4, MajorId = major.Id };
            context.Subjects.Add(subject);

            var semester = new Semester { Name = "Học kỳ 1 (2026-2027)", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(4), IsRegistrationOpen = true };
            context.Semesters.Add(semester);
            await context.SaveChangesAsync();

            // Tạo Lớp học
            var courseClass = new CourseClass { 
                SubjectId = subject.Id, 
                SemesterId = semester.Id, 
                Room = "A1-101", 
                Capacity = 50, 
                DayOfWeek = DayOfWeek.Monday, 
                StartPeriod = 1, 
                EndPeriod = 3,
                RowVersion = Guid.NewGuid().ToByteArray()
            };
            context.CourseClasses.Add(courseClass);
            await context.SaveChangesAsync();

            // QUAN TRỌNG: Phân công Giảng viên dạy Lớp này
            context.ClassProfessors.Add(new ClassProfessor { CourseClassId = courseClass.Id, ProfessorId = profUser!.Id });
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string email, string password, string role, string fullName)
    {
        if (await userManager.FindByEmailAsync(email) == null)
        {
            var user = new ApplicationUser { UserName = email, Email = email, EmailConfirmed = true, FullName = fullName };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
    }

    private static async Task EnsureConcurrencyTokensAsync(ApplicationDbContext context)
    {
        await context.Database.ExecuteSqlRawAsync(
            "UPDATE CourseClasses SET RowVersion = randomblob(16) WHERE RowVersion IS NULL OR length(RowVersion) = 0");
        await context.Database.ExecuteSqlRawAsync(
            "UPDATE Grades SET RowVersion = randomblob(16) WHERE RowVersion IS NULL OR length(RowVersion) = 0");
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613070555_InitialCreateLab06.cs`

- Size: 19455 bytes
- Lines: 416

````csharp
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateLab06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Dob = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AvatarUrl = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    EntityName = table.Column<string>(type: "TEXT", nullable: false),
                    EntityId = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Result = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    HeadMasterId = table.Column<string>(type: "TEXT", nullable: true),
                    FoundDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_AspNetUsers_HeadMasterId",
                        column: x => x.HeadMasterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Majors_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    MajorId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Room = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrolledCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseClasses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false),
                    CourseClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<float>(type: "REAL", nullable: true),
                    Note = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_CourseClasses_CourseClassId",
                        column: x => x.CourseClassId,
                        principalTable: "CourseClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseClasses_SubjectId",
                table: "CourseClasses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_HeadMasterId",
                table: "Faculties",
                column: "HeadMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseClassId",
                table: "Grades",
                column: "CourseClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Majors_FacultyId",
                table: "Majors",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_MajorId",
                table: "Subjects",
                column: "MajorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CourseClasses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613070555_InitialCreateLab06.Designer.cs`

- Size: 19891 bytes
- Lines: 557

````csharp
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Mvc.Data;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20260613070555_InitialCreateLab06")]
    partial class InitialCreateLab06
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EnrolledCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<float?>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId");

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("Grades")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany("Subjects")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Navigation("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613081804_AddSalaryBonusTable.cs`

- Size: 18884 bytes
- Lines: 464

````csharp
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaryBonusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_AspNetUsers_HeadMasterId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_AspNetUsers_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_CourseClasses_CourseClassId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CourseClasses");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundDate",
                table: "Majors",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HeadMasterId",
                table: "Majors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "CourseClasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndPeriod",
                table: "CourseClasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "CourseClasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartPeriod",
                table: "CourseClasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PrerequisiteSubjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredSubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrerequisiteSubjects", x => new { x.SubjectId, x.RequiredSubjectId });
                    table.ForeignKey(
                        name: "FK_PrerequisiteSubjects_Subjects_RequiredSubjectId",
                        column: x => x.RequiredSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrerequisiteSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorProfiles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ProfessorProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorProfiles_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryBonuses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRegistrationOpen = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false),
                    MajorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerProfiles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    JobDescription = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_WorkerProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassProfessors",
                columns: table => new
                {
                    CourseClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessorId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassProfessors", x => new { x.CourseClassId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_ClassProfessors_CourseClasses_CourseClassId",
                        column: x => x.CourseClassId,
                        principalTable: "CourseClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassProfessors_ProfessorProfiles_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "ProfessorProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Majors_HeadMasterId",
                table: "Majors",
                column: "HeadMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId_CourseClassId",
                table: "Grades",
                columns: new[] { "StudentId", "CourseClassId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseClasses_SemesterId",
                table: "CourseClasses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassProfessors_ProfessorId",
                table: "ClassProfessors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrerequisiteSubjects_RequiredSubjectId",
                table: "PrerequisiteSubjects",
                column: "RequiredSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorProfiles_FacultyId",
                table: "ProfessorProfiles",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryBonuses_UserId",
                table: "SalaryBonuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_FacultyId",
                table: "StudentProfiles",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_MajorId",
                table: "StudentProfiles",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseClasses_Semesters_SemesterId",
                table: "CourseClasses",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_ProfessorProfiles_HeadMasterId",
                table: "Faculties",
                column: "HeadMasterId",
                principalTable: "ProfessorProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_CourseClasses_CourseClassId",
                table: "Grades",
                column: "CourseClassId",
                principalTable: "CourseClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_StudentProfiles_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "StudentProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Majors_ProfessorProfiles_HeadMasterId",
                table: "Majors",
                column: "HeadMasterId",
                principalTable: "ProfessorProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseClasses_Semesters_SemesterId",
                table: "CourseClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_ProfessorProfiles_HeadMasterId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_CourseClasses_CourseClassId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentProfiles_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Majors_ProfessorProfiles_HeadMasterId",
                table: "Majors");

            migrationBuilder.DropTable(
                name: "ClassProfessors");

            migrationBuilder.DropTable(
                name: "PrerequisiteSubjects");

            migrationBuilder.DropTable(
                name: "SalaryBonuses");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "StudentProfiles");

            migrationBuilder.DropTable(
                name: "WorkerProfiles");

            migrationBuilder.DropTable(
                name: "ProfessorProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Majors_HeadMasterId",
                table: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId_CourseClassId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_CourseClasses_SemesterId",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "FoundDate",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "HeadMasterId",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "EndPeriod",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "StartPeriod",
                table: "CourseClasses");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Grades",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "CourseClasses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CourseClasses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_AspNetUsers_HeadMasterId",
                table: "Faculties",
                column: "HeadMasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_AspNetUsers_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_CourseClasses_CourseClassId",
                table: "Grades",
                column: "CourseClassId",
                principalTable: "CourseClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613081804_AddSalaryBonusTable.Designer.cs`

- Size: 31589 bytes
- Lines: 873

````csharp
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Mvc.Data;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20260613081804_AddSalaryBonusTable")]
    partial class AddSalaryBonusTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseClassId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ClassProfessors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnrolledCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<float?>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseClassId");

                    b.HasIndex("StudentId", "CourseClassId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectId", "RequiredSubjectId");

                    b.HasIndex("RequiredSubjectId");

                    b.ToTable("PrerequisiteSubjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.ToTable("ProfessorProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SalaryBonuses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRegistrationOpen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MajorId");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("WorkerProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("ClassProfessors")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "Professor")
                        .WithMany("TeachingClasses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Semester", "Semester")
                        .WithMany("CourseClasses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("Grades")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.StudentProfile", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Faculty");

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Subject", "RequiredSubject")
                        .WithMany()
                        .HasForeignKey("RequiredSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany("Prerequisites")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequiredSubject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("ProfessorProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.ProfessorProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("StudentProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.StudentProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Major");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany("Subjects")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("WorkerProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.WorkerProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("ProfessorProfile");

                    b.Navigation("StudentProfile");

                    b.Navigation("WorkerProfile");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Navigation("ClassProfessors");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Navigation("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Navigation("TeachingClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Navigation("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Navigation("Prerequisites");
                });
#pragma warning restore 612, 618
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613082008_InitialStudentPortalDB.cs`

- Size: 470 bytes
- Lines: 23

````csharp
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialStudentPortalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613082008_InitialStudentPortalDB.Designer.cs`

- Size: 31595 bytes
- Lines: 873

````csharp
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Mvc.Data;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20260613082008_InitialStudentPortalDB")]
    partial class InitialStudentPortalDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseClassId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ClassProfessors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnrolledCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<float?>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseClassId");

                    b.HasIndex("StudentId", "CourseClassId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectId", "RequiredSubjectId");

                    b.HasIndex("RequiredSubjectId");

                    b.ToTable("PrerequisiteSubjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.ToTable("ProfessorProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SalaryBonuses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRegistrationOpen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MajorId");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("WorkerProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("ClassProfessors")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "Professor")
                        .WithMany("TeachingClasses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Semester", "Semester")
                        .WithMany("CourseClasses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("Grades")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.StudentProfile", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Faculty");

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Subject", "RequiredSubject")
                        .WithMany()
                        .HasForeignKey("RequiredSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany("Prerequisites")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequiredSubject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("ProfessorProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.ProfessorProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("StudentProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.StudentProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Major");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany("Subjects")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("WorkerProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.WorkerProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("ProfessorProfile");

                    b.Navigation("StudentProfile");

                    b.Navigation("WorkerProfile");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Navigation("ClassProfessors");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Navigation("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Navigation("TeachingClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Navigation("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Navigation("Prerequisites");
                });
#pragma warning restore 612, 618
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613121412_AddNotificationTable.cs`

- Size: 1640 bytes
- Lines: 42

````csharp
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TargetRole = table.Column<string>(type: "TEXT", nullable: true),
                    TargetFacultyId = table.Column<int>(type: "INTEGER", nullable: true),
                    TargetMajorId = table.Column<int>(type: "INTEGER", nullable: true),
                    TargetUserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613121412_AddNotificationTable.Designer.cs`

- Size: 32807 bytes
- Lines: 908

````csharp
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Mvc.Data;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20260613121412_AddNotificationTable")]
    partial class AddNotificationTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseClassId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ClassProfessors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnrolledCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<float?>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseClassId");

                    b.HasIndex("StudentId", "CourseClassId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TargetFacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TargetMajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TargetRole")
                        .HasColumnType("TEXT");

                    b.Property<string>("TargetUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectId", "RequiredSubjectId");

                    b.HasIndex("RequiredSubjectId");

                    b.ToTable("PrerequisiteSubjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.ToTable("ProfessorProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SalaryBonuses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRegistrationOpen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MajorId");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("WorkerProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("ClassProfessors")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "Professor")
                        .WithMany("TeachingClasses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Semester", "Semester")
                        .WithMany("CourseClasses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("Grades")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.StudentProfile", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Faculty");

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Subject", "RequiredSubject")
                        .WithMany()
                        .HasForeignKey("RequiredSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany("Prerequisites")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequiredSubject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("ProfessorProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.ProfessorProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("StudentProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.StudentProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Major");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany("Subjects")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("WorkerProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.WorkerProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("ProfessorProfile");

                    b.Navigation("StudentProfile");

                    b.Navigation("WorkerProfile");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Navigation("ClassProfessors");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Navigation("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Navigation("TeachingClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Navigation("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Navigation("Prerequisites");
                });
#pragma warning restore 612, 618
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613123454_AddPIDToUser.cs`

- Size: 783 bytes
- Lines: 30

````csharp
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddPIDToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PID",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PID",
                table: "AspNetUsers");
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260613123454_AddPIDToUser.Designer.cs`

- Size: 32932 bytes
- Lines: 912

````csharp
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Mvc.Data;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20260613123454_AddPIDToUser")]
    partial class AddPIDToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PID")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseClassId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ClassProfessors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnrolledCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<float?>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseClassId");

                    b.HasIndex("StudentId", "CourseClassId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TargetFacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TargetMajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TargetRole")
                        .HasColumnType("TEXT");

                    b.Property<string>("TargetUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectId", "RequiredSubjectId");

                    b.HasIndex("RequiredSubjectId");

                    b.ToTable("PrerequisiteSubjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.ToTable("ProfessorProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SalaryBonuses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRegistrationOpen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MajorId");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("WorkerProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("ClassProfessors")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "Professor")
                        .WithMany("TeachingClasses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Semester", "Semester")
                        .WithMany("CourseClasses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("Grades")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.StudentProfile", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Faculty");

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Subject", "RequiredSubject")
                        .WithMany()
                        .HasForeignKey("RequiredSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany("Prerequisites")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequiredSubject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("ProfessorProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.ProfessorProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("StudentProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.StudentProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Major");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany("Subjects")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("WorkerProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.WorkerProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("ProfessorProfile");

                    b.Navigation("StudentProfile");

                    b.Navigation("WorkerProfile");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Navigation("ClassProfessors");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Navigation("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Navigation("TeachingClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Navigation("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Navigation("Prerequisites");
                });
#pragma warning restore 612, 618
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260614061719_AddUserNotification.cs`

- Size: 2015 bytes
- Lines: 52

````csharp
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    IsDismissed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => new { x.NotificationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserNotifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_UserId",
                table: "UserNotifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotifications");
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\20260614061719_AddUserNotification.Designer.cs`

- Size: 34321 bytes
- Lines: 949

````csharp
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Mvc.Data;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20260614061719_AddUserNotification")]
    partial class AddUserNotification
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PID")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseClassId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ClassProfessors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnrolledCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<float?>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseClassId");

                    b.HasIndex("StudentId", "CourseClassId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TargetFacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TargetMajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TargetRole")
                        .HasColumnType("TEXT");

                    b.Property<string>("TargetUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectId", "RequiredSubjectId");

                    b.HasIndex("RequiredSubjectId");

                    b.ToTable("PrerequisiteSubjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.ToTable("ProfessorProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SalaryBonuses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRegistrationOpen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MajorId");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.UserNotification", b =>
                {
                    b.Property<int>("NotificationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDismissed")
                        .HasColumnType("INTEGER");

                    b.HasKey("NotificationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("WorkerProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("ClassProfessors")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "Professor")
                        .WithMany("TeachingClasses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Semester", "Semester")
                        .WithMany("CourseClasses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("Grades")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.StudentProfile", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Faculty");

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Subject", "RequiredSubject")
                        .WithMany()
                        .HasForeignKey("RequiredSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany("Prerequisites")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequiredSubject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("ProfessorProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.ProfessorProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("StudentProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.StudentProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Major");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany("Subjects")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.UserNotification", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("WorkerProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.WorkerProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("ProfessorProfile");

                    b.Navigation("StudentProfile");

                    b.Navigation("WorkerProfile");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Navigation("ClassProfessors");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Navigation("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Navigation("TeachingClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Navigation("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Navigation("Prerequisites");
                });
#pragma warning restore 612, 618
        }
    }
}
````

### `StudentPortal.Mvc\Migrations\ApplicationDbContextModelSnapshot.cs`

- Size: 34213 bytes
- Lines: 946

````csharp
// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Mvc.Data;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PID")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfessorId")
                        .HasColumnType("TEXT");

                    b.HasKey("CourseClassId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ClassProfessors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EnrolledCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<int>("SemesterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartPeriod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("BLOB");

                    b.Property<float?>("Score")
                        .HasColumnType("REAL");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseClassId");

                    b.HasIndex("StudentId", "CourseClassId")
                        .IsUnique();

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FoundDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeadMasterId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("HeadMasterId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TargetFacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TargetMajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TargetRole")
                        .HasColumnType("TEXT");

                    b.Property<string>("TargetUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequiredSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubjectId", "RequiredSubjectId");

                    b.HasIndex("RequiredSubjectId");

                    b.ToTable("PrerequisiteSubjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.ToTable("ProfessorProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SalaryBonuses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRegistrationOpen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("MajorId");

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MajorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MajorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.UserNotification", b =>
                {
                    b.Property<int>("NotificationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDismissed")
                        .HasColumnType("INTEGER");

                    b.HasKey("NotificationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserNotifications");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("WorkerProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ClassProfessor", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("ClassProfessors")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "Professor")
                        .WithMany("TeachingClasses")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Semester", "Semester")
                        .WithMany("CourseClasses")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Grade", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.CourseClass", "CourseClass")
                        .WithMany("Grades")
                        .HasForeignKey("CourseClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.StudentProfile", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseClass");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany("Majors")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ProfessorProfile", "HeadMaster")
                        .WithMany()
                        .HasForeignKey("HeadMasterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Faculty");

                    b.Navigation("HeadMaster");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.PrerequisiteSubject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Subject", "RequiredSubject")
                        .WithMany()
                        .HasForeignKey("RequiredSubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Subject", "Subject")
                        .WithMany("Prerequisites")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequiredSubject");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("ProfessorProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.ProfessorProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.SalaryBonus", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("StudentProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.StudentProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Major");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Major", "Major")
                        .WithMany("Subjects")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Major");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.UserNotification", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.WorkerProfile", b =>
                {
                    b.HasOne("StudentPortal.Mvc.Models.ApplicationUser", "User")
                        .WithOne("WorkerProfile")
                        .HasForeignKey("StudentPortal.Mvc.Models.WorkerProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("ProfessorProfile");

                    b.Navigation("StudentProfile");

                    b.Navigation("WorkerProfile");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.CourseClass", b =>
                {
                    b.Navigation("ClassProfessors");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Faculty", b =>
                {
                    b.Navigation("Majors");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Major", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.ProfessorProfile", b =>
                {
                    b.Navigation("TeachingClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Semester", b =>
                {
                    b.Navigation("CourseClasses");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.StudentProfile", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StudentPortal.Mvc.Models.Subject", b =>
                {
                    b.Navigation("Prerequisites");
                });
#pragma warning restore 612, 618
        }
    }
}
````

### `StudentPortal.Mvc\Models\ApplicationUser.cs`

- Size: 792 bytes
- Lines: 23

````csharp
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class ApplicationUser : IdentityUser
{
    [Required, MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? PID { get; set; } 

    public DateTime? Dob { get; set; }
    [MaxLength(255)]
    public string? AvatarUrl { get; set; } 
    public DateTime EntryDate { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; }

    // Navigation Properties (1 User chỉ có thể là 1 trong 3 Profile này)
    public StudentProfile? StudentProfile { get; set; }
    public ProfessorProfile? ProfessorProfile { get; set; }
    public WorkerProfile? WorkerProfile { get; set; }
}
````

### `StudentPortal.Mvc\Models\AuditLog.cs`

- Size: 599 bytes
- Lines: 16

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class AuditLog
{
    public int Id { get; set; }
    public string Action { get; set; } = string.Empty; // VD: Login, UpdateGrade, DeleteClass
    public string EntityName { get; set; } = string.Empty;
    public string? EntityId { get; set; }
    public string? UserName { get; set; } // Ai làm
    public string? IpAddress { get; set; }
    public string Result { get; set; } = "Success";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? Note { get; set; }
}
````

### `StudentPortal.Mvc\Models\ClassProfessor.cs`

- Size: 282 bytes
- Lines: 9

````csharp
namespace StudentPortal.Mvc.Models;
public class ClassProfessor
{
    public int CourseClassId { get; set; }
    public CourseClass? CourseClass { get; set; }

    public string ProfessorId { get; set; } = string.Empty;
    public ProfessorProfile? Professor { get; set; }
}
````

### `StudentPortal.Mvc\Models\CourseClass.cs`

- Size: 1143 bytes
- Lines: 31

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class CourseClass
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public int SemesterId { get; set; }
    public Semester? Semester { get; set; }

    [Required, MaxLength(50)]
    public string Room { get; set; } = string.Empty;

    // Quản lý lịch học thực tế để check trùng (Ví dụ: DayOfWeek = 2 (Thứ 2), StartPeriod = 1, EndPeriod = 3)
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; } // Tiết bắt đầu (1-12)
    public int EndPeriod { get; set; } // Tiết kết thúc (1-12)

    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = Array.Empty<byte>(); // Chống đụng độ khi Đăng ký môn

    public ICollection<ClassProfessor> ClassProfessors { get; set; } = new List<ClassProfessor>();
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
````

### `StudentPortal.Mvc\Models\ErrorViewModel.cs`

- Size: 188 bytes
- Lines: 9

````csharp
namespace StudentPortal.Mvc.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
````

### `StudentPortal.Mvc\Models\Faculty.cs`

- Size: 553 bytes
- Lines: 18

````csharp
using System.ComponentModel.DataAnnotations;
namespace StudentPortal.Mvc.Models;

public class Faculty
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateTime FoundDate { get; set; }
    public bool IsDeleted { get; set; }

    // Trưởng khoa (FK trỏ về ProfessorProfile)
    public string? HeadMasterId { get; set; }
    public ProfessorProfile? HeadMaster { get; set; }

    public ICollection<Major> Majors { get; set; } = new List<Major>();
}
````

### `StudentPortal.Mvc\Models\Grade.cs`

- Size: 650 bytes
- Lines: 21

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class Grade
{
    public int Id { get; set; }
    
    public string StudentId { get; set; } = string.Empty;
    public StudentProfile? Student { get; set; }

    public int CourseClassId { get; set; }
    public CourseClass? CourseClass { get; set; }

    public float? Score { get; set; } // Lúc đăng ký môn thì Score = null. Có điểm mới nhập.
    [MaxLength(255)]
    public string? Note { get; set; }

    public byte[] RowVersion { get; set; } = Array.Empty<byte>(); // Chống 2 giảng viên cùng sửa điểm 1 lúc
}
````

### `StudentPortal.Mvc\Models\Major.cs`

- Size: 609 bytes
- Lines: 20

````csharp
using System.ComponentModel.DataAnnotations;
namespace StudentPortal.Mvc.Models;

public class Major
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateTime FoundDate { get; set; }
    public bool IsDeleted { get; set; }

    public int FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    // Trưởng ngành
    public string? HeadMasterId { get; set; }
    public ProfessorProfile? HeadMaster { get; set; }

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
````

### `StudentPortal.Mvc\Models\Notification.cs`

- Size: 882 bytes
- Lines: 23

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class Notification
{
    public int Id { get; set; }
    
    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Content { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // --- CÁC TIÊU CHÍ GỬI THÔNG BÁO (Tất cả đều cho phép Null) ---
    // Nếu tất cả là Null -> Thông báo chung toàn trường
    public string? TargetRole { get; set; } // Gửi cho: Student, Professor, Worker...
    public int? TargetFacultyId { get; set; } // Gửi cho 1 Khoa cụ thể
    public int? TargetMajorId { get; set; } // Gửi cho 1 Ngành cụ thể
    public string? TargetUserId { get; set; } // Gửi đích danh 1 người (Theo Id)
}
````

### `StudentPortal.Mvc\Models\PrerequisiteSubject.cs`

- Size: 259 bytes
- Lines: 9

````csharp
namespace StudentPortal.Mvc.Models;
public class PrerequisiteSubject
{
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public int RequiredSubjectId { get; set; }
    public Subject? RequiredSubject { get; set; }
}
````

### `StudentPortal.Mvc\Models\ProfessorProfile.cs`

- Size: 483 bytes
- Lines: 16

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class ProfessorProfile
{
    [Key]
    public string UserId { get; set; } = string.Empty; 
    public ApplicationUser? User { get; set; }

    public int FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    // Một giảng viên có thể dạy nhiều lớp
    public ICollection<ClassProfessor> TeachingClasses { get; set; } = new List<ClassProfessor>();
}
````

### `StudentPortal.Mvc\Models\SalaryBonus.cs`

- Size: 1015 bytes
- Lines: 29

````csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Mvc.Models;

public class SalaryBonus
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty; // FK trỏ về ApplicationUser (PID trong Master Plan)
    public ApplicationUser? User { get; set; }

    // Khoảng thời gian tính lương / học bổng
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Kiểu decimal bắt buộc dùng cho tiền bạc
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [MaxLength(500)]
    public string Note { get; set; } = string.Empty; // Ghi chú: Học bổng kỳ 1, Lương tháng 6, Thưởng KPI...

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Không được phép xóa cứng dữ liệu tài chính, chỉ Xóa mềm
    public bool IsDeleted { get; set; } 
}
````

### `StudentPortal.Mvc\Models\Semester.cs`

- Size: 583 bytes
- Lines: 17

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class Semester
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty; // VD: Học kỳ 1 (2026-2027)
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    // Quyền lực của Admin: Bật/Tắt đợt đăng ký môn học
    public bool IsRegistrationOpen { get; set; } 
    
    public ICollection<CourseClass> CourseClasses { get; set; } = new List<CourseClass>();
}
````

### `StudentPortal.Mvc\Models\StudentProfile.cs`

- Size: 533 bytes
- Lines: 18

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class StudentProfile
{
    [Key]
    public string UserId { get; set; } = string.Empty; // PK kiêm luôn FK liên kết 1-1 với ApplicationUser
    public ApplicationUser? User { get; set; }

    public int FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    public int MajorId { get; set; }
    public Major? Major { get; set; }

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
````

### `StudentPortal.Mvc\Models\Subject.cs`

- Size: 679 bytes
- Lines: 19

````csharp
using System.ComponentModel.DataAnnotations;
namespace StudentPortal.Mvc.Models;

public class Subject
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; } // Số tín chỉ

    public int MajorId { get; set; }
    public Major? Major { get; set; }
    public bool IsDeleted { get; set; }

    // Danh sách các môn yêu cầu phải học trước môn này
    public ICollection<PrerequisiteSubject> Prerequisites { get; set; } = new List<PrerequisiteSubject>();
    public ICollection<CourseClass> CourseClasses { get; set; } = new List<CourseClass>();
}
````

### `StudentPortal.Mvc\Models\UserNotification.cs`

- Size: 375 bytes
- Lines: 11

````csharp
namespace StudentPortal.Mvc.Models;
public class UserNotification
{
    public int NotificationId { get; set; }
    public Notification? Notification { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public bool IsDismissed { get; set; } // Đánh dấu User đã bấm xóa thông báo này
}
````

### `StudentPortal.Mvc\Models\WorkerProfile.cs`

- Size: 449 bytes
- Lines: 16

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class WorkerProfile
{
    [Key]
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    [MaxLength(100)]
    public string Department { get; set; } = string.Empty; // Phòng ban
    
    [MaxLength(255)]
    public string JobDescription { get; set; } = string.Empty; // Mô tả công việc
}
````

### `StudentPortal.Mvc\Program.cs`

- Size: 5005 bytes
- Lines: 131

````csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "App_Data", "DataProtectionKeys")));

// 1. Cấu hình Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning)));

// 2. Cấu hình Identity (Authentication)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// 3. Cấu hình Cookie (Đường dẫn khi bị chặn quyền hoặc chưa đăng nhập)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// 4. Cấu hình Phân quyền (Authorization Policies) theo đúng Master Plan
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", p => p.RequireRole("Admin"));
    options.AddPolicy("CanManageAcademics", p => p.RequireRole("Admin", "Professor")); // Nhập điểm
    options.AddPolicy("CanEnrollClasses", p => p.RequireRole("Student")); // Đăng ký lớp
    options.AddPolicy("CanViewDashboard", p => p.RequireRole("Admin", "Professor", "Student", "Worker"));
});

// Đăng ký HttpContextAccessor để AuditLog lấy được thông tin User đăng nhập
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();

builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy("Student Portal is running."), tags: new[] { "live" })
    .AddDbContextCheck<ApplicationDbContext>("database", tags: new[] { "ready" });

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
    };
});

builder.Services.AddControllersWithViews();

var app = builder.Build();


// 5. Seed Data (Tự động tạo tài khoản khi chạy app lần đầu)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // Có thể tự động apply migration ở đây, nhưng chúng ta sẽ gõ tay cho an toàn
        await DbInitializer.SeedDataAsync(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Lỗi khi khởi tạo dữ liệu mẫu.");
    }
}

// 6. Cấu hình Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapStaticAssets();
app.UseRouting();

// THỨ TỰ BẮT BUỘC: Authentication phải đứng TRƯỚC Authorization
app.UseAuthentication(); 
app.UseAuthorization();

app.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = check => check.Tags.Contains("live") });
app.MapHealthChecks("/health/ready", new HealthCheckOptions {
    Predicate = check => check.Tags.Contains("ready"),
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var result = JsonSerializer.Serialize(new {
            status = report.Status.ToString(),
            checks = report.Entries.Select(e => new { name = e.Key, status = e.Value.Status.ToString() }),
            description = "Health check for Student Portal"
        });
        await context.Response.WriteAsync(result);
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();

app.Run();
````

### `StudentPortal.Mvc\Properties\launchSettings.json`

- Size: 642 bytes
- Lines: 24

````json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5059",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7062;http://localhost:5059",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
````

### `StudentPortal.Mvc\Services\AuditLogService.cs`

- Size: 1158 bytes
- Lines: 34

````csharp
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Services;

public class AuditLogService : IAuditLogService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuditLogService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task LogAsync(string action, string entityName, string? entityId, string result, string? note = null)
    {
        var log = new AuditLog
        {
            Action = action,
            EntityName = entityName,
            EntityId = entityId,
            UserName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Anonymous",
            IpAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown",
            Result = result,
            Note = note,
            CreatedAt = DateTime.UtcNow
        };

        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();
    }
}
````

### `StudentPortal.Mvc\Services\EnrollmentService.cs`

- Size: 8825 bytes
- Lines: 205

````csharp
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly ApplicationDbContext _context;
    private readonly IAuditLogService _auditLogService;

    public EnrollmentService(ApplicationDbContext context, IAuditLogService auditLogService)
    {
        _context = context;
        _auditLogService = auditLogService;
    }

    public async Task<List<EnrollmentClassViewModel>> GetAvailableClassesAsync(string studentId)
    {
        var studentProfile = await _context.StudentProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.UserId == studentId);
        if (studentProfile == null) return new List<EnrollmentClassViewModel>();

        var openSemester = await _context.Semesters
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.IsRegistrationOpen);
        if (openSemester == null) return new List<EnrollmentClassViewModel>();

        var classes = await _context.CourseClasses
            .Include(c => c.Subject)
            .Where(c =>
                c.SemesterId == openSemester.Id &&
                !c.IsDeleted &&
                c.Subject != null &&
                c.Subject.MajorId == studentProfile.MajorId)
            .AsNoTracking()
            .OrderBy(c => c.Subject!.Name)
            .ThenBy(c => c.DayOfWeek)
            .ThenBy(c => c.StartPeriod)
            .ToListAsync();

        var enrolledClassIds = await _context.Grades
            .Where(g => g.StudentId == studentId)
            .Select(g => g.CourseClassId)
            .ToListAsync();

        return classes.Select(c => new EnrollmentClassViewModel
        {
            ClassId = c.Id,
            SubjectName = c.Subject?.Name ?? "N/A",
            Credits = c.Subject?.Credits ?? 0,
            Room = c.Room,
            DayOfWeek = c.DayOfWeek,
            StartPeriod = c.StartPeriod,
            EndPeriod = c.EndPeriod,
            Capacity = c.Capacity,
            EnrolledCount = c.EnrolledCount,
            RowVersion = Convert.ToBase64String(c.RowVersion),
            IsEnrolled = enrolledClassIds.Contains(c.Id)
        }).ToList();
    }

    public async Task<bool> EnrollClassAsync(string studentId, int classId, string rowVersion)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var studentProfile = await _context.StudentProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.UserId == studentId);
            if (studentProfile == null) throw new Exception("Không tìm thấy hồ sơ sinh viên.");

            var courseClass = await _context.CourseClasses
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(c => c.Id == classId);
            if (courseClass == null || courseClass.IsDeleted)
                throw new Exception("Lớp học không tồn tại hoặc đã bị hủy.");

            var openSemester = await _context.Semesters
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == courseClass.SemesterId && s.IsRegistrationOpen);
            if (openSemester == null)
                throw new Exception("Lớp học này không thuộc học kỳ đang mở đăng ký.");

            if (courseClass.Subject?.MajorId != studentProfile.MajorId)
                throw new Exception("Bạn chỉ được đăng ký lớp học thuộc ngành của mình.");

            bool alreadyEnrolled = await _context.Grades
                .AnyAsync(g => g.StudentId == studentId && g.CourseClassId == classId);
            if (alreadyEnrolled)
                throw new Exception("Bạn đã đăng ký lớp học này rồi.");

            if (courseClass.EnrolledCount >= courseClass.Capacity)
                throw new Exception("Lớp học này đã hết chỗ.");

            var myEnrolledClasses = await _context.Grades
                .Include(g => g.CourseClass)
                .Where(g => g.StudentId == studentId && g.CourseClass!.SemesterId == courseClass.SemesterId)
                .Select(g => g.CourseClass)
                .ToListAsync();

            bool isConflict = myEnrolledClasses.Any(c =>
                c!.DayOfWeek == courseClass.DayOfWeek &&
                !(c.EndPeriod < courseClass.StartPeriod || c.StartPeriod > courseClass.EndPeriod));

            if (isConflict)
                throw new Exception("Bạn đã đăng ký một môn học khác trùng lịch với lớp này.");

            var prerequisites = await _context.PrerequisiteSubjects
                .Where(p => p.SubjectId == courseClass.SubjectId)
                .Select(p => p.RequiredSubjectId)
                .ToListAsync();

            if (prerequisites.Any())
            {
                var passedSubjects = await _context.Grades
                    .Include(g => g.CourseClass)
                    .Where(g => g.StudentId == studentId && g.Score > 5.0f)
                    .Select(g => g.CourseClass!.SubjectId)
                    .ToListAsync();

                var missing = prerequisites.Except(passedSubjects).ToList();
                if (missing.Any())
                    throw new Exception("Bạn chưa hoàn thành các môn học tiên quyết bắt buộc với điểm trên 5.");
            }

            _context.Grades.Add(new Grade
            {
                StudentId = studentId,
                CourseClassId = classId,
                RowVersion = Guid.NewGuid().ToByteArray()
            });

            courseClass.EnrolledCount += 1;
            courseClass.RowVersion = Guid.NewGuid().ToByteArray();

            if (string.IsNullOrWhiteSpace(rowVersion))
                throw new Exception("Phiên bản lớp học không hợp lệ. Vui lòng tải lại trang.");

            _context.Entry(courseClass).Property(c => c.RowVersion).OriginalValue =
                Convert.FromBase64String(rowVersion);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            await _auditLogService.LogAsync("EnrollClass", "CourseClass", classId.ToString(), "Success", $"Sinh viên {studentId} đăng ký thành công");
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            await transaction.RollbackAsync();
            await _auditLogService.LogAsync("EnrollClass", "CourseClass", classId.ToString(), "Failed", "Lỗi đụng độ slot cuối");
            throw new Exception("LỖI ĐỤNG ĐỘ: Có sinh viên khác vừa giành mất slot cuối cùng. Vui lòng tải lại trang.");
        }
        catch (FormatException)
        {
            await transaction.RollbackAsync();
            await _auditLogService.LogAsync("EnrollClass", "CourseClass", classId.ToString(), "Failed", "RowVersion không hợp lệ");
            throw new Exception("Phiên bản lớp học không hợp lệ. Vui lòng tải lại trang.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            await _auditLogService.LogAsync("EnrollClass", "CourseClass", classId.ToString(), "Failed", ex.Message);
            throw;
        }
    }

    public async Task<bool> UnenrollClassAsync(string studentId, int classId)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var grade = await _context.Grades
                .FirstOrDefaultAsync(g => g.StudentId == studentId && g.CourseClassId == classId);
            if (grade == null) throw new Exception("Bạn chưa đăng ký lớp học này.");

            if (grade.Score.HasValue)
                throw new Exception("Không thể hủy lớp học đã có điểm số.");

            var courseClass = await _context.CourseClasses.FirstOrDefaultAsync(c => c.Id == classId);
            if (courseClass != null)
            {
                courseClass.EnrolledCount = Math.Max(0, courseClass.EnrolledCount - 1);
                courseClass.RowVersion = Guid.NewGuid().ToByteArray();
            }

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            await _auditLogService.LogAsync("UnenrollClass", "CourseClass", classId.ToString(), "Success", $"Sinh viên {studentId} hủy đăng ký");
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            await _auditLogService.LogAsync("UnenrollClass", "CourseClass", classId.ToString(), "Failed", ex.Message);
            throw;
        }
    }
}
````

### `StudentPortal.Mvc\Services\FileUploadService.cs`

- Size: 1796 bytes
- Lines: 46

````csharp
namespace StudentPortal.Mvc.Services;

public class FileUploadService : IFileUploadService
{
    private readonly IWebHostEnvironment _environment;

    public FileUploadService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveImageAsync(IFormFile file, string folderName)
    {
        if (file == null || file.Length == 0) throw new Exception("Vui lòng chọn file.");

        // 1. Kiểm tra dung lượng (Tối đa 2MB)
        if (file.Length > 2 * 1024 * 1024)
            throw new Exception("Dung lượng file quá lớn. Tối đa 2MB.");

        // 2. Whitelist: Chỉ cho phép ảnh
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(ext))
            throw new Exception("Định dạng file không hợp lệ! Chỉ nhận .jpg, .png, .webp");

        // 3. Đổi tên file thành Guid để chống đụng độ và Path Traversal
        var safeName = $"{Guid.NewGuid():N}{ext}";
        
        var folderPath = Path.Combine(_environment.WebRootPath, "uploads", folderName);
        Directory.CreateDirectory(folderPath); 
        
        var filePath = Path.Combine(folderPath, safeName);

        using var stream = new FileStream(filePath, FileMode.CreateNew);
        await file.CopyToAsync(stream);

        return $"/uploads/{folderName}/{safeName}";
    }

    public void DeleteFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath)) return;
        var fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));
        if (File.Exists(fullPath)) File.Delete(fullPath);
    }
}
````

### `StudentPortal.Mvc\Services\IAuditLogService.cs`

- Size: 188 bytes
- Lines: 6

````csharp
namespace StudentPortal.Mvc.Services;

public interface IAuditLogService
{
    Task LogAsync(string action, string entityName, string? entityId, string result, string? note = null);
}
````

### `StudentPortal.Mvc\Services\IEnrollmentService.cs`

- Size: 358 bytes
- Lines: 10

````csharp
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public interface IEnrollmentService
{
    Task<List<EnrollmentClassViewModel>> GetAvailableClassesAsync(string studentId);
    Task<bool> EnrollClassAsync(string studentId, int classId, string rowVersion);
    Task<bool> UnenrollClassAsync(string studentId, int classId);
}
````

### `StudentPortal.Mvc\Services\IFileUploadService.cs`

- Size: 190 bytes
- Lines: 7

````csharp
namespace StudentPortal.Mvc.Services;

public interface IFileUploadService
{
    Task<string> SaveImageAsync(IFormFile file, string folderName);
    void DeleteFile(string filePath);
}
````

### `StudentPortal.Mvc\StudentPortal.Mvc.csproj`

- Size: 1052 bytes
- Lines: 23

````xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="10.0.9" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="10.0.9" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.9">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="10.0.9" />
    <PackageReference Include="Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore" Version="10.0.9" />
    <PackageReference Include="Serilog.AspNetCore" Version="10.0.0" />
    <PackageReference Include="Serilog.Sinks.File" Version="7.0.0" />
  </ItemGroup>

</Project>
````

### `StudentPortal.Mvc\ViewModels\CourseClassEditViewModel.cs`

- Size: 966 bytes
- Lines: 30

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class CourseClassEditViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn môn học")]
    public int SubjectId { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn học kỳ")]
    public int SemesterId { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập phòng học")]
    public string Room { get; set; } = string.Empty;

    public DayOfWeek DayOfWeek { get; set; }

    [Range(1, 15, ErrorMessage = "Tiết học phải từ 1 đến 15")]
    public int StartPeriod { get; set; }

    [Range(1, 15, ErrorMessage = "Tiết học phải từ 1 đến 15")]
    public int EndPeriod { get; set; }

    [Range(1, 200, ErrorMessage = "Sĩ số phải từ 1 đến 200")]
    public int Capacity { get; set; }

    public string? RowVersion { get; set; } // Chống đụng độ
}
````

### `StudentPortal.Mvc\ViewModels\CourseClassListItemViewModel.cs`

- Size: 837 bytes
- Lines: 22

````csharp
namespace StudentPortal.Mvc.ViewModels;

public class CourseClassListItemViewModel
{
    public int Id { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public string SemesterName { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public string Schedule => $"Thứ {(int)DayOfWeek + 1}, Tiết {StartPeriod} - {EndPeriod}";
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }
    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
    
    // --- THÊM 2 DÒNG NÀY ĐỂ FIX LỖI ---
    public bool IsDeleted { get; set; }
    public bool CanManage { get; set; }
    public bool CanTeach { get; set; }
    public bool IsAssignedProfessor { get; set; }
}
````

### `StudentPortal.Mvc\ViewModels\EnrollmentClassViewModel.cs`

- Size: 794 bytes
- Lines: 20

````csharp
namespace StudentPortal.Mvc.ViewModels;

public class EnrollmentClassViewModel
{
    public int ClassId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public int Credits { get; set; }
    public string Room { get; set; } = string.Empty;
    public string Schedule => $"Thứ {(int)DayOfWeek + 1}, Tiết {StartPeriod} - {EndPeriod}";
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }
    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
    public string RowVersion { get; set; } = string.Empty;
    
    // Trạng thái hiển thị nút bấm
    public bool IsEnrolled { get; set; }
    public bool IsFull => EnrolledCount >= Capacity;
}
````

### `StudentPortal.Mvc\ViewModels\FacultyViewModels.cs`

- Size: 1100 bytes
- Lines: 33

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class FacultyListItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HeadMasterName { get; set; } = string.Empty;
    public string FoundDateText { get; set; } = string.Empty;
    public int TotalMajors { get; set; }
    public bool IsDeleted { get; set; }
}

public class FacultyCreateEditViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập tên Khoa")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateTime FoundDate { get; set; } = DateTime.Now;
    public string? HeadMasterId { get; set; } 
    
    // DANH SÁCH CÁC NGÀNH NẰM TRONG KHOA (Inline Form)
    public List<MajorInlineViewModel> Majors { get; set; } = new List<MajorInlineViewModel>();
}

public class MajorInlineViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? HeadMasterId { get; set; }
}
````

### `StudentPortal.Mvc\ViewModels\LoginViewModel.cs`

- Size: 515 bytes
- Lines: 16

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập Email.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập Mật khẩu.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}
````

### `StudentPortal.Mvc\ViewModels\MajorManagementViewModels.cs`

- Size: 637 bytes
- Lines: 17

````csharp
namespace StudentPortal.Mvc.ViewModels;

public class MajorManagementRowViewModel
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int ClassCount { get; set; }
    public int? ClassId { get; set; }
    public string SemesterName { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
    public string ProfessorsText { get; set; } = string.Empty;
    public int StudentCount { get; set; }
    public string StudentsText { get; set; } = string.Empty;
}
````

### `StudentPortal.Mvc\ViewModels\SalaryBonusCreateViewModel.cs`

- Size: 920 bytes
- Lines: 23

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class SalaryBonusCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng chọn nhân sự / sinh viên.")]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

    [Required]
    public DateTime EndDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);

    [Required(ErrorMessage = "Vui lòng nhập số tiền.")]
    [Range(100000, 500000000, ErrorMessage = "Số tiền phải từ 100,000 đến 500,000,000 VNĐ")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập lý do (VD: Học bổng, Lương tháng...)")]
    [MaxLength(500)]
    public string Note { get; set; } = string.Empty;
}
````

### `StudentPortal.Mvc\ViewModels\SalaryBonusListItemViewModel.cs`

- Size: 741 bytes
- Lines: 19

````csharp
namespace StudentPortal.Mvc.ViewModels;

public class SalaryBonusListItemViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string FacultyName { get; set; } = string.Empty;
    public string MajorName { get; set; } = string.Empty;
    public string Period => $"{StartDate:dd/MM/yyyy} - {EndDate:dd/MM/yyyy}";
    public string AmountText => $"{Amount:N0} VNĐ";
    public string Note { get; set; } = string.Empty;
    public string CreatedAtText { get; set; } = string.Empty;
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }
}
````

### `StudentPortal.Mvc\ViewModels\ScheduleViewModels.cs`

- Size: 573 bytes
- Lines: 15

````csharp
namespace StudentPortal.Mvc.ViewModels;

public class ScheduleClassViewModel
{
    public int ClassId { get; set; }
    public string SemesterName { get; set; } = string.Empty;
    public string SubjectName { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }
    public string Schedule => $"Thứ {(int)DayOfWeek + 1}, Tiết {StartPeriod} - {EndPeriod}";
    public string PeopleText { get; set; } = string.Empty;
}
````

### `StudentPortal.Mvc\ViewModels\SubjectViewModels.cs`

- Size: 1315 bytes
- Lines: 41

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class SubjectListItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; }
    public string MajorName { get; set; } = string.Empty;
    public string FacultyName { get; set; } = string.Empty;
    public string PrerequisitesText { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    
    // Biến cờ: Báo cho View biết User hiện tại có quyền Sửa/Xóa môn này không
    public bool CanManage { get; set; } 
}

public class SubjectCreateEditViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên Môn học")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập số tín chỉ")]
    [Range(1, 10, ErrorMessage = "Tín chỉ phải từ 1 đến 10")]
    public int Credits { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn Ngành học")]
    public int MajorId { get; set; }

    public List<PrerequisiteInlineViewModel> Prerequisites { get; set; } = new();
}

public class PrerequisiteInlineViewModel
{
    public int RequiredSubjectId { get; set; }
}
````

### `StudentPortal.Mvc\ViewModels\TranscriptViewModel.cs`

- Size: 1258 bytes
- Lines: 36

````csharp
namespace StudentPortal.Mvc.ViewModels;

public class TranscriptViewModel
{
    public string StudentName { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public string MajorName { get; set; } = string.Empty;
    
    // Danh sách các môn đã học
    public List<GradeItemViewModel> Grades { get; set; } = new List<GradeItemViewModel>();

    // Tính toán GPA hệ 4.0 động (On-the-fly) - Yêu cầu trong Master Plan
    public double TotalGPA 
    {
        get 
        {
            var gradedItems = Grades.Where(g => g.Score.HasValue).ToList();
            if (!gradedItems.Any()) return 0;

            double totalPoints = gradedItems.Sum(g => g.Score!.Value * g.Credits);
            int totalCredits = gradedItems.Sum(g => g.Credits);
            
            return totalCredits == 0 ? 0 : Math.Round(totalPoints / totalCredits, 2);
        }
    }
}

public class GradeItemViewModel
{
    public int GradeId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public int Credits { get; set; }
    public float? Score { get; set; }
    public string? Note { get; set; }
    public string SemesterName { get; set; } = string.Empty;
}
````

### `StudentPortal.Mvc\ViewModels\UserCreateViewModel.cs`

- Size: 1585 bytes
- Lines: 39

````csharp
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class UserCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập Email")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập Mật khẩu")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng xác nhận Mật khẩu")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp!")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập Họ Tên")]
    public string FullName { get; set; } = string.Empty;

    // --- CÁC TRƯỜNG MỚI THÊM VÀO ĐÂY ---
    [Required(ErrorMessage = "Vui lòng nhập Mã định danh (PID)")]
    public string PID { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn Ngày sinh")]
    public DateTime Dob { get; set; } = new DateTime(2000, 1, 1);

    [Required(ErrorMessage = "Vui lòng chọn Vai trò")]
    public string Role { get; set; } = string.Empty; 

    // Các trường Optional (Có dấu ?)
    public int? FacultyId { get; set; }
    public int? MajorId { get; set; }
    public string? Department { get; set; }
    public string? JobDescription { get; set; } // Dành cho Worker
}
````

### `StudentPortal.Mvc\ViewModels\UserEditViewModel.cs`

- Size: 907 bytes
- Lines: 26

````csharp

using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class UserEditViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty; // Chỉ đọc
    public string Role { get; set; } = string.Empty;  // Chỉ đọc

    [Required(ErrorMessage = "Vui lòng nhập Họ Tên")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập Mã định danh (PID)")]
    public string PID { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn Ngày sinh")]
    public DateTime Dob { get; set; }

    // Các trường Profile (Ẩn hiện tùy Role)
    public int? FacultyId { get; set; }
    public int? MajorId { get; set; }
    public string? Department { get; set; }
    public string? JobDescription { get; set; }
}
````

### `StudentPortal.Mvc\ViewModels\UserListItemViewModel.cs`

- Size: 446 bytes
- Lines: 11

````csharp
namespace StudentPortal.Mvc.ViewModels;

public class UserListItemViewModel
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string ProfileInfo { get; set; } = string.Empty; // Chứa tên Khoa/Ngành/Phòng ban
    public bool IsDeleted { get; set; }
}
````

### `StudentPortal.Mvc\Views\_ViewImports.cshtml`

- Size: 116 bytes
- Lines: 4

````cshtml
@using StudentPortal.Mvc
@using StudentPortal.Mvc.Models
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
````

### `StudentPortal.Mvc\Views\_ViewStart.cshtml`

- Size: 35 bytes
- Lines: 4

````cshtml
@{
    Layout = "_Layout";
}
````

### `StudentPortal.Mvc\Views\Account\AccessDenied.cshtml`

- Size: 533 bytes
- Lines: 10

````cshtml
@{ ViewData["Title"] = "Từ chối truy cập"; }

<div class="container text-center mt-5 pt-5">
    <h1 class="display-1 text-danger fw-bold"><i class="bi bi-shield-lock-fill"></i> 403</h1>
    <h2 class="fw-bold">Truy Cập Bị Từ Chối</h2>
    <p class="text-muted fs-5 mt-3">
        Tài khoản của bạn không có đủ thẩm quyền (Role/Policy) để truy cập chức năng này.
    </p>
    <a asp-controller="Home" asp-action="Index" class="btn btn-primary mt-4 px-4">Quay Về Trang Chủ</a>
</div>
````

### `StudentPortal.Mvc\Views\Account\Login.cshtml`

- Size: 2482 bytes
- Lines: 52

````cshtml
@model StudentPortal.Mvc.ViewModels.LoginViewModel
@{ ViewData["Title"] = "Đăng nhập hệ thống"; }

<div class="row justify-content-center mt-5">
    <div class="col-md-5">
        <div class="card shadow-sm border-0 rounded-4">
            <div class="card-body p-5">
                <div class="text-center mb-4">
                    <h2 class="fw-bold text-primary">🎓 School Portal</h2>
                    <p class="text-muted">Đăng nhập để truy cập hệ thống</p>
                </div>

                <form asp-controller="Account" asp-action="Login" asp-route-returnUrl="@ViewData["ReturnUrl"]" method="post">
                    @Html.AntiForgeryToken()
                    
                    <div asp-validation-summary="ModelOnly" class="text-danger mb-3 fw-bold small"></div>

                    <div class="mb-3">
                        <label asp-for="Email" class="form-label fw-bold">Tài khoản Email</label>
                        <input asp-for="Email" class="form-control form-control-lg" placeholder="user@portal.com" />
                        <span asp-validation-for="Email" class="text-danger small"></span>
                    </div>

                    <div class="mb-4">
                        <label asp-for="Password" class="form-label fw-bold">Mật khẩu</label>
                        <input asp-for="Password" class="form-control form-control-lg" placeholder="******" />
                        <span asp-validation-for="Password" class="text-danger small"></span>
                    </div>

                    <div class="mb-3 form-check">
                        <input asp-for="RememberMe" class="form-check-input" />
                        <label asp-for="RememberMe" class="form-check-label text-muted">Ghi nhớ đăng nhập</label>
                    </div>

                    <button type="submit" class="btn btn-primary btn-lg w-100 fw-bold">Đăng Nhập</button>
                </form>

                <hr class="mt-5" />
                <div class="text-center small text-muted">
                    <strong>Demo Accounts:</strong><br />
                    admin@portal.com / Admin@123<br />
                    prof@portal.com / Prof@123<br />
                    student@portal.com / Student@123
                </div>
            </div>
        </div>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
````

### `StudentPortal.Mvc\Views\AuditLogs\Index.cshtml`

- Size: 2242 bytes
- Lines: 46

````cshtml
@model List<StudentPortal.Mvc.Models.AuditLog>
@{ ViewData["Title"] = "Nhật ký Hệ thống"; }

<div class="page-header mb-4 mt-4">
    <h2>🛡️ Nhật ký Hệ thống (Audit Logs)</h2>
    <p class="text-muted">Chỉ Admin mới có quyền truy cập trang này.</p>
</div>

<form method="get" class="row g-2 mb-4 bg-white p-3 shadow-sm rounded border">
    <div class="col-md-5">
        <input type="text" name="keyword" class="form-control" placeholder="Tìm theo Username hoặc Action..." value="@ViewData["Keyword"]" />
    </div>
    <div class="col-md-4">
        <select name="result" class="form-select" onchange="this.form.submit()">
            <option value="">-- Tất cả trạng thái --</option>
            <option value="Success" selected="@(ViewData["Result"]?.ToString() == "Success")">Thành công (Success)</option>
            <option value="Failed" selected="@(ViewData["Result"]?.ToString() == "Failed")">Thất bại (Failed)</option>
        </select>
    </div>
    <div class="col-md-3">
        <button type="submit" class="btn btn-dark w-100 fw-bold">Tra cứu Log</button>
    </div>
</form>

<table class="table table-bordered table-striped bg-white shadow-sm">
    <thead class="table-dark">
        <tr><th>Thời gian (UTC)</th><th>Người dùng</th><th>Hành động</th><th>Đối tượng (ID)</th><th>Kết quả</th><th>Ghi chú</th></tr>
    </thead>
    <tbody>
        @if (Model.Count == 0) { <tr><td colspan="6" class="text-center py-4">Không có bản ghi Log nào.</td></tr> }
        @foreach (var log in Model)
        {
            <tr>
                <td>@log.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss")</td>
                <td class="fw-bold text-primary">@log.UserName</td>
                <td><span class="badge bg-secondary">@log.Action</span></td>
                <td>@log.EntityName (@log.EntityId)</td>
                <td>
                    @if(log.Result == "Success") { <span class="text-success fw-bold">Success</span> }
                    else { <span class="text-danger fw-bold">Failed</span> }
                </td>
                <td class="small">@log.Note</td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\Views\CourseClasses\CreateEdit.cshtml`

- Size: 5476 bytes
- Lines: 96

````cshtml
@model StudentPortal.Mvc.ViewModels.CourseClassEditViewModel
@{ 
    ViewData["Title"] = Model.Id == 0 ? "Mở Lớp Học Mới" : "Cập nhật Lớp học"; 
}

<div class="row justify-content-center mt-4 mb-5">
    <div class="col-md-8">
        <div class="card shadow-sm border-0 rounded-4">
            <div class="card-header bg-primary text-white fw-bold fs-5 d-flex justify-content-between align-items-center">
                <span>@(Model.Id == 0 ? "🆕 Mở Lớp Học Mới" : "✏️ Cập nhật thông tin Lớp học")</span>
            </div>
            
            <div class="card-body p-4">
                <form asp-action="CreateEdit" method="post">
                    @Html.AntiForgeryToken()
                    
                    <!-- 2 TRƯỜNG ẨN BẮT BUỘC ĐỂ BẢO VỆ CONCURRENCY VÀ XÁC ĐỊNH TRẠNG THÁI -->
                    <input type="hidden" asp-for="Id" />
                    <input type="hidden" asp-for="RowVersion" />

                    <div asp-validation-summary="All" class="text-danger fw-bold mb-3"></div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label asp-for="SubjectId" class="form-label fw-bold">Chọn môn học</label>
                            <select asp-for="SubjectId" class="form-select">
                                <option value="">-- Môn học --</option>
                                @foreach (var sub in ViewBag.Subjects) { 
                                    <option value="@sub.Id">@sub.Name</option> 
                                }
                            </select>
                            <span asp-validation-for="SubjectId" class="text-danger small"></span>
                        </div>
                        <div class="col-md-6">
                            <label asp-for="SemesterId" class="form-label fw-bold">Chọn học kỳ</label>
                            <select asp-for="SemesterId" class="form-select">
                                <option value="">-- Học kỳ --</option>
                                @foreach (var sem in ViewBag.Semesters) { 
                                    <option value="@sem.Id">@sem.Name</option> 
                                }
                            </select>
                            <span asp-validation-for="SemesterId" class="text-danger small"></span>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label asp-for="Room" class="form-label fw-bold">Phòng học</label>
                            <input asp-for="Room" class="form-control" placeholder="VD: A1-101" />
                            <span asp-validation-for="Room" class="text-danger small"></span>
                        </div>
                        <div class="col-md-6">
                            <label asp-for="Capacity" class="form-label fw-bold">Sĩ số tối đa</label>
                            <input asp-for="Capacity" class="form-control" type="number" />
                            <span asp-validation-for="Capacity" class="text-danger small"></span>
                        </div>
                    </div>

                    <div class="row mb-4">
                        <div class="col-md-4">
                            <label asp-for="DayOfWeek" class="form-label fw-bold">Thứ (Lịch học)</label>
                            <select asp-for="DayOfWeek" class="form-select">
                                <option value="1">Thứ 2</option>
                                <option value="2">Thứ 3</option>
                                <option value="3">Thứ 4</option>
                                <option value="4">Thứ 5</option>
                                <option value="5">Thứ 6</option>
                                <option value="6">Thứ 7</option>
                            </select>
                            <span asp-validation-for="DayOfWeek" class="text-danger small"></span>
                        </div>
                        <div class="col-md-4">
                            <label asp-for="StartPeriod" class="form-label fw-bold">Tiết bắt đầu</label>
                            <input asp-for="StartPeriod" class="form-control" type="number" />
                            <span asp-validation-for="StartPeriod" class="text-danger small"></span>
                        </div>
                        <div class="col-md-4">
                            <label asp-for="EndPeriod" class="form-label fw-bold">Tiết kết thúc</label>
                            <input asp-for="EndPeriod" class="form-control" type="number" />
                            <span asp-validation-for="EndPeriod" class="text-danger small"></span>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-primary px-4 fw-bold w-100">
                        @(Model.Id == 0 ? "Xác nhận Mở lớp" : "Lưu Thay Đổi")
                    </button>
                    <a asp-action="Index" class="btn btn-light w-100 mt-2">Hủy bỏ</a>
                </form>
            </div>
        </div>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
````

### `StudentPortal.Mvc\Views\CourseClasses\Index.cshtml`

- Size: 5983 bytes
- Lines: 128

````cshtml
@model List<StudentPortal.Mvc.ViewModels.CourseClassListItemViewModel>
@{ ViewData["Title"] = "Quản lý Lớp học"; }

<div class="page-header mt-4 mb-4">
    <div>
        <h2>Danh sách Lớp học</h2>
        <p class="text-muted">Admin và trưởng khoa/ngành được mở, sửa, hủy lớp. Giảng viên được nhận dạy các lớp thuộc khoa của mình.</p>
    </div>
    @if (ViewBag.CanCreateClass == true)
    {
        <a asp-action="CreateEdit" class="btn btn-success fw-bold h-100">+ Mở lớp mới</a>
    }
</div>

@if (TempData["SuccessMessage"] != null) { <div class="alert alert-success shadow-sm">@TempData["SuccessMessage"]</div> }
@if (TempData["ErrorMessage"] != null) { <div class="alert alert-danger shadow-sm">@TempData["ErrorMessage"]</div> }

<form method="get" class="row g-2 mb-4 bg-white p-3 shadow-sm rounded border">
    <div class="col-md-5">
        <select name="facultyId" class="form-select">
            <option value="">-- Tất cả khoa --</option>
            @foreach (var faculty in ViewBag.Faculties)
            {
                <option value="@faculty.Id" selected="@(ViewData["FacultyId"]?.ToString() == faculty.Id.ToString())">@faculty.Name</option>
            }
        </select>
    </div>
    <div class="col-md-5">
        <select name="majorId" class="form-select">
            <option value="">-- Tất cả ngành --</option>
            @foreach (var major in ViewBag.Majors)
            {
                <option value="@major.Id" selected="@(ViewData["MajorId"]?.ToString() == major.Id.ToString())">@major.Name</option>
            }
        </select>
    </div>
    <div class="col-md-2">
        <button type="submit" class="btn btn-primary w-100 fw-bold">Lọc</button>
    </div>
</form>

<table class="table table-bordered table-striped bg-white shadow-sm">
    <thead class="table-dark">
        <tr>
            <th>ID</th>
            <th>Học kỳ</th>
            <th>Môn học</th>
            <th>Phòng học</th>
            <th>Lịch học</th>
            <th>Đã đăng ký / Sĩ số</th>
            <th>Trạng thái</th>
            <th>Thao tác</th>
        </tr>
    </thead>
    <tbody>
        @if (Model.Count == 0)
        {
            <tr><td colspan="8" class="text-center text-muted py-3">Chưa có lớp học nào.</td></tr>
        }
        @foreach (var item in Model)
        {
            <tr>
                <td>@item.Id</td>
                <td>@item.SemesterName</td>
                <td class="fw-bold text-primary">@item.SubjectName</td>
                <td>@item.Room</td>
                <td>@item.Schedule</td>
                <td><span class="badge bg-info text-dark fs-6">@item.EnrolledCount / @item.Capacity</span></td>
                <td>
                    @if (item.IsDeleted) { <span class="badge bg-danger">Đã hủy</span> }
                    else { <span class="badge bg-success">Đang mở</span> }
                </td>
                <td>
                    <div class="d-flex flex-wrap gap-1">
                        @if (item.CanManage)
                        {
                            @if (item.IsDeleted)
                            {
                                <form asp-action="ToggleDelete" method="post">
                                    @Html.AntiForgeryToken()
                                    <input type="hidden" name="id" value="@item.Id" />
                                    <input type="hidden" name="restore" value="true" />
                                    <button type="submit" class="btn btn-sm btn-success fw-bold">Khôi phục</button>
                                </form>
                            }
                            else
                            {
                                <a asp-action="CreateEdit" asp-route-id="@item.Id" class="btn btn-sm btn-primary fw-bold">Sửa</a>
                                <form asp-action="ToggleDelete" method="post" onsubmit="return confirm('Bạn có chắc muốn hủy lớp này?');">
                                    @Html.AntiForgeryToken()
                                    <input type="hidden" name="id" value="@item.Id" />
                                    <input type="hidden" name="restore" value="false" />
                                    <button type="submit" class="btn btn-sm btn-danger fw-bold">Hủy</button>
                                </form>
                            }
                        }

                        @if (item.CanTeach)
                        {
                            @if (item.IsAssignedProfessor)
                            {
                                <form asp-action="UnassignProfessor" method="post" onsubmit="return confirm('Bạn muốn hủy nhận dạy lớp này?');">
                                    @Html.AntiForgeryToken()
                                    <input type="hidden" name="classId" value="@item.Id" />
                                    <button type="submit" class="btn btn-sm btn-outline-danger fw-bold">Hủy nhận</button>
                                </form>
                            }
                            else
                            {
                                <form asp-action="AssignProfessor" method="post">
                                    @Html.AntiForgeryToken()
                                    <input type="hidden" name="classId" value="@item.Id" />
                                    <button type="submit" class="btn btn-sm btn-info fw-bold text-dark">Nhận dạy</button>
                                </form>
                            }
                        }

                        @if (!item.CanManage && !item.CanTeach)
                        {
                            <span class="text-muted small fst-italic">Chỉ xem</span>
                        }
                    </div>
                </td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\Views\Enrollments\Index.cshtml`

- Size: 3392 bytes
- Lines: 65

````cshtml
@model List<StudentPortal.Mvc.ViewModels.EnrollmentClassViewModel>
@{ ViewData["Title"] = "Đăng ký Môn học"; }

<div class="page-header mb-4 mt-4">
    <h2>📝 Đăng ký Môn học</h2>
    <p class="text-muted">Danh sách các lớp học đang mở đăng ký trong học kỳ hiện tại.</p>
</div>

@if (TempData["SuccessMessage"] != null) {
    <div class="alert alert-success shadow-sm fw-bold">✅ @TempData["SuccessMessage"]</div>
}
@if (TempData["ErrorMessage"] != null) {
    <div class="alert alert-danger shadow-sm fw-bold">⚠️ @TempData["ErrorMessage"]</div>
}

<div class="row row-cols-1 row-cols-md-3 g-4">
    @if (Model.Count == 0) {
        <div class="col-12"><div class="alert alert-warning">Hiện tại không có đợt đăng ký môn học nào được mở.</div></div>
    }

    @foreach (var item in Model)
    {
        <div class="col">
            <div class="card h-100 shadow-sm border-0 rounded-4">
                <div class="card-body">
                    <h5 class="fw-bold text-primary mb-3">@item.SubjectName</h5>
                    <p class="mb-1 text-muted small"><i class="bi bi-clock"></i> Lịch: @item.Schedule</p>
                    <p class="mb-1 text-muted small"><i class="bi bi-geo-alt"></i> Phòng: @item.Room</p>
                    <p class="mb-3 text-muted small"><i class="bi bi-book"></i> Tín chỉ: @item.Credits</p>
                    
                    <div class="d-flex justify-content-between align-items-center">
                        <span class="badge @(item.IsFull ? "bg-danger" : "bg-success")">
                            Sĩ số: @item.EnrolledCount / @item.Capacity
                        </span>
                    </div>
                </div>
                <div class="card-footer bg-transparent border-0 pb-3 d-flex gap-2">
                    @if (item.IsEnrolled)
                    {
                        <!-- THÊM NÚT HỦY ĐĂNG KÝ -->
                        <button class="btn btn-success w-50 fw-bold" disabled>Đã Đăng Ký</button>
                        <form asp-action="Unenroll" method="post" class="w-50" onsubmit="return confirm('Bạn có chắc chắn muốn hủy đăng ký lớp này?');">
                            @Html.AntiForgeryToken()
                            <input type="hidden" name="classId" value="@item.ClassId" />
                            <button type="submit" class="btn btn-outline-danger w-100 fw-bold">Hủy Lớp</button>
                        </form>
                    }
                    else if (item.IsFull)
                    {
                        <button class="btn btn-danger w-100 fw-bold" disabled>Lớp Đã Đầy</button>
                    }
                    else
                    {
                        <form asp-action="Enroll" method="post" class="w-100">
                            @Html.AntiForgeryToken()
                            <input type="hidden" name="classId" value="@item.ClassId" />
                            <input type="hidden" name="rowVersion" value="@item.RowVersion" />
                            <button type="submit" class="btn btn-primary w-100 fw-bold">Đăng ký ngay</button>
                        </form>
                    }
                </div>
            </div>
        </div>
    }
</div>
````

### `StudentPortal.Mvc\Views\Faculties\CreateEdit.cshtml`

- Size: 5737 bytes
- Lines: 106

````cshtml
@model StudentPortal.Mvc.ViewModels.FacultyCreateEditViewModel
@{ ViewData["Title"] = Model.Id == 0 ? "Thêm Khoa Mới" : "Cập nhật Khoa"; }

<div class="row justify-content-center mt-4 mb-5">
    <div class="col-md-9">
        <form asp-action="CreateEdit" method="post" class="card shadow-sm border-0 rounded-4">
            @Html.AntiForgeryToken()
            <input type="hidden" asp-for="Id" />
            
            <div class="card-header bg-dark text-white fw-bold fs-5 d-flex justify-content-between align-items-center">
                <span>@(Model.Id == 0 ? "🏢 Mở Khoa Mới" : "✏️ Cập nhật Thông tin Khoa")</span>
                <button type="submit" class="btn btn-sm btn-success fw-bold px-4">Lưu Dữ Liệu</button>
            </div>
            
            <div class="card-body p-4">
                <div asp-validation-summary="All" class="text-danger fw-bold mb-3"></div>

                <h6 class="fw-bold text-primary mb-3">1. Thông tin Khoa</h6>
                <div class="row mb-3">
                    <div class="col-md-8">
                        <label asp-for="Name" class="form-label fw-bold">Tên Khoa</label>
                        <input asp-for="Name" class="form-control" placeholder="VD: Khoa Kinh tế..." />
                    </div>
                    <div class="col-md-4">
                        <label asp-for="FoundDate" class="form-label fw-bold">Ngày thành lập</label>
                        <input asp-for="FoundDate" class="form-control" type="date" />
                    </div>
                </div>

                <div class="mb-4">
                    <label asp-for="HeadMasterId" class="form-label fw-bold">Bổ nhiệm Trưởng Khoa (Tùy chọn)</label>
                    <select asp-for="HeadMasterId" class="form-select">
                        <option value="">-- Chưa bổ nhiệm --</option>
                        @foreach (var prof in ViewBag.Professors) { <option value="@prof.Id">@prof.FullName</option> }
                    </select>
                </div>

                <hr />
                <h6 class="fw-bold text-success mb-3 d-flex justify-content-between align-items-center">
                    2. Các Ngành đào tạo thuộc Khoa
                    <button type="button" class="btn btn-sm btn-outline-success fw-bold" onclick="addMajorRow()">+ Thêm ngành học</button>
                </h6>

                <table class="table table-bordered bg-light align-middle">
                    <thead class="table-secondary"><tr><th>Tên ngành học</th><th>Trưởng ngành (Tùy chọn)</th><th style="width: 50px;">Bỏ</th></tr></thead>
                    <tbody id="majorsBody">
                        @for (int i = 0; i < Model.Majors.Count; i++)
                        {
                            <tr>
                                <td>
                                    <input type="hidden" name="Majors[@i].Id" value="@Model.Majors[i].Id" />
                                    <input type="text" name="Majors[@i].Name" value="@Model.Majors[i].Name" class="form-control" placeholder="Nhập tên ngành..." />
                                </td>
                                <td>
                                    <select name="Majors[@i].HeadMasterId" class="form-select">
                                        <option value="">-- Chưa bổ nhiệm --</option>
                                        @foreach (var prof in ViewBag.Professors)
                                        {
                                            if (prof.Id == Model.Majors[i].HeadMasterId) { <option value="@prof.Id" selected>@prof.FullName</option> }
                                            else { <option value="@prof.Id">@prof.FullName</option> }
                                        }
                                    </select>
                                </td>
                                <td class="text-center">
                                    <button type="button" class="btn btn-sm btn-danger" onclick="this.closest('tr').remove()"><i class="bi bi-x-lg">X</i></button>
                                </td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        </form>
    </div>
</div>

<!-- Template HTML ẩn dùng cho Javascript để Copy ra -->
<template id="majorTemplate">
    <tr>
        <td>
            <input type="hidden" name="Majors[__INDEX__].Id" value="0" />
            <input type="text" name="Majors[__INDEX__].Name" class="form-control" placeholder="Tên ngành mới..." />
        </td>
        <td>
            <select name="Majors[__INDEX__].HeadMasterId" class="form-select">
                <option value="">-- Chưa bổ nhiệm --</option>
                @foreach (var prof in ViewBag.Professors) { <option value="@prof.Id">@prof.FullName</option> }
            </select>
        </td>
        <td class="text-center">
            <button type="button" class="btn btn-sm btn-danger" onclick="this.closest('tr').remove()"><i class="bi bi-x-lg">X</i></button>
        </td>
    </tr>
</template>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
    <script>
        let majorCount = @Model.Majors.Count;
        function addMajorRow() {
            let template = document.getElementById('majorTemplate').innerHTML;
            let html = template.replace(/__INDEX__/g, majorCount);
            document.getElementById('majorsBody').insertAdjacentHTML('beforeend', html);
            majorCount++;
        }
    </script>
}
````

### `StudentPortal.Mvc\Views\Faculties\Index.cshtml`

- Size: 3464 bytes
- Lines: 78

````cshtml
@model List<StudentPortal.Mvc.ViewModels.FacultyListItemViewModel>
@{ ViewData["Title"] = "Quản lý Khoa"; }

<div class="page-header mb-4 mt-4">
    <h2>Quản lý Cơ cấu: Các Khoa</h2>
    @if (ViewBag.IsAdmin == true)
    {
        <a asp-action="CreateEdit" class="btn btn-success fw-bold h-100">+ Mở Khoa mới</a>
    }
</div>

@if (TempData["SuccessMessage"] != null) { <div class="alert alert-success fw-bold">@TempData["SuccessMessage"]</div> }

<form method="get" class="row g-2 mb-4 bg-white p-3 shadow-sm rounded border">
    <div class="col-md-8">
        <input type="text" name="keyword" class="form-control" placeholder="Gõ tên Khoa..." value="@ViewData["Keyword"]" />
    </div>
    <div class="col-md-4">
        <select name="showDeleted" class="form-select fw-bold" onchange="this.form.submit()" disabled="@(ViewBag.IsAdmin != true)">
            <option value="false" selected="@(ViewData["ShowDeleted"]?.ToString() == "False")">Các Khoa đang hoạt động</option>
            <option value="true" selected="@(ViewData["ShowDeleted"]?.ToString() == "True")">Thùng rác</option>
        </select>
    </div>
</form>

<table class="table table-bordered table-striped bg-white shadow-sm">
    <thead class="table-dark">
        <tr>
            <th>ID</th>
            <th>Tên Khoa</th>
            <th>Trưởng Khoa</th>
            <th>Thành lập</th>
            <th>Tổng Ngành</th>
            <th>Thao tác</th>
        </tr>
    </thead>
    <tbody>
        @if (Model.Count == 0)
        {
            <tr><td colspan="6" class="text-center py-4">Chưa có dữ liệu Khoa.</td></tr>
        }
        @foreach (var f in Model)
        {
            <tr>
                <td>@f.Id</td>
                <td class="fw-bold text-primary">@f.Name</td>
                <td class="fw-bold text-danger">@f.HeadMasterName</td>
                <td>@f.FoundDateText</td>
                <td><span class="badge bg-secondary fs-6">@f.TotalMajors</span></td>
                <td>
                    @if (f.IsDeleted && ViewBag.IsAdmin == true)
                    {
                        <form asp-action="ToggleDelete" method="post" class="d-inline">
                            @Html.AntiForgeryToken()
                            <input type="hidden" name="id" value="@f.Id" />
                            <input type="hidden" name="restore" value="true" />
                            <button type="submit" class="btn btn-sm btn-success fw-bold">Khôi phục</button>
                        </form>
                    }
                    else
                    {
                        <a asp-action="CreateEdit" asp-route-id="@f.Id" class="btn btn-sm btn-warning fw-bold">Sửa</a>
                        @if (ViewBag.IsAdmin == true)
                        {
                            <form asp-action="ToggleDelete" method="post" class="d-inline" onsubmit="return confirm('Bạn có chắc muốn xóa mềm Khoa này?');">
                                @Html.AntiForgeryToken()
                                <input type="hidden" name="id" value="@f.Id" />
                                <input type="hidden" name="restore" value="false" />
                                <button type="submit" class="btn btn-sm btn-danger fw-bold">Xóa</button>
                            </form>
                        }
                    }
                </td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\Views\Grades\ClassGrades.cshtml`

- Size: 2580 bytes
- Lines: 54

````cshtml
@model List<StudentPortal.Mvc.Models.Grade>
@{ ViewData["Title"] = "Nhập điểm lớp " + ViewBag.ClassName; }

<div class="page-header mb-4">
    <h2>Nhập điểm: <span class="text-primary">@ViewBag.ClassName</span></h2>
    <p class="text-muted">Phòng: @ViewBag.Room | Sĩ số: @Model.Count</p>
    <a asp-action="Index" class="btn btn-secondary">Quay lại danh sách lớp</a>
</div>

@if (TempData["SuccessMessage"] != null) { <div class="alert alert-success">@TempData["SuccessMessage"]</div> }
@if (TempData["ErrorMessage"] != null) { <div class="alert alert-danger">@TempData["ErrorMessage"]</div> }

<table class="table table-bordered table-striped bg-white shadow-sm">
    <thead class="table-dark">
        <tr>
            <th>Họ và Tên SV</th>
            <th>Email</th>
            <th>Điểm hiện tại</th>
            <th>Ghi chú</th>
            <th>Cập nhật</th>
        </tr>
    </thead>
    <tbody>
        @if (Model.Count == 0)
        {
            <tr><td colspan="5" class="text-center py-4">Lớp này chưa có sinh viên đăng ký.</td></tr>
        }
        @foreach (var grade in Model)
        {
            <tr>
                <td class="fw-bold">@grade.Student?.User?.FullName</td>
                <td>@grade.Student?.User?.Email</td>
                <td>
                    <span class="badge @(grade.Score >= 5 ? "bg-success" : (grade.Score < 5 ? "bg-danger" : "bg-secondary")) fs-6">
                        @(grade.Score?.ToString() ?? "Chưa nhập")
                    </span>
                </td>
                <td>@grade.Note</td>
                <td>
                    <form asp-action="UpdateSingleGrade" method="post" class="d-flex flex-wrap gap-2">
                        @Html.AntiForgeryToken()
                        <input type="hidden" name="gradeId" value="@grade.Id" />
                        <input type="hidden" name="classId" value="@grade.CourseClassId" />
                        <input type="hidden" name="rowVersion" value="@Convert.ToBase64String(grade.RowVersion)" />
                        <input type="number" step="0.1" max="10" min="0" name="score" class="form-control" value="@grade.Score" style="width: 100px;" />
                        <input type="text" name="note" class="form-control" value="@grade.Note" maxlength="255" placeholder="Ghi chú" style="min-width: 220px;" />
                        <button type="submit" class="btn btn-sm btn-primary fw-bold">Lưu</button>
                    </form>
                </td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\Views\Grades\Index.cshtml`

- Size: 1432 bytes
- Lines: 39

````cshtml
@model List<StudentPortal.Mvc.Models.CourseClass>
@{ ViewData["Title"] = "Quản lý Điểm số"; }

<div class="page-header mb-4 mt-4">
    <h2>Quản lý Điểm số</h2>
</div>

@if (TempData["SuccessMessage"] != null) {
    <div class="alert alert-success shadow-sm fw-bold">@TempData["SuccessMessage"]</div>
}
@if (TempData["ErrorMessage"] != null) {
    <div class="alert alert-danger shadow-sm fw-bold">@TempData["ErrorMessage"]</div>
}

<div class="row">
    @if (Model.Count == 0)
    {
        <div class="col-12">
            <div class="alert alert-warning">Bạn chưa nhận giảng dạy lớp nào.</div>
        </div>
    }

    @foreach (var c in Model)
    {
        <div class="col-md-6 mb-4">
            <div class="card shadow-sm border-0 rounded-4">
                <div class="card-header bg-dark text-white fw-bold">
                    Môn: @c.Subject?.Name (Phòng: @c.Room)
                </div>
                <div class="card-body">
                    <p class="text-muted small mb-2">Đã đăng ký: @c.EnrolledCount / @c.Capacity sinh viên</p>
                    <p class="text-muted small mb-3">Lịch: Thứ @((int)c.DayOfWeek + 1), Tiết @c.StartPeriod - @c.EndPeriod</p>
                    <a asp-action="ClassGrades" asp-route-classId="@c.Id" class="btn btn-primary fw-bold w-100">Vào Nhập Điểm Lớp</a>
                </div>
            </div>
        </div>
    }
</div>
````

### `StudentPortal.Mvc\Views\Home\Index.cshtml`

- Size: 16668 bytes
- Lines: 333

````cshtml
@{ ViewData["Title"] = "Dashboard"; }

<div class="mb-4 mt-3">
    <h2 class="fw-bold">👋 Xin chào, @User.Identity?.Name!</h2>
    <p class="text-muted">Chào mừng trở lại Cổng thông tin Quản lý Đào tạo.</p>
</div>

<!-- ========================================== -->
<!-- KHU VỰC THÔNG BÁO TỪ BAN GIÁM HIỆU         -->
<!-- ========================================== -->
<div class="card shadow-sm border-0 border-start border-4 border-danger mb-4">
    <div class="card-header bg-white fw-bold text-danger border-0 pt-3 pb-0">
        <i class="bi bi-bell-fill"></i> THÔNG BÁO MỚI NHẤT TỪ ADMIN
    </div>
   <div class="card-body">
        @if (ViewBag.Notifications != null && ViewBag.Notifications.Count > 0)
        {
            <div class="list-group list-group-flush">
                @foreach (var notif in ViewBag.Notifications)
                {
                    <div class="list-group-item px-0 py-2 border-bottom-0">
                        <div class="d-flex w-100 justify-content-between align-items-start">
                            <div>
                                <h6 class="mb-1 fw-bold text-dark">@notif.Title</h6>
                                <small class="text-muted">@notif.CreatedAt.ToString("dd/MM/yyyy HH:mm")</small>
                                <p class="mb-1 text-secondary small mt-1">@notif.Content</p>
                            </div>
                            
                            <!-- NÚT ẨN/XÓA THÔNG BÁO DÀNH CHO USER -->
                            <form asp-controller="Home" asp-action="DismissNotification" method="post">
                                @Html.AntiForgeryToken()
                                <input type="hidden" name="id" value="@notif.Id" />
                                <button type="submit" class="btn btn-sm btn-light text-muted border-0 shadow-sm" title="Ẩn thông báo này">
                                    <i class="bi bi-x-lg">X</i>
                                </button>
                            </form>
                            
                        </div>
                    </div>
                }
            </div>
        }
        else
        {
            <p class="text-muted small mb-0 fst-italic">Hiện không có thông báo nào mới.</p>
        }
    </div>
</div>

<!-- ========================================== -->
<!-- 1. GÓC NHÌN CỦA QUẢN TRỊ VIÊN (ADMIN)       -->
<!-- ========================================== -->
@if (User.IsInRole("Admin"))
{
    <h5 class="fw-bold text-danger mt-4 mb-3"><i class="bi bi-shield-lock"></i> KHOANG QUẢN TRỊ HỆ THỐNG</h5>
    <div class="row row-cols-1 row-cols-md-4 g-4 mb-5">
        
        <!-- NÚT PHÁT THÔNG BÁO MỚI THÊM -->
        <div class="col">
            <a asp-controller="Notifications" asp-action="Create" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-bottom border-danger border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-danger mb-3">📢</h1>
                        <h5 class="fw-bold text-dark">Gửi Thông Báo</h5>
                        <p class="text-muted small">Phát loa theo đối tượng</p>
                    </div>
                </div>
            </a>
        </div>

        <div class="col">
            <a asp-controller="Users" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-primary mb-3">👥</h1>
                        <h5 class="fw-bold text-dark">Quản lý Tài khoản</h5>
                        <p class="text-muted small">Sinh viên, Giảng viên, Nhân viên</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="Faculties" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-success mb-3">🏢</h1>
                        <h5 class="fw-bold text-dark">Khoa \& Ngành</h5>
                        <p class="text-muted small">Quản lý cơ cấu đào tạo</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="Subjects" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-warning mb-3">📖</h1>
                        <h5 class="fw-bold text-dark">Môn học</h5>
                        <p class="text-muted small">Tín chỉ, Tiên quyết</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="Semesters" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-danger mb-3">📆</h1>
                        <h5 class="fw-bold text-dark">Học kỳ \& Đăng ký</h5>
                        <p class="text-muted small">Đóng/Mở đợt đăng ký môn</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="CourseClasses" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-info mb-3">🏫</h1>
                        <h5 class="fw-bold text-dark">Lớp học</h5>
                        <p class="text-muted small">Thời khóa biểu, Mở lớp</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="SalaryBonuses" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-success mb-3">💰</h1>
                        <h5 class="fw-bold text-dark">Lương \& Học bổng</h5>
                        <p class="text-muted small">Cấp phát tài chính</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="AuditLogs" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-secondary mb-3">🛡️</h1>
                        <h5 class="fw-bold text-dark">Nhật ký Hệ thống</h5>
                        <p class="text-muted small">Audit Logs</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a href="/health/ready" target="_blank" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 text-dark mb-3">🩺</h1>
                        <h5 class="fw-bold text-dark">System Health</h5>
                        <p class="text-muted small">Kiểm tra kết nối Database</p>
                    </div>
                </div>
            </a>
        </div>
    </div>
}

<!-- ========================================== -->
<!-- 2. GÓC NHÌN CỦA GIẢNG VIÊN                 -->
<!-- ========================================== -->
@if (User.IsInRole("Professor"))
{
    <h5 class="fw-bold text-warning mt-4 mb-3"><i class="bi bi-briefcase"></i> TRUNG TÂM GIẢNG VIÊN</h5>
    <div class="row row-cols-1 row-cols-md-4 g-4 mb-5">
        <div class="col">
            <a asp-controller="Grades" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-bottom border-warning border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">📝</h1>
                        <h5 class="fw-bold text-dark">Quản lý Lớp \& Nhập điểm</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="Schedules" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-bottom border-info border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">🏫</h1>
                        <h5 class="fw-bold text-dark">Thời khóa biểu</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="SalaryBonuses" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-bottom border-success border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">💳</h1>
                        <h5 class="fw-bold text-dark">Lương thưởng</h5>
                    </div>
                </div>
            </a>
        </div>
        <!-- Nếu là Trưởng Khoa / Trưởng Ngành sẽ dùng chức năng này -->
        <div class="col">
            <a asp-controller="Subjects" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-bottom border-primary border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">📖</h1>
                        <h5 class="fw-bold text-dark">Quản lý Môn học</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="CourseClasses" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-bottom border-info border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">📚</h1>
                        <h5 class="fw-bold text-dark">Nhận dạy / Mở lớp</h5>
                    </div>
                </div>
            </a>
        </div>
        @if (ViewBag.IsFacultyHeadMaster == true)
        {
            <div class="col">
                <a asp-controller="Faculties" asp-action="Index" class="text-decoration-none">
                    <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-bottom border-success border-4">
                        <div class="card-body text-center p-4">
                            <h1 class="display-5 mb-3">🏢</h1>
                            <h5 class="fw-bold text-dark">Quản lý Khoa</h5>
                        </div>
                    </div>
                </a>
            </div>
        }
        @if (ViewBag.IsMajorHeadMaster == true)
        {
            <div class="col">
                <a asp-controller="Majors" asp-action="Index" class="text-decoration-none">
                    <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-bottom border-primary border-4">
                        <div class="card-body text-center p-4">
                            <h1 class="display-5 mb-3">🧭</h1>
                            <h5 class="fw-bold text-dark">Quản lý Ngành</h5>
                        </div>
                    </div>
                </a>
            </div>
        }
    </div>
}

<!-- ========================================== -->
<!-- 3. GÓC NHÌN CỦA SINH VIÊN                  -->
<!-- ========================================== -->
@if (User.IsInRole("Student"))
{
    <div class="row align-items-center mb-4">
        <div class="col-md-8">
            <h5 class="fw-bold text-primary mb-0"><i class="bi bi-mortarboard"></i> KHÔNG GIAN HỌC TẬP</h5>
        </div>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4 mb-5">
        <div class="col">
            <a asp-controller="Enrollments" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-top border-primary border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">📅</h1>
                        <h5 class="fw-bold text-dark">Đăng ký Môn học</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="Transcripts" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-top border-info border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">📊</h1>
                        <h5 class="fw-bold text-dark">Bảng điểm / Lịch học</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="SalaryBonuses" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-top border-warning border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">🏆</h1>
                        <h5 class="fw-bold text-dark">Học bổng</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="Schedules" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-top border-success border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">🗓️</h1>
                        <h5 class="fw-bold text-dark">Thời khóa biểu</h5>
                    </div>
                </div>
            </a>
        </div>
    </div>
}

<!-- ========================================== -->
<!-- 4. GÓC NHÌN CỦA NHÂN VIÊN (WORKER)         -->
<!-- ========================================== -->
@if (User.IsInRole("Worker"))
{
    <h5 class="fw-bold text-secondary mt-4 mb-3"><i class="bi bi-tools"></i> CỔNG NHÂN VIÊN</h5>
    <div class="row row-cols-1 row-cols-md-3 g-4 mb-5">
        <div class="col">
            <a asp-controller="Profile" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-start border-secondary border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">👤</h1>
                        <h5 class="fw-bold text-dark">Hồ sơ cá nhân</h5>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a asp-controller="SalaryBonuses" asp-action="Index" class="text-decoration-none">
                <div class="card h-100 shadow-sm border-0 bg-white transition-hover border-start border-success border-4">
                    <div class="card-body text-center p-4">
                        <h1 class="display-5 mb-3">💰</h1>
                        <h5 class="fw-bold text-dark">Bảng Lương</h5>
                    </div>
                </div>
            </a>
        </div>
    </div>
}
````

### `StudentPortal.Mvc\Views\Home\LandingPage.cshtml`

- Size: 496 bytes
- Lines: 7

````cshtml
@{ ViewData["Title"] = "Cổng thông tin Đại học"; }

<div class="text-center py-5 mt-5">
    <h1 class="display-4 fw-bold text-primary">🎓 University Student Portal</h1>
    <p class="fs-5 text-muted mt-3">Hệ thống quản lý đào tạo toàn diện. Áp dụng kiến trúc ASP.NET Core Identity & Role-Based Authorization.</p>
    <a asp-controller="Account" asp-action="Login" class="btn btn-primary btn-lg mt-4 px-5 fw-bold shadow-sm">Đăng Nhập Hệ Thống</a>
</div>
````

### `StudentPortal.Mvc\Views\Home\Privacy.cshtml`

- Size: 144 bytes
- Lines: 7

````cshtml
@{
    ViewData["Title"] = "Privacy Policy";
}
<h1>@ViewData["Title"]</h1>

<p>Use this page to detail your site's privacy policy.</p>
````

### `StudentPortal.Mvc\Views\Majors\Index.cshtml`

- Size: 2495 bytes
- Lines: 67

````cshtml
@model List<StudentPortal.Mvc.ViewModels.MajorManagementRowViewModel>
@{ ViewData["Title"] = "Quản lý Ngành"; }

<div class="page-header mt-4 mb-4">
    <div>
        <h2>Quản lý Ngành: @ViewBag.MajorName</h2>
        <p class="text-muted">Tổng hợp môn học, lớp mở, giảng viên, sinh viên và điểm trong ngành bạn phụ trách.</p>
    </div>
</div>

<form method="get" class="row g-2 mb-4 bg-white p-3 shadow-sm rounded border">
    <div class="col-md-10">
        <select name="majorId" class="form-select">
            @foreach (var major in ViewBag.ManagedMajors)
            {
                <option value="@major.Id" selected="@(ViewData["MajorId"]?.ToString() == major.Id.ToString())">@major.Name (@major.Faculty?.Name)</option>
            }
        </select>
    </div>
    <div class="col-md-2">
        <button type="submit" class="btn btn-primary w-100 fw-bold">Xem</button>
    </div>
</form>

<table class="table table-bordered table-striped bg-white shadow-sm align-middle">
    <thead class="table-dark">
        <tr>
            <th>Môn học</th>
            <th>Tín chỉ</th>
            <th>Số lớp</th>
            <th>Học kỳ / Phòng / Lịch</th>
            <th>Giảng viên</th>
            <th>Sinh viên / Điểm</th>
        </tr>
    </thead>
    <tbody>
        @if (Model.Count == 0)
        {
            <tr><td colspan="6" class="text-center py-4">Ngành này chưa có môn học.</td></tr>
        }
        @foreach (var row in Model)
        {
            <tr>
                <td class="fw-bold text-primary">@row.SubjectName</td>
                <td>@row.Credits</td>
                <td><span class="badge bg-secondary">@row.ClassCount</span></td>
                <td>
                    @if (row.ClassId.HasValue)
                    {
                        <div>@row.SemesterName</div>
                        <div class="text-muted small">@row.Room - @row.Schedule</div>
                    }
                    else
                    {
                        <span class="text-muted small">Chưa mở lớp</span>
                    }
                </td>
                <td>@(string.IsNullOrWhiteSpace(row.ProfessorsText) ? "-" : row.ProfessorsText)</td>
                <td>
                    <div class="fw-bold">@row.StudentCount sinh viên</div>
                    <div class="small text-muted">@row.StudentsText</div>
                </td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\Views\Notifications\Create.cshtml`

- Size: 3790 bytes
- Lines: 64

````cshtml
@model StudentPortal.Mvc.Models.Notification
@{ ViewData["Title"] = "Gửi Thông Báo"; }

<div class="row justify-content-center mt-4">
    <div class="col-md-8">
        <div class="card shadow-sm border-0 rounded-4">
            <div class="card-header bg-danger text-white fw-bold fs-5"><i class="bi bi-megaphone"></i> Soạn Thông Báo Mới</div>
            <div class="card-body p-4">
                <form asp-action="Create" method="post">
                    @Html.AntiForgeryToken()
                    
                    <div class="mb-3">
                        <label asp-for="Title" class="form-label fw-bold">Tiêu đề thông báo</label>
                        <input asp-for="Title" class="form-control" required />
                    </div>

                    <div class="mb-4">
                        <label asp-for="Content" class="form-label fw-bold">Nội dung</label>
                        <textarea asp-for="Content" class="form-control" rows="4" required></textarea>
                    </div>

                    <div class="alert alert-secondary p-3">
                        <h6 class="fw-bold mb-3">Tùy chọn đối tượng nhận (Bỏ trống = Gửi Toàn Trường)</h6>
                        <div class="row g-3">
                            <div class="col-md-6">
                                <label class="small fw-bold">Theo Role</label>
                                <select asp-for="TargetRole" class="form-select">
                                    <option value="">-- Bỏ qua --</option>
                                    <option value="Student">Chỉ Học Sinh</option>
                                    <option value="Professor">Chỉ Giảng Viên</option>
                                    <option value="Worker">Chỉ Nhân Viên</option>
                                </select>
                            </div>
                            <div class="col-md-6">
                                <label class="small fw-bold">Theo Cá Nhân</label>
                                <select asp-for="TargetUserId" class="form-select">
                                    <option value="">-- Bỏ qua --</option>
                                    @foreach(var u in ViewBag.Users) { <option value="@u.Id">@u.FullName (@u.Email)</option> }
                                </select>
                            </div>
                            <div class="col-md-6">
                                <label class="small fw-bold">Theo Khoa</label>
                                <select asp-for="TargetFacultyId" class="form-select">
                                    <option value="">-- Bỏ qua --</option>
                                    @foreach(var f in ViewBag.Faculties) { <option value="@f.Id">@f.Name</option> }
                                </select>
                            </div>
                            <div class="col-md-6">
                                <label class="small fw-bold">Theo Ngành</label>
                                <select asp-for="TargetMajorId" class="form-select">
                                    <option value="">-- Bỏ qua --</option>
                                    @foreach(var m in ViewBag.Majors) { <option value="@m.Id">@m.Name</option> }
                                </select>
                            </div>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-danger w-100 fw-bold">🚀 Phát Thông Báo</button>
                    <a asp-controller="Home" asp-action="Index" class="btn btn-light w-100 mt-2">Hủy bỏ</a>
                </form>
            </div>
        </div>
    </div>
</div>
````

### `StudentPortal.Mvc\Views\Profile\Index.cshtml`

- Size: 1796 bytes
- Lines: 30

````cshtml
@model StudentPortal.Mvc.Models.ApplicationUser
@{ ViewData["Title"] = "Hồ sơ cá nhân"; }

<div class="row justify-content-center mt-5">
    <div class="col-md-5">
        @if (TempData["SuccessMessage"] != null) { <div class="alert alert-success fw-bold">✅ @TempData["SuccessMessage"]</div> }
        @if (TempData["ErrorMessage"] != null) { <div class="alert alert-danger fw-bold">⚠️ @TempData["ErrorMessage"]</div> }

        <div class="card shadow-sm border-0 rounded-4 text-center p-4">
            <div class="mb-4">
                @if (!string.IsNullOrEmpty(Model.AvatarUrl)) {
                    <img src="@Model.AvatarUrl" alt="Avatar" class="rounded-circle shadow" style="width: 150px; height: 150px; object-fit: cover;" />
                } else {
                    <div class="rounded-circle bg-secondary d-inline-flex justify-content-center align-items-center text-white shadow" style="width: 150px; height: 150px; font-size: 50px;">
                        @Model.FullName.Substring(0,1).ToUpper()
                    </div>
                }
            </div>
            <h4 class="fw-bold text-primary">@Model.FullName</h4>
            <p class="text-muted">@Model.Email</p>
            <hr />
            <form asp-action="UploadAvatar" method="post" enctype="multipart/form-data" class="d-flex align-items-center gap-2 mt-3">
                @Html.AntiForgeryToken()
                <input type="file" name="avatarFile" class="form-control" accept=".jpg,.png,.webp" required />
                <button type="submit" class="btn btn-success fw-bold">Đổi Ảnh</button>
            </form>
            <small class="text-muted mt-2 d-block text-start">* Hỗ trợ .jpg, .png. Tối đa 2MB</small>
        </div>
    </div>
</div>
````

### `StudentPortal.Mvc\Views\SalaryBonuses\Create.cshtml`

- Size: 2974 bytes
- Lines: 55

````cshtml
@model StudentPortal.Mvc.ViewModels.SalaryBonusCreateViewModel
@{ ViewData["Title"] = "Cấp Lương / Học Bổng"; }

<div class="row justify-content-center mt-5">
    <div class="col-md-6">
        <div class="card shadow-sm border-0 rounded-4">
            <div class="card-header bg-success text-white fw-bold fs-5">💸 Tạo mới Phiếu Lương / Học Bổng</div>
            <div class="card-body p-4">
                <form asp-action="Create" method="post">
                    @Html.AntiForgeryToken()
                    <div asp-validation-summary="All" class="text-danger fw-bold mb-3"></div>

                    <div class="mb-3">
                        <label asp-for="UserId" class="form-label fw-bold">Người nhận (Sinh viên / Giảng viên / Nhân sự)</label>
                        <select asp-for="UserId" class="form-select">
                            <option value="">-- Chọn người nhận --</option>
                            @foreach (var u in ViewBag.Users) { <option value="@u.Id">@u.FullName (@u.Email)</option> }
                        </select>
                        <span asp-validation-for="UserId" class="text-danger small"></span>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label asp-for="StartDate" class="form-label fw-bold">Từ ngày</label>
                            <input asp-for="StartDate" class="form-control" type="date" />
                        </div>
                        <div class="col-md-6">
                            <label asp-for="EndDate" class="form-label fw-bold">Đến ngày</label>
                            <input asp-for="EndDate" class="form-control" type="date" />
                        </div>
                    </div>

                    <div class="mb-3">
                        <label asp-for="Amount" class="form-label fw-bold">Số tiền (VNĐ)</label>
                        <input asp-for="Amount" class="form-control" type="number" />
                        <span asp-validation-for="Amount" class="text-danger small"></span>
                    </div>

                    <div class="mb-4">
                        <label asp-for="Note" class="form-label fw-bold">Lý do / Ghi chú</label>
                        <input asp-for="Note" class="form-control" placeholder="VD: Học bổng xuất sắc HK1, Lương T12..." />
                        <span asp-validation-for="Note" class="text-danger small"></span>
                    </div>

                    <button type="submit" class="btn btn-success px-4 fw-bold w-100">Xác nhận Cấp phát</button>
                    <a asp-action="Index" class="btn btn-light w-100 mt-2">Hủy bỏ</a>
                </form>
            </div>
        </div>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
````

### `StudentPortal.Mvc\Views\SalaryBonuses\Index.cshtml`

- Size: 3830 bytes
- Lines: 92

````cshtml
@model List<StudentPortal.Mvc.ViewModels.SalaryBonusListItemViewModel>
@{ ViewData["Title"] = "Quản lý Lương & Học bổng"; }

<div class="page-header mb-4 mt-4">
    <h2>Quản lý Tài chính (Lương / Học bổng)</h2>
    <p class="text-muted">Admin xem toàn bộ hệ thống. Các tài khoản khác chỉ xem lịch sử của chính mình.</p>
</div>

@if (TempData["SuccessMessage"] != null) { <div class="alert alert-success shadow-sm fw-bold">@TempData["SuccessMessage"]</div> }

@if (ViewBag.IsAdmin)
{
    <div class="mb-4">
        <a asp-action="Create" class="btn btn-success fw-bold">Tạo mới Phiếu Lương / Học Bổng</a>
    </div>

    <form method="get" class="row g-2 mb-4 bg-white p-3 shadow-sm rounded border">
        <div class="col-md-3">
            <select name="roleFilter" class="form-select">
                <option value="">-- Tất cả role --</option>
                <option value="Admin" selected="@(ViewData["RoleFilter"]?.ToString() == "Admin")">Admin</option>
                <option value="Professor" selected="@(ViewData["RoleFilter"]?.ToString() == "Professor")">Giảng viên</option>
                <option value="Student" selected="@(ViewData["RoleFilter"]?.ToString() == "Student")">Sinh viên</option>
                <option value="Worker" selected="@(ViewData["RoleFilter"]?.ToString() == "Worker")">Giáo vụ</option>
            </select>
        </div>
        <div class="col-md-3">
            <select name="facultyId" class="form-select">
                <option value="">-- Tất cả khoa --</option>
                @foreach (var faculty in ViewBag.Faculties)
                {
                    <option value="@faculty.Id" selected="@(ViewData["FacultyId"]?.ToString() == faculty.Id.ToString())">@faculty.Name</option>
                }
            </select>
        </div>
        <div class="col-md-4">
            <select name="majorId" class="form-select">
                <option value="">-- Tất cả ngành --</option>
                @foreach (var major in ViewBag.Majors)
                {
                    <option value="@major.Id" selected="@(ViewData["MajorId"]?.ToString() == major.Id.ToString())">@major.Name</option>
                }
            </select>
        </div>
        <div class="col-md-2">
            <button type="submit" class="btn btn-primary w-100 fw-bold">Lọc</button>
        </div>
    </form>
}

<table class="table table-bordered table-striped bg-white shadow-sm">
    <thead class="table-dark">
        <tr>
            <th>ID</th>
            @if (ViewBag.IsAdmin)
            {
                <th>Người nhận</th>
                <th>Role</th>
                <th>Khoa</th>
                <th>Ngành</th>
            }
            <th>Kỳ áp dụng</th>
            <th>Số tiền</th>
            <th>Lý do / Ghi chú</th>
            <th>Ngày tạo</th>
        </tr>
    </thead>
    <tbody>
        @if (Model.Count == 0)
        {
            <tr><td colspan="9" class="text-center py-4">Chưa có dữ liệu.</td></tr>
        }
        @foreach (var item in Model)
        {
            <tr>
                <td>#@item.Id</td>
                @if (ViewBag.IsAdmin)
                {
                    <td class="fw-bold text-primary">@item.FullName</td>
                    <td>@item.RoleName</td>
                    <td>@(string.IsNullOrWhiteSpace(item.FacultyName) ? "-" : item.FacultyName)</td>
                    <td>@(string.IsNullOrWhiteSpace(item.MajorName) ? "-" : item.MajorName)</td>
                }
                <td>@item.Period</td>
                <td class="fw-bold text-danger">@item.AmountText</td>
                <td>@item.Note</td>
                <td class="text-muted small">@item.CreatedAtText</td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\Views\Schedules\Index.cshtml`

- Size: 1923 bytes
- Lines: 53

````cshtml
@model List<StudentPortal.Mvc.ViewModels.ScheduleClassViewModel>
@{ ViewData["Title"] = "Thời khóa biểu"; }

<div class="page-header mt-4 mb-4">
    <div>
        <h2>Thời khóa biểu</h2>
        <p class="text-muted">@(ViewBag.IsProfessor == true ? "Danh sách lớp bạn đang nhận giảng dạy." : "Danh sách lớp bạn đã đăng ký học.")</p>
    </div>
</div>

<form method="get" class="row g-2 mb-4 bg-white p-3 shadow-sm rounded border">
    <div class="col-md-10">
        <select name="semesterId" class="form-select">
            <option value="">-- Tất cả học kỳ --</option>
            @foreach (var semester in ViewBag.Semesters)
            {
                <option value="@semester.Id" selected="@(ViewData["SemesterId"]?.ToString() == semester.Id.ToString())">@semester.Name</option>
            }
        </select>
    </div>
    <div class="col-md-2">
        <button type="submit" class="btn btn-primary w-100 fw-bold">Lọc</button>
    </div>
</form>

<table class="table table-bordered table-striped bg-white shadow-sm">
    <thead class="table-dark">
        <tr>
            <th>Học kỳ</th>
            <th>Môn học</th>
            <th>Phòng</th>
            <th>Lịch</th>
            <th>@(ViewBag.IsProfessor == true ? "Sĩ số" : "Giảng viên")</th>
        </tr>
    </thead>
    <tbody>
        @if (Model.Count == 0)
        {
            <tr><td colspan="5" class="text-center py-4">Chưa có lịch trong phạm vi đã chọn.</td></tr>
        }
        @foreach (var item in Model)
        {
            <tr>
                <td>@item.SemesterName</td>
                <td class="fw-bold text-primary">@item.SubjectName</td>
                <td>@item.Room</td>
                <td>@item.Schedule</td>
                <td>@(string.IsNullOrWhiteSpace(item.PeopleText) ? "-" : item.PeopleText)</td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\Views\Semesters\Index.cshtml`

- Size: 3388 bytes
- Lines: 68

````cshtml
@model List<StudentPortal.Mvc.Models.Semester>
@{ ViewData["Title"] = "Quản lý Học kỳ"; }

<div class="page-header mb-4 mt-4">
    <h2>📆 Quản lý Học kỳ \& Đợt đăng ký</h2>
    <p class="text-muted">Admin có quyền Tạo Học kỳ và Bật/Tắt đợt đăng ký môn học của sinh viên.</p>
</div>

@if (TempData["SuccessMessage"] != null) { <div class="alert alert-success fw-bold">✅ @TempData["SuccessMessage"]</div> }

<div class="row">
    <!-- Cột Form Thêm Học Kỳ -->
    <div class="col-md-4">
        <div class="card shadow-sm border-0">
            <div class="card-header bg-dark text-white fw-bold">➕ Thêm Học Kỳ Mới</div>
            <div class="card-body">
                <form asp-action="Create" method="post">
                    @Html.AntiForgeryToken()
                    <div class="mb-3">
                        <label class="fw-bold">Tên Học Kỳ</label>
                        <input name="Name" class="form-control" placeholder="VD: Học kỳ 1 (2026-2027)" required />
                    </div>
                    <div class="mb-3">
                        <label class="fw-bold">Ngày bắt đầu</label>
                        <input type="date" name="StartDate" class="form-control" required />
                    </div>
                    <div class="mb-4">
                        <label class="fw-bold">Ngày kết thúc</label>
                        <input type="date" name="EndDate" class="form-control" required />
                    </div>
                    <button type="submit" class="btn btn-primary w-100 fw-bold">Tạo Học Kỳ</button>
                </form>
            </div>
        </div>
    </div>

    <!-- Cột Danh sách Học Kỳ -->
    <div class="col-md-8">
        <table class="table table-bordered bg-white shadow-sm align-middle">
            <thead class="table-dark">
                <tr><th>Học kỳ</th><th>Thời gian</th><th>Trạng thái Đăng ký</th><th>Thao tác</th></tr>
            </thead>
            <tbody>
                @foreach (var sem in Model)
                {
                    <tr>
                        <td class="fw-bold text-primary">@sem.Name</td>
                        <td>@sem.StartDate.ToString("MM/yyyy") - @sem.EndDate.ToString("MM/yyyy")</td>
                        <td>
                            @if(sem.IsRegistrationOpen) { <span class="badge bg-success fs-6">Đang MỞ</span> }
                            else { <span class="badge bg-danger fs-6">Đã ĐÓNG</span> }
                        </td>
                        <td>
                            <form asp-action="ToggleRegistration" asp-route-id="@sem.Id" method="post">
                                @Html.AntiForgeryToken()
                                @if(sem.IsRegistrationOpen) {
                                    <button type="submit" class="btn btn-sm btn-danger fw-bold">Khóa đăng ký</button>
                                } else {
                                    <button type="submit" class="btn btn-sm btn-success fw-bold">Mở đăng ký</button>
                                }
                            </form>
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    </div>
</div>
````

### `StudentPortal.Mvc\Views\Shared\_Layout.cshtml`

- Size: 3645 bytes
- Lines: 75

````cshtml
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - StudentPortal.Mvc</title>
    <script type="importmap"></script>
    <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    <link rel="stylesheet" href="~/StudentPortal.Mvc.styles.css" asp-append-version="true" />
</head>
<body>
    <header>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
            <div class="container-fluid">
                <a class="navbar-brand fw-bold text-primary" asp-area="" asp-controller="Home" asp-action="Index">🎓 University Portal</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav flex-grow-1">
                        <li class="nav-item">
                            <a class="nav-link text-dark fw-bold" asp-area="" asp-controller="Home" asp-action="Index">🏠 Trang chủ (Dashboard)</a>
                        </li>
                    </ul>
                </ul>

                <!-- Khối đăng nhập / Profile bên phải -->
                <ul class="navbar-nav">
                    @if (User.Identity != null && User.Identity.IsAuthenticated)
                    {
                        <li class="nav-item">
                            <a class="nav-link text-primary fw-bold" asp-controller="Profile" asp-action="Index">
                                <img src="/favicon.ico" width="20" class="rounded-circle me-1" /> @User.Identity.Name
                            </a>
                        </li>
                        <li class="nav-item">
                            <form asp-controller="Account" asp-action="Logout" method="post" class="d-inline">
                                @Html.AntiForgeryToken()
                                <button type="submit" class="nav-link btn btn-link text-danger fw-bold">Đăng xuất</button>
                            </form>
                        </li>
                    }
                    else
                    {
                        <li class="nav-item">
                            <a class="nav-link text-dark fw-bold" asp-controller="Account" asp-action="Login">Đăng nhập</a>
                        </li>
                    }
                </ul>             
                </div>

            </div>
        </nav>
    </header>
    <div class="container">
        <main role="main" class="pb-3">
            @RenderBody()
        </main>
    </div>

    <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2026 - StudentPortal.Mvc - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="~/js/site.js" asp-append-version="true"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
````

### `StudentPortal.Mvc\Views\Shared\_Layout.cshtml.css`

- Size: 925 bytes
- Lines: 49

````css
/* Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
for details on configuring this project to bundle and minify static web assets. */

a.navbar-brand {
  white-space: normal;
  text-align: center;
  word-break: break-all;
}

a {
  color: #0077cc;
}

.btn-primary {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.nav-pills .nav-link.active, .nav-pills .show > .nav-link {
  color: #fff;
  background-color: #1b6ec2;
  border-color: #1861ac;
}

.border-top {
  border-top: 1px solid #e5e5e5;
}
.border-bottom {
  border-bottom: 1px solid #e5e5e5;
}

.box-shadow {
  box-shadow: 0 .25rem .75rem rgba(0, 0, 0, .05);
}

button.accept-policy {
  font-size: 1rem;
  line-height: inherit;
}

.footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  white-space: nowrap;
  line-height: 60px;
}
````

### `StudentPortal.Mvc\Views\Shared\_ValidationScriptsPartial.cshtml`

- Size: 181 bytes
- Lines: 3

````cshtml
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"></script>
````

### `StudentPortal.Mvc\Views\Shared\Error.cshtml`

- Size: 884 bytes
- Lines: 26

````cshtml
@model ErrorViewModel
@{
    ViewData["Title"] = "Error";
}

<h1 class="text-danger">Error.</h1>
<h2 class="text-danger">An error occurred while processing your request.</h2>

@if (Model.ShowRequestId)
{
    <p>
        <strong>Request ID:</strong> <code>@Model.RequestId</code>
    </p>
}

<h3>Development Mode</h3>
<p>
    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
````

### `StudentPortal.Mvc\Views\Subjects\CreateEdit.cshtml`

- Size: 6530 bytes
- Lines: 138

````cshtml
@model StudentPortal.Mvc.ViewModels.SubjectCreateEditViewModel
@{
    ViewData["Title"] = Model.Id == 0 ? "Thêm Môn học" : "Cập nhật Môn học";
}

<div class="row justify-content-center mt-4 mb-5">
    <div class="col-md-8">
        <form asp-action="CreateEdit" method="post" class="card shadow-sm border-0 rounded-4" id="subjectForm">
            @Html.AntiForgeryToken()
            <input type="hidden" asp-for="Id" />

            <div class="card-header bg-warning text-dark fw-bold fs-5 d-flex justify-content-between align-items-center">
                <span>@(Model.Id == 0 ? "Tạo Môn Học Mới" : "Cập nhật Môn Học")</span>
                <button type="submit" class="btn btn-sm btn-primary fw-bold px-4">Lưu Dữ Liệu</button>
            </div>

            <div class="card-body p-4">
                <div asp-validation-summary="All" class="text-danger fw-bold mb-3"></div>

                <h6 class="fw-bold text-primary mb-3">1. Thông tin môn học</h6>
                <div class="row mb-3">
                    <div class="col-md-7">
                        <label asp-for="Name" class="form-label fw-bold">Tên Môn Học</label>
                        <input asp-for="Name" class="form-control" />
                        <span asp-validation-for="Name" class="text-danger small"></span>
                    </div>
                    <div class="col-md-5">
                        <label asp-for="Credits" class="form-label fw-bold">Số tín chỉ</label>
                        <input asp-for="Credits" class="form-control" type="number" />
                        <span asp-validation-for="Credits" class="text-danger small"></span>
                    </div>
                </div>

                <div class="mb-4">
                    <label asp-for="MajorId" class="form-label fw-bold">Thuộc Ngành</label>
                    <select asp-for="MajorId" class="form-select">
                        <option value="">-- Chọn Ngành --</option>
                        @foreach (var m in ViewBag.Majors)
                        {
                            <option value="@m.Id">@m.Name</option>
                        }
                    </select>
                    <span asp-validation-for="MajorId" class="text-danger small"></span>
                </div>

                <hr />
                <h6 class="fw-bold text-success mb-3 d-flex justify-content-between align-items-center">
                    2. Môn tiên quyết
                    <button type="button" class="btn btn-sm btn-outline-success fw-bold" onclick="addPrerequisiteRow()">+ Thêm môn tiên quyết</button>
                </h6>

                <table class="table table-bordered bg-light align-middle">
                    <thead class="table-secondary">
                        <tr>
                            <th>Môn học bắt buộc học trước</th>
                            <th style="width: 60px;">Bỏ</th>
                        </tr>
                    </thead>
                    <tbody id="prerequisitesBody">
                        @for (int i = 0; i < Model.Prerequisites.Count; i++)
                        {
                            <tr>
                                <td>
                                    <select name="Prerequisites[@i].RequiredSubjectId" class="form-select prerequisite-select">
                                        <option value="">-- Chọn môn tiên quyết --</option>
                                        @foreach (var subject in ViewBag.PrerequisiteSubjects)
                                        {
                                            if (subject.Id == Model.Prerequisites[i].RequiredSubjectId)
                                            {
                                                <option value="@subject.Id" selected>@subject.Name</option>
                                            }
                                            else
                                            {
                                                <option value="@subject.Id">@subject.Name</option>
                                            }
                                        }
                                    </select>
                                </td>
                                <td class="text-center">
                                    <button type="button" class="btn btn-sm btn-danger" onclick="removePrerequisiteRow(this)">X</button>
                                </td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        </form>

        <a asp-action="Index" class="btn btn-light w-100 mt-2">Hủy bỏ</a>
    </div>
</div>

<template id="prerequisiteTemplate">
    <tr>
        <td>
            <select name="Prerequisites[__INDEX__].RequiredSubjectId" class="form-select prerequisite-select">
                <option value="">-- Chọn môn tiên quyết --</option>
                @foreach (var subject in ViewBag.PrerequisiteSubjects)
                {
                    <option value="@subject.Id">@subject.Name</option>
                }
            </select>
        </td>
        <td class="text-center">
            <button type="button" class="btn btn-sm btn-danger" onclick="removePrerequisiteRow(this)">X</button>
        </td>
    </tr>
</template>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
    <script>
        let prerequisiteCount = @Model.Prerequisites.Count;

        function addPrerequisiteRow() {
            const template = document.getElementById('prerequisiteTemplate').innerHTML;
            const html = template.replace(/__INDEX__/g, prerequisiteCount);
            document.getElementById('prerequisitesBody').insertAdjacentHTML('beforeend', html);
            prerequisiteCount++;
        }

        function removePrerequisiteRow(button) {
            button.closest('tr').remove();
            reindexPrerequisites();
        }

        function reindexPrerequisites() {
            document.querySelectorAll('#prerequisitesBody tr').forEach((row, index) => {
                const select = row.querySelector('select');
                select.name = `Prerequisites[${index}].RequiredSubjectId`;
            });
            prerequisiteCount = document.querySelectorAll('#prerequisitesBody tr').length;
        }

        document.getElementById('subjectForm').addEventListener('submit', reindexPrerequisites);
    </script>
}
````

### `StudentPortal.Mvc\Views\Subjects\Index.cshtml`

- Size: 5207 bytes
- Lines: 118

````cshtml
@model List<StudentPortal.Mvc.ViewModels.SubjectListItemViewModel>
@{ ViewData["Title"] = "Quản lý Môn học"; }

<div class="page-header mb-4 mt-4">
    <h2>Quản lý Môn học</h2>
    @if (ViewBag.CanCreateSubject == true)
    {
        <a asp-action="CreateEdit" class="btn btn-success fw-bold h-100">+ Tạo Môn học mới</a>
    }
</div>

@if (TempData["SuccessMessage"] != null) { <div class="alert alert-success fw-bold">@TempData["SuccessMessage"]</div> }
@if (TempData["ErrorMessage"] != null) { <div class="alert alert-danger fw-bold">@TempData["ErrorMessage"]</div> }

<form method="get" class="row g-2 mb-4 bg-white p-3 shadow-sm rounded border">
    <div class="col-md-3">
        <input type="text" name="keyword" class="form-control" placeholder="Tìm theo Tên môn học..." value="@ViewData["Keyword"]" />
    </div>
    <div class="col-md-3">
        <select name="facultyId" class="form-select">
            <option value="">-- Tất cả khoa --</option>
            @foreach (var faculty in ViewBag.Faculties)
            {
                <option value="@faculty.Id" selected="@(ViewData["FacultyId"]?.ToString() == faculty.Id.ToString())">@faculty.Name</option>
            }
        </select>
    </div>
    <div class="col-md-3">
        <select name="majorId" class="form-select">
            <option value="">-- Tất cả ngành --</option>
            @foreach (var major in ViewBag.Majors)
            {
                <option value="@major.Id" selected="@(ViewData["MajorId"]?.ToString() == major.Id.ToString())">@major.Name</option>
            }
        </select>
    </div>
    <div class="col-md-2">
        <select name="showDeleted" class="form-select fw-bold" onchange="this.form.submit()">
            <option value="false" selected="@(ViewData["ShowDeleted"]?.ToString() == "False")">Đang hoạt động</option>
            <option value="true" selected="@(ViewData["ShowDeleted"]?.ToString() == "True")">Thùng rác</option>
        </select>
    </div>
    <div class="col-md-1">
        <button type="submit" class="btn btn-primary w-100 fw-bold">Lọc</button>
    </div>
</form>

<table class="table table-bordered table-striped bg-white shadow-sm align-middle">
    <thead class="table-dark">
        <tr>
            <th>Tên Môn Học</th>
            <th>Tín Chỉ</th>
            <th>Thuộc Ngành</th>
            <th>Thuộc Khoa</th>
            <th>Môn tiên quyết</th>
            <th>Trạng thái</th>
            <th>Thao tác</th>
        </tr>
    </thead>
    <tbody>
        @if (Model.Count == 0)
        {
            <tr><td colspan="7" class="text-center py-4">Chưa có dữ liệu Môn học.</td></tr>
        }
        @foreach (var item in Model)
        {
            <tr>
                <td class="fw-bold text-primary">@item.Name</td>
                <td><span class="badge bg-secondary">@item.Credits</span></td>
                <td>@item.MajorName</td>
                <td>@item.FacultyName</td>
                <td>
                    @if (string.IsNullOrWhiteSpace(item.PrerequisitesText))
                    {
                        <span class="text-muted small">Không có</span>
                    }
                    else
                    {
                        @item.PrerequisitesText
                    }
                </td>
                <td>
                    @if (item.IsDeleted) { <span class="badge bg-danger">Đã xóa</span> }
                    else { <span class="badge bg-success">Hoạt động</span> }
                </td>
                <td>
                    @if (item.CanManage)
                    {
                        @if (item.IsDeleted)
                        {
                            <form asp-action="ToggleDelete" method="post" class="d-inline">
                                @Html.AntiForgeryToken()
                                <input type="hidden" name="id" value="@item.Id" />
                                <input type="hidden" name="restore" value="true" />
                                <button type="submit" class="btn btn-sm btn-success fw-bold">Khôi phục</button>
                            </form>
                        }
                        else
                        {
                            <a asp-action="CreateEdit" asp-route-id="@item.Id" class="btn btn-sm btn-primary fw-bold">Sửa</a>
                            <form asp-action="ToggleDelete" method="post" class="d-inline" onsubmit="return confirm('Bạn có chắc muốn xóa mềm môn này?');">
                                @Html.AntiForgeryToken()
                                <input type="hidden" name="id" value="@item.Id" />
                                <input type="hidden" name="restore" value="false" />
                                <button type="submit" class="btn btn-sm btn-danger fw-bold ms-1">Xóa</button>
                            </form>
                        }
                    }
                    else
                    {
                        <span class="text-muted small fst-italic">Chỉ xem</span>
                    }
                </td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\Views\Transcripts\Index.cshtml`

- Size: 2629 bytes
- Lines: 52

````cshtml
@model StudentPortal.Mvc.ViewModels.TranscriptViewModel
@{ ViewData["Title"] = "Bảng Điểm Cá Nhân"; }

<div class="row mt-4">
    <div class="col-md-4">
        <div class="card shadow-sm border-0 border-start border-primary border-5 rounded-4 mb-4">
            <div class="card-body">
                <h5 class="fw-bold text-muted">HỌC SINH</h5>
                <h3 class="fw-bold text-primary">@Model.StudentName</h3>
                <p class="mb-1"><i class="bi bi-mortarboard"></i> Chuyên ngành: <strong>@Model.MajorName</strong></p>
                <hr />
                <h6 class="fw-bold text-muted mb-2">ĐIỂM TRUNG BÌNH TÍCH LŨY (GPA)</h6>
                <h1 class="display-4 fw-bold text-success">@Model.TotalGPA <span class="fs-5 text-muted">/ 10.0</span></h1>
            </div>
        </div>
    </div>
    
    <div class="col-md-8">
        <div class="card shadow-sm border-0 rounded-4">
            <div class="card-header bg-dark text-white fw-bold">Chi Tiết Bảng Điểm</div>
            <div class="card-body p-0">
                <table class="table table-striped table-hover mb-0">
                    <thead class="table-light">
                        <tr><th>Học kỳ</th><th>Môn học</th><th>Tín chỉ</th><th>Điểm số</th><th>Ghi chú</th></tr>
                    </thead>
                    <tbody>
                        @if (Model.Grades.Count == 0)
                        {
                            <tr><td colspan="5" class="text-center py-4">Chưa có dữ liệu học tập.</td></tr>
                        }
                        @foreach (var grade in Model.Grades)
                        {
                            <tr>
                                <td>@grade.SemesterName</td>
                                <td class="fw-bold">@grade.SubjectName</td>
                                <td>@grade.Credits</td>
                                <td>
                                    @if(grade.Score.HasValue) {
                                        <span class="badge @(grade.Score >= 5 ? "bg-success" : "bg-danger") fs-6">@grade.Score.Value</span>
                                    } else {
                                        <span class="badge bg-secondary">Chưa có điểm</span>
                                    }
                                </td>
                                <td>@grade.Note</td>
                            </tr>
                        }
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
````

### `StudentPortal.Mvc\Views\Users\Create.cshtml`

- Size: 7990 bytes
- Lines: 140

````cshtml
@model StudentPortal.Mvc.ViewModels.UserCreateViewModel
@{ ViewData["Title"] = "Tạo mới Tài khoản"; }

<div class="row justify-content-center mt-4 mb-5">
    <div class="col-md-8">
        <div class="card shadow-sm border-0 rounded-4">
            <div class="card-header bg-dark text-white fw-bold fs-5">Tạo Tài Khoản \& Cấp Profile</div>
            <div class="card-body p-4">
                <form asp-action="Create" method="post">
                    @Html.AntiForgeryToken()
                    <div asp-validation-summary="All" class="text-danger fw-bold mb-3"></div>

                    <h6 class="fw-bold text-primary mb-3">1. Thông tin đăng nhập</h6>
                    <div class="row mb-3">
                        <div class="col-md-12"><label asp-for="Email" class="form-label fw-bold">Email</label><input asp-for="Email" class="form-control" /></div>
                    </div>
                    <div class="row mb-4">
                        <div class="col-md-6"><label asp-for="Password" class="form-label fw-bold">Mật khẩu</label><input asp-for="Password" class="form-control" /></div>
                        <div class="col-md-6"><label asp-for="ConfirmPassword" class="form-label fw-bold">Xác nhận MK</label><input asp-for="ConfirmPassword" class="form-control" /></div>
                    </div>

                    <h6 class="fw-bold text-primary mb-3">2. Thông tin cá nhân cơ bản (Dùng chung)</h6>
                    <div class="row mb-3">
                        <div class="col-md-6"><label asp-for="FullName" class="form-label fw-bold">Họ và Tên</label><input asp-for="FullName" class="form-control" /></div>
                        <div class="col-md-6"><label asp-for="Dob" class="form-label fw-bold">Ngày sinh</label><input asp-for="Dob" class="form-control" type="date" /></div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-md-6"><label asp-for="PID" class="form-label fw-bold">Mã định danh (PID/CCCD)</label><input asp-for="PID" class="form-control" placeholder="Ví dụ: 079200012345" /></div>
                        <div class="col-md-6">
                            <label asp-for="Role" class="form-label fw-bold">Vai trò (Role)</label>
                            <select asp-for="Role" class="form-select" id="roleSelect">
                                <option value="">-- Chọn Role --</option>
                                <option value="Student">Học sinh (Student)</option>
                                <option value="Professor">Giảng viên (Professor)</option>
                                <option value="Worker">Công nhân viên (Worker)</option>
                                <option value="Admin">Quản trị viên (Admin)</option>
                            </select>
                        </div>
                    </div>

                    <hr />
                    <div class="alert alert-info">Thông tin Hồ sơ (Profile) sẽ tự động hiển thị dựa theo Vai trò được chọn.</div>

                    <!-- KHU VỰC ẨN HIỆN THEO ROLE -->
                    <div class="p-3 bg-light rounded border mb-4" id="dynamicFields" style="display: none;">
                        <div class="row g-3">
                            <div class="col-md-6" id="facultyDiv">
                                <label asp-for="FacultyId" class="form-label fw-bold">Thuộc Khoa</label>
                                <select asp-for="FacultyId" class="form-select">
                                    <option value="">-- Chọn Khoa --</option>
                                    @foreach(var f in ViewBag.Faculties) { <option value="@f.Id">@f.Name</option> }
                                </select>
                            </div>
                            <div class="col-md-6" id="majorDiv">
                                <label asp-for="MajorId" class="form-label fw-bold">Thuộc Ngành (Chỉ Học sinh)</label>
                                <select asp-for="MajorId" class="form-select">
                                    <option value="">-- Chọn Ngành --</option>
                                    @foreach(var m in ViewBag.Majors) { <option value="@m.Id" data-faculty="@m.FacultyId">@m.Name</option> }
                                </select>
                            </div>
                            <div class="col-md-6" id="deptDiv">
                                <label asp-for="Department" class="form-label fw-bold">Phòng ban (Chỉ Worker)</label>
                                <input asp-for="Department" class="form-control" placeholder="VD: Bảo vệ, Kế toán..." />
                            </div>
                            <div class="col-md-6" id="jobDescDiv">
                                <label asp-for="JobDescription" class="form-label fw-bold">Mô tả công việc (Chỉ Worker)</label>
                                <input asp-for="JobDescription" class="form-control" placeholder="VD: Trực cổng chính..." />
                            </div>
                        </div>
                    </div>

                    <button type="submit" class="btn btn-primary w-100 fw-bold">Khởi tạo Tài khoản</button>
                </form>
            </div>
        </div>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
    <script>
        document.getElementById('roleSelect').addEventListener('change', function () {
            var role = this.value;
            var box = document.getElementById('dynamicFields');
            var fac = document.getElementById('facultyDiv');
            var maj = document.getElementById('majorDiv');
            var dept = document.getElementById('deptDiv');
            var jobDesc = document.getElementById('jobDescDiv');

            // Ẩn tất cả trước
            box.style.display = 'block'; 
            fac.style.display = 'none'; 
            maj.style.display = 'none'; 
            dept.style.display = 'none';
            jobDesc.style.display = 'none';

            if (role === 'Student') { 
                fac.style.display = 'block'; 
                maj.style.display = 'block'; 
            }
            else if (role === 'Professor') { 
                fac.style.display = 'block'; 
            }
            else if (role === 'Worker') { 
                dept.style.display = 'block'; 
                jobDesc.style.display = 'block'; 
            }
            else { 
                box.style.display = 'none'; // Admin không cần điền thêm Profile
            } 
        });

        // LOGIC LỌC NGÀNH THEO KHOA (CASCADING DROPDOWN)
        document.getElementById('facultySelect').addEventListener('change', function () {
            var selectedFacultyId = this.value;
            var majorSelect = document.getElementById('majorSelect');
            var options = majorSelect.querySelectorAll('option');

            // Reset ô chọn Ngành
            majorSelect.value = "";

            options.forEach(function (option) {
                if (option.value === "") {
                    option.style.display = 'block'; // Luôn hiện ô "-- Chọn Ngành --"
                    return;
                }

                // Chỉ hiện những Ngành có data-faculty trùng với Khoa đang chọn
                if (option.getAttribute('data-faculty') === selectedFacultyId) {
                    option.style.display = 'block';
                } else {
                    option.style.display = 'none';
                }
            });
        });

        // Trigger lọc lần đầu khi load trang (Dành cho trang Edit)
        document.getElementById('facultySelect').dispatchEvent(new Event('change'));
    </script>  
}
````

### `StudentPortal.Mvc\Views\Users\Edit.cshtml`

- Size: 6315 bytes
- Lines: 114

````cshtml
@model StudentPortal.Mvc.ViewModels.UserEditViewModel
@{ ViewData["Title"] = "Cập nhật Tài khoản"; }

<div class="row justify-content-center mt-4 mb-5">
    <div class="col-md-8">
        <div class="card shadow-sm border-0 rounded-4">
            <div class="card-header bg-primary text-white fw-bold fs-5">✏️ Cập nhật Tài Khoản & Hồ Sơ</div>
            <div class="card-body p-4">
                <form asp-action="Edit" method="post">
                    @Html.AntiForgeryToken()
                    <input type="hidden" asp-for="Id" />
                    <input type="hidden" asp-for="Role" id="userRole" /> 
                    
                    <div asp-validation-summary="All" class="text-danger fw-bold mb-3"></div>

                    <div class="row mb-3">
                        <div class="col-md-6"><label class="form-label fw-bold">Email</label><input asp-for="Email" class="form-control bg-light" readonly /></div>
                        <div class="col-md-6"><label class="form-label fw-bold">Vai trò (Role)</label><input value="@Model.Role" class="form-control bg-light" readonly /></div>
                    </div>

                    <h6 class="fw-bold text-primary mt-4 mb-3">Thông tin cá nhân</h6>
                    <div class="row mb-3">
                        <div class="col-md-12"><label asp-for="FullName" class="form-label fw-bold">Họ và Tên</label><input asp-for="FullName" class="form-control" /></div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-md-6"><label asp-for="PID" class="form-label fw-bold">Mã định danh (PID)</label><input asp-for="PID" class="form-control" /></div>
                        <div class="col-md-6"><label asp-for="Dob" class="form-label fw-bold">Ngày sinh</label><input asp-for="Dob" class="form-control" type="date" /></div>
                    </div>

                    <hr class="mt-4" />
                    <h6 class="fw-bold text-success mb-3">Thông tin Hồ sơ (Profile)</h6>
                    
                    <div class="row g-3">
                        @if (Model.Role == "Student" || Model.Role == "Professor")
                        {
                            <div class="col-md-6">
                                <label asp-for="FacultyId" class="form-label fw-bold">Thuộc Khoa</label>
                                <select asp-for="FacultyId" class="form-select" id="facultySelect">
                                    <option value="">-- Chọn Khoa --</option>
                                    @foreach(var f in ViewBag.Faculties) { <option value="@f.Id">@f.Name</option> }
                                </select>
                            </div>
                        }
                        
                        @if (Model.Role == "Student")
                        {
                            <div class="col-md-6">
                                <label asp-for="MajorId" class="form-label fw-bold">Thuộc Ngành</label>
                                <select asp-for="MajorId" class="form-select" id="majorSelect">
                                    <option value="">-- Chọn Ngành --</option>
                                    @foreach(var m in ViewBag.Majors) { 
                                        <!-- CỰC QUAN TRỌNG: Gắn data-faculty để JS dựa vào đây mà lọc -->
                                        <option value="@m.Id" data-faculty="@m.FacultyId">@m.Name</option> 
                                    }
                                </select>
                            </div>
                        }

                        @if (Model.Role == "Worker")
                        {
                            <div class="col-md-6"><label asp-for="Department" class="form-label fw-bold">Phòng ban</label><input asp-for="Department" class="form-control" /></div>
                            <div class="col-md-6"><label asp-for="JobDescription" class="form-label fw-bold">Mô tả công việc</label><input asp-for="JobDescription" class="form-control" /></div>
                        }
                    </div>

                    <div class="mt-4">
                        <button type="submit" class="btn btn-primary px-5 fw-bold">Lưu Thông Tin</button>
                        <a asp-action="Index" class="btn btn-light ms-2">Hủy bỏ</a>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
    <script>
        // KIỂM TRA XEM CÓ TỒN TẠI Ô CHỌN KHOA VÀ NGÀNH KHÔNG (Vì Worker không có ô này)
        var facSelect = document.getElementById('facultySelect');
        var majSelect = document.getElementById('majorSelect');

        if (facSelect && majSelect) {
            // Biến lưu tạm giá trị Ngành đang được chọn (để phục hồi sau khi JS lọc)
            var currentMajorVal = majSelect.value;

            facSelect.addEventListener('change', function () {
                var selectedFacId = this.value;
                var options = majSelect.querySelectorAll('option');

                majSelect.value = ""; // Tạm thời reset

                options.forEach(function (opt) {
                    if (opt.value === "") { opt.style.display = 'block'; return; }
                    
                    if (opt.getAttribute('data-faculty') === selectedFacId) {
                        opt.style.display = 'block';
                    } else {
                        opt.style.display = 'none';
                    }
                });

                // Cố gắng phục hồi lại Ngành cũ nếu nó nằm trong Khoa vừa chọn
                var currentOpt = majSelect.querySelector('option[value="' + currentMajorVal + '"]');
                if (currentOpt && currentOpt.style.display === 'block') {
                    majSelect.value = currentMajorVal;
                }
            });

            // Kích hoạt ngay khi vừa mở trang Edit
            facSelect.dispatchEvent(new Event('change'));
        }
    </script>
}
````

### `StudentPortal.Mvc\Views\Users\Index.cshtml`

- Size: 4451 bytes
- Lines: 80

````cshtml
@model List<StudentPortal.Mvc.ViewModels.UserListItemViewModel>
@{ ViewData["Title"] = "Quản lý Tài khoản"; }

<div class="page-header mb-4 mt-4">
    <h2>👥 Quản lý Tài Khoản Hệ Thống</h2>
    <a asp-action="Create" class="btn btn-success fw-bold h-100">+ Tạo tài khoản mới</a>
</div>

@if (TempData["SuccessMessage"] != null) { <div class="alert alert-success fw-bold">✅ @TempData["SuccessMessage"]</div> }

<!-- BỘ LỌC TÌM KIẾM -->
<!-- BỘ LỌC TÌM KIẾM AUTO-SUBMIT -->
<form method="get" class="row g-2 mb-4 bg-white p-3 shadow-sm rounded border">
    <div class="col-md-5">
        <input type="text" name="keyword" class="form-control" placeholder="Tìm theo Tên hoặc Email (Nhấn Enter)..." value="@ViewData["Keyword"]" />
    </div>
    <div class="col-md-3">
        <!-- onchange="this.form.submit()" sẽ tự động tìm kiếm khi chọn -->
        <select name="roleFilter" class="form-select" onchange="this.form.submit()">
            <option value="">-- Tất cả vai trò --</option>
            <option value="Student" selected="@(ViewData["RoleFilter"]?.ToString() == "Student")">Học sinh</option>
            <option value="Professor" selected="@(ViewData["RoleFilter"]?.ToString() == "Professor")">Giảng viên</option>
            <option value="Worker" selected="@(ViewData["RoleFilter"]?.ToString() == "Worker")">Nhân sự (Worker)</option>
            <option value="Admin" selected="@(ViewData["RoleFilter"]?.ToString() == "Admin")">Admin</option>
        </select>
    </div>
    <div class="col-md-4">
        <select name="showDeleted" class="form-select" onchange="this.form.submit()">
            <option value="false" selected="@(ViewData["ShowDeleted"]?.ToString() == "False")">Tài khoản Đang hoạt động</option>
            <option value="true" selected="@(ViewData["ShowDeleted"]?.ToString() == "True")">Thùng rác (Đã xóa / Khóa)</option>
        </select>
    </div>
</form>

<table class="table table-bordered table-striped bg-white shadow-sm">
    <thead class="table-dark">
        <tr><th>Họ Tên</th><th>Email</th><th>Vai trò (Role)</th><th>Thông tin đính kèm</th><th>Trạng thái</th><th>Thao tác</th></tr>
    </thead>
    <tbody>
        @if(Model.Count == 0) { <tr><td colspan="6" class="text-center py-4">Không tìm thấy tài khoản.</td></tr> }
        @foreach (var u in Model)
        {
            <tr>
                <td class="fw-bold">@u.FullName</td>
                <td>@u.Email</td>
                <td><span class="badge bg-secondary fs-6">@u.RoleName</span></td>
                <td class="small text-muted">@u.ProfileInfo</td>
                <td>
                    @if(u.IsDeleted) { <span class="badge bg-danger">Đã khóa</span> }
                    else { <span class="badge bg-success">Hoạt động</span> }
                </td>
                <td>
                    @if (u.IsDeleted)
                    {
                        <form asp-action="Restore" method="post" class="d-inline">
                            @Html.AntiForgeryToken()
                            <input type="hidden" name="id" value="@u.Id" />
                            <button type="submit" class="btn btn-sm btn-success fw-bold">Khôi phục</button>
                        </form>
                    }
                    else
                    {
                        <!-- NÚT SỬA NẰM Ở ĐÂY: Tài khoản đang hoạt động là sửa được -->
                        <a asp-action="Edit" asp-route-id="@u.Id" class="btn btn-sm btn-primary fw-bold">Sửa</a>

                        <!-- NÚT XÓA: Vẫn giữ nguyên logic chặn Admin tự xóa mình -->
                        @if (u.Email != User.Identity?.Name)
                        {
                            <form asp-action="Delete" method="post" class="d-inline" onsubmit="return confirm('Khóa và đưa tài khoản này vào thùng rác?');">
                                @Html.AntiForgeryToken()
                                <input type="hidden" name="id" value="@u.Id" />
                                <button type="submit" class="btn btn-sm btn-danger fw-bold ms-1">Xóa</button>
                            </form>
                        }
                    }
                </td>
            </tr>
        }
    </tbody>
</table>
````

### `StudentPortal.Mvc\wwwroot\css\site.css`

- Size: 888 bytes
- Lines: 39

````css
html {
  font-size: 14px;
}

@media (min-width: 768px) {
  html {
    font-size: 16px;
  }
}

.btn:focus, .btn:active:focus, .btn-link.nav-link:focus, .form-control:focus, .form-check-input:focus {
  box-shadow: 0 0 0 0.1rem white, 0 0 0 0.25rem #258cfb;
}

html {
  position: relative;
  min-height: 100%;
}

body {
  margin-bottom: 60px;
}

.form-floating > .form-control-plaintext::placeholder, .form-floating > .form-control::placeholder {
  color: var(--bs-secondary-color);
  text-align: end;
}

.form-floating > .form-control-plaintext:focus::placeholder, .form-floating > .form-control:focus::placeholder {
  text-align: start;
}

.transition-hover {
    transition: transform 0.2s ease-in-out, box-shadow 0.2s ease-in-out;
}
.transition-hover:hover {
    transform: translateY(-5px);
    box-shadow: 0 .5rem 1rem rgba(0,0,0,.15)!important;
}
````

### `StudentPortal.Mvc\wwwroot\js\site.js`

- Size: 231 bytes
- Lines: 5

````javascript
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
````
