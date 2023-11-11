using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Message : MessageHandler
    {
        //int selMessage ;
        //int sel;
        //string[] arr;
        //int num;
        Control control;

        public Message(Control control)
        {
            this.control = control;
        }

        public void CurrentMessage()
        {
            switch (control.selMessage)
            {
                case 0:
                    MainMessage();
                    break;
            }
        }


        public void MainMessage()
        {
            control.arr = ResetString(2);
            this.control.arr[control.sel] = "=>";

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine($"{control.arr[0]}1. 상태보기");
            Console.WriteLine($"{control.arr[1]}2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

             control.num = 1;
        }

        public void SelectMainMessage(ref int selMessage)
        {
            selMessage = (control.sel == 0) ? 1 : 2;
        }

        public string[] ResetString(int count)
        {
            string[] arr = Enumerable.Range(0, count).Select(_ => "").ToArray();

            return arr;
        }

    }
}
