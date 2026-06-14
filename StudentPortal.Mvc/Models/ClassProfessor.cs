namespace StudentPortal.Mvc.Models;
public class ClassProfessor
{
    public int CourseClassId { get; set; }
    public CourseClass? CourseClass { get; set; }

    public string ProfessorId { get; set; } = string.Empty;
    public ProfessorProfile? Professor { get; set; }
}