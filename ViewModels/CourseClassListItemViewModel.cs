namespace StudentPortal.Mvc.ViewModels;

public class CourseClassListItemViewModel
{
    public int Id { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public string SemesterName { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public string Schedule => $"Thứ {(int)DayOfWeek + 1}, Tiết {StartPeriod} - {EndPeriod}";
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }
    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
    public bool IsFull => EnrolledCount >= Capacity;
    
    // --- THÊM 2 DÒNG NÀY ĐỂ FIX LỖI ---
    public bool IsDeleted { get; set; }
    public bool CanManage { get; set; }
    public bool CanTeach { get; set; }
    public bool IsAssignedProfessor { get; set; }
}
