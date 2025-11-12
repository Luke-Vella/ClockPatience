using ClockPatience.Domain.Factories;
using ClockPatience.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClockPatience.Domain.Entities
{
    public class ClockSolitaireGame
    {
        public ClockSolitaireGame() 
        { 
            _deck = DeckFactory.CreateStandard();
            _deck.Shuffle();
            _clock = new SolitaireClock();
        }

        private Deck _deck;
        private SolitaireClock _clock;

        public Guid Id { get; } = Guid.NewGuid();

        public Deck Deck => _deck;

        public void Reset(Deck? seededDeck = null)
        {
            if(seededDeck == null)
            {
                _deck = DeckFactory.CreateStandard();
                _deck.Shuffle();
            }
            else
            {
                _deck = seededDeck;
            }

            _clock = new SolitaireClock();
        }

        public Tuple<int, Card> Play()
        {
            // Deal all cards in the deck to the clock piles
            Card? currentCard = _deck.DealCard();
            do
            {
                foreach (Pile pile in _clock.PileRanks)
                {
                    if (currentCard != null)
                    {
                        _deck.RemoveCard(currentCard);
                        pile.AddCardToTopOfPile(currentCard);

                        currentCard = _deck.DealCard();
                    }
                }
            } while (currentCard != null);


            // Start trying to reorder the cards, starting with the first default pile (King)
            Pile currentActivePile = _clock.GetPileByRank(Rank.King);

            Card? currentPlayingCard = currentActivePile.RevealTopCard(); // Used to track the current card being played
            Card lastPlayedCard = currentPlayingCard;

            int numberOfMoves = 0;

            do
            {
                currentActivePile = MoveCardToPile(_clock, currentPlayingCard, currentActivePile);

                lastPlayedCard = currentPlayingCard;
                numberOfMoves++;

                currentPlayingCard = currentActivePile.RevealTopCard();
            } while (currentPlayingCard != null);


            // Game over - return the number of moves and the last played card
            return new Tuple<int, Card>(numberOfMoves, lastPlayedCard);
        }

        private static Pile MoveCardToPile(SolitaireClock clock, Card currentPlayingCard, Pile currentActivePile)
        {
            foreach (Pile currentPile in clock.PileRanks)
            {
                if (currentPile.AcceptedRank == currentPlayingCard.Rank)
                {
                    currentPile.AddCardToBottomOfPile(currentPlayingCard);
                    currentActivePile.RemoveTopCard();

                    return currentPile;
                }
            }

            return currentActivePile;
        }
    }
}
