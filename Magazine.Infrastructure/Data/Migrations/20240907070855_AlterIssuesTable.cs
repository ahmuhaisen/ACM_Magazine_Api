using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterIssuesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Issues",
                newName: "NumberOfArticles");

            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                table: "Issues",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DirectorNote",
                table: "Issues",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlipHtmlUrl",
                table: "Issues",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectorNote",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "FlipHtmlUrl",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "NumberOfArticles",
                table: "Issues",
                newName: "Year");

            migrationBuilder.AlterColumn<string>(
                name: "CoverImageUrl",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CoverImageUrl", "Description", "Number", "PublishedAt", "Title", "Year" },
                values: new object[] { 1, "issues-covers/16.png", "2024 issue highlights cybersecurity trends, challenges, and expert insights", 16, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyber Security", 2024 });
        }
    }
}
