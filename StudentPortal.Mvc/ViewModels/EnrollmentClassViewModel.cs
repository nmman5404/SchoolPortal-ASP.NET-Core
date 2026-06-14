namespace StudentPortal.Mvc.ViewModels;

public class EnrollmentClassViewModel
{
    public int ClassId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public int Credits { get; set; }
    public string Room { get; set; } = string.Empty;
    public string Schedule => $"Thứ {(int)DayOfWeek + 1}, Tiết {StartPeriod} - {EndPeriod}";
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }
    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
    public string RowVersion { get; set; } = string.Empty;
    
    // Trạng thái hiển thị nút bấm
    public bool IsEnrolled { get; set; }
    public bool IsFull => EnrolledCount >= Capacity;
}