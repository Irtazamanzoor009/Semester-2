using System;
using System.IO;
using EZInput;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = new char[1000, 1000];
            string path = "E:\\Semester 2-\\PD\\PD2\\Task2\\maze.txt";
            char line = '\u2588';
            char[,] player = new char[4, 15] {
                      { '|', ' ', ' ', ' ', '/', line, line, line, line, line, ']', '=', '=', '=', '>'},
                      { ' ', ' ', ' ', ' ', ' ', ' ', line, line, ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                      { ' ', line, line, line, line, line, line, line, line, line, line, line, ']', ' ', ' '},
                      { ' ', '\\', '_', '@', '_', '@', '_', '@', '_', '@', '_', '/', ' ', ' ', ' '}
            };
            char[,] enemy = new char[3, 10] {
                       { '<', '=', '=', '=', '(', '~', '~', ')', '*', '*'},
                       { ' ', ' ', ' ', '/', '_', '_', '_', '_', '_', '\\'},
                       { ' ', ' ', ' ', '\\', '_', '@', '_', '@', '_', '/'}
            };
            Coordinates cord = new Coordinates();
            //Bullets bull = new Bullets();
            List<Bullets> bull = new List<Bullets>();
            cord.px = 5;
            cord.py = 5;
            cord.Ex = 85;
            cord.Ey = 10;
            int timer = 0;
            int score = 0;
            string direction = "up";
            Console.ReadKey();
            ReadMaze(maze, path);
            PrintMaze(maze);
            PrintPlayer(player, cord);
            PrintEnemy(enemy, cord);
            while(true)
            {
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    MoveRight(maze, player, cord);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    MoveLeft(maze, player, cord);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    MoveUp(maze, player, cord);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    MoveDown(maze, player, cord);
                }
                if(Keyboard.IsKeyPressed(Key.Space))
                {
                    GenerateBullets(bull, cord,maze);
                }
                timer++;
                if(timer == 5)
                {
                    MoveEnemy(maze, enemy, cord, ref direction);
                    timer = 0;
                }
                MovePlayerbullet(bull, cord, maze);
                BulletcollisionWithEnemy(maze, cord, bull, ref score);
                Thread.Sleep(50);
            }
            Console.ReadKey();
        }
        static void BulletcollisionWithEnemy(char[,] maze, Coordinates cord, List<Bullets> bull, ref int score)
        {
            for(int i=0; i<bull.Count; i++)
            {
                if(bull[i].isbulletactive == true)
                {
                    if (bull[i].bulletX + 1 == cord.Ey && (bull[i].bulletX + 1 == cord.Ex || bull[i].bulletX + 1 == cord.Ex + 2 || bull[i].bulletX + 1 == cord.Ex + 3))
                    {
                        score = score + 1;
                    }
                    if (cord.Ey - 1 == bull[i].bulletY && cord.Ex + 1 == bull[i].bulletX)
                    {
                        score = score + 1;
                    }
                    PrintScore(ref score);
                }
            }
        }
        static void PrintScore(ref int score)
        {
            Gotoxy(135, 9);
            Console.WriteLine("Score: " + score);
        }
        static void GenerateBullets(List<Bullets> bull, Coordinates cord, char[,] maze)
        {
            char nextlocation = maze[cord.py, cord.px + 15];
            if(nextlocation == ' ')
            {
                Bullets gen = new Bullets();
                gen.bulletX = cord.px + 15;
                gen.bulletY = cord.py;
                gen.isbulletactive = true;
                bull.Add(gen);
                Gotoxy(cord.px + 15, cord.py);
                Console.Write(".");
            }
        }
        static void PrintPlayerBullet(int x, int y)
        {
            Gotoxy(x,y);
            Console.Write(".");
        }
        static void ErasePlayerBullet(int x, int y)
        {
            Gotoxy(x,y);
            Console.Write(" ");
        }
        static void MovePlayerbullet(List<Bullets> bull, Coordinates cord, char[,] maze)
        {
            for(int i=0; i<bull.Count; i++)
            {
                if(bull[i].isbulletactive == true)
                {
                    char nextlocation = maze[bull[i].bulletY, bull[i].bulletX + 1];
                    if(nextlocation == ' ')
                    {
                        ErasePlayerBullet(bull[i].bulletX, bull[i].bulletY);
                        bull[i].bulletX++;
                        PrintPlayerBullet(bull[i].bulletX, bull[i].bulletY);
                    }
                    else
                    {
                        ErasePlayerBullet(bull[i].bulletX, bull[i].bulletY);
                        bull[i].isbulletactive = false;
                    }
                }
            }
        }
        static void MoveRight(char[,] maze, char[,] player, Coordinates cord)
        {
            char nextlocation = maze[cord.py, cord.px+15];
            if (nextlocation == ' ')
            {
                ErasePlayer(cord);
                cord.px++;
                PrintPlayer(player, cord);
            }
        }
        static void MoveLeft(char[,] maze, char[,] player, Coordinates cord)
        {
            char nextlocation = maze[cord.py, cord.px-1];
            if (nextlocation == ' ')
            {
                ErasePlayer(cord);
                cord.px--;
                PrintPlayer(player,cord);
            }
        }
        static void MoveUp(char[,] maze, char[,] player, Coordinates cord)
        {
            char nextlocation = maze[cord.py-1, cord.px];
            if (nextlocation == ' ')
            {
                ErasePlayer(cord);
                cord.py--;
                PrintPlayer(player, cord);
            }
        }
        static void MoveDown(char[,] maze, char[,] player, Coordinates cord)
        {
            char nextlocation = maze[cord.py+4, cord.px];
            if (nextlocation == ' ')
            {
                ErasePlayer(cord);
                cord.py++;
                PrintPlayer(player, cord);
            }
        }
        static void MoveEnemy(char[,] maze, char[,] enemy, Coordinates cord, ref string direction)
        {
            if(direction == "up")
            {
                char nextlocation = maze[cord.Ey-1, cord.Ex];
                if(nextlocation == ' ')
                {
                    EraseEnemy(cord);
                    cord.Ey--;
                    PrintEnemy(enemy, cord);
                }
                else
                {
                    direction = "down";
                }
            }
            if(direction == "down")
            {
                char nextlocation = maze[cord.Ey + 4, cord.Ex];
                if(nextlocation == ' ')
                {
                    EraseEnemy(cord);
                    cord.Ey++;
                    PrintEnemy(enemy, cord);
                }
                else
                {
                    direction = "up";
                }
            }
        }
        static void ReadMaze(char[,] maze, string path)
        {
            StreamReader file = new StreamReader(path);
            string record;
            int row = 0;
            while ((record = file.ReadLine()) != null)
            {
                for (int x = 0; x < 128; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            file.Close();
        }
        static void PrintMaze(char[,] maze)
        {
            for (int x = 0; x < 30; x++)
            {
                for (int y = 0; y < 130; y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void PrintPlayer(char[,] player, Coordinates cord)
        {

            for (int i = 0; i < 4; i++)
            {
                Gotoxy(cord.px, cord.py + i);
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(player[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void PrintEnemy(char[,] enemy, Coordinates cord)
        {
            for (int i = 0; i < 3; i++)
            {
                Gotoxy(cord.Ex, cord.Ey + i);
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(enemy[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void ErasePlayer(Coordinates cord)
        {
            for (int i = 0; i < 4; i++)
            {
                Gotoxy(cord.px, cord.py + i);
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static void EraseEnemy(Coordinates cord)
        {
            for (int i = 0; i < 3; i++)
            {
                Gotoxy(cord.Ex, cord.Ey + i);
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
