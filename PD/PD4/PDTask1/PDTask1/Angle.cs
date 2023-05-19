using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTask1
{
    class Angle
    {
        public int Degree;
        public float Minutes;
        public char Direction;
        Ship ship = new Ship();
        List<Angle> angle = new List<Angle>();
        public Angle(int degree, float minutes, char direction)
        {
            Degree = degree;
            Minutes = minutes;
            Direction = direction;
        }
        
        public Angle()
        {

        }
        public void Changedirection(int degree, float minutes, char direction)
        {
            Degree = degree;
            Minutes = minutes;
            Direction = direction;
        }

       
    }
}
