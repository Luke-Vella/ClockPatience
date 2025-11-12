using ClockPatience.Domain.ValueObjects;

namespace PatienceGame.Entities
{
    /// <summary>
    /// Entity representing a playing card.
    /// </summary>
    public class Card
    {
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
            Name = $"{rank} of {suit}";
        }

        public Suit Suit { get; }
        public Rank Rank { get; }
        public string Name { get; }
    }
}
