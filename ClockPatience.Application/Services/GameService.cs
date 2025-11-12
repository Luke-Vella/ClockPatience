using ClockPatience.Application.DTOs;
using ClockPatience.Application.Interfaces;
using ClockPatience.Domain.Entities;
using ClockPatience.Domain.Interfaces;
using ClockPatience.Domain.Services;

namespace ClockPatience.Application.Services
{
    public class GameService(GameSessionService gameFactory, IGameRepository gameRepository) : IGameService
    {
        private readonly GameSessionService _gameSessionService = gameFactory;
        private readonly IGameRepository _gameRepository = gameRepository;


        /// <summary>
        /// Starts a new game by resetting the number of decks and initializing the decks list.
        /// </summary>
        public void StartNewGame()
        {
            _gameSessionService.StartNewSession();
        }

        /// <summary>
        /// Takes in the number of decks to seed for the game.
        /// </summary>
        /// <param name="numberOfDecks">Number of decks to seed the current game session with</param>
        public List<DeckDTO> SeedDecks(int numberOfDecks)
        {
            List<Deck> decks = _gameSessionService.SeedGameInstances(numberOfDecks);

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
            _gameSessionService.StopCurrentSession();
        }

        /// <summary>
        /// Determines the outcome of all decks seeded into the game session.
        /// </summary>
        public List<Tuple<int, CardDTO>> PlayGame()
        {
            List<Tuple<int, Card>> results = _gameSessionService.PlayGame();

            List<Tuple<int, CardDTO>> resultDTOs = [];

            foreach (Tuple<int, Card> result in results)
            {
                Card card = result.Item2;
                CardDTO cardDTO = new(card);

                Tuple<int, CardDTO> resultDTO = new(result.Item1, cardDTO);

                resultDTOs.Add(resultDTO);
            }

            return resultDTOs;
        }
    }
}
