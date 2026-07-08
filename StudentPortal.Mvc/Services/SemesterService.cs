using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;
using StudentPortal.Mvc.Repositories;

namespace StudentPortal.Mvc.Services;

public class SemesterService : ISemesterService
{
    private readonly ISemesterRepository _semesters;
    public SemesterService(ISemesterRepository semesters) => _semesters = semesters;

    public Task<List<Semester>> GetSemestersAsync() =>
        _semesters.Query().AsNoTracking().OrderByDescending(s => s.StartDate).ToListAsync();

    public async Task<ServiceResult> CreateAsync(string name, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(name)) return ServiceResult.Fail("Ten hoc ky khong hop le.");
        _semesters.Add(new Semester { Name = name, StartDate = startDate, EndDate = endDate, IsRegistrationOpen = false });
        await _semesters.SaveChangesAsync();
        return ServiceResult.Ok("Da them Hoc ky moi thanh cong!");
    }

    public async Task<ServiceResult> ToggleRegistrationAsync(int id)
    {
        var semester = await _semesters.GetByIdAsync(id);
        if (semester == null) return ServiceResult.Missing();

        semester.IsRegistrationOpen = !semester.IsRegistrationOpen;
        await _semesters.SaveChangesAsync();
        return ServiceResult.Ok(semester.IsRegistrationOpen ? $"Da MO dang ky cho {semester.Name}" : $"Da DONG dang ky cho {semester.Name}");
    }
}
