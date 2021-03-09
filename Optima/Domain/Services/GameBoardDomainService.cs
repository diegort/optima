namespace Optima.Domain.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Optima.Entities;

    public class GameBoardDomainService : IGameBoardDomainService
    {
        // Only for easyness purposes. Data should be managed by a Repository.
        public List<Game> ActiveGames = new List<Game>();

        public int StartGame(string homeTeam, string awayTeam)
        {
            var home = new TeamData {
                Name = homeTeam,
                Score = 0
            };

            var away = new TeamData {
                Name = awayTeam,
                Score = 0
            };

            var game = new Game {
                HomeTeam = home,
                AwayTeam = away,
                Id = ActiveGames.Count > 0 ? ActiveGames.Max(g => g.Id) + 1 : 1
            };

            ActiveGames.Add(game);

            return game.Id;
        }

        public bool FinishGame(int gameId)
        {
            var toFinish = FindGame(gameId);
            
            return toFinish != null && ActiveGames.Remove(toFinish);
        }

        public void UpdateScore(int gameId, int homeTeamScore, int awayTeamScore)
        {
            var game = FindGame(gameId);

            if (game == null)
            {
                return;
            }
            game.HomeTeam.Score = homeTeamScore;
            game.AwayTeam.Score = awayTeamScore;
        }

        public IEnumerable<Game> GetSummary()
        {
            return ActiveGames
                    .OrderByDescending(g => g.HomeTeam.Score + g.AwayTeam.Score)
                    .ThenByDescending(g => g.Id);
        }

        private Game FindGame(int gameId)
        {
            return ActiveGames.FirstOrDefault(g => g.Id == gameId);
        }
    }
}
