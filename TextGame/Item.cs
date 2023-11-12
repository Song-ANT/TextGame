using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame
{
    public class Item
    {
        public bool equip;
        public string name;
        public string status;
        public int statusNum;
        public string explan;

        

        public Item(bool equip, string name, string status, int statusNum, string explan)
        {
            this.equip = equip;
            this.name = name;
            this.status = status;
            this.statusNum = statusNum;
            this.explan = explan;
        }



        
    }
    
    
}
