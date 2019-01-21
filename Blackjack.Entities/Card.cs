namespace Blackjack.Entities
{
    class Card
    {
        internal Deck.Values Value { get; }
        internal int Suit { get; }

        internal Card(Deck.Values value, int suit)
        {
            this.Value = value;
            this.Suit = suit;
        }
       
    }
}