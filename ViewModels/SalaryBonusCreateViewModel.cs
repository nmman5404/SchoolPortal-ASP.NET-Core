using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class SalaryBonusCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng chọn nhân sự / sinh viên.")]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

    [Required]
    public DateTime EndDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);

    [Required(ErrorMessage = "Vui lòng nhập số tiền.")]
    [Range(100000, 500000000, ErrorMessage = "Số tiền phải từ 100,000 đến 500,000,000 VNĐ")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập lý do (VD: Học bổng, Lương tháng...)")]
    [MaxLength(500)]
    public string Note { get; set; } = string.Empty;
}