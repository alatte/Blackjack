using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Output
{
    public abstract class AbstractOutput
    {
        public abstract void ShowMessage(string messageText);

        public void Blackjack(string personName)
        {
            ShowMessage(StringSource.Blackjack(personName));
        }
        public void CardsInHand(string personName, string[,] cardsArray)
        {
            ShowMessage(StringSource.CardsInHand(personName, cardsArray));
        }

        public void PersonCheck(string personName)
        {
            ShowMessage(StringSource.PersonCheck(personName));
        }

        public void PlayerTakeCard()
        {
            ShowMessage(StringSource.PlayerTakeCard);
        }

        public void PointsInHand(string personName, int sum)
        {
            ShowMessage(StringSource.PointsInHand(personName, sum));
        }

        public void UnknownCommand()
        {
            ShowMessage(StringSource.UnknownCommand);
        }

        public void Winner(string personName)
        {
            ShowMessage(StringSource.Winner(personName));
        }
    }
}
