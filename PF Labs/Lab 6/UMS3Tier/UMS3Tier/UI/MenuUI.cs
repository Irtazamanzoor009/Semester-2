using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS3Tier.UI
{
    public class MenuUI
    {
        public static void Header()
        {
            Console.WriteLine("********************************************************");
            Console.WriteLine("**                    UMS                             **");
            Console.WriteLine("********************************************************");
        }
        public static string Menu()
        {
            string option = "";
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students for a specific degree");
            Console.WriteLine("6. Register Subject for a specific student");
            Console.WriteLine("7. Calculate fee for all registered student");
            Console.WriteLine("8. Exit");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;
        }
        public static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static void Clearscreen()
        {
            Console.Clear();
        }
    }
}
