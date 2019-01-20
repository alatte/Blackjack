using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        internal string value { get; }
        internal string suit { get; }

        internal Card(string value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }
       
    }
}