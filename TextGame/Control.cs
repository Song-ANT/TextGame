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
        MessageHandler messageHandler;
        public int selMessage = 0;
        public int sel;
        public int num;
        public string[] arr;


        public Control() { }
        public Control(MessageHandler messageHandler) 
        {
            this.messageHandler = messageHandler;
        }

        public void ControlMessage()
        {
            this.sel = 0;
            while (true)
            {
                messageHandler.CurrentMessage();

                if (InputKey(ref sel)) break;
                sel = sel < 0 ? 0 : (sel > num) ? num : sel;
                arr = messageHandler.ResetString(2);
            }

        }



        //public void NextMessage(int selMessage)
        //{
        //    switch (selMessage)
        //    {
        //        case 0:
        //            message.SelectMainMessage(ref selMessage);
        //            break;
        //    }
        //}

        // --------------------------------------------------------------

        public bool InputKey(ref int selMessage)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selMessage--;
                        return false;

                    case ConsoleKey.DownArrow:
                        selMessage++;
                        return false;

                    case ConsoleKey.Enter:
                        return true;

                }
            }

            return false;
        }

        


    }
}
