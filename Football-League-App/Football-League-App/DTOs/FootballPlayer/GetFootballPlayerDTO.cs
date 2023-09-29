using Football_League_App.DTOs.FootballTeam;

namespace Football_League_App.DTOs.FootballPlayer
{
    public class GetFootballPlayerDTO
    {
        public string Name { get; set; }

        public GetFootballTeamDTO FootballTeam { get; set; }
    }
}
