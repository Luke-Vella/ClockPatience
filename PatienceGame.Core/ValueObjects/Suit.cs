using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Domain.ValueObjects
{
    public readonly record struct Suit(string Value, string Description)
    {
        public static readonly Suit Hearts = new("H", "Hearts");
        public static readonly Suit Diamonds = new("D", "Diamonds");
        public static readonly Suit Clubs = new("C", "Clubs");
        public static readonly Suit Spades = new("S", "Spades");

        public override string ToString() => Value;
    }
}
