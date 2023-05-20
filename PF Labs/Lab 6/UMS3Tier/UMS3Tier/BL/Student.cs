using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS3Tier.DL;

namespace UMS3Tier.BL
{
    class Student
    {
        public string Name;
        public int Age;
        public double FscMarks;
        public double EcatMarks;
        public double Merit;
        public List<DegreeProgram> Preferences = new List<DegreeProgram>();
        public List<Subject> subjects = new List<Subject>();

        public Student()
        {

        }
        public Student(string Name, int Age, double FscMarks, double EcatMarks, List<DegreeProgram> Preferences)
        {
            this.Name = Name;
            this.Age = Age;
            this.FscMarks = FscMarks;
            this.EcatMarks = EcatMarks;
            this.Preferences = Preferences;
        }

       /* public void AddinsubjectList(Subject s)
        {
            subjects.Add(s);
        }*/
        public int CalculateFee()
        {
            int fee = 0;           
            foreach(var s in SubjectDL.subjectlist)
            {
                fee = fee + s.SubjectFee;
            }            
            return fee;

        }

        public static int ViewIndex(string name)
        {
            int index = -1;
            for (int i = 0; i < StudentDL.studentlist.Count; i++)
            {
                if (name == StudentDL.studentlist[i].Name)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
