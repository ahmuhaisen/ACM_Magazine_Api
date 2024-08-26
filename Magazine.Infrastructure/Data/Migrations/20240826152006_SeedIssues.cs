using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedIssues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "Description", "Number", "PublishedAt", "Title", "Year" },
                values: new object[] { 1, "2024 issue highlights cybersecurity trends, challenges, and expert insights", 16, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyber Security", 2024 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
