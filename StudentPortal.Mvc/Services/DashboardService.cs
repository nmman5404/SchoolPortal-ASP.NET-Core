using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;

namespace StudentPortal.Mvc.Services;

public class DashboardService : IDashboardService
{
    private readonly INotificationService _notificationService;
    private readonly IUserRepository _users;
    private readonly ICourseClassRepository _classes;
    private readonly IGradeRepository _grades;
    private readonly ISalaryBonusRepository _bonuses;
    private readonly IMajorRepository _majors;

    public DashboardService(INotificationService notificationService, IUserRepository users, ICourseClassRepository classes, IGradeRepository grades, ISalaryBonusRepository bonuses, IMajorRepository majors)
    {
        _notificationService = notificationService;
        _users = users;
        _classes = classes;
        _grades = grades;
        _bonuses = bonuses;
        _majors = majors;
    }

    public async Task<DashboardData> GetDashboardAsync(ApplicationUser user, IList<string> roles)
    {
        var userRole = roles.FirstOrDefault() ?? "";
        var notifications = await _notificationService.GetVisibleNotificationsAsync(user, roles);
        var isFacultyHeadMaster = false;
        var isMajorHeadMaster = false;
        var totalStudents = 0;
        var totalProfs = 0;
        var totalClasses = 0;
        var myClasses = new List<Grade>();
        var gpa = 0d;
        var teachingClasses = new List<ClassProfessor>();
        var myBonuses = new List<SalaryBonus>();

        if (userRole == "Admin")
        {
            totalStudents = (await _users.GetUsersInRoleAsync("Student")).Count;
            totalProfs = (await _users.GetUsersInRoleAsync("Professor")).Count;
            totalClasses = await _classes.Query().CountAsync(c => !c.IsDeleted);
        }
        else if (userRole == "Student")
        {
            myClasses = await _grades.Query()
                .Include(g => g.CourseClass).ThenInclude(c => c!.Subject)
                .Where(g => g.StudentId == user.Id)
                .AsNoTracking()
                .ToListAsync();
            var graded = myClasses.Where(g => g.Score.HasValue).ToList();
            gpa = graded.Any() ? Math.Round(graded.Average(g => g.Score!.Value), 2) : 0;
        }
        else if (userRole == "Professor")
        {
            isFacultyHeadMaster = await _majors.QueryFaculties().AnyAsync(f => f.HeadMasterId == user.Id && !f.IsDeleted);
            isMajorHeadMaster = await _majors.Query().AnyAsync(m => m.HeadMasterId == user.Id && !m.IsDeleted);
            teachingClasses = await _classes.QueryClassProfessors()
                .Include(cp => cp.CourseClass).ThenInclude(c => c!.Subject)
                .Where(cp => cp.ProfessorId == user.Id)
                .AsNoTracking()
                .ToListAsync();
        }
        else if (userRole == "Worker")
        {
            myBonuses = await _bonuses.Query()
                .Where(sb => sb.UserId == user.Id)
                .OrderByDescending(sb => sb.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        return new DashboardData(notifications, isFacultyHeadMaster, isMajorHeadMaster, totalStudents, totalProfs, totalClasses, myClasses, gpa, teachingClasses, myBonuses);
    }
}
