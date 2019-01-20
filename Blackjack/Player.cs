using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player : Person
    {
        internal Player()
            : base("You") { }


        internal override void Action(Deck deck)
        {
            Console.WriteLine("Take card? (Y/N)");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "N")
                status = false;

            else if (answer == "Y")
            {
                TakeCard(deck);
            }

            else Console.WriteLine("Unknown command");
        }

    }
}
