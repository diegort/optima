namespace Optima.Domain.Services
{
    using System.Collections.Generic;
    using Optima.Entities;

    public class GameBoardDomainService : IGameBoardDomainService
    {
        // Only for easyness purposes. Data should be managed by a Repository.
        public List<Game> ActiveGames = new List<Game>();

        public int StartGame(string homeTeam, string awayTeam)
        {
            throw new System.NotImplementedException();
        }

        public bool FinishGame(int gameId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateScore(int gameId, int homeTeamScore, int awayTeamScore)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Game> GetSummary()
        {
            throw new System.NotImplementedException();
        }
    }
}
