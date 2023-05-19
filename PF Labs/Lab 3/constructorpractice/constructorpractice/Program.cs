using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructorpractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Console.WriteLine(s1.name);
            Student s2 = new Student("jack");
            Console.WriteLine(s2.name);
            /*Console.WriteLine("Enter name:");
            s1.name = Console.ReadLine();*/
           // Console.WriteLine(s1.name);
            //Console.WriteLine(s1.marks);
            Console.ReadKey();
        }
    }
}
