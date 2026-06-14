using System.ComponentModel.DataAnnotations;
namespace StudentPortal.Mvc.Models;

public class Major
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateTime FoundDate { get; set; }
    public bool IsDeleted { get; set; }

    public int FacultyId { get; set; }
    public Faculty? Faculty { get; set; }

    // Trưởng ngành
    public string? HeadMasterId { get; set; }
    public ProfessorProfile? HeadMaster { get; set; }

    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}