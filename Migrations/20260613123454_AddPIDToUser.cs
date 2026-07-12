using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddPIDToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PID",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PID",
                table: "AspNetUsers");
        }
    }
}
