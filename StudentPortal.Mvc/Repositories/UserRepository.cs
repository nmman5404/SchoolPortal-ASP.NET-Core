using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IQueryable<ApplicationUser> QueryUsers(bool includeDeleted = false)
    {
        var query = includeDeleted ? _context.Users.IgnoreQueryFilters() : _context.Users;
        return query.AsQueryable();
    }

    public Task<ApplicationUser?> FindByIdAsync(string id) => _userManager.FindByIdAsync(id);

    public Task<ApplicationUser?> FindByIdIncludingDeletedAsync(string id) =>
        _context.Users.IgnoreQueryFilters().FirstOrDefaultAsync(u => u.Id == id);

    public Task<IList<string>> GetRolesAsync(ApplicationUser user) => _userManager.GetRolesAsync(user);
    public Task<bool> IsInRoleAsync(ApplicationUser user, string role) => _userManager.IsInRoleAsync(user, role);
    public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string role) => _userManager.GetUsersInRoleAsync(role);
    public Task<IdentityResult> CreateAsync(ApplicationUser user, string password) => _userManager.CreateAsync(user, password);
    public Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role) => _userManager.AddToRoleAsync(user, role);
    public Task<IdentityResult> UpdateAsync(ApplicationUser user) => _userManager.UpdateAsync(user);
    public Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd) => _userManager.SetLockoutEndDateAsync(user, lockoutEnd);

    public async Task<StudentProfile?> GetStudentProfileAsync(string userId, bool includeLookups = false)
    {
        var query = _context.StudentProfiles.AsQueryable();
        if (includeLookups) query = query.Include(p => p.Faculty).Include(p => p.Major);
        return await query.FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task<ProfessorProfile?> GetProfessorProfileAsync(string userId, bool includeLookups = false)
    {
        var query = _context.ProfessorProfiles.AsQueryable();
        if (includeLookups) query = query.Include(p => p.Faculty);
        return await query.FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public Task<WorkerProfile?> GetWorkerProfileAsync(string userId) =>
        _context.WorkerProfiles.FirstOrDefaultAsync(p => p.UserId == userId);

    public void AddStudentProfile(StudentProfile profile) => _context.StudentProfiles.Add(profile);
    public void AddProfessorProfile(ProfessorProfile profile) => _context.ProfessorProfiles.Add(profile);
    public void AddWorkerProfile(WorkerProfile profile) => _context.WorkerProfiles.Add(profile);
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
