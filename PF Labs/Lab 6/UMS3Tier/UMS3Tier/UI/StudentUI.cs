using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS3Tier.BL;
using UMS3Tier.DL;

namespace UMS3Tier.UI
{
    class StudentUI
    {
        public static Student TakeStudentInput()
        {
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSC Marks: ");
            double fsc = int.Parse(Console.ReadLine());
            Console.Write("Enter Student ECAT Marks: ");
            double ecat = int.Parse(Console.ReadLine());
            Console.Write("Available Degree Programs: ");
            DegreeProgramDL.ShowDegreePrograms();
            Console.Write("Enter Number of Preferences to Enter: ");
            int number = int.Parse(Console.ReadLine());
            for(int i=0; i< number; i++)
            {
                Console.WriteLine("Enter Preference Name: ");
                string preference = Console.ReadLine();
                DegreeProgram add = new DegreeProgram(preference);
                preferences.Add(add);
            }
            Student s = new Student(name, age, fsc, ecat, preferences);
            return s;
        }

        public static void ViewRegisteredStudents()
        {
            Console.WriteLine("Name\t\tFSC\t\tECAT\t\tAge");
            foreach(var student in StudentDL.studentlist)
            {
                Console.WriteLine(student.Name + "\t\t" + student.FscMarks + "\t\t" + student.EcatMarks + "\t\t" + student.Age);
            }
        }

        public static void ViewStudentInSpecificDegree(string Degreename)
        {
            Console.WriteLine("Name\t\tFSC\t\tECAT\t\tAge");
            foreach (var d in DegreeProgramDL.DegreeList)
            {
                if(Degreename == d.Degreename)
                {
                    foreach(var s in StudentDL.studentlist)
                    {
                        for(int i=0; i<s.Preferences.Count; i++)
                        {
                            if(s.Preferences[i].Degreename == Degreename)
                            {
                                Console.WriteLine(s.Name + "\t\t" + s.FscMarks + "\t\t" + s.EcatMarks + "\t\t" + s.Age);
                                break;
                            }
                        }
                    }
                }
            }
        }

        /*public static void CalculateFee()
        {
            int fee = 0;
            foreach(var stu in StudentDL.studentlist)
            {
               foreach(var s in stu.subjects)
               {
                    fee = fee + s.SubjectFee;
               }
            }
           
        }*/

        public static void CalculatefeeforAll()
        {
            foreach(var s in StudentDL.studentlist)
            {
                Console.WriteLine(s.Name + " has fee " + s.CalculateFee());
            }
        }

        public static List<Subject> AddsubjectForStudent(string name)
        {
            foreach(var s in StudentDL.studentlist)
            {
                if(name == s.Name)
                {
                    Console.WriteLine("Enter Subject Code: ");
                    string code = Console.ReadLine();
                    foreach(var d in DegreeProgramDL.DegreeList)
                    {
                        foreach(var sub in d.subjects)
                        {
                            if(code == sub.Code)
                            {
                                Subject st = new Subject(sub);
                                
                            }
                        }
                    }
                }
            }
        }
    }
}
