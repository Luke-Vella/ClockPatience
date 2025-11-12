using PatienceGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClockPatience.Domain.Entities
{
    public class Game
    {
        public Game() { }

        private readonly List<Deck> _decks = new();

        public List<Deck> Decks => _decks;
        public Guid Id { get; } = Guid.NewGuid();


        public void AddDeck(Deck deck) => _decks.Add(deck);
        public void Reset() => _decks.Clear();
    }
}
