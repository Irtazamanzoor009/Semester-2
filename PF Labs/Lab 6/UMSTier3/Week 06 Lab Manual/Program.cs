using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_06_Lab_Manual.BL;
using Week_06_Lab_Manual.DL;
using Week_06_Lab_Manual.UI;

namespace Week_06_Lab_Manual
{
    public class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "subject.txt";
            string degreePath = "degree.txt";
            string studentPath = "student.txt";

            if (SubjectDL.readFromFile(subjectPath))
            {
                Console.WriteLine("Subject Data Has been Loaded Successfully ");
            }
            if (DegreeProgrammeDL.readFromFile(degreePath))
            {
                Console.WriteLine("Degree Data Has been Loaded Successfully ");
            }
            if (StudentDL.readFromFile(studentPath))
            {
                Console.WriteLine("The student Data Has been Loaded Successfully");

            }
            string  option;
            do
            {
                option = MenuUI.menu();
                MenuUI.clearScreen();
                if (option == "1")
                {
                    if (DegreeProgrammeDL.programmeList.Count > 0)
                    {
                        Student s = StudentUI.takeInputForStudent();
                        StudentDL.addStudentIntoList(s);
                        StudentDL.storeIntoFile(studentPath, s);

                    }
                }
                if (option == "2")
                {
                    DegreeProgramme d = DegreeProgramUI.takeInputForDegree();
                    DegreeProgrammeDL.addDegreeIntoList(d);
                    DegreeProgrammeDL.storeDegreeDataInFile(subjectPath, d);
                }
                if (option == "3")
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.sortStudentsByMerit();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                }
                if (option == "4")
                {
                    StudentUI.viewRegiseredStudents();
                }
                if (option == "5")
                {
                    string degreeName;
                    Console.WriteLine("Enter the Degree name");
                    degreeName = Console.ReadLine();
                    StudentUI.viewStudentsInDegree(degreeName);
                }
                if (option == "6")
                {
                    Console.WriteLine("Enter the Student Name ");
                    string Name = Console.ReadLine();
                    Student s = StudentDL.studentPresent(Name);
                    if (s != null)
                    {
                        SubjectUI.registerSubjects(s);
                        SubjectUI.viewSubjects(s);

                    }
                }
                if (option == "7")
                {
                    StudentUI.calculateFeesForAll();

                }
                MenuUI.clearScreen();
            }
            while (option != "8");

        }
    }
}
