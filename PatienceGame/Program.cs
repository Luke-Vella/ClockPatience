// Simple terminal input scaffold for PatienceGame
using ClockPatience.ConsoleApp.Helpers;
using ClockPatience.ConsoleApp.Localisation;
using ConsoleApp.Localization;
using System.ComponentModel;
using System.Reflection;
using StaticContent = PatienceGame.Resources.StaticContent;



public class Program
{
    /// <summary>
    /// Entry point. Program starts here
    /// </summary>
    public static void Main(string[] args)
    {
        // Firstly, we're going to ask the user for his/her prefered language.
        Language lang = AskUserForLanguage();
        ILocalizationProvider loc = new JsonLocalizationProvider(lang);

        // Language has been selected. We can go ahead and introduce the game, using the language selected.
        StartGame(loc);
    }


    /// <summary>
    /// Simple method which asks the user to choose the default language used to play the rest of the game.
    /// </summary>
    /// <returns>Language</returns>
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
    /// Method which starts the actual game of clock patience.
    /// </summary>
    /// <param name="loc">Localisation interface with a language configured</param>
    private static void StartGame(ILocalizationProvider loc)
    {
        // Welcome the user to the game.
        Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_1"));
        Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_2"));
        Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_3"));
        Console.WriteLine(loc.Get("WELCOME_MESSAGE_LN_4"));
        Console.WriteLine(StaticContent.LINE_SEPARATOR);

        // Prompt the user to press any key to continue. Start the game only when a key is pressed.
        Console.ReadKey(false);

        // Game would go here...

        // Game has ended. Thank the user for playing and give instructions to end the game.
        Console.WriteLine(loc.Get("EXIT_PROMPT"));
        Console.ReadKey(true);
    }
}