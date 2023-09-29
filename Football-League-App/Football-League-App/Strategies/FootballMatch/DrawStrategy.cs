using DataAccess.Contracts;
using DataStructure.Models;
using Football_League_App.Strategies.Contracts.FootballMatch;

namespace Football_League_App.Strategies.FootballMatch
{
    public class DrawStrategy : IFootballMatchStrategy
    {
        private readonly IBaseRepository _baseRepository;

        public DrawStrategy(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void SetPoints(FootballTeam host, FootballTeam visitor)
        {
            host.Points = host.Points + 1;
            visitor.Points = visitor.Points + 1;
            _baseRepository.Update<FootballTeam>(host);
            _baseRepository.Update<FootballTeam>(visitor);
        }
    }
}
