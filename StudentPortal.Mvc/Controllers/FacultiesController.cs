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
