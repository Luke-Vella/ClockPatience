using ClockPatience.Domain.Entities;

namespace ClockPatience.Application.DTOs
{
    public class CardDTO(Card card)
    {
        public string Rank { get; set; } = card.Rank.Value;
        public string Suit { get; set; } = card.Suit.Value;
        public string Value { get; set; } = card.Value;
    }
}
