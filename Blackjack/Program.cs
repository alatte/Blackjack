using System;
using System.Collections.Generic;
using Blackjack.Entities;
using Blackjack.Output;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = GetPlayerName();
            double playerMoney = GetPlayerMoney();
            Output.AbstractOutput output = AlertOrConsole();

            do
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear();
                Game game = new Game(output);
                game.Play(playerName, playerMoney);
                Console.WriteLine("Play again? (Y/N)");
            } while (Console.ReadLine().ToUpper() == "Y");
        }

        private static string GetPlayerName()
        {
            Console.WriteLine("Your name: ");
            return Console.ReadLine();
        }

        private static double GetPlayerMoney()
        {            
            double money = 0
;
            bool success = false;
            while (!success)
            {
                Console.WriteLine("How much money do you have?");
                success = double.TryParse(Console.ReadLine(), out money);
            }
            return money;
        }

        private static AbstractOutput AlertOrConsole()
        {
            while (true)
            {
                Console.WriteLine("Use Alert instead of Console? (Y/N)");
                string resp = Console.ReadLine().ToUpper();
                if (resp == "Y")
                    return new AlertOutput();
                else if (resp == "N")
                    return new ConsoleOutput();
                else
                    Console.WriteLine("Unknown command");
            }
        }
    }
}
