using ClockPatience.Application.DTOs;

namespace ClockPatience.Application.Interfaces
{
    public interface IGameService
    {
        public void StartNewGame();

        public List<DeckDTO> SeedInput(int numberOfDecks, bool useCaseStudy = false);

        public List<Tuple<int, CardDTO>> PlayGame();
    }
}
