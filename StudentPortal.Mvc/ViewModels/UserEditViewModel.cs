
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class UserEditViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty; // Chỉ đọc
    public string Role { get; set; } = string.Empty;  // Chỉ đọc

    [Required(ErrorMessage = "Vui lòng nhập Họ Tên")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập Mã định danh (PID)")]
    public string PID { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn Ngày sinh")]
    public DateTime Dob { get; set; }

    // Các trường Profile (Ẩn hiện tùy Role)
    public int? FacultyId { get; set; }
    public int? MajorId { get; set; }
    public string? Department { get; set; }
    public string? JobDescription { get; set; }
}