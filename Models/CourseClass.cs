using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.Models;

public class CourseClass
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public int SemesterId { get; set; }
    public Semester? Semester { get; set; }

    [Required, MaxLength(50)]
    public string Room { get; set; } = string.Empty;

    // Quản lý lịch học thực tế để check trùng (Ví dụ: DayOfWeek = 2 (Thứ 2), StartPeriod = 1, EndPeriod = 3)
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; } // Tiết bắt đầu (1-12)
    public int EndPeriod { get; set; } // Tiết kết thúc (1-12)

    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
    public bool IsDeleted { get; set; }

    public byte[] RowVersion { get; set; } = Array.Empty<byte>(); // Chống đụng độ khi Đăng ký môn

    public ICollection<ClassProfessor> ClassProfessors { get; set; } = new List<ClassProfessor>();
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
