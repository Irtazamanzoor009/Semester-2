using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    class product
    {
        public string productName;
        public string productCategory;
        public int productPrice;
        public int stockQuantity;
        public int minimumStock;

        public product(string name, string category, int price, int stockquan, int minquan)
        {
            productName = name;
            productCategory = category;
            productPrice = price;
            stockQuantity = stockquan;
            minimumStock = minquan;
        }
    }
    class store
    {
        List<product> products = new List<product>();
        public void AddProduct()
        {
            Console.Clear();
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Product Category: ");
            string category = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Enter Stock Quantity: ");
            int stockquantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Minimum Stock Quantity: ");
            int minimumstock = int.Parse(Console.ReadLine());
            products.Add(new product(name, category, price, stockquantity, minimumstock));

        }
        public void ViewProducts()
        {
            Console.Clear();
            Console.WriteLine("Name\tCategory\tPrice\tStock Quantity\tMinimum Stock");
            foreach(var product in products)
            {
                Console.WriteLine(product.productName + "\t" + product.productCategory + "\t" + product.productPrice + "\t" + product.stockQuantity + "\t" + product.minimumStock);
            }
        }
        public void ViewSaletax()
        {
            Console.Clear();
            Console.WriteLine("Name\tPrice");
            foreach(var product in products)
            {
                double tax;
                if(product.productCategory == "Groceries")
                {
                    tax = product.productPrice * 0.1;
                }
                else if(product.productCategory == "FreshFruit")
                {
                    tax = product.productPrice * 0.05;
                }
                else
                {
                    tax = product.productPrice * 0.15;
                }
                Console.WriteLine(product.productName + "\t" + tax);
            }
        }
        public void ProductOrdered()
        {
            Console.Clear();
            Console.WriteLine("Products to be order: ");
            foreach(var product in products)
            {
                if(product.stockQuantity <= product.minimumStock)
                {
                    Console.WriteLine(product.productName);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            store Store = new store();
            string choice="";
            while(choice != "5")
            {
                choice = Menu();
                if(choice == "1")
                {
                    Store.AddProduct();
                }
                else if(choice == "2")
                {
                    Store.ViewProducts();
                }
                else if(choice == "3")
                {
                    Store.ViewSaletax();
                }
                else if(choice == "4")
                {
                    Store.ProductOrdered();
                }
                Getch();
            }
            Console.ReadKey();
        }
        static string Menu()
        {
            Console.Clear();
            string option;
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. View Sales Tax");
            Console.WriteLine("4. Products to be orderd");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
