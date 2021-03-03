namespace Optima.Domain.Services
{
    using System.Collections.Generic;
    using Entities;

    public class GameBoardDomainService : IGameBoardDomainService
    {
        public int StartGame(string homeTeam, string awayTeam)
        {
            throw new System.NotImplementedException();
        }

        public void FinishGame(int gameId)
        {
        }

        public void UpdateScore(int gameId, int homeTeamScore, int awayTeamScore)
        {
        }

        public IEnumerable<Game> GetSummary()
        {
            throw new System.NotImplementedException();
        }
    }
}
