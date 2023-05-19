using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class Bullets
    {
        public int bulletX;
        public int bulletY;
        public bool isbulletactive;
        //Coordinates cord = new Coordinates();
        public Bullets()
        {

        }
        public void GenerateBullets(char[,] maze, List<Bullets> bull, Coordinates cord)
        {
            char nextlocation = maze[cord.py, cord.px + 15];
            if (nextlocation == ' ')
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
        public void MovePlayerbullet(char[,] maze, List<Bullets> bull)
        {
            foreach (var bullet in bull)
            {
                if (bullet.isbulletactive == true)
                {
                    char nextlocation = maze[bullet.bulletY, bullet.bulletX + 1];
                    if (nextlocation == ' ')
                    {
                        ErasePlayerBullet(bullet.bulletX, bullet.bulletY);
                        bullet.bulletX++;
                        PrintPlayerBullet(bullet.bulletX, bullet.bulletY);
                    }
                    else
                    {
                        ErasePlayerBullet(bullet.bulletX, bullet.bulletY);
                        bullet.isbulletactive = false;
                    }
                }
            }
        }
        public void BulletcollisionWithEnemy(List<Bullets> bull, ref int score, Coordinates cord)
        {
            foreach (var bullet in bull)
            {
                if (bullet.isbulletactive == true)
                {
                    if (bullet.bulletX + 1 == cord.Ey && (bullet.bulletX + 1 == cord.Ex || bullet.bulletX + 1 == cord.Ex + 2 || bullet.bulletX + 1 == cord.Ex + 3))
                    {
                        score = score + 1;
                    }
                    if (cord.Ey - 1 == bullet.bulletY && cord.Ex + 1 == bullet.bulletX)
                    {
                        score = score + 1;
                    }
                    PrintScore(ref score);
                }
            }
        }
        public void PrintScore(ref int score)
        {
            Gotoxy(135, 9);
            Console.WriteLine("Score: " + score);
        }
        public void PrintPlayerBullet(int x, int y)
        {
            Gotoxy(x, y);
            Console.Write(".");
        }
        public void ErasePlayerBullet(int x, int y)
        {
            Gotoxy(x, y);
            Console.Write(" ");
        }
        static void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
