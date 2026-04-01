using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenguinStreamerBot.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScAiResponseCodes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    PreviousResponseId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScAiResponseCodes", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScAiResponseCodes_UserId",
                table: "ScAiResponseCodes",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScAiResponseCodes");
        }
    }
}
