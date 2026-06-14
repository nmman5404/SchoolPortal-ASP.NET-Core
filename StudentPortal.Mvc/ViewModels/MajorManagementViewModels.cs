namespace StudentPortal.Mvc.ViewModels;

public class MajorManagementRowViewModel
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int ClassCount { get; set; }
    public int? ClassId { get; set; }
    public string SemesterName { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
    public string ProfessorsText { get; set; } = string.Empty;
    public int StudentCount { get; set; }
    public string StudentsText { get; set; } = string.Empty;
}
