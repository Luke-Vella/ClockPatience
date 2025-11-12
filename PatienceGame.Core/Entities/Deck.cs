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

        public void Reset()
        {
            _cards.Clear();
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

        public Card DealFirstCard()
        {
            if (_cards.Count == 0)
            {
                throw new InvalidOperationException("The deck is empty.");
            }

            Card cardToDeal = _cards[0];
            cardToDeal.IsFaceUp = true;

            RemoveCard(cardToDeal);

            return _cards[0];
        }

        public Card? DealCard()
        {
            if (_cards.Count == 0)
            {
                return null;
            }

            Card dealtCard = _cards[0];
            RemoveCard(_cards[0]);
            
            return dealtCard;
        }

        public void RemoveCard(Card card)
        {
            if (!_cards.Remove(card))
            {
                throw new InvalidOperationException("The specified card is not in the deck.");
            }
        }
    }
}
