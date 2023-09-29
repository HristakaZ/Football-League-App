using DataAccess.Contracts;
using DataStructure.Models;
using Football_League_App.Strategies.Contracts.FootballMatch;

namespace Football_League_App.Strategies.FootballMatch
{
    public class VisitorWinnerStrategy : IFootballMatchStrategy
    {
        private readonly IBaseRepository _baseRepository;

        public VisitorWinnerStrategy(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void SetPoints(FootballTeam? host, FootballTeam visitor)
        {
            visitor.Points = visitor.Points + 3;
            _baseRepository.Update<FootballTeam>(visitor);
        }
    }
}
