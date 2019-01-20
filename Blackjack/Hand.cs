using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Hand
    {
        List<Card> cards;

        internal Hand()
        {
            cards = new List<Card>();
        }

        internal void AddCard(Card card)
        {
            cards.Add(card);
        }

        internal bool IsItDefeat()
        {
            int maxGameValue = 21;
            return CheckSum() > maxGameValue;
        }

        internal int CheckSum()
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

            foreach (Card card in cards)
            {
                sum += values[card.value];
            }

            return sum;
        }

        internal bool CheckBlackjack()
        {
            if (cards[0].value == cards[1].value && cards[0].value == "Jack" || CheckSum() == 21)
            {
                return true;
            }
            else return false;
        }

        internal void WriteCards()
        {
            foreach (Card card in cards)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Write("|{0} {1}| ", card.value, (char)int.Parse(card.suit));

            }
            Console.WriteLine("");
            Console.WriteLine(new string('=', 15));
        }
    }
}
