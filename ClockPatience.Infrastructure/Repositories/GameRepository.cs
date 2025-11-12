using ClockPatience.Domain.Entities;
using ClockPatience.Domain.Interfaces;

namespace ClockPatience.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        public void SaveGameResult(List<Tuple<int, Card>> results)
        {
            // Flesh out with actual data persistence logic later
        }

        public void AddGame(ClockSolitaireGame currentGameSession)
        {
            // Flesh out with actual data persistence logic later
        }

        // Additional repository methods to store game data can be added here as needed
    }
}
