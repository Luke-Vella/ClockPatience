// Simple terminal input scaffold for PatienceGame
using ClockPatience.Application.DTOs;
using ClockPatience.Application.Interfaces;
using ClockPatience.Application.Services;
using ClockPatience.ConsoleApp.Localisation;
using ClockPatience.Domain.Factories;
using ConsoleApp.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace ClockPatience.ConsoleApp
{
    public class Program
    {
        private static ServiceProvider _serviceProvider = null!;
        private static ILocalizationProvider _loc = null!;
        private static IGameService _gameService = null!;

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

            List<DeckDTO>? seededDecks = _gameService.SeedDecks(GameConsoleUI.PromptUserToSeedDecks(_loc));

            GameConsoleUI.InformUserSeedingIsComplete(_loc);
            GameConsoleUI.PrintGenericContinueMessageWithSpacing(_loc);

            if (seededDecks != null)
            {
                foreach (DeckDTO deckDTO in seededDecks)
                {
                    GameConsoleUI.PrintDeckToTerminal(deckDTO);
                }
            }

            GameConsoleUI.PromptUserToReviewDecks(_loc);
        }
    }
}