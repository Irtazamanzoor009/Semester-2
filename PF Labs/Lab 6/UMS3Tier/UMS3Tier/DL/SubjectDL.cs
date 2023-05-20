using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS3Tier.BL;

namespace UMS3Tier.DL
{
    class SubjectDL
    {
        public static List<Subject> subjectlist = new List<Subject>();

        public static void AddinSubjectList(Subject s)
        {
            subjectlist.Add(s);
        }

        /*public static void ViewSubjects(Student s)
        {
            Console.WriteLine("Sub Code\t\tSub Type");
            if(s.subjects != null)
            {
                foreach (var sub in subjectlist)
                {
                    Console.WriteLine(sub.Code + ' ' + sub.Type);
                }
            }
        }*/
    }
}
