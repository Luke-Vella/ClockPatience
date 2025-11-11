using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatienceGame.Entities
{
    /// <summary>
    /// Entity representing a playing card.
    /// </summary>
    public class Card
    {
        public Card() {}

        public int Id { get; set; }
        public required string Suit { get; set; }
        public required string Rank { get; set; }
        public required string Name { get; set; }
        public bool IsFaceUp { get; set; }
    }
}
