using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Domain.ValueObjects
{
    public readonly record struct Suit(string Value)
    {
        public static readonly Suit Hearts = new("H");
        public static readonly Suit Diamonds = new("D");
        public static readonly Suit Clubs = new("C");
        public static readonly Suit Spades = new("S");

        public override string ToString() => Value;
    }
}
