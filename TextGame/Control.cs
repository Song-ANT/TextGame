using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Control 
    {
        Message message;
        public int selNext=0;
        public int sel;
        public int num;
        public string[] arr;


        public Control(Message message)
        {
            this.message = message;
        }

        public int ControlMessage(int selCurrent)
        {
            this.sel = 0;
            while (true)
            {
                num = message.CurrentMessage(selCurrent, sel);

                if (InputKey(ref sel)) break;
                sel = sel < 0 ? 0 : (sel > num) ? num : sel;
            }
            selCurrent = message.NextMessage(selCurrent, sel);
            return selCurrent;
            //return selNext;
            
        }



       

        // --------------------------------------------------------------

        public bool InputKey(ref int sel)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        sel--;
                        return false;

                    case ConsoleKey.DownArrow:
                        sel++;
                        return false;

                    case ConsoleKey.Enter:
                        return true;

                }
            }

            return false;
        }

        


    }
}
