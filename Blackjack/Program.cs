using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        internal static List<string> deck;

        static void Main(string[] args)
        {
            List<string> cards = new List<string>()
            {
                "2/9824", "3/9824", "4/9824", "5/9824", "6/9824", "7/9824", "8/9824", "9/9824", "10/9824", "Jack/9824", "Queen/9824", "King/9824", "Ace/9824",
                "2/9827", "3/9827", "4/9827", "5/9827", "6/9827", "7/9827", "8/9827", "9/9827", "10/9827", "Jack/9827", "Queen/9827", "King/9827", "Ace/9827",
                "2/9829", "3/9829", "4/9829", "5/9829", "6/9829", "7/9829", "8/9829", "9/9829", "10/9829", "Jack/9829", "Queen/9829", "King/9829", "Ace/9829",
                "2/9830", "3/9830", "4/9830", "5/9830", "6/9830", "7/9830", "8/9830", "9/9830", "10/9830", "Jack/9830", "Queen/9830", "King/9830", "Ace/9830"
            };
            List<Player> players = new List<Player>() {
                 new Player("Dealer"), new Player("You")
            };
            Functions fun = new Functions();
            double bid;
            do
            {
                foreach (Player p in players)
                    p.cards = new List<string>();
                Console.Clear();
                while (true)
                {
                    Console.WriteLine("Your bid?");
                    bool success = Double.TryParse(Console.ReadLine(), out bid);
                    if (success || bid < 0)
                        Console.WriteLine("Error");
                    else break;
                }
                deck = cards.Clone();               
                fun.MixDeck(deck);
                fun.DealCards(players);

                while (players[0].status && players[1].status)
                {
                    Console.WriteLine("Take card? (Y/N)");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "N")
                        break;

                    else if (answer == "Y")
                    {
                        fun.TakeCard(players[1]);
                        if (players[1].status)
                        {
                            fun.DealerAction(players[0]);
                        }
                    }

                    else Console.WriteLine("Unknown command");
                }

                if (players[1].status)
                    while (fun.CheckSum(players[0]) < 16)
                        fun.DealerAction(players[0]);

                if (players[0].status && players[1].status)
                {
                    foreach (Player p in players)
                    {
                        Console.WriteLine($"{p.name} cards: ");
                        fun.WriteCards(p.cards);
                        Console.WriteLine($"{p.name} points = {fun.CheckSum(p)}");
                    }
                    fun.WhoIsWinner(players);
                }

                Console.WriteLine("Play again? (Y/N)");
            } while (Console.ReadLine().ToUpper() == "Y");
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
