namespace Blackjack.Entities
{
    class Card
    {
        internal Deck.Values value { get; }
        internal int suit { get; }

        internal Card(Deck.Values value, int suit)
        {
            this.value = value;
            this.suit = suit;
        }
       
    }
}