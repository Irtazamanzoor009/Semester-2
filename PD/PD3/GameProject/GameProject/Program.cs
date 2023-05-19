using System;
using System.IO;
using EZInput;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameProject
{    

    
    class Program
    {
        static void Main(string[] args)
        {
            List<Bullets> bull = new List<Bullets>();
            Coordinates cord = new Coordinates();
            Bullets bullet = new Bullets();
            char[,] maze = new char[1000, 1000];
            string path = "maze.txt";
            string direction = "up";
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
            cord.px = 5;
            cord.py = 5;
            cord.Ex = 85;
            cord.Ey = 10;
            int timer = 0;
            int score = 0;
            Console.ReadKey();
            ReadMaze(maze, path);
            PrintMaze(maze);
            cord.PrintEnemy(enemy);
            while (true)
            {
                cord.PrintPlayer(player);
                bullet.PrintScore(ref score);
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    cord.MoveRight(maze, player);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    cord.MoveLeft(maze, player);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    cord.MoveUp(maze, player);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    cord.MoveDown(maze, player);
                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    bullet.GenerateBullets(maze, bull, cord);
                }
                timer++;
                if (timer == 5)
                {
                    cord.MoveEnemy(maze, enemy, ref direction);
                    timer = 0;
                }
                bullet.MovePlayerbullet(maze, bull);
                bullet.BulletcollisionWithEnemy(bull,ref score, cord);
                Thread.Sleep(50);
            }
                Console.ReadKey();
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
        
        
    }
}
