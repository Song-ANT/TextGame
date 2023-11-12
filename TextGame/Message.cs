using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Message
    {
        Character character;
        int count;

        public Message(Character character)
        {
            this.character = character;
            this.count = character.itemList.Count;
        }


        public int CurrentMessage(int selMessage, int sel)
        {
            switch (selMessage)
            {
                case 0:
                    return MainMessage(sel);
                case 1:
                    return StatusMessage(sel);
                case 2:
                    return InventoryMessage(sel);
                case 3:
                    return ManageInventoryMessage(sel);
            }
            return 0;
        }

        public int NextMessage(int selMessage, int sel)
        {
            switch (selMessage)
            {
                case -1:
                    return -1;
                case 0:
                    return MainMessageSelect(sel);
                case 1:
                    return 0;
                case 2:
                    return InventoryMessageSelect(sel);
                case 3:
                    return ManageInventoryMessageSelect(sel);

            }

            return 0;
        }


        // -------------------------------------------------------------------------
        // 0. 마을 메인메세지
        public int MainMessage(int sel)
        {
            string[] arr = new string[3];
            arr[sel] = "=> ";

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine($"{arr[0]}1. 상태보기");
            Console.WriteLine($"{arr[1]}2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine($"\n\n{arr[2]} 게임 종료");
            Console.WriteLine("원하시는 행동을 Enter키를 이용해 선택하세요");

            //selNext = MainMessageSelect(sel);
            
            return 2;
        }

        // 메인 메세지 선택지로 이동하기 위한 return 값
        int MainMessageSelect(int sel)
        {
            return (sel == 2) ? -1 : sel+1;
        }

        //--------------------------------------------------------------------
        // 1. 상태보기
        public int StatusMessage(int sel)
        {
            string[] arr = new string[1];
            arr[sel] = "=> ";

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보르 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{character.Level}");
            Console.WriteLine($"{character.Name}({character.Job})");
            Console.Write($"공격력 :{character.Atk}");
            Console.WriteLine($" ({character.CalculateStatus("공격력")})");
            Console.Write($"방어력 : {character.Def}");
            Console.WriteLine($" ({character.CalculateStatus("방어력")})");
            Console.WriteLine($"체력 : {character.Hp}");
            Console.WriteLine($"Gold : {character.Gold} G");
            Console.WriteLine();
            Console.WriteLine($"{arr[0]}나가기");

            //selNext = 0;
            return 0;
        }

        //--------------------------------------------------------------------
        // 2. 인벤토리
        public int InventoryMessage(int sel)
        {
            string[] arr = new string[2];
            arr[sel] = "=> ";

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            character.ShowInventory();
            Console.WriteLine($"{arr[0]} 장착관리");
            Console.WriteLine($"{arr[1]} 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 Enter키를 이용해 선택하세요");

            //selNext = InventoryMessageSelect(sel);
            return 1;
        }

        int InventoryMessageSelect(int sel)
        {
            return (sel == 0) ? 3 : 0;
        }

        //--------------------------------------------------------------------
        // 3. 장착관리
        public int ManageInventoryMessage(int sel)
        {
            
            string[] arr = new string[count+1];
           
            arr[sel] = "=> ";

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{arr[i]} ");
                foreach (var item in character.table.Rows[i].Skip(1))
                {
                    Console.Write($"{item} | ");
                }
                if (character.itemList[i].equip) Console.Write(" [E]");
                Console.WriteLine();
            }
            Console.WriteLine($"\n\n{arr[count]} 나가기");

            Console.WriteLine("원하시는 행동을 Enter키를 이용해 선택하세요");

            //selNext = ManageInventoryMessageSelect(sel, count);
            return count;
        }
        int ManageInventoryMessageSelect(int sel)
        {
            if (sel != count)
            {
                character.itemList[sel].equip = !character.itemList[sel].equip;
                character.table.Rows[sel].SetValue(character.itemList[sel].equip ? "[E]": "", 0);
            }

            return (sel == count) ?  2 : 3;
        }

    }
}
