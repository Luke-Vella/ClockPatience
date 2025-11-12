using ClockPatience.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Application.DTOs
{
    public class DeckDTO
    {
        public DeckDTO(Deck deck, int deckNumber)
        {
            DeckNumber = deckNumber;
            Cards = [.. deck.Cards.Select(card => new CardDTO
            {
                Suit = card.Suit.Value,
                Rank = card.Rank.Value,
                Name = card.Name
            })];
        }

        public int DeckNumber { get; set; }
        public List<CardDTO> Cards { get; set; } = [];
    }
}
