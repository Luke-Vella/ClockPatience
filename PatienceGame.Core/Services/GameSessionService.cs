using ClockPatience.Domain.Entities;
using ClockPatience.Domain.Factories;
using ClockPatience.Domain.ValueObjects;

namespace ClockPatience.Domain.Services
{
    public class GameSessionService
    {
        private List<ClockSolitaireGame> _gameInstancesToBePlayed;

        public GameSessionService()
        {
            _gameInstancesToBePlayed = [];
        }

        public void StartNewSession()
        {
            _gameInstancesToBePlayed = [];
        }

        public void StopCurrentSession()
        {
            _gameInstancesToBePlayed = [];
        }

        public List<Deck> SeedGameInstances(int amountOfDecks)
        {
            for (int i = 0; i < amountOfDecks; i++)
            {
                ClockSolitaireGame game = new();
                _gameInstancesToBePlayed.Add(game);
            }

            return [.. _gameInstancesToBePlayed.Select(game => game.Deck)];  
        }

        public List<Tuple<int, Card>> PlayGame()
        {
            List<Tuple<int, Card>> results = [];
            for (int i = 0; i < _gameInstancesToBePlayed.Count; i++)
            {
                Tuple<int, Card> result = _gameInstancesToBePlayed[i].Play();
                results.Add(result);
            }

            return results;
        }
    }
}
