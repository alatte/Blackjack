using Blackjack.Output;
using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{
    class Hand
    {
        List<Card> cards;
        int maxGameValue = 21;

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
            return CheckSum() > maxGameValue;
        }

        internal int CheckSum()
        {

            int sum = 0;

            foreach (Card card in cards)
            {
                sum += (int) card.value;
            }

            return sum;
        }

        internal bool CheckBlackjack()
        {
            if (cards[0].value == cards[1].value && Enum.GetName(typeof(Deck.Values), cards[0].value) == "Jack" || CheckSum() == maxGameValue)
            {
                return true;
            }
            else return false;
        }

        internal void WriteCards(string name, IOutput output)
        {
            output.ShowMessage(StringSource.CardsInHand(name, cards));
        }
    }
}
