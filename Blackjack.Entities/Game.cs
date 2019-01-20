using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Entities;
using Blackjack.Output;

namespace Blackjack.Entities
{
    public class Game
    {
        Deck deck;
        IOutput output;       

        public Game(bool output)
        {
            deck = new Deck();
            if (output)
                this.output = new AlertOutput();
            else this.output = new ConsoleOutput();
        }

        public void Play(string playerName, double playerMoney)
        {
            Dealer dealer = new Dealer(output);
            Player player = new Player(playerName, playerMoney, output);
            player.DealCards(deck);
            dealer.DealCards(deck);

            IsAnybodyHasBlackjack(dealer, player);

            while (dealer.status || player.status)
            {
                if (player.status)
                    player.TurnAction(deck);

                if (dealer.status && !player.hand.IsItDefeat())
                    dealer.TurnAction(deck);
                else break;
            }

            WhoIsWinner(dealer, player);            
        }

        private void IsAnybodyHasBlackjack (Person first, Person second)
        {
            second.status = false;
            first.status = false;
            if (first.blackjack && !second.blackjack)
                output.ShowMessage(StringSource.Blackjack(first.name));
            else if (!first.blackjack && second.blackjack)
                output.ShowMessage(StringSource.Blackjack(second.name));
            else if (first.blackjack && second.blackjack)
                output.ShowMessage(StringSource.Blackjack("Both"));
            else
            {               
                first.status = true;
                second.status = true;
            }
        }

        private void WhoIsWinner(Person first, Person second)
        {
            //Ничего лучше у меня не получилось придумать
            if (first.hand.IsItDefeat() && !second.hand.IsItDefeat())
                output.ShowMessage(StringSource.Winner(second.name));
            else if (second.hand.IsItDefeat() && !first.hand.IsItDefeat())
                output.ShowMessage(StringSource.Winner(first.name));
            else
            {
                if (first.hand.CheckSum() > second.hand.CheckSum())
                    output.ShowMessage(StringSource.Winner(first.name)); 
                else if (first.hand.CheckSum() < second.hand.CheckSum())
                    output.ShowMessage(StringSource.Winner(second.name));
                else if (first.hand.CheckSum() == second.hand.CheckSum())
                    output.ShowMessage(StringSource.Winner("Nobody"));
            }
        }
    }
}
