using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.Write("Enter author name: ");
            string author = Console.ReadLine();
            Console.Write("Enter Pages: ");
            int pages = int.Parse(Console.ReadLine());
            Console.Write("Enter Book Mark: ");
            int bookmark = int.Parse(Console.ReadLine());
            Console.Write("Enter Price: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Enter number of chapters: ");
            int chapters = int.Parse(Console.ReadLine());
            Book add = new Book(author, pages, bookmark, price);
            for(int i=0; i<chapters; i++)
            {
                Console.Write("Enter Chapter" + (i + 1) + "name: ");
                string chaptername = Console.ReadLine();
                add.Addchapter(chaptername);
            }

            Console.WriteLine("Chapter Name: " + add.Getchapter(2));
            Console.WriteLine("Book Mark: " + add.Getbookmark());
            Console.WriteLine("Book Price: " + add.Getbookprice());
            add.SetBookmark(125);
            add.SetBookprice(1500);
            Console.WriteLine("New Book Mark: " + add.Getbookmark());
            Console.WriteLine("New Price: " + add.Getbookprice());
            Console.ReadKey();

            
        }
    }
}
