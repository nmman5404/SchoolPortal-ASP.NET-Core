using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public record ServiceResult(bool Success, string? Message = null, bool NotFound = false, bool AccessDenied = false, bool ConcurrencyConflict = false)
{
    public static ServiceResult Ok(string? message = null) => new(true, message);
    public static ServiceResult Fail(string message) => new(false, message);
    public static ServiceResult Missing(string? message = null) => new(false, message, NotFound: true);
    public static ServiceResult Denied(string? message = null) => new(false, message, AccessDenied: true);
    public static ServiceResult Concurrency(string message) => new(false, message, ConcurrencyConflict: true);
}

public record LookupOption(int Id, string Name);
public record UserLookupOption(string Id, string FullName, string? Email);

public record SubjectIndexData(
    List<SubjectListItemViewModel> Subjects,
    List<Faculty> Faculties,
    List<Major> Majors,
    bool CanCreateSubject);

public record SubjectFormLists(List<LookupOption> Majors, List<LookupOption> PrerequisiteSubjects);
public record SubjectSaveResult(ServiceResult Result, SubjectFormLists? FormLists = null);

public record CourseClassIndexData(
    List<CourseClassListItemViewModel> Classes,
    List<Faculty> Faculties,
    List<Major> Majors,
    List<Semester> Semesters,
    bool CanCreateClass);

public record CourseClassFormLists(List<LookupOption> Subjects, List<Semester> Semesters);
public record CourseClassSaveResult(ServiceResult Result, CourseClassFormLists? FormLists = null);

public record GradeClassData(CourseClass CourseClass, List<Grade> Grades);

public record NotificationFormLists(List<Faculty> Faculties, List<Major> Majors, List<UserLookupOption> Users);

public record SalaryBonusIndexData(
    List<SalaryBonusListItemViewModel> Bonuses,
    List<Faculty> Faculties,
    List<Major> Majors,
    bool IsAdmin);

public record DashboardData(
    List<Notification> Notifications,
    bool IsFacultyHeadMaster,
    bool IsMajorHeadMaster,
    int TotalStudents,
    int TotalProfs,
    int TotalClasses,
    List<Grade> MyClasses,
    double GPA,
    List<ClassProfessor> TeachingClasses,
    List<SalaryBonus> MyBonuses);
