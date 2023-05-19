using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Product product = new Product();
            Clearscreen();
            customer = Takeuserinput();
            
            Clearscreen();
            string choice = "";
            while(choice != "2")
            {
                choice = Menu();
                if(choice == "1")
                {
                    product = TakeProductinfo();
                    customer.addproduct(product);
                    float tax = product.calculateTax();
                    Console.WriteLine("Tax is: " + tax);
                    Getch();
                }
            }
        }
        static void Clearscreen()
        {
            Console.Clear();
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static string Menu()
        {
            string option;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Purchase Product");
            Console.WriteLine("2. Exit");
            option = Console.ReadLine();
            return option;
        }
        static Customer Takeuserinput()
        {
            Console.WriteLine("-------------------------------");
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Customer Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Customer Contact: ");
            string contact = Console.ReadLine();

            Customer add = new Customer(name, address, contact);
            return add;
        }
        static Product TakeProductinfo()
        {
            Console.WriteLine("----------------------------");
            Console.Write("Enter Product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            int price = int.Parse(Console.ReadLine());

            Product add = new Product(name, category, price);
            return add;
        }
    }
}
