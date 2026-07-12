using System.ComponentModel.DataAnnotations;
namespace StudentPortal.Mvc.Models;

public class Subject
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; } // Số tín chỉ

    public int MajorId { get; set; }
    public Major? Major { get; set; }
    public bool IsDeleted { get; set; }

    // Danh sách các môn yêu cầu phải học trước môn này
    public ICollection<PrerequisiteSubject> Prerequisites { get; set; } = new List<PrerequisiteSubject>();
    public ICollection<CourseClass> CourseClasses { get; set; } = new List<CourseClass>();
}
