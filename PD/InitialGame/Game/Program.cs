using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EZInput;
using System.Text;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int px = 5, py = 10;
            int Ex = 100, Ey = 20;
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
            char[,] maze = new char[30, 130];
            string direction = "up";
            int bulletCount = 0;
            int[] bulletX = new int[1000];
            int[] bulletY = new int[1000];
            bool[] isBulletActive = new bool[1000];
            /*{"################################################################################################################################"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"#                                                                                                                              #"},
            {"################################################################################################################################"},
       };*/

            int score = 0;
            ClearScreen();
            ReadMaze(maze);
            PrintMaze(maze);
            PrintEnemy(enemy, ref Ex, ref Ey);
            //PrintPlayer(player, ref px, ref py);
            bool gamerunning = true;
            while (true)
            {

                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    MoveRight(maze, ref px, ref py, player);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    MoveLeft(maze, ref px, ref py, player);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    MoveUp(maze, ref px, ref py, player);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    MoveDown(maze, ref px, ref py, player);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    GenerateBullet(player, ref bulletX, ref bulletY, ref bulletCount, ref px, ref py, isBulletActive);
                }

                MoveEnemy(maze, ref Ex, ref Ey, enemy, ref direction);
                MoveBullet(ref bulletCount, isBulletActive, maze, ref px, ref py, ref bulletX, ref bulletY);
                bulletCollisionwithEnemy1(ref bulletCount, isBulletActive, bulletX, bulletY, ref Ex, ref Ey, ref score);
                Thread.Sleep(150);

            }
            Console.ReadLine();
        }
        static void PrintScore(ref int score)
        {
            Gotoxy(135, 9);
            Console.WriteLine("Score: " + score);
        }
        static void GenerateBullet(char[,] player, ref int[] bulletX, ref int[] bulletY, ref int bulletCount, ref int px, ref int py, bool[] isBulletActive)
        {
            bulletX[bulletCount] = px;
            bulletY[bulletCount] = py+15;
            isBulletActive[bulletCount] = true;
            //Gotoxy(py+15, px);
            //Console.Write(".");
            bulletCount++;
            
        }
        static void MoveEnemy(char[,] maze, ref int Ex, ref int Ey, char[,] enemy, ref string direction)
        {
            if(direction == "up")
            {
                if(Ey <= 2)
                {
                    direction = "down";
                }
                else
                {                
                    EraseEnemy(ref Ex,ref Ey);
                    Ey--;
                    PrintEnemy(enemy, ref Ex, ref Ey);
                }
                
            }
            if(direction == "down")
            {
                if(Ey>=29)
                {
                    direction = "up";
                }
                else
                {                                 
                    EraseEnemy(ref Ex, ref Ey);
                    Ey++;
                    PrintEnemy(enemy, ref Ex, ref Ey);
                }
                

            }
               
        }
        static void erasePlayerbullet(ref int x, ref int y) // erase plalyer's bullet
        {
            Gotoxy(x, y);
            Console.WriteLine(" ");
        }
        static void printPlayerbullet(ref int x, ref int y) // print player's bullets 
        {
            Gotoxy(x, y);
            Console.WriteLine(".");
        }
        static void MoveBullet(ref int bulletcount, bool[] isbulletactive, char[,] maze, ref int px, ref int py, ref int[] bulletX, ref int[] bulletY)
        {
            for (int i = 0; i < bulletcount; i++)
            {
                if (isbulletactive[i] == true)
                {
                    if (maze[px , py+15] != '#')
                    {
                        erasePlayerbullet(ref bulletY[i], ref bulletX[i]);
                        bulletY[i] = bulletY[i] + 2;
                        printPlayerbullet(ref bulletY[i], ref bulletX[i]);
                    }
                    else
                    {

                        erasePlayerbullet(ref bulletY[i], ref bulletX[i]);
                        isbulletactive[i] = false;
                    }
                }
            }
        }
        static void bulletCollisionwithEnemy1(ref int bulletcount, bool[] isbulletactive, int[] bulletX, int[] bulletY, ref int Ex, ref int Ey, ref int score) // detect bullet collision of player with enemy
        {
            for (int i = 0; i < bulletcount; i++)
            {
                if (isbulletactive[i] == true)
                {
                    if (bulletY[i] + 1 == Ey && (bulletX[i] + 1 == Ex || bulletX[i] + 1 == Ex + 2 || bulletX[i] + 1 == Ex + 3))
                    {
                        score = score + 1;
                    }
                    if (Ey - 1 == bulletY[i] && Ex + 1 == bulletX[i])
                    {
                        score = score + 1;                        
                    }
                    PrintScore(ref score);
                }
            }
            
        }
        static void MoveRight(char[,] maze, ref int px, ref int py, char[,] player)
        {
            if (maze[px, py + 15] == ' ')
            {
                ErasePlayer(ref py, ref px);
                py = py + 1;
                PrintPlayer(player, ref py, ref px);
            }
        }
        static void MoveLeft(char[,] maze, ref int px, ref int py, char[,] player)
        {
            if (maze[px, py - 1] == ' ')
            {
                ErasePlayer(ref py, ref px);
                py = py - 1;
                PrintPlayer(player, ref py, ref px);
            }
        }
        static void MoveUp(char[,] maze, ref int px, ref int py, char[,] player)
        {
            if (maze[px - 1, py] == ' ')
            {
                ErasePlayer(ref py, ref px);
                px = px - 1;
                PrintPlayer(player, ref py, ref px);
            }
        }
        static void MoveDown(char[,] maze, ref int px, ref int py, char[,] player)
        {
            if (maze[px + 2, py] == ' ')
            {
                ErasePlayer(ref py, ref px);
                px = px + 1;
                PrintPlayer(player, ref py, ref px);
            }
        }
        static void ClearScreen()
        {
            Console.Clear();
        }
        static void PrintPlayer(char[,] player, ref int px, ref int py)
        {

            for (int i = 0; i < 4; i++)
            {
                Gotoxy(px, py + i);
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(player[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void PrintEnemy(char[,] enemy, ref int Ex, ref int Ey)
        {
            for(int i=0; i<3; i++)
            {
                Gotoxy(Ex, Ey + i);
                for(int j=0; j<10; j++)
                {
                    Console.Write(enemy[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void ErasePlayer(ref int px, ref int py)
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
        static void EraseEnemy(ref int Ex, ref int Ey)
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
        static void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        static void ReadMaze(char[,] maze)
        {
            StreamReader file = new StreamReader("E:\\Semester 2-\\PD\\Game\\maze.txt");
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


    }
}