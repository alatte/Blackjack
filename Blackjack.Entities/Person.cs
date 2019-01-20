using Blackjack.Output;

namespace Blackjack.Entities
{
    abstract class Person
    {
        internal string name;
        internal Hand hand;
        internal bool status;
        internal bool blackjack;
        internal IOutput output;

        internal abstract void TurnAction(Deck deck);

        internal Person(string name, IOutput output)
        {
            this.name = name;
            this.output = output;
            hand = new Hand();
            status = true;
            blackjack = false;           
        }

        internal void DealCards(Deck deck)
        {
            hand.AddCard(deck.GetCard());
            hand.AddCard(deck.GetCard());

            hand.WriteCards(name, output);
            blackjack = hand.CheckBlackjack();
        }

        internal void TakeCard(Deck deck)
        {
            hand.AddCard(deck.GetCard());
            hand.WriteCards(name, output);

            output.ShowMessage(StringSource.PointsInHand(name, hand.CheckSum()));
            if (hand.IsItDefeat())
            {
                status = false;
            }
        }
    }
}
