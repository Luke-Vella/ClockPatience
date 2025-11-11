// Simple terminal input scaffold for PatienceGame
using ClockPatience.Application.Services;
using ClockPatience.ConsoleApp.Helpers;
using ClockPatience.ConsoleApp.Localisation;
using ConsoleApp.Localization;
using System.ComponentModel;
using System.Reflection;
using StaticContent = PatienceGame.Resources.StaticContent;



public class Program
{
    /// <summary>
    /// Entry point. Program starts here.
    /// </summary>
    public static void Main(string[] args)
    {
        // Firstly, we're going to ask the user for his/her prefered language.
        Language lang = AskUserForLanguage();
        ILocalizationProvider loc = new JsonLocalizationProvider(lang);

        // Language has been selected. We can go ahead and introduce the game using the language selected.
        PlayGame(loc);
    }


    /// <summary>
    /// Method which starts the actual game of clock patience.
    /// </summary>
    /// <param name="loc">Localisation interface with a language configured</param>
    private static void PlayGame(ILocalizationProvider loc)
    {
        // Welcome the user to the game.
        WelcomeUserToGame(loc);

        Console.Clear();

        // Start the actual game using the game service
        GameService gameService = new();
        gameService.StartNewGame();

        PrintSeperator();
        Console.WriteLine(loc.Get("GAME_START_MESSAGE"));
        PrintSeperator();

        // Prompt user to seed game with desired amount of decks...
        int decksToSeed = PromptUserToSeedDecks(loc);
        gameService.SeedDecks(decksToSeed);

        Console.WriteLine(loc.Get("SEEDING_DECKS_COMPLETED") + " " + loc.Get("GENERIC_BUTTON_PRESS_TO_CONTINUE"));
        PrintSeperator(false, false, true);

        // Game has ended. Thank the user for playing and give instructions to end the game.
        Console.ReadKey(true);
    }


    /// <summary>
    /// Asks the user to choose the default language used to play the rest of the game.
    /// </summary>
    /// <returns>Language chosen</returns>
    private static Language AskUserForLanguage()
    {
        var languageValues = Enum.GetValues(typeof(Language)).Cast<Language>().ToArray();
        string[] languageOptions = languageValues.Select(p => EnumHelper.GetEnumDescription(p)).ToArray();

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
    /// Outputs lines to the terminal welcoming player to the game
    /// </summary>
    /// <param name="loc">Localisation options</param>
    private static void WelcomeUserToGame(ILocalizationProvider loc)
    {
        PrintSeperator(true, true);
        Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_1"));
        Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_2"));
        Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_3"));
        PrintSeperator();

        Console.WriteLine(loc.Get("GENERIC_BUTTON_PRESS_TO_CONTINUE"));
        Console.ReadKey(false);
    }

    /// <summary>
    /// Prompts user to input the amount of decks s/he wishes to seed into the game
    /// </summary>
    /// <param name="loc">Localisation options</param>
    /// <returns>Valid number which the game should be seeded with.</returns>
    private static int PromptUserToSeedDecks(ILocalizationProvider loc)
    {
        var decksToSeedInput = string.Empty;
        int decksToSeedInt = 0;

        int attempts = 0;

        // Loop until a valid integer is entered
        while (true)
        {
            if (attempts > 0)
            {
                PrintSeperator(false,true);
                Console.WriteLine(loc.Get("INPUT_INVALID_NUMBER_OF_DECKS"));
            }

            decksToSeedInput = Console.ReadLine();

            // TryParse returns bool; use the out parameter to get the parsed int
            if (int.TryParse(decksToSeedInput, out decksToSeedInt))
            {
                break;
            }

            attempts++;
        }

        PrintSeperator(false, true);
        Console.WriteLine(string.Format(loc.Get("SEEDING_DECKS"), decksToSeedInt));

        return decksToSeedInt;
    }


    /// <summary>
    /// Utility method used to separate text content in the terminal.
    /// </summary>
    /// <param name="includeEmptyLine">Whether to print an empty line in the terminal or not.</param>
    /// <param name="includeLineSeperator">Whether to include a line seperator in the terminal or not.</param>
    private static void PrintSeperator(bool includeLineSeperator = true, bool includeEmptyLineBefore = false, bool includeEmptyLineAfter = false)
    {
        if (includeEmptyLineBefore)
            Console.WriteLine();

        if (includeLineSeperator)
            Console.WriteLine(StaticContent.LINE_SEPARATOR);

        if (includeEmptyLineAfter)
            Console.WriteLine();
    }
}