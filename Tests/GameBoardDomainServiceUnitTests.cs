using Optima.Helpers;

namespace Optima
{
    using System;
    using System.Linq;
    using Xunit;
    using Optima.Domain.Services;
    using Optima.Entities;

    public class GameBoardDomainServiceUnitTests
    {
        private readonly GameBoardDomainService service;
        public GameBoardDomainServiceUnitTests()
        {
            service = new GameBoardDomainService();
        }

        [Fact]
        public void StartGame_ValidTeamNames_GameIsRegistered()
        {
            // Arrange
            var homeTeam = "Team 1";
            var awayTeam = "Team 2";

            // Act
            service.StartGame(homeTeam, awayTeam);

            // Assert
            Assert.Single(service.ActiveGames);
        }

        [Fact]
        public void FinishGame_ValidGameId_GameIsRemoved()
        {
            // Arrange
            var game = GameBuilder.Build("Team1", 4, "Team2", 3, 1);

            service.ActiveGames.Add(game);

            // Act
            var result = service.FinishGame(game.Id);

            // Assert
            Assert.True(result);
            Assert.Empty(service.ActiveGames);
        }

        [Fact]
        public void FinishGame_WrongGameId_GameIsRemoved()
        {
            // Arrange
            var game = GameBuilder.Build("Team1", 4, "Team2", 3, 1);

            service.ActiveGames.Add(game);

            // Act
            var result = service.FinishGame(game.Id + 1);

            // Assert
            Assert.False(result);
            Assert.Single(service.ActiveGames);
        }

        [Fact]
        public void UpdateGame_ValidNameIdValidScore_ScoreGetsUpdated()
        {
            // Arrange
            var homeScore = 0;
            var awayScore = 0;
            var newAwayScore = 1;
            var game = GameBuilder.Build("Team1", homeScore, "Team2", awayScore, 1);

            service.ActiveGames.Add(game);

            // Act
            service.UpdateScore(game.Id, game.HomeTeam.Score, newAwayScore);

            // Assert
            Assert.Equal(homeScore, service.ActiveGames[0].HomeTeam.Score);
            Assert.Equal(newAwayScore, service.ActiveGames[0].AwayTeam.Score);
        }

        [Fact]
        public void GetSummary_SomeGamesInProgress_ReturnedInProperOrder()
        {
            // Arrange
            var game1 = GameBuilder.Build("Mexico", 0, "Canada", 5, 1);
            service.ActiveGames.Add(game1);

            var game2 = GameBuilder.Build("Spain", 10, "Brazil", 2, 2);
            service.ActiveGames.Add(game2);

            var game3 = GameBuilder.Build("Germany", 2, "France", 2, 3);
            service.ActiveGames.Add(game3);

            var game4 = GameBuilder.Build("Uruguay", 6, "Italy", 6, 4);
            service.ActiveGames.Add(game4);

            var game5 = GameBuilder.Build("Argentina", 3, "Australia", 1, 5);
            service.ActiveGames.Add(game5);

            // Act
            var games = service.GetSummary().ToList();

            // Assert
            Assert.Equal(game4.Id, games[0].Id);
            Assert.Equal(game2.Id, games[1].Id);
            Assert.Equal(game1.Id, games[2].Id);
            Assert.Equal(game5.Id, games[3].Id);
            Assert.Equal(game3.Id, games[4].Id);
        }
    }
}
