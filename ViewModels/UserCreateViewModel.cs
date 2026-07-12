using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class UserCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập Email")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập Mật khẩu")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 ký tự")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng xác nhận Mật khẩu")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp!")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập Họ Tên")]
    public string FullName { get; set; } = string.Empty;

    // --- CÁC TRƯỜNG MỚI THÊM VÀO ĐÂY ---
    [Required(ErrorMessage = "Vui lòng nhập Mã định danh (PID)")]
    public string PID { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn Ngày sinh")]
    public DateTime Dob { get; set; } = new DateTime(2000, 1, 1);

    [Required(ErrorMessage = "Vui lòng chọn Vai trò")]
    public string Role { get; set; } = string.Empty; 

    // Các trường Optional (Có dấu ?)
    public int? FacultyId { get; set; }
    public int? MajorId { get; set; }
    public string? Department { get; set; }
    public string? JobDescription { get; set; } // Dành cho Worker
}