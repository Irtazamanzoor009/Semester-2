using Coffeetask.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeetask.UI
{
    class MenuItemUI
    {
        public static MenuItemBL AddMenuItem()
        {
            Console.WriteLine("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Type: ");
            string Type = Console.ReadLine();
            Console.WriteLine("Enter Product Price: ");
            double price = double.Parse(Console.ReadLine());
            MenuItemBL add = new MenuItemBL(name, Type, price);
            return add;
        }

        public static string TakeOrder()
        {
            Console.WriteLine("Enter Name of Order: ");
            string name = Console.ReadLine();
            return name;
        }

        
    }
}
