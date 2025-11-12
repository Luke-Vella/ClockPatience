using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Domain.ValueObjects
{
    public readonly record struct Rank(string Value, string Description)
    {
        public static readonly Rank Ace = new("A", "Ace");
        public static readonly Rank Two = new("2", "Two");
        public static readonly Rank Three = new("3", "Three");
        public static readonly Rank Four = new("4", "Four");
        public static readonly Rank Five = new("5", "Five");
        public static readonly Rank Six = new("6", "Six");
        public static readonly Rank Seven = new("7", "Seven");
        public static readonly Rank Eight = new("8", "Eight");
        public static readonly Rank Nine = new("9", "Nine");
        public static readonly Rank Ten = new("T", "Ten");
        public static readonly Rank Jack = new("J", "Jack");
        public static readonly Rank Queen = new("Q", "Queen");
        public static readonly Rank King = new("K", "King");

        public override string ToString() => Value;

        public static Rank FromSymbol(string symbol)
        {
            return symbol switch
            {
                "A" => new Rank("A", "Ace"),
                "2" => new Rank("2", "Two"),
                "3" => new Rank("3", "Three"),
                "4" => new Rank("4", "Four"),
                "5" => new Rank("5", "Five"),
                "6" => new Rank("6", "Six"),
                "7" => new Rank("7", "Seven"),
                "8" => new Rank("8", "Eight"),
                "9" => new Rank("9", "Nine"),
                "T" => new Rank("T", "Ten"),
                "J" => new Rank("J", "Jack"),
                "Q" => new Rank("Q", "Queen"),
                "K" => new Rank("K", "King"),
                _ => throw new ArgumentException($"Invalid rank symbol: {symbol}")
            };
        }
    }
}
