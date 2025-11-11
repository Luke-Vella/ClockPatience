using ClockPatience.Core.Entities;
using PatienceGame.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Application.Services
{
    public class GameService
    {
        private int _numberOfDecks;
        private List<Deck> _decks;

        public GameService() { }

        /// <summary>
        /// Starts a new game by resetting the number of decks and initializing the decks list.
        /// </summary>
        public void StartNewGame()
        {
            _numberOfDecks = 0;
            _decks = new List<Deck>();

        }

        /// <summary>
        /// Takes in the number of decks to seed for the game.
        /// </summary>
        /// <param name="numberOfDecks"></param>
        public void SeedDecks(int numberOfDecks)
        {
            _numberOfDecks = numberOfDecks;
            for (int i = 0; i < _numberOfDecks; i++)
            {
                _decks.Add(DeckFactory.CreateDeck());
            }
        }
    }
}
