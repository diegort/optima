using Optima.Entities;

namespace Optima.Helpers
{
    public class GameBuilder
    {
        public static Game Build(string homeTeamName, int homeTeamScore, string awayTeamName, int awayTeamScore, int gameId)
        {
            var homeTeam = new TeamData
            {
                Name = homeTeamName,
                Score = homeTeamScore
            };
            var awayTeam = new TeamData
            {
                Name = awayTeamName,
                Score = awayTeamScore
            };

            var game = new Game
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                Id = gameId
            };

            return game;
        }
    }
}