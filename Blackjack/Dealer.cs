using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Dealer : Person
    {
        internal Dealer() 
            : base("Dealer") { }

        internal override void Action(Deck deck)
        {
            int dealerMustTake = 16;
            if (hand.CheckSum() <= dealerMustTake)
            {
                TakeCard(deck);
            }
            else
            {
                Console.WriteLine("Dealer checks");
                status = false;
            }
        }
    }
}
