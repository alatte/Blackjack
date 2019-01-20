using Blackjack.Output;
using System;

namespace Blackjack.Entities
{
    class Player : Person
    {
        double money;

        internal Player(string name, double money, IOutput output)
            : base(name, output)
        {
            this.money = money;
        }

        internal override void TurnAction(Deck deck)
        {
            output.ShowMessage(StringSource.playerTakeCard);
            string answer = Console.ReadLine().ToUpper();
            if (answer == "N")
            {
                output.ShowMessage(StringSource.PersonCheck(name));
                status = false;
            }

            else if (answer == "Y")
            {
                TakeCard(deck);
            }

            else output.ShowMessage(StringSource.unknownCommand);
        }

    }
}
