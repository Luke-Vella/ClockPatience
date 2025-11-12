using ClockPatience.Domain.ValueObjects;

namespace ClockPatience.Domain.Entities
{
    /// <summary>
    /// Entity representing a pile of cards in Clock Solitaire.
    /// </summary>
    public class Pile
    {
        public Pile() { }

        public Pile(Rank acceptedRank) 
        {
            Id = Guid.NewGuid();
            AcceptedRank = acceptedRank;
            Cards = [];
        }

        public Guid Id { get; set; }
        public List<Card> Cards { get; set; } = [];
        public Rank AcceptedRank{ get; set; }

        public void AddCardToTopOfPile(Card card)
        {
            Cards.Add(card);
        }

        public void AddCardToBottomOfPile(Card card)
        {
            card.IsFaceUp = true;

            Cards.Insert(0, card);
        }

        public Card RevealTopCard()
        {
            if (Cards.Count == 0)
            {
                throw new InvalidOperationException("No cards in the pile to reveal.");
            }

            Card cardToReveal = Cards[^1];
            cardToReveal.IsFaceUp = true;

            return cardToReveal;
        }

        public void RemoveTopCard()
        {
            if (Cards.Count == 0)
            {
                throw new InvalidOperationException("No cards in the pile to remove.");
            }

            Cards.RemoveAt(Cards.Count - 1);
        }

    }
}
