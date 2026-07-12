using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Mvc.Models;

public class SalaryBonus
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty; // FK trỏ về ApplicationUser (PID trong Master Plan)
    public ApplicationUser? User { get; set; }

    // Khoảng thời gian tính lương / học bổng
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Kiểu decimal bắt buộc dùng cho tiền bạc
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [MaxLength(500)]
    public string Note { get; set; } = string.Empty; // Ghi chú: Học bổng kỳ 1, Lương tháng 6, Thưởng KPI...

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Không được phép xóa cứng dữ liệu tài chính, chỉ Xóa mềm
    public bool IsDeleted { get; set; } 
}