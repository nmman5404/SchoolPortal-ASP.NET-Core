using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class Semester
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty; // VD: Học kỳ 1 (2026-2027)
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    // Quyền lực của Admin: Bật/Tắt đợt đăng ký môn học
    public bool IsRegistrationOpen { get; set; } 
    
    public ICollection<CourseClass> CourseClasses { get; set; } = new List<CourseClass>();
}