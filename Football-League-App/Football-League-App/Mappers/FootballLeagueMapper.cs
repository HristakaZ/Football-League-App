using DataStructure.Models;
using Football_League_App.ViewModels.FootballLeague;

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
    }
}
