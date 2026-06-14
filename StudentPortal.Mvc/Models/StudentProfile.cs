using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class StudentProfile
{
    [Key]
    public string UserId { get; set; } = string.Empty; // PK kiêm luôn FK liên kết 1-1 với ApplicationUser
    public ApplicationUser? User { get; set; }

    public int FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    public int MajorId { get; set; }
    public Major? Major { get; set; }

    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}