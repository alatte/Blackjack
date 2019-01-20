using System;
using System.Collections.Generic;

namespace Blackjack.Entities
{
    public static class StringSource
    {
        internal static string unknownCommand = "Unknown command";
        internal static string playerTakeCard = "Take card? (Y/N)";

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

        internal static string CardsInHand(string personName, List<Card> cards)
        {          
            string result = $"{personName}'s cards:\n" +
                $"";           
            foreach (Card card in cards)
            {
                
                result += ($"|{card.value} {(char)card.suit}| ");

            }
            result += "\n";
            result += (new string('=', 15));
            return result;
        }

        internal static string PointsInHand(string personName, int sum)
        {
            return $"{personName} points = {sum}";
        }
    }
}
