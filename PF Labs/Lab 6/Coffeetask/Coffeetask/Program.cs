using Coffeetask.BL;
using Coffeetask.DL;
using Coffeetask.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeetask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "menu.txt";
            MenuUI.ClearScreen();
            MenuUI.Header();
            bool check1 = CoffeeShopUI.ReadData(path);
            if(check1)
            {
                Console.WriteLine("Data Loaded Successfully");
                MenuUI.Getch();
            }
            else
            {
                Console.WriteLine("File Not Found");
                MenuUI.Getch();
            }
            string option = "";
            while(option != "9")
            {
                MenuUI.ClearScreen();
                MenuUI.Header();
                option = MenuUI.Menu();
                if(option == "1") // add menu
                {
                    MenuUI.ClearScreen();
                    MenuUI.Header();
                    MenuItemBL m = MenuItemUI.AddMenuItem();
                    CoffeeShopDL.AddInMenuList(m);
                    CoffeeShopUI.StoreData(path, m);
                    MenuUI.Getch();
                }
                else if(option == "2") // view cheapest menu
                {
                    MenuItemBL b = CoffeeShopDL.GetCheapestItem();
                    CoffeeShopUI.DisplayCheapestItem(b);
                    MenuUI.Getch();
                }
                else if(option == "3") // view drink's menu
                {
                    MenuUI.ClearScreen();
                    MenuUI.Header();
                    Console.WriteLine("-------------- Drink Menu ------------------");
                    CoffeeShopUI.DisplayDrinks("drink");
                    MenuUI.Getch();
                }
                else if(option == "4") // view Food menu
                {
                    MenuUI.ClearScreen();
                    MenuUI.Header();
                    Console.WriteLine("-------------- Food Menu ------------------");
                    CoffeeShopUI.DisplayDrinks("food");
                    MenuUI.Getch();
                }
                else if(option == "5") // add order
                {
                    MenuUI.ClearScreen();
                    MenuUI.Header();
                    string name = MenuItemUI.TakeOrder();
                    bool check = CoffeeShopDL.CheckOrder(name);
                    if(check)
                    {
                        CoffeeShopBL.AddinOrdersList(name);
                        Console.WriteLine("Your order has been added");
                        MenuUI.Getch();
                    }
                    else
                    {
                        Console.WriteLine("This item is not currently available");
                        MenuUI.Getch();
                    }
                }
                else if(option == "6") // fullfill the order
                {
                    MenuUI.ClearScreen();
                    MenuUI.Header();
                    bool check = CoffeeShopBL.CheckOrderList();
                    if(check)
                    {
                        CoffeeShopBL.FullfillOrders();
                        CoffeeShopBL.Orders = null;
                        MenuUI.Getch();
                    }
                    else if(!check)
                    {
                        Console.WriteLine("All Orders have been Fullfilled");
                        MenuUI.Getch();
                    }
                }
                else if (option == "7") // View the Order's list
                {
                    MenuUI.ClearScreen();
                    MenuUI.Header();
                    CoffeeShopBL.Orderlist();
                    MenuUI.Getch();
                }
                else if(option == "8") // Total Payable Amount
                {
                    MenuUI.ClearScreen();
                    MenuUI.Header();
                    double amount = CoffeeShopBL.PayableAmount();
                    Console.WriteLine("Payable amount: " + amount);
                    MenuUI.Getch();
                }

            }
        }
    }
}
