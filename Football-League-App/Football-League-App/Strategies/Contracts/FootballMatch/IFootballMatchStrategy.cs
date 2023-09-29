using DataStructure.Models;

namespace Football_League_App.Strategies.Contracts.FootballMatch
{
    public interface IFootballMatchStrategy
    {
        void SetPoints(FootballTeam host, FootballTeam visitor);
    }
}
