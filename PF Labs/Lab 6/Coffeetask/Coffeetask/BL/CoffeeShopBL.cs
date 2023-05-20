using Coffeetask.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeetask.BL
{
    class CoffeeShopBL
    {
        public string Name;
        
        public static List<String> Orders = new List<string>();

        public CoffeeShopBL(string name)
        {
            this.Name = name;
        }

        public static void AddinOrdersList(string name)
        {
            Orders.Add(name);
        }

        public static void Orderlist()
        {
            if(Orders != null)
            {
                foreach(var u in Orders)
                {
                    Console.WriteLine(u);
                }
            }
        }

        public static double PayableAmount()
        {
            double sum = 0;
            if(Orders != null)
            {
                foreach(var u in Orders)
                {
                    foreach(var o in CoffeeShopDL.Menu)
                    {
                        if(u == o.Name)
                        {
                            sum = sum + o.Price;
                        }
                    }
                }
            }
            return sum;
        }

        public static bool CheckOrderList()
        {
            if (Orders != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void FullfillOrders()
        {
            foreach(var u in Orders)
            {
                Console.WriteLine("The " + u + " item is ready");
            }

        }
        
    }
}
