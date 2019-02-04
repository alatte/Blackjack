using System;

namespace Blackjack.Entities
{
    public class Dealer : Person, IObserver<Player>
    {
        private IDisposable unsubscriber;

        public Dealer()
            : base("Dealer") { }
       
        public void DealCards(Person person)
        {
            person.Hand.AddCard(Game.GameDeck.GetCard());
            person.Hand.AddCard(Game.GameDeck.GetCard());
            person.Blackjack = person.Hand.CheckBlackjack();
        }

        public void GiveCard(Person person)
        {
            person.Hand.AddCard(Game.GameDeck.GetCard());
            if (person.Hand.IsItDefeat())
            {
                person.Status = false;
            }
        }

        //IObserver parts
        public virtual void Subscribe(IObservable<Player> player)
        {
            if (player != null)
                unsubscriber = player.Subscribe(this);
        }

        public void OnNext(Player player)
        {
            if (player.Hand.Cards.Count == 0)
                DealCards(player);

            else GiveCard(player);
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("OnError");
        }

        public void OnCompleted()
        {
            Console.WriteLine("OnCompleted");
            this.Unsubscribe();
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
