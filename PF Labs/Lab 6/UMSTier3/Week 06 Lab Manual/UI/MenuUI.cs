using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06_Lab_Manual.UI
{
    class MenuUI
    {
        public static void header()
        {
            Console.WriteLine("#########################################");
            Console.WriteLine("#                 UAMS                  #");
            Console.WriteLine("#########################################");
        }
        public static string  menu()
        {
            header();
            Console.WriteLine("1. Add Student ");
            Console.WriteLine("2. Add Degree Programme ");
            Console.WriteLine("3. Generate Merit ");
            Console.WriteLine("4. View Registered Students ");
            Console.WriteLine("5. View Students Of The Specific Program  ");
            Console.WriteLine("6. Register Subjects For Specific Program ");
            Console.WriteLine("7. Calculate Fees for All Registered Students ");
            Console.WriteLine("8. Exit ");
            Console.WriteLine("Enter option ");
            string Option;
            Option = Console.ReadLine();
            return Option;
        }
        public static void clearScreen()
        {
            Console.WriteLine("Press any Key To Continue ");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
