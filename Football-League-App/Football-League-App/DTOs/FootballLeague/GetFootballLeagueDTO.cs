using Football_League_App.DTOs.FootballTeam;

namespace Football_League_App.DTOs.FootballLeague
{
    public class GetFootballLeagueDTO
    {
        public string Name { get; set; }

        public List<GetFootballTeamDTO> FootballTeams { get; set; } = new List<GetFootballTeamDTO>();
    }
}
