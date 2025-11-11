using ClockPatience.Application.DTOs;
using ClockPatience.Application.Interfaces;
using ClockPatience.Core.Entities;
using ClockPatience.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Application.Services
{
    public class ClockPatienceGameService : IClockPatienceGameService
    {
        private int _numberOfDecks;
        private List<Deck> _decks = [];

        /// <summary>
        /// Starts a new game by resetting the number of decks and initializing the decks list.
        /// </summary>
        public void StartNewGame()
        {
            _numberOfDecks = 0;
            _decks = [];
        }

        /// <summary>
        /// Takes in the number of decks to seed for the game.
        /// </summary>
        /// <param name="numberOfDecks"></param>
        public List<DeckDTO> SeedDecks(int numberOfDecks)
        {
            _numberOfDecks = numberOfDecks;
            _decks.Clear();

            var deckDtos = new List<DeckDTO>();

            for (int i = 0; i < _numberOfDecks; i++)
            {
                var deck = DeckFactory.CreateDeck();
                _decks.Add(deck);

                var deckDto = new DeckDTO
                {
                    DeckNumber = i + 1,
                    Cards = deck.Cards.Select(c => new CardDTO
                    {
                        Suit = c.Suit,
                        Rank = c.Rank,
                        Name = c.Name
                    }).ToList()
                };

                deckDtos.Add(deckDto);
            }

            return deckDtos;
        }

        /// <summary>
        /// Stops the current game.
        /// </summary>
        public void StopGame()
        {
            // Currently no specific logic needed to stop the game.
            // This method is a placeholder for potential future functionality.
        }
    }
}
