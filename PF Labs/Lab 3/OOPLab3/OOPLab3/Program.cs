using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3
{
    class Program
    {
        class Student
        {
            public string name;
            public float matricmarks;
            public float fscmarks;
            public float ecatmarks;
            public float aggregate;
        }
        class Student1
        {
            public Student1()
            {
                Console.WriteLine("Default Constructer Called");
            }
            public string name;
            public float matricmarks;
            public float fscmarks;
            public float ecatmarks;
            public float aggregate;
        }
        class Student2
        {
            public Student2()
            {
                name = "jill";
            }
            public string name;
            public float matricmarks;
            public float fscmarks;
            public float ecatmarks;
            public float aggregate;
        }
        class Student3
        {
            public Student3()
            {
                name = "jill";
                matricmarks = 1049F;
                fscmarks = 1058F;
                ecatmarks = 114F;
                aggregate = 79.2F;
            }
            public string name;
            public float matricmarks;
            public float fscmarks;
            public float ecatmarks;
            public float aggregate;
        }
        class Student4
        {
            public Student4(string n, float m, float f, float e, float a)
            {
                name = n;
                matricmarks = m;
                fscmarks = f;
                ecatmarks = e;
                aggregate = a;
            }
            public string name;
            public float matricmarks;
            public float fscmarks;
            public float ecatmarks;
            public float aggregate;
        }
        class Student5
        {
            public Student5()
            {
                Console.WriteLine("Default Constructer Called");
            }
            public Student5(Student5 s)
            {
                name = s.name;
                matricmarks = s.matricmarks;
                fscmarks = s.fscmarks;
                ecatmarks = s.ecatmarks;
                aggregate = s.aggregate;
            }
            public string name;
            public float matricmarks;
            public float fscmarks;
            public float ecatmarks;
            public float aggregate;
        }
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //SelfAssesmentTask1();
            //Task4();
            //Task5();
            Task6();
        }
        static void Task1()
        {
            Student s1 = new Student();
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.matricmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmarks);
            Console.WriteLine(s1.aggregate);
            Console.ReadKey();
        }
        static void Task2()
        {
            Student1 s1 = new Student1();
            Console.ReadKey();
        }
        static void Task3()
        {
            Student2 s1 = new Student2();
            Console.WriteLine(s1.name);
            Console.ReadKey();
        }
        static void SelfAssesmentTask1()
        {
            Student3 s1 = new Student3();
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.matricmarks);
            Console.WriteLine(s1.fscmarks);
            Console.WriteLine(s1.ecatmarks);
            Console.WriteLine(s1.aggregate);
            Console.ReadKey();
        }
        static void Task4()
        {
            Student4 s1 = new Student4("John", 1049, 1058, 114, 79.2F);
            Console.WriteLine(s1.name + ' ' + s1.matricmarks + ' ' +  s1.fscmarks + ' ' +  s1.ecatmarks + ' ' + s1.aggregate);
            Student4 s2 = new Student4("Jack", 1050, 1060, 130, 80);
            Console.WriteLine(s2.name + ' ' +  s2.matricmarks + ' ' + s2.fscmarks +' '+ s2.ecatmarks +' '+ s2.aggregate);
            Console.ReadKey();
        }
        static void Task5()
        {
            Student5 s1 = new Student5();
            s1.name = "jack";
            Student5 s2 = new Student5(s1);
            Console.WriteLine(s1.name);
            Console.WriteLine(s2.name);
            Console.ReadKey();
        }
        static void Task6()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            foreach(var i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
