using Blackjack.Output;
using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(Person person, Deck deck);
    }

    public class Game : IObservable
    {
        Deck GameDeck;
        AbstractOutput Output;
        List<IObserver> observers;

        public Game(AbstractOutput output)
        {
            GameDeck = new Deck(new CardFactory());
            observers = new List<IObserver>();
            this.Output = output;
        }
           
        public void Play(string playerName, double playerMoney)
        {
            Dealer dealer = new Dealer(this);
            Player player = new Player(playerName, playerMoney);
            NotifyObservers(player, GameDeck);
            NotifyObservers(dealer, GameDeck);
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
        private void PlayerTurn (Player player)
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
                NotifyObservers(player, GameDeck);
            }
            else Output.UnknownCommand();
        }

        private void DealerTurn(Dealer dealer)
        {
            int dealerMustTake = 16;
            if (dealer.Hand.CheckSum() <= dealerMustTake)
            {
                NotifyObservers(dealer, GameDeck);
            }
            else
            {
                Output.PersonCheck(dealer.Name);
                dealer.Status = false;
            }
        }

        private void GetPersonCards(Person person)
        {
            string[,] cardsArray = new string[person.Hand.Cards.Count,2];
            for(int i = 0; i < person.Hand.Cards.Count; i++)
            {
                cardsArray[i, 0] = (person.Hand.Cards[i].Value).ToString();
                cardsArray[i, 1] = (person.Hand.Cards[i].Suit).ToString();
            }
            Output.CardsInHand(person.Name, cardsArray);
            Output.PointsInHand(person.Name, person.Hand.CheckSum());
        }

        private void IsAnybodyHasBlackjack (Person first, Person second)
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

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(Person person, Deck deck)
        {
            foreach (IObserver o in observers)
            {
                o.Update(person, deck);
            }
        }
    }
}
