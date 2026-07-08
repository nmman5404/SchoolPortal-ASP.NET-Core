using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Repositories;

public interface ISubjectRepository
{
    IQueryable<Subject> Query(bool includeDeleted = false);
    IQueryable<PrerequisiteSubject> QueryPrerequisites();
    Task<Subject?> GetByIdAsync(int id, bool includeDeleted = false, bool includePrerequisites = false);
    void Add(Subject subject);
    void AddPrerequisite(PrerequisiteSubject prerequisite);
    void RemovePrerequisite(PrerequisiteSubject prerequisite);
    Task<List<PrerequisiteSubject>> GetPrerequisitesAsync(int subjectId);
    Task<List<string>> GetActiveDependentSubjectNamesAsync(int requiredSubjectId);
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task SaveChangesAsync();
}

public class SubjectRepository : ISubjectRepository
{
    private readonly ApplicationDbContext _context;
    public SubjectRepository(ApplicationDbContext context) => _context = context;

    public IQueryable<Subject> Query(bool includeDeleted = false) =>
        (includeDeleted ? _context.Subjects.IgnoreQueryFilters() : _context.Subjects).AsQueryable();

    public IQueryable<PrerequisiteSubject> QueryPrerequisites() => _context.PrerequisiteSubjects.AsQueryable();

    public async Task<Subject?> GetByIdAsync(int id, bool includeDeleted = false, bool includePrerequisites = false)
    {
        var query = Query(includeDeleted);
        if (includePrerequisites) query = query.Include(s => s.Prerequisites);
        return await query.FirstOrDefaultAsync(s => s.Id == id);
    }

    public void Add(Subject subject) => _context.Subjects.Add(subject);
    public void AddPrerequisite(PrerequisiteSubject prerequisite) => _context.PrerequisiteSubjects.Add(prerequisite);
    public void RemovePrerequisite(PrerequisiteSubject prerequisite) => _context.PrerequisiteSubjects.Remove(prerequisite);
    public Task<List<PrerequisiteSubject>> GetPrerequisitesAsync(int subjectId) => _context.PrerequisiteSubjects.Where(p => p.SubjectId == subjectId).ToListAsync();

    public Task<List<string>> GetActiveDependentSubjectNamesAsync(int requiredSubjectId) =>
        _context.PrerequisiteSubjects
            .Join(
                _context.Subjects.IgnoreQueryFilters(),
                prerequisite => prerequisite.SubjectId,
                subject => subject.Id,
                (prerequisite, subject) => new { prerequisite, subject })
            .Where(x => x.prerequisite.RequiredSubjectId == requiredSubjectId && !x.subject.IsDeleted)
            .Select(x => x.subject.Name)
            .Distinct()
            .OrderBy(name => name)
            .ToListAsync();

    public Task<IDbContextTransaction> BeginTransactionAsync() => _context.Database.BeginTransactionAsync();
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}

public interface ICourseClassRepository
{
    IQueryable<CourseClass> Query(bool includeDeleted = false);
    IQueryable<ClassProfessor> QueryClassProfessors();
    Task<CourseClass?> GetByIdAsync(int id, bool includeDeleted = false);
    Task<CourseClass?> GetForStudentManagementAsync(int id);
    void Add(CourseClass courseClass);
    void AddClassProfessor(ClassProfessor assignment);
    void RemoveClassProfessor(ClassProfessor assignment);
    void SetOriginalRowVersion(CourseClass courseClass, byte[] rowVersion);
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task SaveChangesAsync();
}

public class CourseClassRepository : ICourseClassRepository
{
    private readonly ApplicationDbContext _context;
    public CourseClassRepository(ApplicationDbContext context) => _context = context;

    public IQueryable<CourseClass> Query(bool includeDeleted = false) =>
        (includeDeleted ? _context.CourseClasses.IgnoreQueryFilters() : _context.CourseClasses).AsQueryable();

    public IQueryable<ClassProfessor> QueryClassProfessors() => _context.ClassProfessors.AsQueryable();

    public Task<CourseClass?> GetByIdAsync(int id, bool includeDeleted = false) =>
        Query(includeDeleted).FirstOrDefaultAsync(c => c.Id == id);

    public Task<CourseClass?> GetForStudentManagementAsync(int id) =>
        Query(includeDeleted: true)
            .Include(c => c.Subject).ThenInclude(s => s!.Major).ThenInclude(m => m!.Faculty)
            .Include(c => c.Semester)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

    public void Add(CourseClass courseClass) => _context.CourseClasses.Add(courseClass);
    public void AddClassProfessor(ClassProfessor assignment) => _context.ClassProfessors.Add(assignment);
    public void RemoveClassProfessor(ClassProfessor assignment) => _context.ClassProfessors.Remove(assignment);
    public void SetOriginalRowVersion(CourseClass courseClass, byte[] rowVersion) => _context.Entry(courseClass).Property(c => c.RowVersion).OriginalValue = rowVersion;
    public Task<IDbContextTransaction> BeginTransactionAsync() => _context.Database.BeginTransactionAsync();
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}

public interface IGradeRepository
{
    IQueryable<Grade> Query();
    Task<Grade?> GetByIdAsync(int id);
    void Add(Grade grade);
    void Remove(Grade grade);
    void SetOriginalRowVersion(Grade grade, byte[] rowVersion);
    Task SaveChangesAsync();
}

public class GradeRepository : IGradeRepository
{
    private readonly ApplicationDbContext _context;
    public GradeRepository(ApplicationDbContext context) => _context = context;

    public IQueryable<Grade> Query() => _context.Grades.AsQueryable();
    public Task<Grade?> GetByIdAsync(int id) => _context.Grades.FirstOrDefaultAsync(g => g.Id == id);
    public void Add(Grade grade) => _context.Grades.Add(grade);
    public void Remove(Grade grade) => _context.Grades.Remove(grade);
    public void SetOriginalRowVersion(Grade grade, byte[] rowVersion) => _context.Entry(grade).Property(g => g.RowVersion).OriginalValue = rowVersion;
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}

public interface ISemesterRepository
{
    IQueryable<Semester> Query();
    Task<Semester?> GetByIdAsync(int id);
    void Add(Semester semester);
    Task SaveChangesAsync();
}

public class SemesterRepository : ISemesterRepository
{
    private readonly ApplicationDbContext _context;
    public SemesterRepository(ApplicationDbContext context) => _context = context;
    public IQueryable<Semester> Query() => _context.Semesters.AsQueryable();
    public Task<Semester?> GetByIdAsync(int id) => _context.Semesters.FindAsync(id).AsTask();
    public void Add(Semester semester) => _context.Semesters.Add(semester);
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}

public interface IMajorRepository
{
    IQueryable<Major> Query(bool includeDeleted = false);
    IQueryable<Faculty> QueryFaculties(bool includeDeleted = false);
    Task<bool> MajorBelongsToFacultyAsync(int majorId, int facultyId);
}

public class MajorRepository : IMajorRepository
{
    private readonly ApplicationDbContext _context;
    public MajorRepository(ApplicationDbContext context) => _context = context;

    public IQueryable<Major> Query(bool includeDeleted = false) =>
        (includeDeleted ? _context.Majors.IgnoreQueryFilters() : _context.Majors).AsQueryable();

    public IQueryable<Faculty> QueryFaculties(bool includeDeleted = false) =>
        (includeDeleted ? _context.Faculties.IgnoreQueryFilters() : _context.Faculties).AsQueryable();

    public Task<bool> MajorBelongsToFacultyAsync(int majorId, int facultyId) =>
        _context.Majors.AnyAsync(m => m.Id == majorId && m.FacultyId == facultyId);
}
