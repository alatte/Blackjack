using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        internal string name { get; }
        internal List<string> cards { get; set; }
        internal bool status { get; set; }
        internal double money { get; set; }

        internal Player(string name)
        {
            this.name = name;
            cards = new List<string>();
            money = 1000;
            status = true;
        }
    }
}
