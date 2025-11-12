using ClockPatience.Domain.Entities;

namespace ClockPatience.Application.DTOs
{
    public class DeckDTO(Deck deck, int deckNumber)
    {
        public int DeckNumber { get; set; } = deckNumber;
        public List<CardDTO> Cards { get; set; } = [.. deck.Cards.Select(card => new CardDTO(card))];
    }
}
