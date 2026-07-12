using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class ApplicationUser : IdentityUser
{
    [Required, MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string? PID { get; set; } 

    public DateTime? Dob { get; set; }
    [MaxLength(255)]
    public string? AvatarUrl { get; set; } 
    public DateTime EntryDate { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; }

    // Navigation Properties (1 User chỉ có thể là 1 trong 3 Profile này)
    public StudentProfile? StudentProfile { get; set; }
    public ProfessorProfile? ProfessorProfile { get; set; }
    public WorkerProfile? WorkerProfile { get; set; }
}