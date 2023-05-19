using System;
using System.Collections.Generic;
using System.Globalization;
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
            //Task4();
            //Task5();
            //Task6();
            //Task7();
            //Task8();
            //Task9();
            //Task10();
            //Task11();
            //Task12();
            //Task13();
            //Task14();
            //Task15();
            //Task16();

            // task of addition
            /*int num1, num2;
            Console.WriteLine("Enter number 1: ");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number 2: ");
            num2 = int.Parse(Console.ReadLine());
            int add = Task17(num1, num2);
            Console.WriteLine("Result is: " + add);*/

            //Task18();
            Task19();
        }
        static void Task1()
        {
            Console.Write("Hello World");
            Console.Write("Hello World");
            Console.ReadLine();
        }
        static void Task2() 
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
        static void Task3()
        {
            int variable = 7;
            Console.Write("Value is: ");
            Console.Write(variable);
            Console.ReadLine();
        }
        static void Task4()
        {
            string variable = "I am string";
            Console.Write(variable);
            Console.ReadLine();
        }
        static void Task5()
        {
            char ch = 'A';
            Console.Write(ch);
            Console.ReadLine();
        }
        static void Task6()
        {
            float value = 2.2F;
            Console.Write(value);
            Console.ReadLine();
        }
        static void Task7()
        {
            string line;
            line = Console.ReadLine();
            Console.Write("You entered: ");
            Console.Write(line);
            Console.ReadLine();
        }
        static void Task8()
        {
            int number;
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            Console.Write("You entered: {0}",number);
            Console.ReadLine();
        }
        static void Task9()
        {
            float number;
            Console.Write("Enter a number: ");
            number = float.Parse(Console.ReadLine());
            Console.Write("You entered: {0}", number);
            Console.ReadLine();
        }
        static void Task10()
        {
            int length, area;
            Console.WriteLine("Enter length: ");
            length = int.Parse(Console.ReadLine());
            area = length * length;
            Console.WriteLine("Area of square is: ");
            Console.WriteLine(area);
            Console.ReadLine();
        }
        static void Task11()
        {
            int marks;
            Console.WriteLine("Enter your marks: ");
            marks = int.Parse(Console.ReadLine());
            if (marks >= 50)
            {
                Console.WriteLine("You are pass");
            }
            else
            {
                Console.WriteLine("You are fail");
            }
        }
        static void Task12()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Welcome Jack");
            }
        }
        static void Task13()
        {
            int number;
            int sum = 0;
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            while (number != -1)
            {
                sum += number;
                Console.Write("Enter number: ");
                number = int.Parse(Console.ReadLine());

            }
            Console.Write("Sum is: {0}", sum);
        }
        static void Task14()
        {
            int[] numbers = new int[3];
            for(int i=0; i<3; i++)
            {
                Console.Write("Enter a number: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int largest = -1;
            for(int i=0; i<3; i++)
            {
                if (numbers[i] > largest)
                {
                    largest = numbers[i];
                }
            }
            Console.Write("Largest is: {0}", largest);
        }
        static void Task15() 
        {
            int age, priceOfToy;
            float priceOfMachine;
            int priceReceived = 0, toyRecieved = 0;

            int j = 0, x = 1;
            Console.Write("Enter age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter price of Washing machine: ");
            priceOfMachine = float.Parse(Console.ReadLine());
            Console.Write("Enter price of toy: ");
            priceOfToy = int.Parse(Console.ReadLine());

            for(int i=1; i<=age; i++)
            {
                if(i % 2 == 0)
                {
                    priceReceived = priceReceived + (x * 10);
                    x++;
                    j++;
                }
                else if(i % 2 != 0)
                {
                    toyRecieved += 1;
                    
                }
            }

            float totalAmount = priceReceived - j;
            float priceoftoys = priceOfToy * toyRecieved;
            float AmountSaved = totalAmount + priceoftoys;
            float remaining = priceOfMachine - AmountSaved;
            
            if(AmountSaved > priceOfMachine)
            {
                if(remaining < 0)
                {
                    remaining *= -1;
                }
                Console.WriteLine("Yes!" + remaining + " is remaining amount");
            }
            else
            {
                Console.WriteLine("No!" + remaining + " is insufficent");
            }
        }
        static void Task16()
        {
            int num;
            int sum = 0;
            do
            {
                Console.Write("Enter number: ");
                num = int.Parse(Console.ReadLine());
                sum += num;
            } while (num != -1);
            sum = sum + 1;
            Console.WriteLine("The total sum is: {0}", sum);
        }
        static int Task17(int num1, int num2)
        {
            int add = num1 + num2;
            return add;
        }
        static void Task18()
        {
            string path = "C:\\Users\\IRTAZA MANZOOR\\Desktop\\Semester 2\\OOP Tasks\\test.txt";
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string line;
                while ((line = fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File not found");
            }    
        }
        static void Task19()
        {
            string path = "E:\\Semester 2\\OOP Tasks\\test.txt";
            StreamWriter fileVariable = new StreamWriter(path,true);
            fileVariable.WriteLine("Welcome to CS");
            fileVariable.Flush();
            fileVariable.Close();
        }
    }

}