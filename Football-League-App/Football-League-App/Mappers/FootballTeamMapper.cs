using DataStructure.Models;
using Football_League_App.DTOs.FootballTeam;

namespace Football_League_App.Mappers
{
    public static class FootballTeamMapper
    {
        public static FootballTeam MapCreateFootballTeamDTOToModel(CreateFootballTeamDTO createFootballTeamDTO,
            FootballLeague footballLeague)
        {
            return new FootballTeam()
            {
                Name = createFootballTeamDTO.Name,
                Points = createFootballTeamDTO.Points,
                Stadium = createFootballTeamDTO.Stadium,
                FootballLeague = footballLeague
            };
        }

        public static FootballTeam MapUpdateFootballTeamDTOToModel(UpdateFootballTeamDTO updateFootballTeamDTO,
            FootballLeague footballLeague,
            FootballTeam model)
        {
            model.Name = updateFootballTeamDTO.Name;
            model.Points = updateFootballTeamDTO.Points;
            model.Stadium = updateFootballTeamDTO.Stadium;
            model.FootballLeague = footballLeague;

            return model;
        }

        public static GetFootballTeamDTO MapFootballTeamToGetFootballTeamDTO(FootballTeam footballTeam)
        {
            return new GetFootballTeamDTO()
            {
                ID = footballTeam.ID,
                Name = footballTeam.Name,
                Points = footballTeam.Points,
                Stadium = footballTeam.Stadium
            };
        }

        public static List<GetFootballTeamDTO> MapFootballTeamToGetFootballTeamDTO(IQueryable<FootballTeam> footballTeams)
        {
            List<GetFootballTeamDTO> getFootballTeamDTOs = new List<GetFootballTeamDTO>();

            foreach (FootballTeam footballTeam in footballTeams)
            {
                getFootballTeamDTOs.Add(new GetFootballTeamDTO()
                {
                    ID = footballTeam.ID,
                    Name = footballTeam.Name,
                    Points = footballTeam.Points,
                    Stadium = footballTeam.Stadium
                });
            }

            return getFootballTeamDTOs;
        }
    }
}
