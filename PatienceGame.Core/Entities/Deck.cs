using PatienceGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Core.Entities
{
    public class Deck
    {
        public Deck()
        {
            Id = Guid.NewGuid();
            Cards = new List<Card>();
        }

        public Guid Id { get; set; }
        public List<Card> Cards { get; set; }
    }
}
