using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Output
{
    public class ConsoleOutput : IOutput
    {
        public void ShowMessage(string messageText)
        {
            Console.WriteLine(messageText); 
        }
    }
}
