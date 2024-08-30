using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVolunteersRolesToContributions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteersRoles");

            migrationBuilder.CreateTable(
                name: "Contributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<byte>(type: "tinyint", nullable: false),
                    IssueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributions_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contributions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contributions_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_IssueId",
                table: "Contributions",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_RoleId",
                table: "Contributions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_VolunteerId",
                table: "Contributions",
                column: "VolunteerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contributions");

            migrationBuilder.CreateTable(
                name: "VolunteersRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<byte>(type: "tinyint", nullable: false),
                    VolunteerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteersRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteersRoles_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteersRoles_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersRoles_IssueId",
                table: "VolunteersRoles",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersRoles_RoleId",
                table: "VolunteersRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersRoles_VolunteerId",
                table: "VolunteersRoles",
                column: "VolunteerId");
        }
    }
}
