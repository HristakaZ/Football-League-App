using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FootballLeagues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballLeagues", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FootballTeams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Stadium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FootballLeagueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballTeams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FootballTeams_FootballLeagues_FootballLeagueID",
                        column: x => x.FootballLeagueID,
                        principalTable: "FootballLeagues",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FootballMatches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostID = table.Column<int>(type: "int", nullable: false),
                    VisitorID = table.Column<int>(type: "int", nullable: false),
                    ScheduledDateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballMatches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FootballMatches_FootballTeams_HostID",
                        column: x => x.HostID,
                        principalTable: "FootballTeams",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FootballMatches_FootballTeams_VisitorID",
                        column: x => x.VisitorID,
                        principalTable: "FootballTeams",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FootballPlayers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FootballTeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPlayers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FootballPlayers_FootballTeams_FootballTeamID",
                        column: x => x.FootballTeamID,
                        principalTable: "FootballTeams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssisterID = table.Column<int>(type: "int", nullable: false),
                    FootballMatchID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assists_FootballMatches_FootballMatchID",
                        column: x => x.FootballMatchID,
                        principalTable: "FootballMatches",
                        principalColumn: "ID");
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
                    GoalscorerID = table.Column<int>(type: "int", nullable: false),
                    FootballMatchID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Goals_FootballMatches_FootballMatchID",
                        column: x => x.FootballMatchID,
                        principalTable: "FootballMatches",
                        principalColumn: "ID");
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
                name: "IX_FootballMatches_HostID",
                table: "FootballMatches",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_FootballMatches_VisitorID",
                table: "FootballMatches",
                column: "VisitorID");

            migrationBuilder.CreateIndex(
                name: "IX_FootballPlayers_FootballTeamID",
                table: "FootballPlayers",
                column: "FootballTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_FootballTeams_FootballLeagueID",
                table: "FootballTeams",
                column: "FootballLeagueID");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_FootballMatchID",
                table: "Goals",
                column: "FootballMatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GoalscorerID",
                table: "Goals",
                column: "GoalscorerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assists");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "FootballMatches");

            migrationBuilder.DropTable(
                name: "FootballPlayers");

            migrationBuilder.DropTable(
                name: "FootballTeams");

            migrationBuilder.DropTable(
                name: "FootballLeagues");
        }
    }
}
