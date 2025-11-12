using ClockPatience.Domain.Entities;

namespace ClockPatience.Domain.ValueObjects
{
    public class SolitaireClock
    {
        public SolitaireClock()
        {
            PileRanks =
            [
                new (Rank.Ace),
                new (Rank.Two),
                new (Rank.Three),
                new (Rank.Four),
                new (Rank.Five),
                new (Rank.Six),
                new (Rank.Seven),
                new (Rank.Eight),
                new (Rank.Nine),
                new (Rank.Ten),
                new (Rank.Jack),
                new (Rank.Queen),
                new (Rank.King)
            ];
        }

        public List<Pile> PileRanks { get; } = [];

        public Pile GetPileByRank(Rank acceptedRank)
        {
            Pile? pileToReturn = PileRanks.FirstOrDefault(p => p.AcceptedRank == acceptedRank);

            if (pileToReturn != null)
            {
                return pileToReturn;
            }
            else
            {
                throw new InvalidOperationException($"No pile found for the rank: {acceptedRank}");
            }
        }

        public IEnumerable<Pile> GetAllPiles()
        {
            return PileRanks;
        }

        public void Reset()
        {
            foreach (var pile in PileRanks)
            {
                pile.Cards.Clear();
            }
        }

        public Card DealFirstCard()
        {
            return GetPileByRank(Rank.King).RevealTopCard();
        }

        public Card DealNextCard(Rank currentRank)
        {
            Pile currentPile = GetPileByRank(currentRank);
            Card revealedCard = currentPile.RevealTopCard();
            return revealedCard;
        }
    }
}
