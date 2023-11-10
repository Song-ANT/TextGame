using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    internal class Message
    {
        Control control = new Control();
        public void MainScene()
        {

            int sel = 0;
            string[] arr = control.ResetString(2);


            while (true)
            {
                
                arr[sel] = "=>";

                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine($"{arr[0]}1. 상태보기");
                Console.WriteLine($"{arr[1]}2. 인벤토리");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                if (control.InputKey(ref sel)) break;
                sel = sel < 0 ? 0 : (sel > 1) ? 1 : sel;
                arr = control.ResetString(2);
                
            }
        }


    }
}
