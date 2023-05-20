using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffeetask.UI
{
    class MenuUI
    {
        public static string Menu()
        {
            string option = "";
            Console.WriteLine(" Welocme to Tesha's Cofee Shop");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Add a Menu Item");
            Console.WriteLine("2. View the Cheapest Item in the Menu");
            Console.WriteLine("3. View the Drink's Menu");
            Console.WriteLine("4. View the Food's Menu");
            Console.WriteLine("5. Add order");
            Console.WriteLine("6. Fullfill the order");
            Console.WriteLine("7. View the Order's list");
            Console.WriteLine("8. Total Payable Amount");
            Console.WriteLine("9. Exit");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Select yout option...");
            option = Console.ReadLine();
            return option;

        }

        public static void Header()
        {
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("**                  Welcome to Coffee Shop                     **");
            Console.WriteLine("*****************************************************************");
        }
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
