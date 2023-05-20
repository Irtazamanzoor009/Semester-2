using Coffeetask.BL;
using Coffeetask.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeetask.UI
{
    class CoffeeShopUI
    {
        public static void DisplayDrinks(string type)
        {
            foreach (var u in CoffeeShopDL.Menu)
            {
                if(u.Type == type || u.Type == type)
                {
                    Console.WriteLine("Name: " + u.Name);
                    Console.WriteLine("Price: " + u.Price);
                    Console.WriteLine("Type: " + u.Type);
                }
                Console.WriteLine();
            }
        }

        public static void DisplayCheapestItem(MenuItemBL b)
        {
            Console.WriteLine("Name: " + b.Name);
            Console.WriteLine("Price: " + b.Price);
            Console.WriteLine("Type: " + b.Type);
        }

        public static void StoreData(string path, MenuItemBL m)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(m.Name + ',' + m.Type + ',' + m.Price);
            file.Close();
        }

        public static bool ReadData(string path)
        {
            if(File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while((record = file.ReadLine()) != null)
                {
                    string[] SplitedRecord = record.Split(',');
                    string name = SplitedRecord[0];
                    string type = SplitedRecord[1];
                    double price = double.Parse(SplitedRecord[2]);
                    MenuItemBL m = new MenuItemBL(name, type, price);
                    CoffeeShopDL.AddInMenuList(m);
                    
                }
                file.Close();
                return true;
            }
            return false;
        }




    }
}
