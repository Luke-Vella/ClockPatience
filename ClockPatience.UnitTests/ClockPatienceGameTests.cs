using ClockPatience.Domain.Entities;
using ClockPatience.Domain.Factories;

namespace ClockPatience.UnitTests
{
    public class ClockPatienceGameTests
    {
        [Fact]
        public void Play_WithKnownLosingDeck_ShouldLoseGame()
        {
            // Arrange: Use the deterministic losing deck
            string input = @"7D TD TH KH 6S AH 3S 5S 5D 2C 7H 7C 8D 4S 2D TS 6H JH 6C 4H QD 9H 5C 4D 7S 9C AD 3C 8C 4C JC 8S KS QC AS 6D KC 9S 2S AC 2H KD JD 8H 3H TC 9D 3D JS QS QH 5H";

            Deck deck = DeckFactory.CreateFromCardCodes(input);

            var game = new ClockSolitaireGame();

            // Act
            var (moves, lastCard) = game.Play();

            // Assert: Should not reach 51 moves (win condition)
            Assert.NotEqual(51, moves);
        }

        [Fact]
        public void Play_WithKnownWinningDeck_ShouldWinGame()
        {
            string input = @"4H 4S JC QD 6D 3H 7H 9C JH 5D AD 8S 5H 7C 6H 2D 5C AC 6S TH JD 4D JS AS QS KS TC QH 7S 9H 9S 3S 8H 8D TS AH KD 5S 7D 2H 3D KC TD 9D QC 3C 2S 4C 6C 2C KH 8C";

            Deck deck = DeckFactory.CreateFromCardCodes(input);

            var game = new ClockSolitaireGame(deck);

            var (moves, lastCard) = game.Play();

            // Assert: Should reach 51 moves (win condition)
            Assert.Equal(51, moves);
        }


        [Fact]
        public void Play_WithCaseStudyDeck_ShouldLoseGameWith44Moves()
        {            
            var game = new ClockSolitaireGame(true);

            var (moves, lastCard) = game.Play();

            // Assert: Should reach 44 moves
            Assert.Equal(44, moves);
        }

    }
}