using ClockPatience.Core.Entities;
using ClockPatience.Core.Helpers;
using PatienceGame.Entities;

namespace ClockPatience.Core.Factories
{
    /// <summary>
    /// Factory class for instantiating decks of cards.
    /// </summary>
    public static class DeckFactory
    {
        /// <summary>
        /// Creates a full deck of cards with every possiblity accounted for.
        /// </summary>
        /// <returns>A full deck of cards, with optional jokers.</returns>
        public static Deck CreateDeck(bool includeJoker = false)
        {
            var deck = new Deck();

            foreach (var suit in CardHelper.Suits)
            {
                foreach (var rank in CardHelper.Ranks)
                {
                    var card = CreateCard(suit, rank);
                    deck.Cards.Add(card);
                }
            }

            if(includeJoker)
            {
                var joker1 = CreateJoker();
                var joker2 = CreateJoker();

                deck.Cards.Add(joker1);
                deck.Cards.Add(joker2);
            }

            return deck;
        }

        public static Card CreateCard(string suit, string rank)
        {
            var card = new Card
            {
                Suit = suit,
                Rank = rank,
                Name = $"{CardHelper.GetRankDescription(rank)} of {CardHelper.GetSuitName(suit)}"
            };
            return card;
        }

        public static Card CreateJoker()
        {
            return new Card
            {
                Suit = "Joker",
                Rank = "Joker",
                Name = "Joker"
            };
        }
    }
}
