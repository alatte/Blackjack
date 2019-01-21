using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{
    class Deck
    {
        List<Card> Cards;
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
            Cards = new List<Card>();

            foreach (int suit in Enum.GetValues(typeof(Suits)))
                foreach (string value in Enum.GetNames(typeof(Values)))
                    Cards.Add(new Card((Values)Enum.Parse(typeof(Values), value), suit));

            MixDeck();
        }

        internal void MixDeck()
        {
            Random rnd = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                Card tmp = Cards[0];
                Cards.RemoveAt(0);
                Cards.Insert(rnd.Next(Cards.Count), tmp);
            }
        }

        internal Card GetCard()
        {
            Card card = Cards[0];
            Cards.Remove(Cards[0]);
            return card;
        }
    }
}
