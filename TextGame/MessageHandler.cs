using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public interface MessageHandler
    {
        void CurrentMessage();
        void SelectMainMessage(ref int selMessage);
        string[] ResetString(int count);
    }
}
