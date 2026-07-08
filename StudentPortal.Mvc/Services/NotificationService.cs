using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;

namespace StudentPortal.Mvc.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notifications;
    private readonly IMajorRepository _majors;
    private readonly IUserRepository _users;

    public NotificationService(INotificationRepository notifications, IMajorRepository majors, IUserRepository users)
    {
        _notifications = notifications;
        _majors = majors;
        _users = users;
    }

    public async Task<NotificationFormLists> GetFormListsAsync()
    {
        var faculties = await _majors.QueryFaculties().AsNoTracking().OrderBy(f => f.Name).ToListAsync();
        var majors = await _majors.Query().AsNoTracking().OrderBy(m => m.Name).ToListAsync();
        var users = await _users.QueryUsers().AsNoTracking().OrderBy(u => u.FullName)
            .Select(u => new UserLookupOption(u.Id, u.FullName, u.Email))
            .ToListAsync();
        return new NotificationFormLists(faculties, majors, users);
    }

    public async Task<ServiceResult> CreateAsync(Notification model)
    {
        model.TargetRole = string.IsNullOrWhiteSpace(model.TargetRole) ? null : model.TargetRole;
        model.TargetUserId = string.IsNullOrWhiteSpace(model.TargetUserId) ? null : model.TargetUserId;

        if (model.TargetFacultyId.HasValue && model.TargetMajorId.HasValue &&
            !await _majors.MajorBelongsToFacultyAsync(model.TargetMajorId.Value, model.TargetFacultyId.Value))
            return ServiceResult.Fail("TargetMajorId|Ngành nhận thông báo phải thuộc khoa đã chọn.");

        model.CreatedAt = DateTime.Now;
        _notifications.Add(model);
        await _notifications.SaveChangesAsync();
        return ServiceResult.Ok("Đã gửi thông báo thành công!");
    }

    public async Task<List<Notification>> GetVisibleNotificationsAsync(ApplicationUser user, IList<string> roles)
    {
        int? myFacultyId = null;
        int? myMajorId = null;
        var userRole = roles.FirstOrDefault() ?? "";
        if (userRole == "Student")
        {
            var profile = await _users.GetStudentProfileAsync(user.Id);
            myFacultyId = profile?.FacultyId;
            myMajorId = profile?.MajorId;
        }
        else if (userRole == "Professor")
        {
            var profile = await _users.GetProfessorProfileAsync(user.Id);
            myFacultyId = profile?.FacultyId;
        }

        var dismissedIds = await _notifications.QueryUserNotifications()
            .Where(un => un.UserId == user.Id && un.IsDismissed)
            .Select(un => un.NotificationId)
            .ToListAsync();

        return await _notifications.Query()
            .AsNoTracking()
            .Where(n => !dismissedIds.Contains(n.Id))
            .Where(n => n.CreatedAt >= user.EntryDate)
            .Where(n =>
                (!string.IsNullOrEmpty(n.TargetUserId) && n.TargetUserId == user.Id) ||
                (string.IsNullOrEmpty(n.TargetUserId) &&
                 (string.IsNullOrEmpty(n.TargetRole) || roles.Contains(n.TargetRole)) &&
                 (n.TargetFacultyId == null || n.TargetFacultyId == myFacultyId) &&
                 (n.TargetMajorId == null || n.TargetMajorId == myMajorId)))
            .OrderByDescending(n => n.CreatedAt)
            .Take(5)
            .ToListAsync();
    }

    public async Task<ServiceResult> DismissAsync(int id, string userId)
    {
        var exists = await _notifications.QueryUserNotifications().AnyAsync(un => un.NotificationId == id && un.UserId == userId);
        if (!exists)
        {
            _notifications.AddUserNotification(new UserNotification { NotificationId = id, UserId = userId, IsDismissed = true });
            await _notifications.SaveChangesAsync();
        }

        return ServiceResult.Ok();
    }
}
