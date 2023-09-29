using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assists");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "FootballMatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "FootballMatches");

            migrationBuilder.CreateTable(
                name: "Assists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssisterID = table.Column<int>(type: "int", nullable: false),
                    FootballMatchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assists_FootballMatches_FootballMatchID",
                        column: x => x.FootballMatchID,
                        principalTable: "FootballMatches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assists_FootballPlayers_AssisterID",
                        column: x => x.AssisterID,
                        principalTable: "FootballPlayers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FootballMatchID = table.Column<int>(type: "int", nullable: false),
                    GoalscorerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Goals_FootballMatches_FootballMatchID",
                        column: x => x.FootballMatchID,
                        principalTable: "FootballMatches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_FootballPlayers_GoalscorerID",
                        column: x => x.GoalscorerID,
                        principalTable: "FootballPlayers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assists_AssisterID",
                table: "Assists",
                column: "AssisterID");

            migrationBuilder.CreateIndex(
                name: "IX_Assists_FootballMatchID",
                table: "Assists",
                column: "FootballMatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_FootballMatchID",
                table: "Goals",
                column: "FootballMatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalscorerID",
                table: "Goals",
                column: "GoalscorerID");
        }
    }
}
