using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            Color();

        }
        static void Task1()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next();
            Console.WriteLine(randomNumber);
        }
        static void Task2()
        {
            Random rnd = new Random();
            int min = 0;
            int max = 100;
            int randomNumber = rnd.Next(min, max);
            Console.WriteLine(randomNumber);
        }
        static void Task3()
        {
            Random rnd = new Random();
            double randomDouble = rnd.NextDouble();
            Console.WriteLine(randomDouble);
        }
        static void Color()
        {
            Console.WriteLine("I am message without color");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I am red");
            Console.ForegroundColor = ConsoleColor.White;

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("I am green");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}