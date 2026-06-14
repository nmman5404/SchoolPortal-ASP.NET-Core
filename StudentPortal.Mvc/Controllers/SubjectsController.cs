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
