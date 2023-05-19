using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockTypeChallenge1
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
        public void printtime()
        {
            Console.Write(hours + " " + minutes + " " + seconds);
        }
        public int ElapsedTime()
        {
            int elapsed = (hours * 3600) + (minutes * 60) + seconds;
            return elapsed;
        }
        public int RemainingTime()
        {
            int remaining = 86400 - ElapsedTime();
            return remaining;
        }
        public int Difference(int time1, int time2)
        {
            int difference = 0;
            difference = time1 - time2;
            if(difference < 0)
            {
                return difference * -1;
            }
            else
            {
                return difference;
            }
        }
        public void ConvertTime(int sec)
        {
            hours = sec / 3600;
            minutes = (sec % 3600) / 60;
            seconds = sec % 60;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Clocktype clock1 = new Clocktype(10, 15, 00);
            Clocktype clock2 = new Clocktype(8, 20, 30);
            Console.Write("Clock 1: ");
            clock1.printtime();
            Console.Write("\nClock 2: ");
            clock2.printtime();

            int elpase1 = clock1.ElapsedTime();
            Console.Write("\nElapsed time of clock 1: " + elpase1);

            int elapse2 = clock2.ElapsedTime();
            Console.Write("\nElapsed time of clock 2: " + elapse2);

            int remaining1 = clock1.RemainingTime();
            clock1.ConvertTime(remaining1);
            Console.Write("\nRemaining time of clock 1: ");
            clock1.printtime();

            int remaining2 = clock2.RemainingTime();
            clock2.ConvertTime(remaining2);
            Console.Write("\nRemaining time of clock 2: ");
            clock2.printtime();

            Clocktype diff = new Clocktype();
            int difference = diff.Difference(remaining1, remaining2);
            diff.ConvertTime(difference);
            Console.Write("\nThe difference is: ");
            diff.printtime();

            Console.ReadKey();
        }
    }
}
