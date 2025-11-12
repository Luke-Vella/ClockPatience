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
        public List<DeckDTO> SeedInput(int numberOfDecks)
        {
            List<Deck> decks = [];
            
            for (int i = 0; i < numberOfDecks; i++)
            {
                ClockSolitaireGame game = new();
                decks.Add(game.Input);
                games.Add(game);
            }

            return mapDeckToDTO(decks);
        }

        public List<DeckDTO> SeedInput()
        {
            List<Deck> decks = [];

            ClockSolitaireGame game = new(true);
            decks.Add(game.Input);
            games.Add(game);

            return mapDeckToDTO(decks);
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

        public static List<DeckDTO> mapDeckToDTO(List<Deck> decks)
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
