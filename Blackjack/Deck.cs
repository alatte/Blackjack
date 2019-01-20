using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Deck
    {
        List<Card> cards;

        internal Deck()
        {
            cards = new List<Card>();
            List<string> suits = new List<string>()
            {
                "9824", "9827", "9829", "9830"
            };
            List<string> values = new List<string>()
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"
            };
            foreach (string suit in suits)
                foreach (string value in values)
                    cards.Add(new Card(value, suit));

            MixDeck();
        }

        internal void MixDeck()
        {
            Random rnd = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                Card tmp = cards[0];
                cards.RemoveAt(0);
                cards.Insert(rnd.Next(cards.Count), tmp);
            }
        }

        internal Card GetCard()
        {
            Card card = cards[0];
            cards.Remove(cards[0]);
            return card;
        }
    }
}
