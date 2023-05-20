using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_06_Lab_Manual.BL;

namespace Week_06_Lab_Manual.UI
{
    class SubjectUI
    {
        public static Subject takeInputForSubject()
        {
            string code;
            string type;
            int subjectFees;
            int creditHours;
            Console.WriteLine("Enter the Subject Code ");
            code = Console.ReadLine();
            Console.WriteLine("Enter the Subject Type ");
            type = Console.ReadLine();
            Console.WriteLine("Enter the Subject Fees ");
            subjectFees = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Subject Credit Hours ");
            creditHours = int.Parse(Console.ReadLine());
            Subject sub = new Subject(code, type, creditHours, subjectFees);
            return sub;
        }
        public static void viewSubjects(Student s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("Subject Code \t\t\t Subject Type ");
                foreach (Subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t\t" + sub.type);
                }
            }
        }
        public static void registerSubjects(Student s)
        {
            Console.WriteLine("How many Subjects You Want to registered ");
            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                Console.WriteLine("Enter the Subject Code ");
                string Code = Console.ReadLine();
                bool Flag = false;
                foreach (Subject sub in s.regDegree.subjects)
                {
                    if (Code == sub.code && !(s.regSubject.Contains(sub)))
                    {
                        if (s.regStudentSubject(sub))
                        {
                            Flag = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A Student Can not Have More Than 9 Credit Hours ");
                            Flag = true;
                            break;
                        }
                       
                    }
                    if (Flag == false )
                    {
                        Console.WriteLine("Enter Valid Course ");
                        x--;

                    }
                }
                if (Flag == false)
                {
                    Console.WriteLine("Enter Valid Course ");
                    x--;
                }
            }
        }

    }

}
