using ClockPatience.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Application.DTOs
{
    public class DeckDTO(Deck deck, int deckNumber)
    {
        public int DeckNumber { get; set; } = deckNumber;
        public List<CardDTO> Cards { get; set; } = [.. deck.Cards.Select(card => new CardDTO(card))];
    }
}
