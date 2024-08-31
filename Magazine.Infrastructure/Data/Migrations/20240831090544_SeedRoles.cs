using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Magazine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name", "isUnique" },
                values: new object[,]
                {
                    { (byte)1, "Oversees the entire publication process and team.", "Director", true },
                    { (byte)2, "Responsible for the overall editorial direction and content quality.", "EditorInChief", true }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { (byte)3, "Creates the visual design and layout for the publication.", "Designer" },
                    { (byte)4, "Assists with editing and content management.", "EditorialAssistant" },
                    { (byte)5, "Writes articles or content on a regular basis.", "ContributingWriter" },
                    { (byte)6, "Contributes content occasionally, usually for special topics.", "GuestWriter" },
                    { (byte)7, "Provides narration or voiceovers for the podcast version.", "VoiceOver" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)7);
        }
    }
}
