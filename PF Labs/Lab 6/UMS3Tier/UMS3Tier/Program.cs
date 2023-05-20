using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS3Tier.BL;
using UMS3Tier.DL;
using UMS3Tier.UI;

namespace UMS3Tier
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = "";
            MenuUI.Clearscreen();
            MenuUI.Header();
            while(option != "8")
            {
                MenuUI.Clearscreen();
                MenuUI.Header();
                option = MenuUI.Menu();
                if(option == "1") // add student
                {
                   if(DegreeProgramDL.DegreeList.Count > 0)
                   {
                        MenuUI.Clearscreen();
                        MenuUI.Header();
                        Student s = StudentUI.TakeStudentInput();
                        StudentDL.AddinList(s);
                        Console.WriteLine("Student Data Add Successfully");
                        MenuUI.Getch();
                   }
                   else
                   {
                        MenuUI.Clearscreen();
                        MenuUI.Header();
                        Console.WriteLine("NO Program Added yet");
                        MenuUI.Getch();
                   }
                }
                else if(option == "2") // add program
                {
                    MenuUI.Clearscreen();
                    MenuUI.Header();
                    DegreeProgram d = DegreeProgramUI.TakeInputForDegree();
                    DegreeProgramDL.StoreInDegreeList(d);
                    Console.WriteLine("Degree Program Added Successfully");
                    MenuUI.Getch();
                }
                else if(option == "3") // generate merit
                {
                    MenuUI.Clearscreen();
                    MenuUI.Header();
                    StudentDL.CalculateMerit();
                    StudentDL.SortStudentByMerit();
                    StudentDL.GiveAdmissions();
                    MenuUI.Getch();
                }
                else if(option == "4") // view registered student
                {
                    MenuUI.Clearscreen();
                    MenuUI.Header();
                    StudentUI.ViewRegisteredStudents();
                    MenuUI.Getch();
                }
                else if(option == "5") // view student of a specific degree
                {
                    MenuUI.Clearscreen();
                    MenuUI.Header();
                    Console.WriteLine("Enter Degree Name: ");
                    string degname = Console.ReadLine();
                    StudentUI.ViewStudentInSpecificDegree(degname);
                    MenuUI.Getch();
                }
                else if(option == "6") // register subject for a specific student
                {
                    Console.WriteLine("Enter Student Name: ");
                    string name = Console.ReadLine();
                    int index = Student.ViewIndex(name);
                    if(index >= 0)
                    {

                    }
                    
                }
                else if(option == "7") // calculate fee for all registered students
                {
                    MenuUI.Clearscreen();
                    MenuUI.Header();
                    StudentUI.CalculatefeeforAll();
                    MenuUI.Getch();
                }
            }

        }
    }
}
