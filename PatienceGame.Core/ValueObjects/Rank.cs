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
        public static readonly Rank Ten = new("10", "Ten");
        public static readonly Rank Jack = new("J", "Jack");
        public static readonly Rank Queen = new("Q", "Queen");
        public static readonly Rank King = new("K", "King");

        public override string ToString() => Value;
    }
}
