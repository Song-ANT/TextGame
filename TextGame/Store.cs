using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TextGame
{
    public class Store
    {
        public List<Item> itemList = new List<Item>();
        public ConsoleTable table = new ConsoleTable("아이템이름", "효과", "설명", "가격");
        

        public Store()
        {
            itemList.Add(new Item(false, "수련자 갑옷", "방어력", 5, "수련에 도움을 주는 갑옷입니다.", 500));
            itemList.Add(new Item(false, "무쇠갑옷", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 900));
            itemList.Add(new Item(false, "스파르타의 갑옷", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 1500));
            itemList.Add(new Item(false, "낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 200));
            itemList.Add(new Item(false, "청동 도끼", "공격력", 5, "어디선가 사용됐던거 같은 도끼입니다.", 500));
            itemList.Add(new Item(false, "스파르타의 창", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 700));
            itemList.ForEach(x => table.AddRow(x.name, x.status + " "+ x.statusNum, x.explan, x.gold));
        }

        public void ShowStore()
        {
            table.Write();
        }

        public void BuyStore(Character character, int sel)
        {
            if (character.Gold >= itemList[sel].gold)
            {
                Item item = new Item(
                    itemList[sel].equip,
                    itemList[sel].name,
                    itemList[sel].status,
                    itemList[sel].statusNum,
                    itemList[sel].explan,
                    itemList[sel].gold);
                

                character.itemList.Add(item);
                character.Gold -= itemList[sel].gold;

                character.AddInventory();
            }
        }

        public void SellStore(Character character, int sel)
        {
            //Console.WriteLine("sel : " + sel);
            //Console.WriteLine(character.itemList[sel].name);
            //Console.WriteLine();
            //foreach (Item item in character.itemList)
            //{
            //    Console.WriteLine($"{item.name}, {item.equip}");
            //}
            //Console.WriteLine();
            //character.ShowInventory();
            //Console.ReadKey();

            
            character.itemList.RemoveAt(sel);
            character.table.Rows.RemoveAt(sel);
            
        }

    }
}
