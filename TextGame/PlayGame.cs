using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class PlayGame
    {
        
        public void Play()
        {
            Control control = new Control(messageHandler);
            MessageHandler messageHandler = new Message(control);
            

            control.ControlMessage();
        }
    }
}
