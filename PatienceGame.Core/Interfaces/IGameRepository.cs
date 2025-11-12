using ClockPatience.Domain.Entities;

namespace ClockPatience.Domain.Interfaces
{
    public interface IGameRepository
    {
        void AddGame(ClockSolitaireGame currentGameSession);
        void SaveGameResult(List<Tuple<int, Card>> results);
    }
}
