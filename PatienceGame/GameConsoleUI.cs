using ClockPatience.Application.DTOs;
using ClockPatience.ConsoleApp.Helpers;
using ClockPatience.ConsoleApp.Localisation;
using ClockPatience.ConsoleApp.Resources;

namespace ClockPatience.ConsoleApp
{
    /// <summary>
    /// The terminal printer class is responsible for printing various messages and prompts to the terminal.
    /// </summary>
    public static class GameConsoleUI
    {
        /// <summary>
        /// Asks the user to choose the default language used to play the rest of the game.
        /// </summary>
        /// <returns>Language chosen</returns>
        public static Language AskUserForLanguage()
        {
            var languageValues = Enum.GetValues(typeof(Language)).Cast<Language>().ToArray();
            string[] languageOptions = [.. languageValues.Select(p => EnumHelper.GetEnumDescription(p))];

            Console.WriteLine("Before we get started, kindly pick your Language!");

            for (int i = 0; i < languageOptions.Length; i++)
            {
                if (i == 0)
                    Console.WriteLine($"→{languageOptions[i]}");
                else
                    Console.WriteLine($"  {languageOptions[i]}");
            }

            int index = 0;

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow) index = Math.Max(0, index - 1);
                if (key == ConsoleKey.DownArrow) index = Math.Min(languageOptions.Length - 1, index + 1);
                if (key == ConsoleKey.Enter) break;

                Console.Clear();

                if (languageOptions[index] == "[MT] Malti")
                    Console.WriteLine("Qabel ma nibdew, jekk jogħġbok (u anke jekk ma jogħġbokx), agħżel il-lingwa tiegħek:");
                else
                {
                    Console.WriteLine("Before we get started, kindly pick your Language!");
                }

                for (int i = 0; i < languageOptions.Length; i++)
                {
                    if (i == index)
                        Console.WriteLine($"→ {languageOptions[i]}");
                    else
                        Console.WriteLine($"  {languageOptions[i]}");
                }
            }

            return languageValues[index];
        }


        /// <summary>
        /// Prints a friendly welcoming message to the terminal for the player.
        /// </summary>
        /// <param name="loc">Localisation options</param>
        public static void WelcomeUserToGame(ILocalizationProvider loc)
        {
            Console.Clear();

            PrintSpacer(true, true);
            Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_1"));
            PrintSpacer(false, false, true);

            Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_2"));
            Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_3"));
            PrintSpacer(false, true);

            Console.WriteLine(loc.Get("GENERIC_BUTTON_PRESS_TO_CONTINUE"));
            PrintSpacer(true);

            Console.ReadKey(true);
            Console.Clear();
        }


        /// <summary>
        /// Informs the user that the game is starting
        /// </summary>
        /// <param name="loc">Localization options</param>
        public static void InformUserGameIsStarting(ILocalizationProvider loc)
        {
            PrintSpacer(true, true);
            Console.WriteLine(loc.Get("GAME_START_MESSAGE_1"));
            Console.WriteLine(loc.Get("GAME_START_MESSAGE_2"));
            Console.WriteLine(loc.Get("GAME_START_MESSAGE_3"));
            PrintSpacer(true);
        }


        /// <summary>
        /// Prompts user to input the amount of decks s/he wishes to seed into the game
        /// </summary>
        /// <param name="loc">Localisation options</param>
        /// <returns>Valid number which the game should be seeded with.</returns>
        public static int? ReadUserSeeding(ILocalizationProvider loc)
        {
            string? decksToSeedInput;


            int decksToSeedInt;

            int attempts = 0;

            // Loop until a valid integer is entered
            while (true)
            {
                if (attempts > 0)
                {
                    PrintSpacer(false, true);
                    Console.WriteLine(loc.Get("INPUT_INVALID_NUMBER_OF_DECKS"));
                }

                decksToSeedInput = Console.ReadLine();
                
                if(decksToSeedInput != null && decksToSeedInput.Equals("sample input"))
                {
                    return null;
                }

                // TryParse returns bool; use the out parameter to get the parsed int
                if (int.TryParse(decksToSeedInput, out decksToSeedInt))
                {
                    break;
                }

                attempts++;
            }

            PrintSpacer(false, true);
            Console.WriteLine(string.Format(loc.Get("SEEDING_DECKS"), decksToSeedInt));
            PrintSpacer(false, true);

            return decksToSeedInt;
        }


        /// <summary>
        /// Informs the user that the decks have been seeded and are being shown
        /// </summary>
        /// <param name="loc">Localization options</param>
        public static void InformUserSeedingIsComplete(ILocalizationProvider loc)
        {
            PrintSpacer(true, true);
            Console.WriteLine(loc.Get("SEEDING_DECKS_COMPLETED"));
            Console.WriteLine(loc.Get("SHOWING_ALL_DECKS_MESSAGE"));

            PrintSpacer(false, true);
            Console.WriteLine(loc.Get("GENERIC_BUTTON_PRESS_TO_CONTINUE"));
            PrintSpacer(true);

            Console.ReadKey(true);
            Console.Clear();
        }


        /// <summary>
        /// Informs the user that sample data is to be used for this game.
        /// </summary>
        /// <param name="loc">Localization options</param>
        public static void InformUserAboutSampleDataChoice(ILocalizationProvider loc)
        {
            PrintSpacer(true, true);
            Console.WriteLine(loc.Get("SAMPLE_DATA_CHOSEN_MESSAGE_1"));
            Console.WriteLine(loc.Get("SAMPLE_DATA_CHOSEN_MESSAGE_2"));
            Console.WriteLine(loc.Get("SAMPLE_DATA_CHOSEN_MESSAGE_3"));

            PrintSpacer(false, true);
            Console.WriteLine(loc.Get("GENERIC_BUTTON_PRESS_TO_CONTINUE"));
            PrintSpacer(true);

            Console.ReadKey(true);
            Console.Clear();
        }


        /// <summary>
        /// Prints a generic "press any button to continue" message with spacing before and after.
        /// </summary>
        /// <param name="loc">Localisation provider</param>
        public static void PrintGenericContinueMessageWithSpacing(ILocalizationProvider loc)
        {
            PrintSpacer(false, true);
            Console.WriteLine(loc.Get("GENERIC_BUTTON_PRESS_TO_CONTINUE"));
            PrintSpacer(true);

            Console.ReadKey(true);
            Console.Clear();
        }


        /// <summary>
        /// Prints the given deck to the terminal in a human-readable format.
        /// </summary>
        /// <param name="deckDTO">Deck to output</param>
        /// <param name="loc">Localisation provider</param>
        public static void PrintDeckToTerminal(DeckDTO deckDTO, bool isSampleInput)
        {
            PrintSpacer(true, true);
            Console.WriteLine( isSampleInput ? "Sample Input" : "Input {0}", deckDTO.DeckNumber);
            PrintSpacer(false, true);

            int currentCardIndex = 0;

            for(int i=0; i<4; i++)
            {
                for (int j=0; j<13; j++)
                {
                    var card = deckDTO.Cards[currentCardIndex];
                    Console.Write("{0}{1} ", card.Rank, card.Suit);
                    currentCardIndex++;
                }
                Console.WriteLine();
            }

            Console.WriteLine("#");

            PrintSpacer(true, false, true);
        }


        /// <summary>
        /// Informs the user to review the decks and reshuffle if needed.
        /// </summary>
        /// <param name="loc">Localisation provider</param>
        public static void PromptUserToReviewDecks(ILocalizationProvider loc)
        {
            PrintSpacer(false, true);
            Console.WriteLine(loc.Get("GAME_ABOUT_TO_BE_PLAYED_MESSAGE_1"));
            Console.WriteLine(loc.Get("GAME_ABOUT_TO_BE_PLAYED_MESSAGE_2"));
            Console.WriteLine(loc.Get("GAME_ABOUT_TO_BE_PLAYED_MESSAGE_3"));

            PrintSpacer(false, true);
            Console.WriteLine(loc.Get("GENERIC_BUTTON_PRESS_TO_CONTINUE"));
            PrintSpacer(true);

            Console.ReadKey(true);
        }


        /// <summary>
        /// Utility method used to separate text content in the terminal.
        /// </summary>
        /// <param name="includeLineSeperator">Whether to include a line seperator in the terminal or not.</param>
        public static void PrintSpacer(bool includeLineSeperator = true, bool includeEmptyLineBefore = false, bool includeEmptyLineAfter = false)
        {
            if (includeEmptyLineBefore)
                Console.WriteLine();

            if (includeLineSeperator)
                Console.WriteLine(StaticContent.LINE_SEPARATOR);

            if (includeEmptyLineAfter)
                Console.WriteLine();
        }

        /// <summary>
        /// Displays the game results to the user in the terminal.
        /// </summary>
        /// <param name="results">Results of game</param>
        /// <param name="loc">Localisation provider</param>
        /// <returns>Whether the user won or not</returns>
        public static bool DisplayGameResultsToUser(List<Tuple<int, CardDTO>> results, ILocalizationProvider loc)
        {
            Console.WriteLine(loc.Get("GAME_RESULT_MESSAGE"));
            
            bool hasWon = false;
            int amountOfGames = 0;
            int amountOfWonGames = 0;

            for (int i=0; i< results.Count; i++)
            {
                int amountOfMoves = results[i].Item1;
                CardDTO? cardDTO = results[i].Item2;
                if (amountOfMoves == 51)
                {
                    Console.WriteLine(string.Format(loc.Get("DECK_RESULT_WON"), i+1, amountOfMoves, cardDTO.Value));
                    hasWon = true;
                    amountOfWonGames++;
                }
                else
                {
                    Console.WriteLine(string.Format(loc.Get("DECK_RESULT_LOST"), i+1, amountOfMoves, cardDTO.Value));
                }

                amountOfGames++;
            }

            PrintSpacer(false, true);
            if (hasWon)
            {
                Console.WriteLine(loc.Get("CONGRATULATE_PLAYER_MESSAGE"));
                Console.WriteLine(string.Format(loc.Get("STATISTICS_MESSAGE"), amountOfGames, amountOfWonGames));
            }
            else
            {
                Console.WriteLine(loc.Get("CONSOLE_PLAYER_MESSAGE"));

            }
            PrintSpacer(true);

            return hasWon;
        }

        public static bool FarewellUser(ILocalizationProvider loc, bool hasWon)
        {
            PrintSpacer(false, true);


            PrintSpacer(false, true);
            Console.WriteLine(loc.Get("ASK_RESTART_GAME_MESSAGE"));
            PrintSpacer(true);

            string? userInput = Console.ReadLine();

            if (userInput != null && userInput.ToLower() == "y")
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.Clear();
                Environment.Exit(0);
                return false;
            }

        }
    }
}
