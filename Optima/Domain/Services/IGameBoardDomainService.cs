namespace Optima.Domain.Services
{
    using System.Collections.Generic;
    using Optima.Entities;

    public interface IGameBoardDomainService
    {
        int StartGame(string homeTeam, string awayTeam);

        bool FinishGame(int gameId);

        void UpdateScore(int gameId, int homeTeamScore, int awayTeamScore);

        IEnumerable<Game> GetSummary();
    }
}