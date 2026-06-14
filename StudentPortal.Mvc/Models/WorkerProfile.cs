using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class WorkerProfile
{
    [Key]
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    [MaxLength(100)]
    public string Department { get; set; } = string.Empty; // Phòng ban
    
    [MaxLength(255)]
    public string JobDescription { get; set; } = string.Empty; // Mô tả công việc
}