using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Domain.ValueObjects
{
    public readonly record struct Rank(string Value)
    {
        public static readonly Rank Ace = new("A");
        public static readonly Rank Two = new("2");
        public static readonly Rank Three = new("3");
        public static readonly Rank Four = new("4");
        public static readonly Rank Five = new("5");
        public static readonly Rank Six = new("6");
        public static readonly Rank Seven = new("7");
        public static readonly Rank Eight = new("8");
        public static readonly Rank Nine = new("9");
        public static readonly Rank Ten = new("10");
        public static readonly Rank Jack = new("J");
        public static readonly Rank Queen = new("Q");
        public static readonly Rank King = new("K");

        public override string ToString() => Value;
    }
}
