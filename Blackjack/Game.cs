using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Game
    {
        Deck deck;
        internal Game()
        {
            deck = new Deck();
        }

        internal void Play()
        {
            Dealer dealer = new Dealer();
            Player player = new Player();
            player.DealCards(deck);
            dealer.DealCards(deck);

            IsAnybodyHasBlackjack(dealer, player);

            while (dealer.status || player.status)
            {
                if (player.status)
                    player.Action(deck);

                if (dealer.status)
                    dealer.Action(deck);
            }

            WhoIsWinner(dealer, player);            
        }

        internal void IsAnybodyHasBlackjack (Person first, Person second)
        {
            second.status = false;
            first.status = false;
            if (first.blackjack && !second.blackjack)
                Console.WriteLine($"====={first.name} get BlackJack=====");
            else if (!first.blackjack && second.blackjack)
                Console.WriteLine($"====={second.name} get BlackJack=====");
            else if (first.blackjack && second.blackjack)
                Console.WriteLine("=====Two BlackJacks. Not bad=====");
            else
            {               
                first.status = true;
                second.status = true;
            }
        }

        internal void WhoIsWinner(Person first, Person second)
        {
            //Ничего лучше у меня не получилось придумать
            if (first.hand.IsItDefeat() && !second.hand.IsItDefeat())
                Console.WriteLine($"====={second.name} win=====");
            else if (second.hand.IsItDefeat() && !first.hand.IsItDefeat())
                Console.WriteLine($"====={first.name} win=====");
            else if (second.hand.IsItDefeat() && first.hand.IsItDefeat())
                Console.WriteLine("=====Dva loha. Nobody wins=====");
            else
            {
                if (first.hand.CheckSum() > second.hand.CheckSum())
                    Console.WriteLine($"====={first.name} win=====");
                else if (first.hand.CheckSum() < second.hand.CheckSum())
                    Console.WriteLine($"====={second.name} win=====");
                else if (first.hand.CheckSum() == second.hand.CheckSum())
                    Console.WriteLine("=====Push=====");
            }
        }
    }

    static class ListExtensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
