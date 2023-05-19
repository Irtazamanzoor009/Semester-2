using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Coordinates
    {
        public int px;
        public int py;
        public int Ex;
        public int Ey;

        public Coordinates()
        {

        }
        public void PrintPlayer(char[,] player)
        {
            for (int i = 0; i < 4; i++)
            {
                Gotoxy(px, py + i);
                {
                    for (int j = 0; j < 15; j++)
                    {
                        Console.Write(player[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }
        public void PrintEnemy(char[,] enemy)
        {
            for (int i = 0; i < 3; i++)
            {
                Gotoxy(Ex, Ey + i);
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(enemy[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void ErasePlayer()
        {
            for (int i = 0; i < 4; i++)
            {
                Gotoxy(px, py + i);
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public void MoveRight(char[,] maze, char[,] player)
        {
            char nextlocation = maze[py, px + 15];
            if (nextlocation == ' ')
            {
                ErasePlayer();
                px++;
                PrintPlayer(player);
            }
        }
        public void MoveLeft(char[,] maze, char[,] player)
        {
            char nextlocation = maze[py, px - 1];
            if (nextlocation == ' ')
            {
                ErasePlayer();
                px--;
                PrintPlayer(player);
            }
        }
        public void MoveUp(char[,] maze, char[,] player)
        {
            char nextlocation = maze[py - 1, px];
            if (nextlocation == ' ')
            {
                ErasePlayer();
                py--;
                PrintPlayer(player);
            }
        }
        public void MoveDown(char[,] maze, char[,] player)
        {
            char nextlocation = maze[py + 4, px];
            if (nextlocation == ' ')
            {
                ErasePlayer();
                py++;
                PrintPlayer(player);
            }
        }


        static void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        public void EraseEnemy()
        {
            for (int i = 0; i < 3; i++)
            {
                Gotoxy(Ex, Ey + i);
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public void MoveEnemy(char[,] maze, char[,] enemy, ref string direction)
        {
            if (direction == "up")
            {
                char nextlocation = maze[Ey - 1, Ex];
                if (nextlocation == ' ')
                {
                    EraseEnemy();
                    Ey--;
                    PrintEnemy(enemy);
                }
                else
                {
                    direction = "down";
                }
            }
            if (direction == "down")
            {
                char nextlocation = maze[Ey + 4, Ex];
                if (nextlocation == ' ')
                {
                    EraseEnemy();
                    Ey++;
                    PrintEnemy(enemy);
                }
                else
                {
                    direction = "up";
                }
            }
        }
    }
}
    
