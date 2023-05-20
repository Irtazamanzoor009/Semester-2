using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_06_Lab_Manual.BL;
using Week_06_Lab_Manual.DL;

namespace Week_06_Lab_Manual.UI
{
    class DegreeProgramUI
    {
        public static DegreeProgramme takeInputForDegree()

        {
            Console.WriteLine("Enter Degree Name ");
            string DegreeName = Console.ReadLine();
            Console.WriteLine("Enter Degree Duration ");
            float DegreeDuration = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number of the Seats in the Degree ");
            int Seats = int.Parse(Console.ReadLine());
            DegreeProgramme degProg = new DegreeProgramme(DegreeName, DegreeDuration, Seats);
            Console.WriteLine("Enter the Number Of the Subjects You Want To Enter");
            int Count = int.Parse(Console.ReadLine());


            for (int x = 0; x < Count; x++)
            {
                Subject s = SubjectUI.takeInputForSubject();
                if (degProg.AddSubject(s))
                {
                    //It is done here because we do not have the separate option to add only the subjects
                    if (!(SubjectDL.subjectList.Contains(s)))
                    {
                        SubjectDL.addSubjectIntoList(s);
                        SubjectDL.storeDataInFile("subject.txt", s);

                    }

                    Console.WriteLine("Subject Added Successfully");

                }
                else
                {
                    Console.WriteLine("Subject Not Added");
                    Console.WriteLine("20 Hours Limit Exceded");


                }

            }
            return degProg;
         
        }
        public  static void viewDegreeProgramme()
        {
            foreach (DegreeProgramme dp in DegreeProgrammeDL.programmeList)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
    }
}
