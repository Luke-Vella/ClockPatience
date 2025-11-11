using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatience.Core.Helpers
{
    public static class CardHelper
    {
        public static readonly string[] Suits =
        [
            "H", // Hearts
            "D", // Diamonds
            "C", // Clubs
            "S" // Spades
        ];

        public static readonly string[] Ranks =
        [
            "A",
            "2", 
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "J",
            "Q",
            "K"
        ];

        public static string GetRankDescription(string rank)
        {
            return rank switch
            {
                "A" => "Ace",
                "2" => "Two",
                "3" => "Three",
                "4" => "Four",
                "5" => "Five",
                "6" => "Six",
                "7" => "Seven",
                "8" => "Eight",
                "9" => "Nine",
                "10" => "Ten",
                "J" => "Jack",
                "Q" => "Queen",
                "K" => "King",
                _ => "Unknown Rank"
            };
        }

        public static string GetSuitName(string suit)
        {
            return suit switch
            {
                "H" => "Hearts",
                "D" => "Diamonds",
                "C" => "Clubs",
                "S" => "Spades",
                _ => "Unknown Suit"
            };
        }
    }
}
