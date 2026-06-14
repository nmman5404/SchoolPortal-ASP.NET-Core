using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaryBonusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_AspNetUsers_HeadMasterId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_AspNetUsers_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_CourseClasses_CourseClassId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CourseClasses");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundDate",
                table: "Majors",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HeadMasterId",
                table: "Majors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "CourseClasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndPeriod",
                table: "CourseClasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "CourseClasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartPeriod",
                table: "CourseClasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PrerequisiteSubjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredSubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrerequisiteSubjects", x => new { x.SubjectId, x.RequiredSubjectId });
                    table.ForeignKey(
                        name: "FK_PrerequisiteSubjects_Subjects_RequiredSubjectId",
                        column: x => x.RequiredSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrerequisiteSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorProfiles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ProfessorProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorProfiles_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryBonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryBonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryBonuses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsRegistrationOpen = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    FacultyId = table.Column<int>(type: "INTEGER", nullable: false),
                    MajorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_Majors_MajorId",
                        column: x => x.MajorId,
                        principalTable: "Majors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkerProfiles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    JobDescription = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerProfiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_WorkerProfiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassProfessors",
                columns: table => new
                {
                    CourseClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfessorId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassProfessors", x => new { x.CourseClassId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_ClassProfessors_CourseClasses_CourseClassId",
                        column: x => x.CourseClassId,
                        principalTable: "CourseClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassProfessors_ProfessorProfiles_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "ProfessorProfiles",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Majors_HeadMasterId",
                table: "Majors",
                column: "HeadMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId_CourseClassId",
                table: "Grades",
                columns: new[] { "StudentId", "CourseClassId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseClasses_SemesterId",
                table: "CourseClasses",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassProfessors_ProfessorId",
                table: "ClassProfessors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrerequisiteSubjects_RequiredSubjectId",
                table: "PrerequisiteSubjects",
                column: "RequiredSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorProfiles_FacultyId",
                table: "ProfessorProfiles",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryBonuses_UserId",
                table: "SalaryBonuses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_FacultyId",
                table: "StudentProfiles",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_MajorId",
                table: "StudentProfiles",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseClasses_Semesters_SemesterId",
                table: "CourseClasses",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_ProfessorProfiles_HeadMasterId",
                table: "Faculties",
                column: "HeadMasterId",
                principalTable: "ProfessorProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_CourseClasses_CourseClassId",
                table: "Grades",
                column: "CourseClassId",
                principalTable: "CourseClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_StudentProfiles_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "StudentProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Majors_ProfessorProfiles_HeadMasterId",
                table: "Majors",
                column: "HeadMasterId",
                principalTable: "ProfessorProfiles",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseClasses_Semesters_SemesterId",
                table: "CourseClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_ProfessorProfiles_HeadMasterId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_CourseClasses_CourseClassId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_StudentProfiles_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Majors_ProfessorProfiles_HeadMasterId",
                table: "Majors");

            migrationBuilder.DropTable(
                name: "ClassProfessors");

            migrationBuilder.DropTable(
                name: "PrerequisiteSubjects");

            migrationBuilder.DropTable(
                name: "SalaryBonuses");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "StudentProfiles");

            migrationBuilder.DropTable(
                name: "WorkerProfiles");

            migrationBuilder.DropTable(
                name: "ProfessorProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Majors_HeadMasterId",
                table: "Majors");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId_CourseClassId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_CourseClasses_SemesterId",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "FoundDate",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "HeadMasterId",
                table: "Majors");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "EndPeriod",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "CourseClasses");

            migrationBuilder.DropColumn(
                name: "StartPeriod",
                table: "CourseClasses");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Grades",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "CourseClasses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CourseClasses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_AspNetUsers_HeadMasterId",
                table: "Faculties",
                column: "HeadMasterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_AspNetUsers_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_CourseClasses_CourseClassId",
                table: "Grades",
                column: "CourseClassId",
                principalTable: "CourseClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
