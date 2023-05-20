using System;
using System.Collections.Generic;
using Week_06_Lab_Manual.BL;
using Week_06_Lab_Manual.DL;
using Week_06_Lab_Manual.UI;

namespace Week_06_Lab_Manual.UI
{
    class StudentUI
    {
        

        public static void printStudents()
        {
            foreach (Student s in StudentDL.studentsList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.Name + "got Admission in the following Degree   " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine("The Students did not get admission ");
                }
            }
        }
        public static void viewStudentsInDegree(string degName)
        {
            Console.WriteLine("Name \t  Inter \t Ecat \t Age");
            foreach (Student s in StudentDL.studentsList)
            {
                if (s.regDegree != null)
                {
                    if (degName == s.regDegree.degreeName)
                    {
                        Console.WriteLine(s.Name + "\t" + s.inter_Marks + "\t" + s.ecat_MArks + "\t" + s.age);
                    }

                }
            }
        }
        public static void viewRegiseredStudents()
        {
            Console.WriteLine("Name \t  Inter \t Ecat \t Age");
            foreach (Student s in StudentDL.studentsList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.Name + "\t" + s.inter_Marks + "\t" + s.ecat_MArks + "\t" + s.age);
                }
            }
        }
        public static Student takeInputForStudent()
        {
            List<DegreeProgramme> preference = new List<DegreeProgramme>();
            string Name;
            Console.WriteLine("Enter Your Name ");
            Name = Console.ReadLine();
            int Age;
            Console.WriteLine("Enter Your Age ");
            Age = int.Parse(Console.ReadLine());
            double Inter;
            Console.WriteLine("Enter Your Inter Marks ");
            Inter = double.Parse(Console.ReadLine());
            double Ecat;
            Console.WriteLine("Enter Your Ecat Marks ");
            Ecat = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Programme List ");
            DegreeProgramUI.viewDegreeProgramme();
            Console.Write("ENter the Number of the Preference ");
            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                Console.WriteLine("Enter Your Degree Name ");
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgramme dp in DegreeProgramme.programmeList)
                {
                    if (degName == dp.degreeName && !(preference.Contains(dp)))
                    {
                        preference.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Programme Name ");
                    x--;
                }

            }
            Student s = new Student(Name, Age, Inter, Ecat, preference);
            return s;

        }

        public static void calculateFeesForAll()
        {
            foreach (Student s in StudentDL.studentsList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.Name + "has Fees " + s.calculateFee());
                }
            }
        }
    }
}
