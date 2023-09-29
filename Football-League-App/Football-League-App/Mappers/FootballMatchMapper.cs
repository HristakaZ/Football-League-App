using DataStructure.Models;
using Football_League_App.DTOs.FootballMatch;
using Football_League_App.DTOs.FootballTeam;

namespace Football_League_App.Mappers
{
    public class FootballMatchMapper
    {
        public static List<GetFootballMatchDTO> MapFootballMatchToGetFootballMatchDTO(IQueryable<FootballMatch> footballMatches)
        {
            List<GetFootballMatchDTO> getFootballMatchDTOs = new List<GetFootballMatchDTO>();

            foreach (FootballMatch footballMatch in footballMatches)
            {
                getFootballMatchDTOs.Add(new GetFootballMatchDTO()
                {
                    Host = FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballMatch.FootballTeams[0]),
                    Visitor = FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballMatch.FootballTeams[1]),
                    ScheduledDateAndTime = footballMatch.ScheduledDateAndTime,
                    Result = footballMatch.EndResult
                });
            }

            return getFootballMatchDTOs;
        }

        public static GetFootballMatchDTO MapFootballMatchToGetFootballMatchDTO(FootballMatch footballMatch)
        {
            return new GetFootballMatchDTO()
            {
                Host = FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballMatch.FootballTeams[0]),
                Visitor = FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballMatch.FootballTeams[1]),
                ScheduledDateAndTime = footballMatch.ScheduledDateAndTime,
                Result = footballMatch.EndResult
            };
        }

        public static FootballMatch MapCreateFootballMatchDTOToModel(CreateFootballMatchDTO createFootballMatchDTO,
            List<FootballTeam> footballTeams)
        {
            return new FootballMatch()
            {
                FootballTeams = footballTeams,
                ScheduledDateAndTime = createFootballMatchDTO.ScheduledDateAndTime,
                EndResult = createFootballMatchDTO.EndResult ?? "0-0"
            };
        }

        public static FootballMatch MapUpdateFootballTeamDTOToModel(UpdateFootballMatchDTO updateFootballMatchDTO,
            List<FootballTeam> footballTeams,
            FootballMatch model)
        {
            model.ScheduledDateAndTime = updateFootballMatchDTO.ScheduledDateAndTime;
            model.FootballTeams = footballTeams;
            model.EndResult = updateFootballMatchDTO.EndResult ?? "0-0";

            return model;
        }
    }
}
