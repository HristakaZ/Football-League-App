using DataStructure.Models;
using Football_League_App.Strategies.Contracts.FootballMatch;

namespace Football_League_App.Services.Contracts
{
    public interface IFootballMatchService
    {
        IFootballMatchStrategy SetFootballMatchStrategy(string result);
    }
}
