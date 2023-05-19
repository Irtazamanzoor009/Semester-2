using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3ClockTypeClass
{
    class Program
    {
        class Clocktype
        {
            public int hours;
            public int minutes;
            public int seconds;
            public Clocktype()
            {
                hours = 0;
                minutes = 0;
                seconds = 0;
            }
            public Clocktype(int h)
            {
                hours = h;
            }
            public Clocktype(int h, int m)
            {
                hours = h;
                minutes = m;
            }
            public Clocktype(int h, int m, int s)
            {
                hours = h;
                minutes = m;
                seconds = s;
            }
            public void incrementsecond()
            {
                seconds++;
            }
            public void incrementminute()
            {
                minutes++;
            }
            public void incrementhours()
            {
                hours++;
            }
            public void printtime()
            {
                Console.WriteLine(hours + " " + minutes + " " + seconds);
            }
            public bool isequal(int h, int m, int s)
            {
                if(hours == h && minutes == m && seconds == s)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool isequal(Clocktype temp)
            {
                if(hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        static void Main(string[] args)
        {
            // default constructer
            Clocktype emptytime = new Clocktype();
            Console.Write("Empty time: ");
            emptytime.printtime();

            // parametrized consturctor (one parameter)
            Clocktype hour = new Clocktype(8);
            Console.Write("Hour time: ");
            hour.printtime();

            // parametrized constructor (two parameters)
            Clocktype minutes = new Clocktype(8, 10);
            Console.Write("Minute time: ");
            minutes.printtime();

            // parametrized constructor (three parameters)
            Clocktype fulltime = new Clocktype(8, 10, 10);
            Console.Write("Second time: ");
            fulltime.printtime();

            // increment seconds
            fulltime.incrementsecond();
            Console.Write("Full Time (increment second): ");
            fulltime.printtime();

            // increment minutes
            fulltime.incrementminute();
            Console.Write("Full Time (increment minutes): ");
            fulltime.printtime();

            // increment hours 
            fulltime.incrementhours();
            Console.Write("Full Time (increment hours): ");
            fulltime.printtime();

            // check if equal
            bool flag = fulltime.isequal(9, 11, 11);
            Console.WriteLine("Flag: " + flag);

            // check if equal is object
            Clocktype cmp = new Clocktype(10,12,1);
            flag = fulltime.isequal(cmp);
            Console.WriteLine("Object Flag: " + flag);

            Console.ReadKey();
        }
    }
}
