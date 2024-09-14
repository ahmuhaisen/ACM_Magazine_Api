using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNumberOfArticlesFromIssues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfArticles",
                table: "Issues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfArticles",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
