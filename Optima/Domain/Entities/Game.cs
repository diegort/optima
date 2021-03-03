namespace Optima.Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public TeamData HomeTeam { get; set; }
        
        public TeamData AwayTeam { get; set; }
    }
}