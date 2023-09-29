using DataStructure.Models;
using Football_League_App.DTOs.FootballLeague;

namespace Football_League_App.Mappers
{
    public static class FootballLeagueMapper
    {
        public static FootballLeague MapCreateFootballLeagueDTOToModel(CreateFootballLeagueDTO createFootballLeagueDTO)
        {
            return new FootballLeague()
            {
                Name = createFootballLeagueDTO.Name
            };
        }

        public static List<GetFootballLeagueDTO> MapFootballTeamToGetFootballTeamDTO(IQueryable<FootballLeague> footballLeagues)
        {
            List<GetFootballLeagueDTO> getFootballLeagueDTOs = new List<GetFootballLeagueDTO>();
            foreach (FootballLeague footballLeague in footballLeagues)
            {
                getFootballLeagueDTOs.Add(new GetFootballLeagueDTO()
                {
                    Name = footballLeague.Name,
                    FootballTeams = FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballLeague.FootballTeams.AsQueryable())
                });
            }

            return getFootballLeagueDTOs;
        }

        public static GetFootballLeagueDTO MapFootballTeamToGetFootballTeamDTO(FootballLeague footballLeague)
        {
            return new GetFootballLeagueDTO()
            {
                Name = footballLeague.Name,
                FootballTeams = FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballLeague.FootballTeams.AsQueryable())
            };
        }
    }
}
