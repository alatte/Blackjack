using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{
    class Deck
    {
        List<Card> cards;
        internal enum Suits
        {
            Spades = 9824,
            Clubs = 9827,
            Hearts = 9829,
            Diamonds = 9830
        }
        internal enum Values
        {
            Two = 2,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack = 10,
            Queen = 10,
            King = 10,
            Ace = 11
        }


        internal Deck()
        {
            cards = new List<Card>();

            foreach (int suit in Enum.GetValues(typeof(Suits)))
                foreach (string value in Enum.GetNames(typeof(Values)))
                    cards.Add(new Card((Values)Enum.Parse(typeof(Values), value), suit));

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
