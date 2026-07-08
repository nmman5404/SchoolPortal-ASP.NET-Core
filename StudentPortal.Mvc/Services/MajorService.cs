using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;
using StudentPortal.Mvc.ViewModels;

namespace StudentPortal.Mvc.Services;

public class MajorService : IMajorService
{
    private readonly IMajorRepository _majors;
    private readonly ISubjectRepository _subjects;

    public MajorService(IMajorRepository majors, ISubjectRepository subjects)
    {
        _majors = majors;
        _subjects = subjects;
    }

    public async Task<(ServiceResult Result, List<Major> ManagedMajors, int? SelectedMajorId, string? MajorName, List<MajorManagementRowViewModel> Rows)> GetManagementAsync(string userId, int? majorId)
    {
        var managedMajors = await _majors.Query()
            .Include(m => m.Faculty)
            .AsNoTracking()
            .Where(m => m.HeadMasterId == userId && !m.IsDeleted)
            .OrderBy(m => m.Name)
            .ToListAsync();

        if (!managedMajors.Any())
            return (ServiceResult.Denied(), managedMajors, null, null, new List<MajorManagementRowViewModel>());

        var selectedMajorId = majorId.HasValue && managedMajors.Any(m => m.Id == majorId.Value) ? majorId.Value : managedMajors.First().Id;
        var majorName = managedMajors.First(m => m.Id == selectedMajorId).Name;

        var subjects = await _subjects.Query()
            .Include(s => s.CourseClasses).ThenInclude(c => c.Semester)
            .Include(s => s.CourseClasses).ThenInclude(c => c.ClassProfessors).ThenInclude(cp => cp.Professor).ThenInclude(p => p!.User)
            .Include(s => s.CourseClasses).ThenInclude(c => c.Grades).ThenInclude(g => g.Student).ThenInclude(s => s!.User)
            .AsNoTracking()
            .Where(s => s.MajorId == selectedMajorId && !s.IsDeleted)
            .OrderBy(s => s.Name)
            .ToListAsync();

        var rows = new List<MajorManagementRowViewModel>();
        foreach (var subject in subjects)
        {
            var activeClasses = subject.CourseClasses.Where(c => !c.IsDeleted).OrderBy(c => c.Semester?.StartDate).ThenBy(c => c.DayOfWeek).ToList();
            if (!activeClasses.Any())
            {
                rows.Add(new MajorManagementRowViewModel { SubjectId = subject.Id, SubjectName = subject.Name, Credits = subject.Credits, ClassCount = 0 });
                continue;
            }

            foreach (var courseClass in activeClasses)
            {
                rows.Add(new MajorManagementRowViewModel
                {
                    SubjectId = subject.Id,
                    SubjectName = subject.Name,
                    Credits = subject.Credits,
                    ClassCount = activeClasses.Count,
                    ClassId = courseClass.Id,
                    SemesterName = courseClass.Semester?.Name ?? "N/A",
                    Room = courseClass.Room,
                    Schedule = $"Thứ {(int)courseClass.DayOfWeek + 1}, Tiết {courseClass.StartPeriod} - {courseClass.EndPeriod}",
                    ProfessorsText = string.Join(", ", courseClass.ClassProfessors.Select(cp => cp.Professor?.User?.FullName).Where(n => !string.IsNullOrWhiteSpace(n))),
                    StudentCount = courseClass.Grades.Count,
                    StudentsText = string.Join("; ", courseClass.Grades.Select(g => $"{g.Student?.User?.FullName}: {(g.Score.HasValue ? g.Score.Value.ToString("0.0") : "Chưa có điểm")}"))
                });
            }
        }

        return (ServiceResult.Ok(), managedMajors, selectedMajorId, majorName, rows);
    }
}
