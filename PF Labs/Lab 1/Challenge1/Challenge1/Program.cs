using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            Products[] p = new Products[10];
            int count = 0;
            string choice = "";
            while(choice != "4")
            {
                choice = Menu();
                if(choice == "1") // Add Product
                {
                    p[count] = AddProduct();
                    count++;
                    Getch();
                }
                else if(choice == "2") // Show Products
                {
                    if(count == 0)
                    {
                        Console.WriteLine("No Products Added");
                    }
                    else
                    {
                         ViewProducts(p, count);
                    }
                    Getch();
                }
                else if(choice == "3") // Total Store worth
                {
                    int sum;
                    sum = TotalSum(p, count);
                    Console.WriteLine("Sum of Products is: {0}", sum);
                    Getch();
                }
            }
        }
        static string Menu()
        {
            Console.Clear();
            string choice;
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Add Products");
            Console.WriteLine("2. Show Products");
            Console.WriteLine("3. Total Store Worth");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-----------------------------");
            Console.Write("Select your option...");
            choice = Console.ReadLine();
            return choice;
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static Products AddProduct()
        {
            Console.Clear();
            Products p1 = new Products();
            Console.Write("Enter Product ID: ");
            p1.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Name: ");
            p1.name = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            p1.price = int.Parse(Console.ReadLine());
            Console.Write("Enter Product Category: ");
            p1.category = Console.ReadLine();
            Console.Write("Enter BrandName: ");
            p1.brandname = Console.ReadLine();
            Console.Write("Enter Country: ");
            p1.country = Console.ReadLine();
            return p1;
        }
        static void ViewProducts(Products[] p, int count)
        {
            Console.Clear();
            Console.WriteLine("ID\t\tName\t\tPrice\t\tCategory\t\tBrandName\t\tCountry");
            for(int i=0; i<count; i++)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", p[i].ID, p[i].name, p[i].price, p[i].category, p[i].brandname, p[i].country);
            }
        }
        static int TotalSum(Products[] p, int count)
        {
            Console.Clear();
            int sum = 0;
            for(int i=0; i<count; i++)
            {
                sum = sum + p[i].price;
            }
            return sum;
        }
    }
}
