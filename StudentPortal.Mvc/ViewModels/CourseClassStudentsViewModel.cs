namespace StudentPortal.Mvc.ViewModels;

public class CourseClassStudentsViewModel
{
    public int ClassId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public string SemesterName { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public DayOfWeek DayOfWeek { get; set; }
    public int StartPeriod { get; set; }
    public int EndPeriod { get; set; }
    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsFull => EnrolledCount >= Capacity;
    public string Schedule => $"Thứ {(int)DayOfWeek + 1}, Tiết {StartPeriod} - {EndPeriod}";

    public List<CourseClassStudentItemViewModel> Students { get; set; } = new();
    public List<CourseClassStudentOptionViewModel> CandidateStudents { get; set; } = new();
}

public class CourseClassStudentItemViewModel
{
    public string StudentId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PID { get; set; } = string.Empty;
    public string MajorName { get; set; } = string.Empty;
    public float? Score { get; set; }
}

public class CourseClassStudentOptionViewModel
{
    public string StudentId { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PID { get; set; } = string.Empty;
}
