using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class Grade
{
    public int Id { get; set; }
    
    public string StudentId { get; set; } = string.Empty;
    public StudentProfile? Student { get; set; }

    public int CourseClassId { get; set; }
    public CourseClass? CourseClass { get; set; }

    public float? Score { get; set; } // Lúc đăng ký môn thì Score = null. Có điểm mới nhập.
    [MaxLength(255)]
    public string? Note { get; set; }

    public byte[] RowVersion { get; set; } = Array.Empty<byte>(); // Chống 2 giảng viên cùng sửa điểm 1 lúc
}
