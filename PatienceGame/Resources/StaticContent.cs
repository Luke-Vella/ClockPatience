using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatienceGame.Resources
{
    public static class StaticContent
    {
        public static readonly string[] Suits = new string[]
        {
            "Hearts",
            "Diamonds",
            "Clubs",
            "Spades"
        };

        public static readonly string[] Ranks = new string[]
        {
            "Ace",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "Jack",
            "Queen",
            "King"
        };


        public const string GREETING_MESSAGE_GB = "Before we get started, kindly pick your Language!";
        public const string GREETING_MESSAGE_MT = "Qabel ma nibdew, jekk jogħġbok (u anke jekk ma jogħġbokx), agħżel il-lingwa tiegħek!";

        public const string LINE_SEPARATOR = "----------------------------------------";
    }
}
