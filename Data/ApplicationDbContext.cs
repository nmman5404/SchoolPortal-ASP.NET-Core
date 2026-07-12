using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<ProfessorProfile> ProfessorProfiles => Set<ProfessorProfile>();
    public DbSet<WorkerProfile> WorkerProfiles => Set<WorkerProfile>();
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Major> Majors => Set<Major>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Semester> Semesters => Set<Semester>();
    public DbSet<CourseClass> CourseClasses => Set<CourseClass>();
    public DbSet<ClassProfessor> ClassProfessors => Set<ClassProfessor>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<PrerequisiteSubject> PrerequisiteSubjects => Set<PrerequisiteSubject>();
    public DbSet<SalaryBonus> SalaryBonuses => Set<SalaryBonus>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<UserNotification> UserNotifications => Set<UserNotification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // 1. Cấu hình Profile 1-1 với ApplicationUser
        builder.Entity<StudentProfile>().HasOne(s => s.User).WithOne(u => u.StudentProfile).HasForeignKey<StudentProfile>(s => s.UserId);
        builder.Entity<ProfessorProfile>().HasOne(p => p.User).WithOne(u => u.ProfessorProfile).HasForeignKey<ProfessorProfile>(p => p.UserId);
        builder.Entity<WorkerProfile>().HasOne(w => w.User).WithOne(u => u.WorkerProfile).HasForeignKey<WorkerProfile>(w => w.UserId);

        // 2. Chống lỗi Cascade Delete (Khóa ngoại vòng lặp) khi Trưởng khoa/Trưởng ngành bị xóa
        builder.Entity<Faculty>().HasOne(f => f.HeadMaster).WithMany().HasForeignKey(f => f.HeadMasterId).OnDelete(DeleteBehavior.SetNull);
        builder.Entity<Major>().HasOne(m => m.HeadMaster).WithMany().HasForeignKey(m => m.HeadMasterId).OnDelete(DeleteBehavior.SetNull);

        // 3. Khóa chính Composite cho các bảng trung gian (M-N)
        builder.Entity<ClassProfessor>().HasKey(cp => new { cp.CourseClassId, cp.ProfessorId });
        builder.Entity<PrerequisiteSubject>().HasKey(ps => new { ps.SubjectId, ps.RequiredSubjectId });
        builder.Entity<UserNotification>().HasKey(un => new { un.NotificationId, un.UserId });

        // Cấu hình bảng Đệ quy (Môn học Tiên quyết)
        builder.Entity<PrerequisiteSubject>()
            .HasOne(ps => ps.Subject)
            .WithMany(s => s.Prerequisites)
            .HasForeignKey(ps => ps.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Entity<PrerequisiteSubject>()
            .HasOne(ps => ps.RequiredSubject)
            .WithMany()
            .HasForeignKey(ps => ps.RequiredSubjectId)
            .OnDelete(DeleteBehavior.Restrict); // Không được phép xóa môn A nếu môn B đang bắt buộc học môn A

        // 4. Đảm bảo 1 Học sinh chỉ có 1 điểm duy nhất cho 1 Lớp
        builder.Entity<Grade>().HasIndex(g => new { g.StudentId, g.CourseClassId }).IsUnique();

        // 5. Cấu hình Concurrency cho SQLite
        builder.Entity<CourseClass>().Property(c => c.RowVersion)
            .IsRequired()
            .IsConcurrencyToken()
            .ValueGeneratedNever();
        builder.Entity<Grade>().Property(g => g.RowVersion)
            .IsRequired()
            .IsConcurrencyToken()
            .ValueGeneratedNever();

        // 6. Global Query Filters (Soft Delete)
        builder.Entity<ApplicationUser>().HasQueryFilter(u => !u.IsDeleted);
        builder.Entity<Faculty>().HasQueryFilter(f => !f.IsDeleted);
        builder.Entity<Major>().HasQueryFilter(m => !m.IsDeleted);
        builder.Entity<Subject>().HasQueryFilter(s => !s.IsDeleted);
        builder.Entity<CourseClass>().HasQueryFilter(c => !c.IsDeleted);
        builder.Entity<SalaryBonus>().HasQueryFilter(s => !s.IsDeleted);
    }
}
