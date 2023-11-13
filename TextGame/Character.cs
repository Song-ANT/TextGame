using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; set; }

        public List<Item> itemList = new List<Item>();
        public ConsoleTable table = new ConsoleTable(" ","아이템 이름", "효과", "설명");

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
            itemList.Add(new Item(false, "수련자 갑옷", "방어력", 5, "수련에 도움을 주는 갑옷입니다.", 500));
            itemList.Add(new Item(true, "낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 200));
            itemList.Add(new Item(false, "청동 도끼", "공격력", 5, "어디선가 사용됐던거 같은 도끼입니다.", 500));
            AddInventory();
        }

        public void AddInventory()
        {
            table.Rows.Clear();
            itemList.ForEach(x => table.AddRow(((x.equip == true) ? "[E]" : ""),x.name, x.status +" "+ x.statusNum, x.explan));
        }

        public void ShowInventory()
        {
            table.Write();
        }

        public int CalculateStatus(string status)
        {
            int sum = 0;
            var num = itemList
                .Where(x => (x.equip) && (x.status == status))
                .Select(x => x.statusNum).ToList();
            num.ForEach(x => sum += x);

            return sum;
        }

    }
}
