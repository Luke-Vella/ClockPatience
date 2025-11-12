using ClockPatience.Domain.Entities;
using ClockPatience.Domain.ValueObjects;
using PatienceGame.Entities;

namespace ClockPatience.Domain.Factories
{
    /// <summary>
    /// Factory class for instantiating decks of cards.
    /// </summary>
    public class DeckFactory
    {
        /// <summary>
        /// Creates a full deck of cards with every possiblity accounted for.
        /// </summary>
        /// <returns>A full deck of cards, with optional jokers.</returns>
        public Deck CreateStandard(bool includeJokers = false)
        {
            var cards = new List<Card>();
            var suits = new[] { Suit.Hearts, Suit.Diamonds, Suit.Clubs, Suit.Spades };
            var ranks = new[] { Rank.Ace, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.Jack, Rank.Queen, Rank.King };

            foreach (var suit in suits)
                foreach (var rank in ranks)
                    cards.Add(new Card(suit, rank));

            if (includeJokers)
            {
                cards.Add(new Card(new Suit("Joker"), new Rank("Joker")));
                cards.Add(new Card(new Suit("Joker"), new Rank("Joker")));
            }

            var deck = new Deck(cards);
            deck.Shuffle();

            return deck;
        }
    }
}
