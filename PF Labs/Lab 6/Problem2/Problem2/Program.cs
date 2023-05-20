using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] triangle = new char[5, 3] { { '@', ' ', ' ' }, { '@', '@', ' ' }, { '@', '@', '@' }, { '@', '@', ' ' }, { '@', ' ', ' ' } };
            char[,] optriangle = new char[5, 3] { { ' ', ' ', '@' }, { ' ', '@', ' ' }, { '@', '@', '@' }, { ' ', '@', '@' }, { ' ', ' ', '@' } };

            Boundary b = new Boundary();
            GameObject g1 = new GameObject(triangle, new Point(5, 5), b, "LefttoRight");
            GameObject g2 = new GameObject(optriangle, new Point(30, 60), b, "RighttoLeft");
            List<GameObject> list = new List<GameObject>();
            list.Add(g1);
            list.Add(g2);
            Console.ReadKey();
            while (true)
            {
                Thread.Sleep(50);
                foreach (GameObject g in list)
                {
                    g.Erase();
                    g.Move();
                    g.Draw();
                }
            }
        }
    }
}
