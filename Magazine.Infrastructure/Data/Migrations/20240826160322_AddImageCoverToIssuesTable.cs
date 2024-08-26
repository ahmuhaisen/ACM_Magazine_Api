using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageCoverToIssuesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Issues",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoverImageUrl",
                value: "issues-covers/16.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Issues");
        }
    }
}
