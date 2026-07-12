using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjects;
    private readonly IMajorRepository _majors;
    private readonly IUserRepository _users;

    public SubjectService(ISubjectRepository subjects, IMajorRepository majors, IUserRepository users)
    {
        _subjects = subjects;
        _majors = majors;
        _users = users;
    }

    public async Task<SubjectIndexData> GetSubjectsAsync(string userId, bool isAdmin, string? keyword, int? facultyId, int? majorId, bool showDeleted)
    {
        var (faculties, majors) = await GetIndexFiltersAsync(userId, isAdmin, facultyId);
        var query = await GetVisibleSubjectsQueryAsync(userId, isAdmin);
        query = query.IgnoreQueryFilters()
            .Include(s => s.Major).ThenInclude(m => m!.Faculty)
            .Include(s => s.Prerequisites).ThenInclude(p => p.RequiredSubject)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(keyword))
            query = query.Where(s => s.Name.Contains(keyword));
        if (facultyId.HasValue)
            query = query.Where(s => s.Major != null && s.Major.FacultyId == facultyId.Value);
        if (majorId.HasValue)
            query = query.Where(s => s.MajorId == majorId.Value);

        query = showDeleted ? query.Where(s => s.IsDeleted) : query.Where(s => !s.IsDeleted);
        var list = await query.OrderBy(s => s.Major!.Faculty!.Name).ThenBy(s => s.Major!.Name).ThenBy(s => s.Name).ToListAsync();
        var model = new List<SubjectListItemViewModel>();

        foreach (var subject in list)
        {
            model.Add(new SubjectListItemViewModel
            {
                Id = subject.Id,
                Name = subject.Name,
                Credits = subject.Credits,
                MajorName = subject.Major?.Name ?? "N/A",
                FacultyName = subject.Major?.Faculty?.Name ?? "N/A",
                PrerequisitesText = string.Join(", ", subject.Prerequisites.Select(p => p.RequiredSubject?.Name).Where(n => !string.IsNullOrWhiteSpace(n))),
                IsDeleted = subject.IsDeleted,
                CanManage = await CheckCanManageSubjectAsync(subject.MajorId, userId, isAdmin)
            });
        }

        var canCreate = isAdmin || await GetManageableMajorsQuery(userId, isAdmin).AnyAsync();
        return new SubjectIndexData(model, faculties, majors, canCreate);
    }

    public async Task<SubjectFormLists> GetFormListsAsync(string userId, bool isAdmin, int? currentSubjectId = null)
    {
        var majors = await GetManageableMajorsQuery(userId, isAdmin)
            .AsNoTracking()
            .OrderBy(m => m.Faculty!.Name)
            .ThenBy(m => m.Name)
            .Select(m => new LookupOption(m.Id, $"{m.Name} ({m.Faculty!.Name})"))
            .ToListAsync();

        var prerequisiteQuery = await GetVisibleSubjectsQueryAsync(userId, isAdmin);
        if (currentSubjectId.HasValue)
            prerequisiteQuery = prerequisiteQuery.Where(s => s.Id != currentSubjectId.Value);

        var prerequisites = await prerequisiteQuery
            .AsNoTracking()
            .Where(s => !s.IsDeleted)
            .OrderBy(s => s.Major!.Name)
            .ThenBy(s => s.Name)
            .Select(s => new LookupOption(s.Id, $"{s.Name} ({s.Major!.Name})"))
            .ToListAsync();

        return new SubjectFormLists(majors, prerequisites);
    }

    public async Task<SubjectCreateEditViewModel?> GetSubjectForEditAsync(int id, string userId, bool isAdmin)
    {
        var subject = await _subjects.GetByIdAsync(id, includePrerequisites: true);
        if (subject == null) return null;
        if (!await CheckCanManageSubjectAsync(subject.MajorId, userId, isAdmin)) return null;

        return new SubjectCreateEditViewModel
        {
            Id = subject.Id,
            Name = subject.Name,
            Credits = subject.Credits,
            MajorId = subject.MajorId,
            Prerequisites = subject.Prerequisites.Select(p => new PrerequisiteInlineViewModel { RequiredSubjectId = p.RequiredSubjectId }).ToList()
        };
    }

    public async Task<bool> CheckCanManageSubjectAsync(int majorId, string userId, bool isAdmin)
    {
        if (isAdmin) return true;

        return await _majors.Query()
            .Include(m => m.Faculty)
            .AsNoTracking()
            .AnyAsync(m => m.Id == majorId && (m.HeadMasterId == userId || (m.Faculty != null && m.Faculty.HeadMasterId == userId)));
    }

    public async Task<SubjectSaveResult> SaveSubjectAsync(SubjectCreateEditViewModel model, string userId, bool isAdmin)
    {
        if (model.Id > 0 && model.Prerequisites.Select(p => p.RequiredSubjectId).Where(id => id > 0).Contains(model.Id))
            return new SubjectSaveResult(ServiceResult.Fail("Prerequisites|Môn học không thể là môn tiên quyết của chính nó."), await GetFormListsAsync(userId, isAdmin, model.Id));

        if (!await CheckCanManageSubjectAsync(model.MajorId, userId, isAdmin))
            return new SubjectSaveResult(ServiceResult.Denied(), null);

        await using var transaction = await _subjects.BeginTransactionAsync();
        try
        {
            Subject subject;
            var message = "Đã cập nhật môn học!";
            if (model.Id == 0)
            {
                subject = new Subject { Name = model.Name, Credits = model.Credits, MajorId = model.MajorId };
                _subjects.Add(subject);
                await _subjects.SaveChangesAsync();
                message = "Đã thêm môn học mới!";
            }
            else
            {
                subject = await _subjects.GetByIdAsync(model.Id) ?? throw new InvalidOperationException("Không tìm thấy môn học.");
                if (!await CheckCanManageSubjectAsync(subject.MajorId, userId, isAdmin))
                    return new SubjectSaveResult(ServiceResult.Denied(), null);

                subject.Name = model.Name;
                subject.Credits = model.Credits;
                subject.MajorId = model.MajorId;
                await _subjects.SaveChangesAsync();
            }

            await SyncPrerequisitesAsync(subject.Id, model.Prerequisites);
            await _subjects.SaveChangesAsync();
            await transaction.CommitAsync();
            return new SubjectSaveResult(ServiceResult.Ok(message), null);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return new SubjectSaveResult(ServiceResult.Fail("Đã xảy ra lỗi: " + (ex.InnerException?.Message ?? ex.Message)), await GetFormListsAsync(userId, isAdmin, model.Id == 0 ? null : model.Id));
        }
    }

    public async Task<ServiceResult> ToggleDeleteAsync(int id, bool restore, string userId, bool isAdmin)
    {
        var subject = await _subjects.GetByIdAsync(id, includeDeleted: true);
        if (subject == null) return ServiceResult.Missing();
        if (!await CheckCanManageSubjectAsync(subject.MajorId, userId, isAdmin)) return ServiceResult.Denied();

        if (!restore && !subject.IsDeleted)
        {
            var dependentSubjects = await _subjects.GetActiveDependentSubjectNamesAsync(subject.Id);
            if (dependentSubjects.Any())
                return ServiceResult.Fail("Không thể xóa môn học này vì đang là môn tiên quyết của: " + string.Join(", ", dependentSubjects) + ".");
        }

        subject.IsDeleted = !restore;
        await _subjects.SaveChangesAsync();
        return ServiceResult.Ok(restore ? "Đã khôi phục môn học!" : "Đã đưa môn học vào thùng rác!");
    }

    private IQueryable<Major> GetManageableMajorsQuery(string userId, bool isAdmin)
    {
        var query = _majors.Query().Include(m => m.Faculty).AsQueryable();
        if (isAdmin) return query;
        return query.Where(m => m.HeadMasterId == userId || (m.Faculty != null && m.Faculty.HeadMasterId == userId));
    }

    private async Task<IQueryable<Subject>> GetVisibleSubjectsQueryAsync(string userId, bool isAdmin)
    {
        var query = _subjects.Query().Include(s => s.Major).ThenInclude(m => m!.Faculty).AsQueryable();
        if (isAdmin) return query;

        var professorProfile = await _users.GetProfessorProfileAsync(userId);
        if (professorProfile == null) return query.Where(s => false);
        return query.Where(s => s.Major != null && s.Major.FacultyId == professorProfile.FacultyId);
    }

    private async Task<(List<Faculty> Faculties, List<Major> Majors)> GetIndexFiltersAsync(string userId, bool isAdmin, int? facultyId)
    {
        if (isAdmin)
        {
            var faculties = await _majors.QueryFaculties().AsNoTracking().Where(f => !f.IsDeleted).OrderBy(f => f.Name).ToListAsync();
            var majors = await _majors.Query().Include(m => m.Faculty).AsNoTracking()
                .Where(m => !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
                .OrderBy(m => m.Faculty!.Name).ThenBy(m => m.Name).ToListAsync();
            return (faculties, majors);
        }

        var visibleSubjects = await GetVisibleSubjectsQueryAsync(userId, isAdmin);
        var facultyIds = await visibleSubjects.Where(s => s.Major != null).Select(s => s.Major!.FacultyId).Distinct().ToListAsync();
        var visibleFaculties = await _majors.QueryFaculties().AsNoTracking().Where(f => facultyIds.Contains(f.Id) && !f.IsDeleted).OrderBy(f => f.Name).ToListAsync();
        var visibleMajors = await _majors.Query().Include(m => m.Faculty).AsNoTracking()
            .Where(m => facultyIds.Contains(m.FacultyId) && !m.IsDeleted && (facultyId == null || m.FacultyId == facultyId.Value))
            .OrderBy(m => m.Name).ToListAsync();
        return (visibleFaculties, visibleMajors);
    }

    private async Task SyncPrerequisitesAsync(int subjectId, List<PrerequisiteInlineViewModel> prerequisites)
    {
        var selectedIds = prerequisites.Select(p => p.RequiredSubjectId).Where(id => id > 0 && id != subjectId).Distinct().ToList();
        selectedIds = await _subjects.Query().Where(s => selectedIds.Contains(s.Id) && !s.IsDeleted).Select(s => s.Id).ToListAsync();
        var existing = await _subjects.GetPrerequisitesAsync(subjectId);

        foreach (var prerequisite in existing.Where(p => !selectedIds.Contains(p.RequiredSubjectId)))
            _subjects.RemovePrerequisite(prerequisite);

        var existingIds = existing.Select(p => p.RequiredSubjectId).ToHashSet();
        foreach (var requiredSubjectId in selectedIds.Where(id => !existingIds.Contains(id)))
            _subjects.AddPrerequisite(new PrerequisiteSubject { SubjectId = subjectId, RequiredSubjectId = requiredSubjectId });
    }
}
