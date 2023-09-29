using DataStructure.Models;
using Football_League_App.DTOs.FootballTeam;

namespace Football_League_App.DTOs.FootballMatch
{
    public class GetFootballMatchDTO
    {
        public GetFootballTeamDTO Host { get; set; }

        public GetFootballTeamDTO Visitor { get; set; }

        public DateTime ScheduledDateAndTime { get; set; }

        public string Result { get; set; }
    }
}
