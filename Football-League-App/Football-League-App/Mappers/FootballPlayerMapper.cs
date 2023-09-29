using DataStructure.Models;
using Football_League_App.DTOs.FootballPlayer;

namespace Football_League_App.Mappers
{
    public static class FootballPlayerMapper
    {
        public static List<GetFootballPlayerDTO> MapFootballPlayerModelToGetFootballPlayerDTO(IQueryable<FootballPlayer> footballPlayers)
        {
            List<GetFootballPlayerDTO> getFootballPlayerDTOs = new List<GetFootballPlayerDTO>();

            foreach (FootballPlayer footballPlayer in footballPlayers)
            {
                getFootballPlayerDTOs.Add(new GetFootballPlayerDTO()
                {
                    Name = footballPlayer.Name,
                    FootballTeam = FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballPlayer.FootballTeam)
                });
            }

            return getFootballPlayerDTOs;
        }

        public static GetFootballPlayerDTO MapFootballPlayerModelToGetFootballPlayerDTO(FootballPlayer footballPlayer)
        {
            return new GetFootballPlayerDTO()
            {
                Name = footballPlayer.Name,
                FootballTeam = FootballTeamMapper.MapFootballTeamToGetFootballTeamDTO(footballPlayer.FootballTeam)
            };
        }

        public static FootballPlayer MapCreateFootballPlayerDTOToModel(CreateFootballPlayerDTO createFootballPlayerDTO,
            FootballTeam footballTeam)
        {
            return new FootballPlayer()
            {
                Name = createFootballPlayerDTO.Name,
                FootballTeam = footballTeam
            };
        }

        public static FootballPlayer MapUpdateFootballPlayerDTOToModel(UpdateFootballPlayerDTO updateFootballPlayerDTO,
                FootballTeam footballTeam,
                FootballPlayer model)
        {
            model.Name = updateFootballPlayerDTO.Name;
            model.FootballTeam = footballTeam;

            return model;
        }
    }
}
