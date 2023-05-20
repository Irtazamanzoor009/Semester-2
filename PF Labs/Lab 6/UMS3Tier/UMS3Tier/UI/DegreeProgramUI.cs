using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS3Tier.BL;
using UMS3Tier.DL;

namespace UMS3Tier.UI
{
    class DegreeProgramUI
    {
        public static DegreeProgram TakeInputForDegree()
        {
                //List<Subject> subjects = new List<Subject>();
                Student add = new Student();
            Console.Write("Enter Degree Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            double duration = double.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree: ");
            int seats = int.Parse(Console.ReadLine());
            Console.Write("Enter how many subjects to Enter: ");
            int numberofsubjects = int.Parse(Console.ReadLine());
            for(int i=0; i<numberofsubjects; i++)
            {
                Subject s = SubjectUI.TakeInputForSubject();
                //add.AddinsubjectList(s);
                SubjectDL.AddinSubjectList(s);
            }
            DegreeProgram d = new DegreeProgram(name, duration, seats, SubjectDL.subjectlist);
            return d;
        }

    }
}
