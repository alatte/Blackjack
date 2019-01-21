namespace Blackjack.Entities
{
    abstract class Person
    {
        internal string Name;
        internal Hand Hand;
        internal bool Status;
        internal bool Blackjack;

        internal Person(string name)
        {
            this.Name = name;
            Hand = new Hand();
            Status = true;
            Blackjack = false;           
        }

        internal void DealCards(Deck deck)
        {
            Hand.AddCard(deck.GetCard());
            Hand.AddCard(deck.GetCard());
            Blackjack = Hand.CheckBlackjack();
        }

        internal void TakeCard(Deck deck)
        {
            Hand.AddCard(deck.GetCard());           
            if (Hand.IsItDefeat())
            {
                Status = false;
            }
        }
    }
}
