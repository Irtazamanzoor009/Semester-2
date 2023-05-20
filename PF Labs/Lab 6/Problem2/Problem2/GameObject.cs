using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class GameObject
    {
        public char[,] Shape;
        /* public int x=0;
         public int y=0;*/
        public Point StartingPoint;
        public Boundary Premises;
        public string Direction;

        public GameObject(char[,] shape, Point start, Boundary premises, string direction)
        {
            this.Shape = shape;
            this.StartingPoint = start;
            this.Premises = premises;
            this.Direction = direction;
        }

        public void Erase()
        {
            for (int i = 0; i < 5; i++)
            {
                Gotoxy(StartingPoint.GetX(), StartingPoint.GetY() + i);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void Gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public void Draw()
        {
            for (int i = 0; i < 5; i++)
            {
                Gotoxy(StartingPoint.GetX(), StartingPoint.GetY() + i);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Shape[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Move()
        {
            if (Direction == "LefttoRight")
            {
                if (StartingPoint.GetX() < Premises.TopRight.GetX())
                {
                    StartingPoint.SetX(StartingPoint.GetX() + 1);
                }
            }
            else if (Direction == "RighttoLeft")
            {
                if (StartingPoint.GetX() > Premises.TopLeft.GetX())
                {
                    StartingPoint.SetX(StartingPoint.GetX() - 1);
                }
            }
            else if (Direction == "PatrolR")
            {
                if (StartingPoint.GetX() < Premises.TopRight.GetX())
                {
                    StartingPoint.SetX(StartingPoint.GetX() + 1);
                }
                else
                {
                    Direction = "PatrolL";
                }
            }
            else if (Direction == "PatrolL")
            {
                if (StartingPoint.GetX() > Premises.TopLeft.GetX())
                {
                    StartingPoint.SetX(StartingPoint.GetX() - 1);
                }
                else
                {
                    Direction = "PatrolR";
                }
            }
            else if (Direction == "Diagonal")
            {
                if (StartingPoint.GetX() < Premises.BottomRight.GetX() && StartingPoint.GetY() < Premises.BottomRight.GetY())
                {
                    StartingPoint.SetX(StartingPoint.GetX() + 4);
                    StartingPoint.SetY(StartingPoint.GetY() + 1);
                }
            }
            else if (Direction == "Projectile")
            {
                int count = 0;
                while (count < 5)
                {
                    if ((StartingPoint.GetX() < Premises.TopRight.GetX()))
                    {
                        StartingPoint.SetY(StartingPoint.GetY() - 1);
                        StartingPoint.SetX(StartingPoint.GetX() + 1);
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                int count2 = 0;
                while(count2 < 2)
                {
                    if (StartingPoint.GetX() < Premises.TopRight.GetX())
                    {
                        StartingPoint.SetX(StartingPoint.GetX() + 1);
                        count2++;
                    }
                    else
                    {
                        break;
                    }
                }
                count2 = 0;
                while(count2 < 4)
                {
                    if (StartingPoint.GetX() < Premises.BottomRight.GetX())
                    {
                        StartingPoint.SetX(StartingPoint.GetX() + 1);
                        StartingPoint.SetY(StartingPoint.GetY() + 1);
                        count2++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}

                
                
            
    

