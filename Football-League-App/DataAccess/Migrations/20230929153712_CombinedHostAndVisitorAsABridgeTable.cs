using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CombinedHostAndVisitorAsABridgeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FootballTeams_FootballMatches_FootballMatchID",
                table: "FootballTeams");

            migrationBuilder.DropIndex(
                name: "IX_FootballTeams_FootballMatchID",
                table: "FootballTeams");

            migrationBuilder.DropColumn(
                name: "FootballMatchID",
                table: "FootballTeams");

            migrationBuilder.CreateTable(
                name: "FootballMatchFootballTeam",
                columns: table => new
                {
                    FootballMatchesID = table.Column<int>(type: "int", nullable: false),
                    FootballTeamsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballMatchFootballTeam", x => new { x.FootballMatchesID, x.FootballTeamsID });
                    table.ForeignKey(
                        name: "FK_FootballMatchFootballTeam_FootballMatches_FootballMatchesID",
                        column: x => x.FootballMatchesID,
                        principalTable: "FootballMatches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FootballMatchFootballTeam_FootballTeams_FootballTeamsID",
                        column: x => x.FootballTeamsID,
                        principalTable: "FootballTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FootballMatchFootballTeam_FootballTeamsID",
                table: "FootballMatchFootballTeam",
                column: "FootballTeamsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballMatchFootballTeam");

            migrationBuilder.AddColumn<int>(
                name: "FootballMatchID",
                table: "FootballTeams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootballTeams_FootballMatchID",
                table: "FootballTeams",
                column: "FootballMatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_FootballTeams_FootballMatches_FootballMatchID",
                table: "FootballTeams",
                column: "FootballMatchID",
                principalTable: "FootballMatches",
                principalColumn: "ID");
        }
    }
}
