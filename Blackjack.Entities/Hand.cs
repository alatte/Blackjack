﻿using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{
    class Hand
    {
        internal List<Card> Cards;
        int MaxGameValue = 21;

        internal Hand()
        {
            Cards = new List<Card>();
        }

        internal void AddCard(Card card)
        {
            Cards.Add(card);
        }

        internal bool IsItDefeat()
        {            
            return CheckSum() > MaxGameValue;
        }

        internal int CheckSum()
        {

            int sum = 0;

            foreach (Card card in Cards)
            {
                if (card.Value.ToString() == "Jack" || card.Value.ToString() == "Queen" || card.Value.ToString() == "King")
                    sum += 10;
                else sum += (int) card.Value;
            }

            return sum;
        }

        internal bool CheckBlackjack()
        {
            if (Cards[0].Value == Cards[1].Value && Enum.GetName(typeof(Values), Cards[0].Value) == "Jack" || CheckSum() == MaxGameValue)
            {
                return true;
            }
            else return false;
        }
    }
}
