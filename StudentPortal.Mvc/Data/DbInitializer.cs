using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Mvc.Models;

namespace StudentPortal.Mvc.Data;

public static class DbInitializer
{
    public static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        await EnsureConcurrencyTokensAsync(context);

        // 1. Tạo các Vai trò (Roles)
        string[] roles = { "Admin", "Professor", "Student", "Worker" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // 2. Tạo Tài khoản mẫu
        await SeedUserAsync(userManager, "admin@portal.com", "Admin@123", "Admin", "Nguyễn Quản Trị");
        await SeedUserAsync(userManager, "prof@portal.com", "Prof@123", "Professor", "PGS.TS. Trần Giảng Viên");
        await SeedUserAsync(userManager, "student@portal.com", "Student@123", "Student", "Lê Học Sinh");
        await SeedUserAsync(userManager, "worker@portal.com", "Worker@123", "Worker", "Phạm Giáo Vụ");

        // 3. Tạo Dữ liệu Cấu trúc đào tạo (Khoa, Ngành, Profile, Môn học, Lớp học)
        if (!context.Faculties.Any())
        {
            var adminUser = await userManager.FindByEmailAsync("admin@portal.com");
            var profUser = await userManager.FindByEmailAsync("prof@portal.com");
            var studentUser = await userManager.FindByEmailAsync("student@portal.com");
            var workerUser = await userManager.FindByEmailAsync("worker@portal.com");

            // Tạo Khoa và Ngành
            var faculty = new Faculty { Name = "Khoa Công nghệ Thông tin", HeadMasterId = profUser?.Id, FoundDate = new DateTime(2000, 1, 1) };
            context.Faculties.Add(faculty);
            await context.SaveChangesAsync();

            var major = new Major { Name = "Kỹ thuật Phần mềm", FacultyId = faculty.Id, HeadMasterId = profUser?.Id };
            context.Majors.Add(major);
            await context.SaveChangesAsync();

            // Tạo Hồ sơ (Profile) cho từng User liên kết với Khoa/Ngành
            if (!context.ProfessorProfiles.Any(p => p.UserId == profUser!.Id))
            {
                context.ProfessorProfiles.Add(new ProfessorProfile { UserId = profUser!.Id, FacultyId = faculty.Id });
                context.StudentProfiles.Add(new StudentProfile { UserId = studentUser!.Id, FacultyId = faculty.Id, MajorId = major.Id });
                context.WorkerProfiles.Add(new WorkerProfile { UserId = workerUser!.Id, Department = "Phòng Đào tạo", JobDescription = "Giáo vụ khoa" });
                await context.SaveChangesAsync();
            }

            // Tạo Môn học & Học kỳ
            var subject = new Subject { Name = "Lập trình Web ASP.NET Core MVC", Credits = 4, MajorId = major.Id };
            context.Subjects.Add(subject);

            var semester = new Semester { Name = "Học kỳ 1 (2026-2027)", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(4), IsRegistrationOpen = true };
            context.Semesters.Add(semester);
            await context.SaveChangesAsync();

            // Tạo Lớp học
            var courseClass = new CourseClass { 
                SubjectId = subject.Id, 
                SemesterId = semester.Id, 
                Room = "A1-101", 
                Capacity = 50, 
                DayOfWeek = DayOfWeek.Monday, 
                StartPeriod = 1, 
                EndPeriod = 3,
                RowVersion = Guid.NewGuid().ToByteArray()
            };
            context.CourseClasses.Add(courseClass);
            await context.SaveChangesAsync();

            // QUAN TRỌNG: Phân công Giảng viên dạy Lớp này
            context.ClassProfessors.Add(new ClassProfessor { CourseClassId = courseClass.Id, ProfessorId = profUser!.Id });
            await context.SaveChangesAsync();
        }
    }

    private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string email, string password, string role, string fullName)
    {
        if (await userManager.FindByEmailAsync(email) == null)
        {
            var user = new ApplicationUser { UserName = email, Email = email, EmailConfirmed = true, FullName = fullName };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
    }

    private static async Task EnsureConcurrencyTokensAsync(ApplicationDbContext context)
    {
        await context.Database.ExecuteSqlRawAsync(
            "UPDATE CourseClasses SET RowVersion = randomblob(16) WHERE RowVersion IS NULL OR length(RowVersion) = 0");
        await context.Database.ExecuteSqlRawAsync(
            "UPDATE Grades SET RowVersion = randomblob(16) WHERE RowVersion IS NULL OR length(RowVersion) = 0");
    }
}
