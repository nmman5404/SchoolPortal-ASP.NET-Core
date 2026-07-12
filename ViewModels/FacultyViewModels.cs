using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class FacultyListItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string HeadMasterName { get; set; } = string.Empty;
    public string FoundDateText { get; set; } = string.Empty;
    public int TotalMajors { get; set; }
    public bool IsDeleted { get; set; }
}

public class FacultyCreateEditViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập tên Khoa")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public DateTime FoundDate { get; set; } = DateTime.Now;
    public string? HeadMasterId { get; set; } 
    
    // DANH SÁCH CÁC NGÀNH NẰM TRONG KHOA (Inline Form)
    public List<MajorInlineViewModel> Majors { get; set; } = new List<MajorInlineViewModel>();
}

public class MajorInlineViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? HeadMasterId { get; set; }
}