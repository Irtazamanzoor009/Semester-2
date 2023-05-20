using Coffeetask.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeetask.DL
{
    class CoffeeShopDL
    {
        public static List<MenuItemBL> Menu = new List<MenuItemBL>();

        public static void AddInMenuList(MenuItemBL m)
        {
            Menu.Add(m);
        }
        public static MenuItemBL GetCheapestItem()
        {
            List<MenuItemBL> SortedOrder = new List<MenuItemBL>();
            SortedOrder = Menu.OrderBy(o => o.Price).ToList();
            MenuItemBL C = SortedOrder[0];
            return C;
        }

        public static bool CheckOrder(string name)
        {
            bool flag = false;
            foreach(var u in Menu)
            {
                if(name == u.Name)
                {
                    flag = true;
                }
            }
            return flag;
        }
        
        
    }
}
