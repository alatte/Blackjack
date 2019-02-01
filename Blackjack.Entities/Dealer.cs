using System;

namespace Blackjack.Entities
{
    class Dealer : Person, IObserver
    {
        IObservable Game;

        internal Dealer(IObservable game) 
            : base("Dealer")
        {
            Game = game;
            Game.RegisterObserver(this);
        }
       
        private void DealCards(Person person, Deck deck)
        {
            person.Hand.AddCard(deck.GetCard());
            person.Hand.AddCard(deck.GetCard());
            person.Blackjack = person.Hand.CheckBlackjack();
        }

        private void GiveCard(Person person, Deck deck)
        {
            person.Hand.AddCard(deck.GetCard());
            if (person.Hand.IsItDefeat())
            {
                person.Status = false;
            }
        }

        //Таки события это есть наблюдатель?
        public void Update(Person person, Deck deck)
        {
            if (person.Hand.Cards.Count == 0)
                DealCards(person, deck);

            else GiveCard(person, deck);          
        }
    }

    public interface IObserver
    {
        void Update(Person person, Deck deck);
    }
}
