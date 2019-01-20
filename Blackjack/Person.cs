using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    abstract class Person
    {
        internal string name;
        internal Hand hand;
        internal bool status;
        internal bool blackjack;

        internal abstract void Action(Deck deck);

        internal Person(string name)
        {
            this.name = name;
            hand = new Hand();
            status = true;
            blackjack = false;
        }

        internal void DealCards(Deck deck)
        {
            hand.AddCard(deck.GetCard());
            hand.AddCard(deck.GetCard());

            Console.WriteLine($"{name} cards: ");
            hand.WriteCards();
            blackjack = hand.CheckBlackjack();
        }

        internal  void TakeCard(Deck deck)
        {
            hand.AddCard(deck.GetCard());
            Console.WriteLine($"{name} take a card: ");
            hand.WriteCards();

            Console.WriteLine($"{name} points = {hand.CheckSum()}");
            if (hand.IsItDefeat())
            {
                status = false;
            }
        }
    }
}
