using ClockPatience.Domain.Entities;
using ClockPatience.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Domain.Services
{
    public class GameSessionService
    {
        private Game _game;

        public GameSessionService()
        {
            _game = new Game();
        }

        public Game StartNewGame()
        {
            _game = new Game();

            return _game;
        }

        public List<Deck> SeedDecks(int numberOfDecks)
        {
            DeckFactory deckFactory = new();
            for (int i = 0; i < numberOfDecks; i++)
            {
                var deck = deckFactory.CreateStandard();
                _game.AddDeck(deck);
            }

            return _game.Decks;
        }
    }
}
