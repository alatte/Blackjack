﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack.Output
{
    public class AlertOutput : AbstractOutput
    {
        public override void ShowMessage(string messageText)
        {
            MessageBox.Show(messageText);
        }
    }
}
