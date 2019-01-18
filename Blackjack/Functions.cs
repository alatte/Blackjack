using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Functions
    {
        static List<string> deck;

        internal void WhoIsWinner(List<Player> players)
        {
            if (CheckSum(players[0]) > CheckSum(players[1]))
                Console.WriteLine($"====={players[0].name} win=====");
            else if (CheckSum(players[0]) < CheckSum(players[1]))
                Console.WriteLine($"====={players[1].name} win=====");
            else if (CheckSum(players[0]) == CheckSum(players[1]))
                Console.WriteLine("=====Push. Nobody win=====");
        }

        internal void DealerAction(Player dealer)
        {
            if (CheckSum(dealer) <= 16)
            {
                TakeCard(dealer);
                if (CheckSum(dealer) > 21)
                {
                    Console.WriteLine("=====You win=====");
                    dealer.status = false;
                }
            }
            else Console.WriteLine("Dealer checks");
        }

        internal void TakeCard(Player player)
        {
            player.cards.Add(deck[0]);
            Console.WriteLine($"{player.name} take a card: ");
            WriteCard(deck[0]);
            deck.Remove(deck[0]);

            int sum = CheckSum(player);
            Console.WriteLine($"{player.name} points = {sum}");
            if (sum > 21)
            {
                Console.WriteLine($"====={player.name} lose=====");
                player.status = false;
            }
        }

        internal int CheckSum(Player player)
        {
            Dictionary<string, int> values = new Dictionary<string, int>
            {
                ["2"] = 2,
                ["3"] = 3,
                ["4"] = 4,
                ["5"] = 5,
                ["6"] = 6,
                ["7"] = 7,
                ["8"] = 8,
                ["9"] = 9,
                ["10"] = 10,
                ["Jack"] = 10,
                ["Queen"] = 10,
                ["King"] = 10,
                ["Ace"] = 11
            };
            int sum = 0;

            foreach (string card in player.cards)
            {
                string[] num = card.Split('/');
                sum += values[num[0]];
            }

            return sum;
        }

        internal void MixDeck(List<string> listToMix)
        {
            Random rnd = new Random();
            for (int i = 0; i < listToMix.Count; i++)
            {
                string tmp = listToMix[0];
                listToMix.RemoveAt(0);
                listToMix.Insert(rnd.Next(listToMix.Count), tmp);
            }
        }

        internal void DealCards(List<Player> players)
        {
            deck = Program.deck;
            foreach (Player p in players)
            {
                for (int i = 0; i < 2; i++)
                {
                    p.cards.Add(deck[0]);
                    deck.Remove(deck[0]);
                }
            }

            foreach (Player p in players)
            {
                Console.WriteLine($"{p.name} cards: ");
                WriteCards(p.cards);
                p.status = CheckBlackjack(p);
            }
        }

        internal bool CheckBlackjack(Player player)
        {
            string first = player.cards[0].Split('/')[0];
            string second = player.cards[1].Split('/')[0];
            if (first == second && first == "Jack" || CheckSum(player) == 21)
            {
                Console.WriteLine($"====={player.name} get BlackJack====");
                return false;
            }

            else return true;
        }

        internal void WriteCards(List<string> cards)
        {
            foreach (string card in cards)
            {
                string[] num = card.Split('/');
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Write("|{0} {1}| ", num[0], (char)int.Parse(num[1]));

            }
            Console.WriteLine("");
            Console.WriteLine(new string('=', 15));
        }

        internal void WriteCard(string card)
        {
            string[] num = card.Split('/');
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("|{0} {1}| ", num[0], (char)int.Parse(num[1]));
        }
    }
}
