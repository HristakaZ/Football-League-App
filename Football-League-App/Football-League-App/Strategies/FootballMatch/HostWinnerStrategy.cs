using DataAccess.Contracts;
using DataStructure.Models;
using Football_League_App.Strategies.Contracts;
using Football_League_App.Strategies.Contracts.FootballMatch;

namespace Football_League_App.Strategies.FootballMatch
{
    public class HostWinnerStrategy : IFootballMatchStrategy
    {
        private readonly IBaseRepository _baseRepository;
        public HostWinnerStrategy(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void SetPoints(FootballTeam host, FootballTeam? visitor)
        {
            host.Points = host.Points + 3;
            _baseRepository.Update<FootballTeam>(host);
        }
    }
}
