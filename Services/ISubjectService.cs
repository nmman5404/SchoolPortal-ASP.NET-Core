using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public interface ISubjectService
{
    Task<SubjectIndexData> GetSubjectsAsync(string userId, bool isAdmin, string? keyword, int? facultyId, int? majorId, bool showDeleted);
    Task<SubjectFormLists> GetFormListsAsync(string userId, bool isAdmin, int? currentSubjectId = null);
    Task<SubjectCreateEditViewModel?> GetSubjectForEditAsync(int id, string userId, bool isAdmin);
    Task<bool> CheckCanManageSubjectAsync(int majorId, string userId, bool isAdmin);
    Task<SubjectSaveResult> SaveSubjectAsync(SubjectCreateEditViewModel model, string userId, bool isAdmin);
    Task<ServiceResult> ToggleDeleteAsync(int id, bool restore, string userId, bool isAdmin);
}
