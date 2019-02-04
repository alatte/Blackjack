using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Entities
{
    enum Suits
    {
        Spades = 9824,
        Clubs = 9827,
        Hearts = 9829,
        Diamonds = 9830
    }
    //А вот об этой ошибке я у тебя еще почти в самом начале спрашивала
    enum Values
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

    struct Card
    {
        internal Values Value { get; }
        internal int Suit { get; }

        internal Card(Values value, int suit)
        {
            this.Value = value;
            this.Suit = suit;
        }      
    }

    /*struct Card
     {
        private AbstractSuit suit;
        private AbstractValue value;

        public Card (CardFactory factory)
        {
            suit = factory.CreateSuit();
            value = factory.CreateValue();
        }
     }*/   
}