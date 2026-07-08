using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Services;

public interface INotificationService
{
    Task<NotificationFormLists> GetFormListsAsync();
    Task<ServiceResult> CreateAsync(Notification model);
    Task<List<Notification>> GetVisibleNotificationsAsync(ApplicationUser user, IList<string> roles);
    Task<ServiceResult> DismissAsync(int id, string userId);
}
