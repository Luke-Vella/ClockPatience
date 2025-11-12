using ClockPatience.Application.DTOs;
using ClockPatience.Application.Services;
using ClockPatience.ConsoleApp.Localisation;
using Microsoft.Extensions.DependencyInjection;


namespace ClockPatience.ConsoleApp
{
    public class Program
    {
        private static ServiceProvider _serviceProvider = null!;
        private static ILocalizationProvider _loc = null!;
        private static GameService _gameService = null!;

        /// <summary>
        /// Entry point. Program starts here.
        /// </summary>
        public static void Main()
        {
            Setup();
            StartGame();
        }

        /// <summary>
        /// Bootstrapping app and setting up localisation.
        /// </summary>
        private static void Setup()
        {
            _serviceProvider = Bootstrapper.Bootstrap();
            _gameService = _serviceProvider.GetRequiredService<GameService>();
            _loc = new JsonLocalizationProvider(GameConsoleUI.AskUserForLanguage());
        }

        /// <summary>
        /// Method which starts the actual game of clock patience.
        /// </summary>
        private static void StartGame()
        {
            GameConsoleUI.WelcomeUserToGame(_loc);

            _gameService.StartNewGame();

            GameConsoleUI.InformUserGameIsStarting(_loc);

            int? decksToSeed = GameConsoleUI.ReadUserSeeding(_loc);

            List<DeckDTO> inputDecks;
            if (decksToSeed.HasValue)
            {
                GameConsoleUI.InformUserSeedingIsComplete(_loc);
                inputDecks = _gameService.SeedInput(decksToSeed.Value);
            }
            else
            {
                GameConsoleUI.InformUserAboutSampleDataChoice(_loc);
                inputDecks = _gameService.SeedInput();
            }

            if (inputDecks != null)
            {
                foreach (DeckDTO deckDTO in inputDecks)
                {
                    GameConsoleUI.PrintDeckToTerminal(deckDTO, !decksToSeed.HasValue);
                }
            }

            GameConsoleUI.PromptUserToReviewDecks(_loc);

            List<Tuple<int, CardDTO>> results = _gameService.PlayGame();

            GameConsoleUI.DisplayGameResultsToUser(results, _loc);

            if (GameConsoleUI.AskUserToRestartGame(_loc))
            {
                StartGame();
            }
        }
    }
}