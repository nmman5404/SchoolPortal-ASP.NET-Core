namespace StudentPortal.Mvc.ViewModels;

public class SalaryBonusListItemViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public string FacultyName { get; set; } = string.Empty;
    public string MajorName { get; set; } = string.Empty;
    public string Period => $"{StartDate:dd/MM/yyyy} - {EndDate:dd/MM/yyyy}";
    public string AmountText => $"{Amount:N0} VNĐ";
    public string Note { get; set; } = string.Empty;
    public string CreatedAtText { get; set; } = string.Empty;
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }
}
