using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public interface ICourseClassService
{
    Task<CourseClassIndexData> GetClassesAsync(string userId, bool isAdmin, bool isProfessor, int? facultyId, int? majorId, int? semesterId);
    Task<CourseClassFormLists> GetFormListsAsync(string userId, bool isAdmin);
    Task<CourseClassEditViewModel?> GetClassForEditAsync(int id, string userId, bool isAdmin);
    Task<bool> CheckCanManageClassAsync(int subjectId, string userId, bool isAdmin);
    Task<CourseClassSaveResult> SaveClassAsync(CourseClassEditViewModel model, string userId, bool isAdmin);
    Task<CourseClassStudentsViewModel?> GetStudentsAsync(int classId, string userId, bool isAdmin);
    Task<ServiceResult> AddStudentAsync(int classId, string studentId, bool isAdmin);
    Task<ServiceResult> RemoveStudentAsync(int classId, string studentId, bool isAdmin);
    Task<ServiceResult> ToggleDeleteAsync(int id, bool restore, string userId, bool isAdmin);
    Task<ServiceResult> AssignProfessorAsync(int classId, string professorId);
    Task<ServiceResult> UnassignProfessorAsync(int classId, string professorId);
    Task<List<object>> SearchAsync(string keyword);
}
