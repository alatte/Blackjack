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
        Ace,
        Jack,
        Queen,
        King
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
}