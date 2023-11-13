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
            Character character = new Character("Chad", "전사", 1, 10, 5, 100, 1500);
            Store store = new Store();
            Message message = new Message(character, store);
            Control control = new Control(message);


            int selCurrent = 0;
            while (true)
            {
                selCurrent = control.ControlMessage(selCurrent);
                if (selCurrent == -1) break;
            }
        }
    }
}
