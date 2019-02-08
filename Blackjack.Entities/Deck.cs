using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{
    public class Deck
    {
        List<Card> Cards;
        
        internal Deck(CardFactory factory)
        {            
            Cards = factory.CreateDeck() as List<Card>;
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
