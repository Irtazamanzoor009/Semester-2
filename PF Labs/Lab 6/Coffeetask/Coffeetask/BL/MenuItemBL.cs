using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeetask.BL
{
    class MenuItemBL
    {
        public string Name;
        public string Type;
        public double Price;

        public MenuItemBL(string name, string type, double price)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }
        public MenuItemBL()
        {

        }
        
    }
}
