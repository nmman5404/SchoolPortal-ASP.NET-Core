namespace StudentPortal.Mvc.ViewModels;

public class UserListItemViewModel
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string ProfileInfo { get; set; } = string.Empty; // Chứa tên Khoa/Ngành/Phòng ban
    public bool IsDeleted { get; set; }
}