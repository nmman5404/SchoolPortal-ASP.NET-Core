using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Services;

public interface IDashboardService
{
    Task<DashboardData> GetDashboardAsync(ApplicationUser user, IList<string> roles);
}
