using ClockPatience.Domain.ValueObjects;

namespace ClockPatience.Domain.Entities
{
    /// <summary>
    /// Entity representing a playing card.
    /// </summary>
    public class Card(Suit suit, Rank rank)
    {
        public Suit Suit { get; } = suit;
        public Rank Rank { get; } = rank;
        public string Value { get; } = $"{rank.Value}{suit.Value}";
        public string Description { get; } = $"{rank.Description} of {suit.Description}";
        public bool IsFaceUp { get; set; } = false;
    }
}
