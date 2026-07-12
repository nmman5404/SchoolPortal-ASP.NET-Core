using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Data;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Repositories;

public interface INotificationRepository
{
    IQueryable<Notification> Query();
    IQueryable<UserNotification> QueryUserNotifications();
    void Add(Notification notification);
    void AddUserNotification(UserNotification userNotification);
    Task SaveChangesAsync();
}

public class NotificationRepository : INotificationRepository
{
    private readonly ApplicationDbContext _context;
    public NotificationRepository(ApplicationDbContext context) => _context = context;
    public IQueryable<Notification> Query() => _context.Notifications.AsQueryable();
    public IQueryable<UserNotification> QueryUserNotifications() => _context.UserNotifications.AsQueryable();
    public void Add(Notification notification) => _context.Notifications.Add(notification);
    public void AddUserNotification(UserNotification userNotification) => _context.UserNotifications.Add(userNotification);
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}

public interface ISalaryBonusRepository
{
    IQueryable<SalaryBonus> Query(bool includeDeleted = false);
    void Add(SalaryBonus salaryBonus);
    Task SaveChangesAsync();
}

public class SalaryBonusRepository : ISalaryBonusRepository
{
    private readonly ApplicationDbContext _context;
    public SalaryBonusRepository(ApplicationDbContext context) => _context = context;
    public IQueryable<SalaryBonus> Query(bool includeDeleted = false) =>
        (includeDeleted ? _context.SalaryBonuses.IgnoreQueryFilters() : _context.SalaryBonuses).AsQueryable();
    public void Add(SalaryBonus salaryBonus) => _context.SalaryBonuses.Add(salaryBonus);
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}

public interface IAuditLogRepository
{
    void Add(AuditLog log);
    Task SaveChangesAsync();
}

public class AuditLogRepository : IAuditLogRepository
{
    private readonly ApplicationDbContext _context;
    public AuditLogRepository(ApplicationDbContext context) => _context = context;
    public void Add(AuditLog log) => _context.AuditLogs.Add(log);
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
