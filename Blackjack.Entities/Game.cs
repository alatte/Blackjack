using Blackjack.Output;
using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{
    public class Game : IObservable<Player>
    {
        public static Deck GameDeck;
        private List<IObserver<Player>> observers;
        AbstractOutput Output;

        public Game(AbstractOutput output)
        {
            GameDeck = new Deck(new CardFactory());
            observers = new List<IObserver<Player>>();
            this.Output = output;
        }

        public void Play(string playerName, double playerMoney)
        {
            Dealer dealer = new Dealer();
            Player player = new Player(playerName, playerMoney);
            dealer.Subscribe(this);

            NotifyObservers(player);
            dealer.DealCards(dealer);
            GetPersonCards(player);
            GetPersonCards(dealer);

            IsAnybodyHasBlackjack(dealer, player);

            while (dealer.Status || player.Status)
            {
                if (player.Status)
                {
                    PlayerTurn(player);
                    GetPersonCards(player);
                }

                if (dealer.Status && !player.Hand.IsItDefeat())
                {
                    DealerTurn(dealer);
                    GetPersonCards(dealer);
                }
                else break;
            }

            WhoIsWinner(dealer, player);
        }

        //Это портит СОЛИД, да?
        //Хотя а был ли он здесь вообще?
        private void PlayerTurn(Player player)
        {
            Output.PlayerTakeCard();
            string answer = Console.ReadLine().ToUpper();
            if (answer == "N")
            {
                Output.PersonCheck(player.Name);
                player.Status = false;
            }
            else if (answer == "Y")
            {
                NotifyObservers(player);
            }
            else Output.UnknownCommand();
        }

        private void DealerTurn(Dealer dealer)
        {
            int dealerMustTake = 16;
            if (dealer.Hand.CheckSum() <= dealerMustTake)
            {
                dealer.GiveCard(dealer);
            }
            else
            {
                Output.PersonCheck(dealer.Name);
                dealer.Status = false;
            }
        }

        private void GetPersonCards(Person person)
        {
            string[,] cardsArray = new string[person.Hand.Cards.Count, 2];
            for (int i = 0; i < person.Hand.Cards.Count; i++)
            {
                cardsArray[i, 0] = (person.Hand.Cards[i].Value).ToString();
                cardsArray[i, 1] = (person.Hand.Cards[i].Suit).ToString();
            }
            Output.CardsInHand(person.Name, cardsArray);
            Output.PointsInHand(person.Name, person.Hand.CheckSum());
        }

        private void IsAnybodyHasBlackjack(Person first, Person second)
        {
            second.Status = false;
            first.Status = false;
            if (first.Blackjack && !second.Blackjack)
                Output.Blackjack(first.Name);
            else if (!first.Blackjack && second.Blackjack)
                Output.Blackjack(second.Name);
            else if (first.Blackjack && second.Blackjack)
                Output.Blackjack("Both");
            else
            {
                first.Status = true;
                second.Status = true;
            }
        }

        private void WhoIsWinner(Person first, Person second)
        {
            if (first.Hand.IsItDefeat() && !second.Hand.IsItDefeat())
                Output.Winner(second.Name);
            else if (second.Hand.IsItDefeat() && !first.Hand.IsItDefeat())
                Output.Winner(first.Name);
            else
            {
                if (first.Hand.CheckSum() > second.Hand.CheckSum())
                    Output.Winner(first.Name);
                else if (first.Hand.CheckSum() < second.Hand.CheckSum())
                    Output.Winner(second.Name);
                else if (first.Hand.CheckSum() == second.Hand.CheckSum())
                    Output.Winner("Nobody");
            }
        }

        //IObservable parts
        public IDisposable Subscribe(IObserver<Player> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Player>> _observers;
            private IObserver<Player> _observer;

            public Unsubscriber(List<IObserver<Player>> observers, IObserver<Player> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        private void NotifyObservers(Player player)
        {
            foreach (var observer in observers)
                observer.OnNext(player);
        }
    }
}
