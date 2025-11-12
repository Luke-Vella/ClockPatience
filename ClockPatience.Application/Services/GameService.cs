using ClockPatience.Application.DTOs;
using ClockPatience.Application.Interfaces;
using ClockPatience.Domain.Entities;
using ClockPatience.Domain.Interfaces;

namespace ClockPatience.Application.Services
{
    public class GameService(IGameRepository gameRepository) : IGameService
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
        public List<DeckDTO> SeedInput(int numberOfDecks, bool useCaseStudy = false)
        {
            List<Deck> decks = [];
            
            if (useCaseStudy)
            {
                ClockSolitaireGame game = new(true);
                decks.Add(game.Input);
                games.Add(game);
            }
            else
            {
                for (int i = 0; i < numberOfDecks; i++)
                {
                    ClockSolitaireGame game = new();
                    decks.Add(game.Input);
                    games.Add(game);
                }
            }

            List<DeckDTO> deckDTOs = [];
            foreach (Deck deck in decks)
            {
                DeckDTO deckDTO = new(deck, decks.IndexOf(deck) + 1);
                deckDTOs.Add(deckDTO);
            }

            return deckDTOs;
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

            return resultDTOs;
        }
    }
}
