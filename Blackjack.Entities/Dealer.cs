using Blackjack.Output;

namespace Blackjack.Entities
{
    class Dealer : Person
    {
        internal Dealer(IOutput output) 
            : base("Dealer", output) { }

        internal override void TurnAction(Deck deck)
        {
            int dealerMustTake = 16;
            if (hand.CheckSum() <= dealerMustTake)
            {
                TakeCard(deck);
            }
            else
            {
                output.ShowMessage(StringSource.PersonCheck(name));
                status = false;
            }
        }
    }
}
