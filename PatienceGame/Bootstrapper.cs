using ClockPatience.Application.Services;
using ClockPatience.Domain.Factories;
using ClockPatience.Domain.Interfaces;
using ClockPatience.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ClockPatience.ConsoleApp
{
    internal class Bootstrapper
    {
        public static ServiceProvider Bootstrap()
        {
            return BootstrapDI();
        }


        /// <summary>
        /// Bootstraps dependency injection for the application.
        /// </summary>
        /// <returns>Service Provider</returns>
        private static ServiceProvider BootstrapDI()
        {
            // Create service collection
            var services = new ServiceCollection();

            // Register domain factories
            services.AddSingleton<DeckFactory>();

            // Register application services
            services.AddScoped<GameService>();

            // Register repository (infrastructure)
            services.AddScoped<IGameRepository, GameRepository>();

            // Build provider
            return services.BuildServiceProvider();
        }
    }
}
