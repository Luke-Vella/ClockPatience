using ClockPatience.Application.DTOs;

namespace ClockPatience.Application.Interfaces
{
    public interface IGameService
    {
        public void StartNewGame();

        public List<DeckDTO> SeedDecks(int numberOfDecks);

        public void StopGame();

        public List<Tuple<int, CardDTO>> PlayGame();
    }
}
