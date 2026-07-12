using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class CourseClassEditViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn môn học")]
    public int SubjectId { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn học kỳ")]
    public int SemesterId { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập phòng học")]
    public string Room { get; set; } = string.Empty;

    public DayOfWeek DayOfWeek { get; set; }

    [Range(1, 15, ErrorMessage = "Tiết học phải từ 1 đến 15")]
    public int StartPeriod { get; set; }

    [Range(1, 15, ErrorMessage = "Tiết học phải từ 1 đến 15")]
    public int EndPeriod { get; set; }

    [Range(1, 200, ErrorMessage = "Sĩ số phải từ 1 đến 200")]
    public int Capacity { get; set; }

    public string? RowVersion { get; set; } // Chống đụng độ
}