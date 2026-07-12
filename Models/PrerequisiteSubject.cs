namespace StudentPortal.Mvc.Models;
public class PrerequisiteSubject
{
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }

    public int RequiredSubjectId { get; set; }
    public Subject? RequiredSubject { get; set; }
}