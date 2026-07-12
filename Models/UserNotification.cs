namespace StudentPortal.Mvc.Models;
public class UserNotification
{
    public int NotificationId { get; set; }
    public Notification? Notification { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public bool IsDismissed { get; set; } // Đánh dấu User đã bấm xóa thông báo này
}