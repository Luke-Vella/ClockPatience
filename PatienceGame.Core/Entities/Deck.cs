using PatienceGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Domain.Entities
{
    public class Deck
    {
        private readonly List<Card> _cards = [];
        public IReadOnlyList<Card> Cards => _cards;

        internal Deck(IEnumerable<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public void Shuffle(Random? random = null)
        {
            random ??= Random.Shared;
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
            }
        }

        public Card DealCard()
        {
            if (_cards.Count == 0)
            {
                throw new InvalidOperationException("No cards left in the deck to deal.");
            }

            Card dealtCard = _cards[_cards.Count - 1];
            _cards.RemoveAt(_cards.Count - 1);
            
            return dealtCard;
        }
    }
}
