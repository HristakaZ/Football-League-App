using DataAccess.Contracts;
using Football_League_App.Services;
using Football_League_App.Services.Contracts;
using Football_League_App.Strategies.Contracts.FootballMatch;
using Football_League_App.Strategies.FootballMatch;
using Moq;

namespace Football_League_App.Tests
{
    public class Tests
    {
        private IFootballMatchService _footballMatchService;

        [SetUp]
        public void Setup()
        {
            _footballMatchService = new FootballMatchService(It.IsAny<IBaseRepository>());
        }

        [Test]
        public void SetFootballMatchStrategy_WithHostWinningResult_ShouldReturnHostWinnerStrategy()
        {
            //Arrange
            string result = "4-3";

            //Act
            IFootballMatchStrategy strategy = _footballMatchService.SetFootballMatchStrategy(result);

            //Assert
            Assert.True(strategy is HostWinnerStrategy);
        }

        [Test]
        public void SetFootballMatchStrategy_WithVisitorWinningResult_ShouldReturnVisitorWinnerStrategy()
        {
            //Arrange
            string result = "3-4";

            //Act
            IFootballMatchStrategy strategy = _footballMatchService.SetFootballMatchStrategy(result);

            //Assert
            Assert.True(strategy is VisitorWinnerStrategy);
        }

        [Test]
        public void SetFootballMatchStrategy_WithDrawResult_ShouldReturnDrawStrategy()
        {
            //Arrange
            string result = "4-4";

            //Act
            IFootballMatchStrategy strategy = _footballMatchService.SetFootballMatchStrategy(result);

            //Assert
            Assert.True(strategy is DrawStrategy);
        }
    }
}