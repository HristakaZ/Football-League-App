using DataAccess.Contracts;
using Football_League_App.Services.Contracts;
using Football_League_App.Strategies.Contracts.FootballMatch;
using Football_League_App.Strategies.FootballMatch;

namespace Football_League_App.Services
{
    public class FootballMatchService : IFootballMatchService
    {
        private readonly IBaseRepository _baseRepository;
        public FootballMatchService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        private int FindWinner(string result)
        {
            string[] goalsByTeam = result.Split('-');
            int hostGoals = int.Parse(goalsByTeam[0]);
            int visitorGoals = int.Parse(goalsByTeam[1]);

            if (hostGoals > visitorGoals)
            {
                return 1;
            }
            else if (hostGoals < visitorGoals)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public IFootballMatchStrategy SetFootballMatchStrategy(string result)
        {
            int winner = FindWinner(result);
            IFootballMatchStrategy strategy = null!;
            if (winner == 1)
            {
                strategy = new HostWinnerStrategy(_baseRepository);
            }
            else if (winner == 0)
            {
                strategy = new VisitorWinnerStrategy(_baseRepository);
            }
            else
            {
                strategy = new DrawStrategy(_baseRepository);
            }

            return strategy;
        }
    }
}
