namespace StudentPortal.Mvc.ViewModels;

public class ScheduleClassViewModel
{
    public int ClassId { get; set; }
    public string SemesterName { get; set; } = string.Empty;
    public string SubjectName { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }
    public string Schedule => $"Thứ {(int)DayOfWeek + 1}, Tiết {StartPeriod} - {EndPeriod}";
    public string PeopleText { get; set; } = string.Empty;
}
