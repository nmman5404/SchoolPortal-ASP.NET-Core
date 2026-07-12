namespace StudentPortal.Mvc.ViewModels;

public class TranscriptViewModel
{
    public string StudentName { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public string MajorName { get; set; } = string.Empty;
    
    // Danh sách các môn đã học
    public List<GradeItemViewModel> Grades { get; set; } = new List<GradeItemViewModel>();

    // Tính toán GPA hệ 4.0 động (On-the-fly) - Yêu cầu trong Master Plan
    public double TotalGPA 
    {
        get 
        {
            var gradedItems = Grades.Where(g => g.Score.HasValue).ToList();
            if (!gradedItems.Any()) return 0;

            double totalPoints = gradedItems.Sum(g => g.Score!.Value * g.Credits);
            int totalCredits = gradedItems.Sum(g => g.Credits);
            
            return totalCredits == 0 ? 0 : Math.Round(totalPoints / totalCredits, 2);
        }
    }
}

public class GradeItemViewModel
{
    public int GradeId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public int Credits { get; set; }
    public float? Score { get; set; }
    public string? Note { get; set; }
    public string SemesterName { get; set; } = string.Empty;
}