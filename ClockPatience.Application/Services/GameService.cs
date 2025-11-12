using ClockPatience.Application.DTOs;
using ClockPatience.Domain.Entities;
using ClockPatience.Domain.Interfaces;

namespace ClockPatience.Application.Services
{
    public class GameService(IGameRepository gameRepository)
    {
        private List<ClockSolitaireGame> games = [];

        /// <summary>
        /// Starts a new game by resetting the number of decks and initializing the decks list.
        /// </summary>
        public void StartNewGame() 
        {
            games = [];
        }

        /// <summary>
        /// Takes in the number of decks to seed for the game.
        /// </summary>
        /// <param name="numberOfDecks">Number of decks to seed the current game session with</param>
        /// <returns>Deck as DTO</returns>
        public List<DeckDTO> SeedInput(int numberOfDecks)
        {
            List<Deck> decks = [];
            
            for (int i = 0; i < numberOfDecks; i++)
            {
                ClockSolitaireGame game = new();
                decks.Add(game.Input);
                games.Add(game);
            }

            return MapDeckToDTO(decks);
        }

        /// <summary>
        /// Takes in a specific deck to seed for the game.
        /// </summary>
        /// <param name="deck">Deck to seed a game with</param>
        /// <returns>Deck as DTO</returns>
        public List<DeckDTO> SeedInput(Deck deck)
        {
            List<Deck> decks = [];

            ClockSolitaireGame game = new(deck);
            decks.Add(game.Input);
            games.Add(game);

            return MapDeckToDTO(decks);
        }

        /// <summary>
        /// Seeds game with default case study deck.
        /// </summary>
        /// <returns>Deck DTO</returns>
        public List<DeckDTO> SeedInput()
        {
            List<Deck> decks = [];

            ClockSolitaireGame game = new(true);
            decks.Add(game.Input);
            games.Add(game);

            return MapDeckToDTO(decks);
        }

        /// <summary>
        /// Determines the outcome of all decks seeded into the game session.
        /// </summary>
        public List<Tuple<int, CardDTO>> PlayGame()
        {
            List< Tuple<int, Card> > results = [];
            foreach (ClockSolitaireGame game in games)
            {
                Tuple<int, Card> result = game.Play();
                results.Add(result);
            }

            List<Tuple<int, CardDTO>> resultDTOs = [];

            foreach (Tuple<int, Card> result in results)
            {
                Card card = result.Item2;
                CardDTO cardDTO = new(card);

                Tuple<int, CardDTO> resultDTO = new(result.Item1, cardDTO);

                resultDTOs.Add(resultDTO);
            }

            gameRepository.SaveGameResult(results);

            return resultDTOs;
        }

        /// <summary>
        /// Maps deck entity to deck DTO.
        /// </summary>
        /// <param name="decks">List of deck entities</param>
        /// <returns>List of deck DTOs</returns>
        public static List<DeckDTO> MapDeckToDTO(List<Deck> decks)
        {
            List<DeckDTO> deckDTOs = [];
            foreach (Deck deck in decks)
            {
                DeckDTO deckDTO = new(deck, decks.IndexOf(deck) + 1);
                deckDTOs.Add(deckDTO);
            }

            return deckDTOs;
        }
    }
}
