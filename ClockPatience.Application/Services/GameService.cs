using ClockPatience.Application.DTOs;
using ClockPatience.Application.Interfaces;
using ClockPatience.Domain.Entities;
using ClockPatience.Domain.Interfaces;
using ClockPatience.Domain.Services;

namespace ClockPatience.Application.Services
{
    public class GameService : IGameService
    {
        private readonly GameSessionService _gameSessionService;
        private readonly IGameRepository _gameRepository;
        private Game? _currentGameSession;

        public GameService(GameSessionService gameFactory, IGameRepository gameRepository)
        {
            _gameSessionService = gameFactory;
            _gameRepository = gameRepository;
        }


        /// <summary>
        /// Starts a new game by resetting the number of decks and initializing the decks list.
        /// </summary>
        public void StartNewGame()
        {
            _currentGameSession = _gameSessionService.StartNewGame();
            _gameRepository.AddGame(_currentGameSession);
        }

        /// <summary>
        /// Takes in the number of decks to seed for the game.
        /// </summary>
        /// <param name="numberOfDecks">Number of decks to seed the current game session with</param>
        public List<DeckDTO> SeedDecks(int numberOfDecks)
        {
            List<Deck> decks = _gameSessionService.SeedDecks(numberOfDecks);

            List<DeckDTO> deckDTOs = [];
            foreach (Deck deck in decks)
            {
                DeckDTO deckDTO = new(deck, decks.IndexOf(deck) + 1);
                deckDTOs.Add(deckDTO);
            }

            return deckDTOs;
        }

        /// <summary>
        /// Stops the current game.
        /// </summary>
        public void StopGame()
        {
            _gameSessionService.StopGame();

            if (_currentGameSession != null)
            {
                _gameRepository.SaveGameResult(_currentGameSession);
            }
        }

        /// <summary>
        /// Determines the outcome of the current game session.
        /// </summary>
        public void DetermineGameOutcome()
        {
            if (_currentGameSession != null)
            {
                _gameSessionService.PlayGame();
            }
        }
    }
}
