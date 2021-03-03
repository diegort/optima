namespace Optima.Domain.Services
{
    using System.Collections.Generic;
    using Entities;

    public interface IGameBoardDomainService
    {
        int StartGame(string homeTeam, string awayTeam);

        void FinishGame(int gameId);

        void UpdateScore(int gameId, int homeTeamScore, int awayTeamScore);

        IEnumerable<Game> GetSummary();
    }
}