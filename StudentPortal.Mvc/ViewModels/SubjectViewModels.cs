using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Mvc.ViewModels;

public class SubjectListItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; }
    public string MajorName { get; set; } = string.Empty;
    public string FacultyName { get; set; } = string.Empty;
    public string PrerequisitesText { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    
    // Biến cờ: Báo cho View biết User hiện tại có quyền Sửa/Xóa môn này không
    public bool CanManage { get; set; } 
}

public class SubjectCreateEditViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên Môn học")]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập số tín chỉ")]
    [Range(1, 10, ErrorMessage = "Tín chỉ phải từ 1 đến 10")]
    public int Credits { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn Ngành học")]
    public int MajorId { get; set; }

    public List<PrerequisiteInlineViewModel> Prerequisites { get; set; } = new();
}

public class PrerequisiteInlineViewModel
{
    public int RequiredSubjectId { get; set; }
}
