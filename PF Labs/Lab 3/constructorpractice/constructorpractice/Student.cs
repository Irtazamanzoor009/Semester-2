using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructorpractice
{
    class Student
    {
        public Student()
        {
            name = "jill";
        }
        public Student(string n)
        {
            //Console.WriteLine("Default Constructer called");
            name = n;
        }
        public string name;
        public int marks;
        public float aggregate;
    }
}
