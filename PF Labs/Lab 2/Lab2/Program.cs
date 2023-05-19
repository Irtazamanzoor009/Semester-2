using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        public class Students
        {
            public string name;
            public int rollNo;
            public float cgpa;
        }
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            Task4();
            
        }
        static void Task4()
        {
            
            int count = 0;
            Uetstudents[] s = new Uetstudents[10];
            string option = "";
            while (option != "4")
            {
            
                option = Menu();
                if (option == "1") // Add Student
                {
                    s[count] = Addstudents();
                    count++;
                    Getch();
                }
                if (option == "2") // View Student
                {
                    ViewStudents(s, count);
                    Getch();
                }
                if (option == "3") // top 3 students
                {
                    TopStudent(s, count);
                    Getch();
                }

            }
        }
        static void Task1()
        {
            Students s1 = new Students();
            s1.name = "irtaza";
            s1.rollNo = 123;
            s1.cgpa = 3.5F;
            Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s1.name, s1.rollNo, s1.cgpa);
            Console.Read();
        }
        static void Task2()
        {
            // first object
            Students s1 = new Students();
            s1.name = "ali";
            s1.rollNo = 123;
            s1.cgpa = 3.3F;
            Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s1.name, s1.rollNo, s1.cgpa);
            // second object
            Students s2 = new Students();
            s2.name = "bilal";
            s2.rollNo = 455;
            s2.cgpa = 3.5F;
            Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s2.name, s2.rollNo, s2.cgpa);
            Console.Read();
        }
        static void Task3()
        {
            Students s1 = new Students();
            Console.WriteLine("Enter Name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter Roll No: ");
            s1.rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s1.name, s1.rollNo, s1.cgpa);
            Console.Read();

        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static string Menu()
        {
            Console.Clear();
            string choice;
            Console.WriteLine("------------------------------------");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Student");
            Console.WriteLine("3. Top 3 Student");
            Console.WriteLine("4. Go Back");
            Console.WriteLine("------------------------------------");
            Console.Write("Select your option...");
            choice = Console.ReadLine();
            return choice;
        }
        static Uetstudents Addstudents()
        {
            Console.Clear();
            Uetstudents s1 = new Uetstudents();
            Console.Write("Enter Name: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter Roll No: ");
            s1.rollno = int.Parse(Console.ReadLine());
            Console.Write("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.Write("Enter Departnemnt: ");
            s1.department = Console.ReadLine();
            Console.Write("Is Hostellide(y/n): ");
            s1.ishostellide = char.Parse(Console.ReadLine());
            return s1;
        }
        static void ViewStudents(Uetstudents[] s, int count)
        {
            Console.Clear();
            Console.WriteLine("Name\t\t\tRoll Number\t\tCGPA\t\t Department\t\tIs Hostellide");
            for(int i=0; i<count; i++)
            {
                Console.WriteLine("{0}\t\t {1} \t\t\t{2} \t\t{3} \t\t\t {4} ", s[i].name, s[i].rollno, s[i].cgpa, s[i].department, s[i].ishostellide);
            }
        }
        static int GetLargestIndex(Uetstudents[] s, int start, int count)
        {
            int index = start;
            float largest = s[start].cgpa;
            for(int i=start; i < count; i++)
            {
                if(largest < s[i].cgpa)
                {
                    largest = s[i].cgpa;
                    index = i;
                }
            }
            return index;
        }
        static void TopStudent(Uetstudents[] s, int count)
        {
            Console.Clear();
            if(count == 0)
            {
                Console.WriteLine("No Record Present");
                //Getch();
            }
            else if(count == 1)
            {
                ViewStudents(s, 1);
            }
            else if(count == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    int index = GetLargestIndex(s, i, count);
                    Uetstudents temp = s[index];
                    s[index] = s[i];
                    s[i] = temp;
                }
                ViewStudents(s, 2);
            }
            else
            {
                for(int i=0; i<3; i++)
                {
                    int index = GetLargestIndex(s, i, count);
                    Uetstudents temp = s[index];
                    s[index] = s[i];
                    s[i] = temp;
                }
                ViewStudents(s, 3);
            }

        }
    }
}
