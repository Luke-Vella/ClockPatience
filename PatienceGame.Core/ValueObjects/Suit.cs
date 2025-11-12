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

        public static Suit FromSymbol(string symbol)
        {
            return symbol switch
            {
                "H" => new Suit("H", "Hearts"),
                "D" => new Suit("D", "Diamonds"),
                "C" => new Suit("C", "Clubs"),
                "S" => new Suit("S", "Spades"),
                _ => throw new ArgumentException($"Invalid suit symbol: {symbol}")
            };
        }
    }
}
