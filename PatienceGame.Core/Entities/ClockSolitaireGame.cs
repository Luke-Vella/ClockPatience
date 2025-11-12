using ClockPatience.Domain.Factories;
using ClockPatience.Domain.ValueObjects;

namespace ClockPatience.Domain.Entities
{
    /// <summary>
    /// Entity representing a game of Clock Solitaire.
    /// </summary>
    public class ClockSolitaireGame
    {
        private readonly Deck _input;
        private readonly SolitaireClock _clock;

        public ClockSolitaireGame(bool useCaseStudy = false) 
        { 
            if(useCaseStudy)
            {
                _input = DeckFactory.CreateCaseStudyDeck();
            }
            else
            {
                _input = DeckFactory.CreateStandard();
                _input.Shuffle();
            }

            _clock = new SolitaireClock();
        }

        public ClockSolitaireGame(Deck inputDeck)
        {
            _input = inputDeck;
            _clock = new SolitaireClock();
        }

        public Guid Id { get; } = Guid.NewGuid();
        public Deck Input => _input;

        /// <summary>
        /// Plays the Clock Solitaire game according to the rules.
        /// </summary>
        /// <returns>Results of the game</returns>
        public Tuple<int, Card> Play()
        {
            // First pile should always be king, as per the rules of the game
            var currentPile = _clock.GetPileByRank(Rank.King);

            // Deal first card
            var currentCard = _input.DealFirstCard();
            
            // Metrics for game over condition
            var lastPlayed = currentCard;
            int moves = 0;

            // While there are still cards left to be played and there isn't a pile with 4 cards which are already flipped over...
            while (currentCard != null && currentPile.Cards.Count < 4)
            {
                lastPlayed = currentCard;

                // Add a flipped over card to the bottom of the current pile.
                currentPile.AddCardToBottomOfPile(currentCard);

                // Assign the current pile to be the pile matching the rank of the current card.
                currentPile = _clock.GetPileByRank(currentCard.Rank);

                // Deal next card
                var nextCard = _input.DealCard();

                // Assign next card to be current card for next iteration.
                currentCard = nextCard;

                // Increment moves.
                moves++;
            }

            // Return moves played and last card played
            return new Tuple<int, Card>(moves, lastPlayed);
        }
    }
}
