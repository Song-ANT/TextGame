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

        public string[] ResetString(int count)
        {
            string[] arr = Enumerable.Range(0, count).Select(_=>"").ToArray();

            return arr;
        }


    }
}
