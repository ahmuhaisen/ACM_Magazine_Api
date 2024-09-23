using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "security",
                table: "Users",
                newName: "UniversityId");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "security",
                table: "Users",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UniversityId",
                schema: "security",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                schema: "security",
                table: "Users",
                newName: "FirstName");
        }
    }
}
