using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        internal static List<string> deck;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Game game = new Game();
                game.Play();
                Console.WriteLine("Play again? (Y/N)");
            } while (Console.ReadLine().ToUpper() == "Y");
        }
    }
}
