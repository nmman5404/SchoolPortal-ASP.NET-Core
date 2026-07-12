using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class ProfessorProfile
{
    [Key]
    public string UserId { get; set; } = string.Empty; 
    public ApplicationUser? User { get; set; }

    public int FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    // Một giảng viên có thể dạy nhiều lớp
    public ICollection<ClassProfessor> TeachingClasses { get; set; } = new List<ClassProfessor>();
}