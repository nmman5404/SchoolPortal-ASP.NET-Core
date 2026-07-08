using Microsoft.AspNetCore.Identity;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Repositories;

public interface IUserRepository
{
    IQueryable<ApplicationUser> QueryUsers(bool includeDeleted = false);
    Task<ApplicationUser?> FindByIdAsync(string id);
    Task<ApplicationUser?> FindByIdIncludingDeletedAsync(string id);
    Task<IList<string>> GetRolesAsync(ApplicationUser user);
    Task<bool> IsInRoleAsync(ApplicationUser user, string role);
    Task<IList<ApplicationUser>> GetUsersInRoleAsync(string role);
    Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
    Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
    Task<IdentityResult> UpdateAsync(ApplicationUser user);
    Task<IdentityResult> SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd);
    Task<StudentProfile?> GetStudentProfileAsync(string userId, bool includeLookups = false);
    Task<ProfessorProfile?> GetProfessorProfileAsync(string userId, bool includeLookups = false);
    Task<WorkerProfile?> GetWorkerProfileAsync(string userId);
    void AddStudentProfile(StudentProfile profile);
    void AddProfessorProfile(ProfessorProfile profile);
    void AddWorkerProfile(WorkerProfile profile);
    Task SaveChangesAsync();
}
