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
            var game_id = service.StartGame(homeTeam, awayTeam);

            // Assert
            Assert.Single(service.ActiveGames);
        }

        [Fact]
        public void FinishGame_ValidGameId_GameIsRemoved()
        {
            // Arrange
            var homeTeam = new TeamData {
                Name = "Team1",
                Score = 4
            };
            var awayTeam = new TeamData {
                Name = "Team2",
                Score = 3
            };

            var game = new Game
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                Id = 1
            };

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
            var homeTeam = new TeamData {
                Name = "Team1",
                Score = 4
            };
            var awayTeam = new TeamData {
                Name = "Team2",
                Score = 3
            };

            var game = new Game
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                Id = 1
            };

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
            var homeTeam = new TeamData {
                Name = "Team1",
                Score = homeScore
            };

            var awayTeam = new TeamData {
                Name = "Team2",
                Score = awayScore
            };

            var game = new Game
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                Id = 1
            };

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
            var homeTeam1 = new TeamData {
                Name = "HT1",
                Score = 3
            };

            var awayTeam1 = new TeamData {
                Name = "AT1",
                Score = 4
            };

            var game1 = new Game
            {
                HomeTeam = homeTeam1,
                AwayTeam = awayTeam1,
                Id = 1
            };

            service.ActiveGames.Add(game1);

            var homeTeam2 = new TeamData {
                Name = "HT2",
                Score = 5
            };

            var awayTeam2 = new TeamData {
                Name = "AT2",
                Score = 5
            };

            var game2 = new Game
            {
                HomeTeam = homeTeam2,
                AwayTeam = awayTeam2,
                Id = 2
            };

            service.ActiveGames.Add(game2);

            // Act
            var games = service.GetSummary().ToList();

            // Assert
            Assert.Equal(game2.Id, games[0].Id);
            Assert.Equal(game1.Id, games[1].Id);
        }
    }
}
