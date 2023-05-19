using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DegreeProgram> degreelist = new List<DegreeProgram>();
            List<Subject> subjectlist = new List<Subject>();
            List<Student> studentlist = new List<Student>();
            Student studentobject = new Student();
            DegreeProgram degreeobject = new DegreeProgram();
            ClearScreen();
            Header();
            string choice = "";
            while(choice != "8")
            {
                ClearScreen();
                Header();
                choice = Menu();
                if(choice == "1") // add student
                {
                    studentlist.Add(AddStudent(degreelist));
                    Console.WriteLine("Student data add successfully");
                    Getch();
                }        
                else if(choice == "2") // add degree program
                {
                    ClearScreen();
                    Header();
                    ProgramSubmenudriver(degreelist, subjectlist);
                    Getch();
                }
                else if(choice == "3") // add subject
                {
                    ClearScreen();
                    Header();
                    SubjectSubMenudriver(subjectlist, degreelist);
                    Getch();
                }
                else if(choice == "4") // generate merit
                {
                    ClearScreen();
                    Header();
                    CalculateMerit(studentlist);
                    SortStudentsByMerit(studentlist);
                    GiveAdmissions(studentlist);
                    PrintAdmitStudent(studentlist);
                    Getch();                   

                }
                else if(choice == "5") // view registered student
                {
                    ClearScreen();
                    Header();
                    ViewRegisteredStudents(studentlist);
                    Getch();
                }
                else if(choice == "6") // view students of specific program
                {
                    ClearScreen();
                    Header();
                    Console.WriteLine("Enter Degree Name: ");
                    string degname = Console.ReadLine();
                    ViewStudentInDegree(studentlist, degname);
                    Getch();
                }
                else if(choice == "7") // Register subjects for specific students
                {
                    Console.WriteLine("Enter Student Name: ");
                    string name = Console.ReadLine();
                    Student s = Studentpresent(name, studentlist);
                    if(s != null)
                    {
                        ViewSubjects(s);
                        RegisterSubjects(s, subjectlist);
                        Getch();
                    }

                }
                else if(choice == "8") // calculate fee for all registerd students
                {
                    CalculateFeeforAll(studentlist, subjectlist);
                    Getch();
                }
            }
        }
        static void ViewSubjects(Student s)
        {
            if(s.regDegree != null)
            {
                Console.WriteLine("Sub Code\t\t Sub Type");
                foreach(Subject S in s.regDegree.subjectlist)
                {
                    Console.WriteLine(S.Code + "\t\t" + S.Type);
                }
            }
        }
        static Student Studentpresent(string name, List<Student> studentlist)
        {
            foreach(Student s in studentlist)
            {
                if(name == s.Name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }

        static void CalculateFeeforAll(List<Student> studentlist, List<Subject> subjectlist)
        {
            foreach(Student S in studentlist)
            {
                if(S.regDegree != null)
                {
                    Console.WriteLine(S.Name + " has " + S.CalculateFee(subjectlist) + " fees");
                }
            }
        }
        static void RegisterSubjects(Student S, List<Subject> subjectlist)
        {
            Console.WriteLine("Enter how many subjects you want to enter: ");
            int count = int.Parse(Console.ReadLine());
            for(int i=0; i<count; i++)
            {
                Console.WriteLine("Enter the Subject Code: ");
                string code = Console.ReadLine();
                bool flag = false;
                foreach(Subject Sub in S.regDegree.subjectlist)
                {
                    if(code == Sub.Code && !(S.regSubject.Contains(Sub)))
                    {
                        S.regstudentssubjects(Sub,subjectlist);
                        flag = true;
                        break;
                    }
                }
                if(flag == false)
                {
                    Console.WriteLine("Enter Valid Course");
                    i--;
                }
            }
        }
        static void ViewStudentInDegree(List<Student> studentlist, string name)
        {
            Console.WriteLine("Name\t\tFSC\t\tECAT\t\tAge");
            foreach(Student S in studentlist)
            {
                if(S.regDegree != null)
                {
                    if (name == S.regDegree.Degreename)
                    {
                        Console.WriteLine(S.Name + "\t\t" + S.Fscmarks + "\t\t" + S.Ecatmarks + "\t\t" + S.Age);
                    }
                }
            }
        }
        static void ViewRegisteredStudents(List<Student> studentlist)
        {
            Console.WriteLine("Name\t\tFSC\t\tECAT\t\tAge");
            foreach(Student S in studentlist)
            {
                if(S.regDegree != null)
                {
                    Console.WriteLine(S.Name + "\t\t" + S.Fscmarks + "\t\t" + S.Ecatmarks + "\t\t" + S.Age);
                }
            }
        }
        static void CalculateMerit(List<Student> student)
        {
            foreach (var merit in student)
            {
                double findmerit = (merit.Fscmarks * 60F / 1100F) + (merit.Ecatmarks * 40F / 400F);
                merit.Merit = findmerit;
            }
        }
        static void SortStudentsByMerit(List<Student> Stud)
        {
            for (int i = 0; i < Stud.Count; i++)
            {
                for (int j = 0; j < Stud.Count; j++)
                {
                    Student temp = new Student();
                    if (Stud[i].Merit < Stud[j].Merit)
                    {
                        temp = Stud[i];
                        Stud[i] = Stud[j];
                        Stud[j] = temp;
                    }
                }
            }
        }
        static void GiveAdmissions(List<Student> studentlist)
        {
            foreach(Student S in studentlist)
            {
                foreach(DegreeProgram D in S.degreelist)
                {
                    if(D.Seats > 0 && S.regDegree == null)
                    {
                        S.regDegree = D;
                        D.Seats--;
                        break;
                    }
                }
            }
        }
        static void PrintAdmitStudent(List<Student> studentlist)
        {
            foreach (Student S in studentlist)
            {
                if(S.regDegree != null)
                {
                    Console.WriteLine(S.Name + " got admission in " + S.regDegree.Degreename);
                }
                else
                {
                    Console.WriteLine(S.Name + " did not get admission");
                }
            }
        }
        static Student AddStudent(List<DegreeProgram> degreelist)
        {
            List<DegreeProgram> pref = new List<DegreeProgram>();
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSC Marks: ");
            double fsc = int.Parse(Console.ReadLine());
            Console.Write("Enter Student ECAT Marks: ");
            double ecat = int.Parse(Console.ReadLine());
            Console.Write("Available Degree Programs: ");
            DegreeProgram viewname = new DegreeProgram();
            foreach (var nameq in degreelist)
            {
                Console.Write(nameq.Degreename + " ");
            }
            Console.Write("Enter number of preferences to enter: ");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Console.Write("Enter Preference Name: ");
                string preferences = Console.ReadLine();
                DegreeProgram add = new DegreeProgram(preferences);
                pref.Add(add);
            }
            Student S = new Student(name, age, fsc, ecat, pref);
            return S;

        }
        static string SubjectSubmenu()
        {
            string option = "";
            Console.WriteLine("1. Add Subject");
            Console.WriteLine("2. View Subjects");
            Console.WriteLine("3. Delete Subjects");
            Console.WriteLine("4. Exit");
            Console.WriteLine("---------------------------- ");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;

        }
        static void SubjectSubMenudriver(List<Subject> subjectlist, List<DegreeProgram> degreelist)
        {
            while(true)
            {
                ClearScreen();
                Header();
                string option = SubjectSubmenu();
                if(option == "1") // add subject
                {
                    DegreeProgram searchdegree = IsprogramValid(degreelist);
                    if(searchdegree != null)
                    {
                        searchdegree.AddSubjects(AddSubject(), subjectlist);
                        Console.WriteLine("Subject has been added");
                        Getch();
                    }
                    else
                    {
                        Console.WriteLine("Error! Degree Program not found");
                        Getch();
                    }
                }
                else if(option == "2") // view subject
                {
                    DegreeProgram searchdegree = IsprogramValid(degreelist);
                    if (searchdegree != null)
                    {
                        searchdegree.DisplaySubject(subjectlist);
                        Getch();
                    }
                    else
                    {
                        Console.WriteLine("Error! Degree Program not found");
                        Getch();
                    }
                }
                else if(option == "3") // delete subject
                {

                }
                else if(option == "4") // exit
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error! Entered Wrong option");
                    Getch();
                }
            }
        }
        static DegreeProgram IsprogramValid(List<DegreeProgram> degreelist)
        {
            Console.WriteLine("Enter Subject Degree Name: ");
            string name = Console.ReadLine();
            foreach(var program in degreelist)
            {
                if(program.Degreename == name)
                {
                    return program;
                }
            }
            return null;
        }
        static void ProgramSubmenudriver(List<DegreeProgram> degreelist, List<Subject> subjectlist)
        {
            while (true)
            {
                ClearScreen();
                Header();
                string submenuoption = ProgramSubmenu();
                if (submenuoption == "1") // add program
                {
                    ClearScreen();
                    Header();
                    degreelist.Add(AddProgram());
                    Console.WriteLine("Program has been added successfully");
                    Getch();
                }
                else if (submenuoption == "2") // view program
                {
                    ClearScreen();
                    Header();
                    DegreeProgram degree = new DegreeProgram();
                    degree.ViewDegreePrograms(degreelist);
                    Getch();
                }
                else if (submenuoption == "3") // delete program
                {

                }
                else if (submenuoption == "4") // exit
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error! Wrong option try again");
                    Getch();
                }
            }
        }
        static string ProgramSubmenu()
        {
            string option="";
            Console.WriteLine("1. Add Program");
            Console.WriteLine("2. View Program");
            Console.WriteLine("3. Delete Program");
            Console.WriteLine("4. Exit");
            Console.WriteLine("---------------------------- ");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;

        }
        
        static DegreeProgram AddProgram()
        {
            Console.Write("Enter Degree Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            double duration = double.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree: ");
            int seats = int.Parse(Console.ReadLine());
            DegreeProgram add = new DegreeProgram(name, duration, seats);
            return add;
        }
        static Subject AddSubject()
        {
            Console.WriteLine("Enter Subject Code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Subject Type: ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Credit Hours: ");
            int credithours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject Fee: ");
            int fee = int.Parse(Console.ReadLine());
            Subject add = new Subject(code, type, credithours, fee);
            return add; 
        }
        static string Menu()
        {
            string option = "";
            Console.WriteLine("----------------------");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Add Subject");
            Console.WriteLine("4. Generate Merit");
            Console.WriteLine("5. View Registered Students");
            Console.WriteLine("6. View Students of Specific Programs");
            Console.WriteLine("7. Register subjects for specific students");
            Console.WriteLine("8. Calculate Fee for all Registered Students");
            Console.WriteLine("9. Exit");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;
        }

        static void Header()
        {
            Console.WriteLine("*********************************************************");
            Console.WriteLine("**                    UAMS                             **");
            Console.WriteLine("*********************************************************");
        }
        static void ClearScreen()
        {
            Console.Clear();
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
