using ClockPatience.Domain.Entities;
using ClockPatience.Domain.ValueObjects;

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
        public static Deck CreateStandard(bool includeJokers = false)
        {
            var cards = new List<Card>();
            var suits = new[] { Suit.Hearts, Suit.Diamonds, Suit.Clubs, Suit.Spades };
            var ranks = new[] { Rank.Ace, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.Jack, Rank.Queen, Rank.King };

            foreach (var suit in suits)
                foreach (var rank in ranks)
                    cards.Add(new Card(suit, rank));

            if (includeJokers)
            {
                cards.Add(new Card(new Suit("Joker", "Joker"), new Rank("Joker", "Joker")));
                cards.Add(new Card(new Suit("Joker", "Joker"), new Rank("Joker", "Joker")));
            }

            var deck = new Deck(cards);

            return deck;
        }

        /// <summary>
        /// Creates a deterministic deck for testing, based on a predefined input layout.
        /// </summary>
        /// <returns>A deck with cards in the exact order defined by the case study.</returns>
        public static Deck CreateCaseStudyDeck()
        {
            var deckString = "TS QC 8S 8D QH 2D 3H KH 9H 2H TH KS KC 9D JH 7H JD 2S QS TD 2C 4H 5H AD 4D 5D 6D 4S 9S 5S 7S JS 8H 3D 8C 3S 4C 6S 9C AS 7C AH 6H KD JC 7D AC 5C TC QD 6C 3C";
            var cardCodes = deckString.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            var cards = new List<Card>();
            foreach (var code in cardCodes)
            {
                var rankChar = code[0];
                var suitChar = code[1];

                var rank = Rank.FromSymbol(rankChar.ToString());
                var suit = Suit.FromSymbol(suitChar.ToString());

                cards.Add(new Card(suit, rank));
            }

            return new Deck(cards);
        }


    }
}
