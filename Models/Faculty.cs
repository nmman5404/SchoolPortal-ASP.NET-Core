using System.ComponentModel.DataAnnotations;
namespace StudentPortal.Mvc.Models;

public class Faculty
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateTime FoundDate { get; set; }
    public bool IsDeleted { get; set; }

    // Trưởng khoa (FK trỏ về ProfessorProfile)
    public string? HeadMasterId { get; set; }
    public ProfessorProfile? HeadMaster { get; set; }

    public ICollection<Major> Majors { get; set; } = new List<Major>();
}
