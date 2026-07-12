using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class Notification
{
    public int Id { get; set; }
    
    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Content { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // --- CÁC TIÊU CHÍ GỬI THÔNG BÁO (Tất cả đều cho phép Null) ---
    // Nếu tất cả là Null -> Thông báo chung toàn trường
    public string? TargetRole { get; set; } // Gửi cho: Student, Professor, Worker...
    public int? TargetFacultyId { get; set; } // Gửi cho 1 Khoa cụ thể
    public int? TargetMajorId { get; set; } // Gửi cho 1 Ngành cụ thể
    public string? TargetUserId { get; set; } // Gửi đích danh 1 người (Theo Id)
}