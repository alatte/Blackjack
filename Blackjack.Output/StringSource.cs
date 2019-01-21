using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Output
{
    public static class StringSource
    {
        internal static string UnknownCommand = "Unknown command";
        internal static string PlayerTakeCard = "Take card? (Y/N)";

        internal static string Blackjack(string personName)
        {
            return $"====={personName} gets BlackJack=====";
        }

        internal static string Winner(string personName)
        {
            return $"====={personName} is Winner=====";
        }

        internal static string PersonCheck(string personName)
        {
            return $"====={personName} cheks=====";
        }

        internal static string CardsInHand(string personName, string[,] cardsArray)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"{personName}'s cards:\n");           
            for (int i = 0; i < cardsArray.GetLength(0); i++)
            {
                //Извините, я не придумала ничего другого :(
                builder.Append($"|{cardsArray[i,0]} {(char)int.Parse(cardsArray[i, 1])}| ");
            }
            return builder.ToString();
        }

        internal static string PointsInHand(string personName, int sum)
        {
            return $"\n{personName} points = {sum}\n {new string('=', 15)}";
        }
    }
}
