using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class AuditLog
{
    public int Id { get; set; }
    public string Action { get; set; } = string.Empty; // VD: Login, UpdateGrade, DeleteClass
    public string EntityName { get; set; } = string.Empty;
    public string? EntityId { get; set; }
    public string? UserName { get; set; } // Ai làm
    public string? IpAddress { get; set; }
    public string Result { get; set; } = "Success";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? Note { get; set; }
}