using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Clearscreen();
            Header();
            List<Student> student = new List<Student>();
            Student S = new Student();
            string choice = "";
            while(choice != "4")
            {
                Clearscreen();
                Header();
                choice = Menu();
                if(choice == "1") // add information
                {
                    Clearscreen();
                    Header();
                    S = TakeInput();
                    if(S != null)
                    {
                        StoredatainList(S, student);
                        Console.WriteLine("Your information has been recorded");
                        Getch();
                    }
                    else
                    {
                        Console.WriteLine("Wring Credentials entered");
                        Getch();
                    }
                }
                else if(choice == "2") // view information
                {
                    Clearscreen();
                    Header();
                    S.ViewInformation(student);
                    Getch();
                }
                else if(choice == "3") // check merit and scholarship
                {
                    Clearscreen();
                    Header();
                    float merit = S.CalculateMerit();
                    Console.WriteLine("Merit: " + merit);
                    bool check = S.AvailScholarship(merit);
                    if(check)
                    {
                        Console.WriteLine("You are eligible for scholarship");
                    }
                    else
                    {
                        Console.WriteLine("You are not eligible");
                    }

                    Getch();

                }



            }
        }
        static void Header()
        {
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("**             UNIVERSITY ADMISSION MANAGEMENT SYSTEM                     **");
            Console.WriteLine("****************************************************************************");
        }
        static void Clearscreen()
        {
            Console.Clear();
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static string Menu()
        {
            string option;
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Add Information");
            Console.WriteLine("2. View Information");
            Console.WriteLine("3. Check Merit and Scholarship");
            Console.WriteLine("4. Exit");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;
        }
        static Student TakeInput()
        {
            Console.WriteLine("---------------------------");
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Roll No: ");
            int rollno = int.Parse(Console.ReadLine());
            Console.Write("Enter CGPA: ");
            float cgpa = float.Parse(Console.ReadLine());
            Console.Write("Enter Matric Marks: ");
            int matric = int.Parse(Console.ReadLine());
            Console.Write("Enter FSC Marks: ");
            int fsc = int.Parse(Console.ReadLine());
            Console.Write("Enter ECAT Marks: ");
            int ecat = int.Parse(Console.ReadLine());
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Are you hostellite(true/false): ");
            bool hostellite = bool.Parse(Console.ReadLine());
            Console.Write("Is Taking Scholarship: ");
            bool scholarship = bool.Parse(Console.ReadLine());
            if(name != null && rollno != null && cgpa != null && matric != null && fsc != null && ecat != null && address != null && hostellite != null && scholarship != null)
            {
                Student add = new Student(name, rollno, cgpa, matric, fsc, ecat, address, hostellite, scholarship);
                return add;
            }
            return null;

        }
        static void StoredatainList(Student S, List<Student> student)
        {
            student.Add(S);
        }
    }
}
