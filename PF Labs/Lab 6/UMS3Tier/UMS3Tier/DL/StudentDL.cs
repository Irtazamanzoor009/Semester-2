using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS3Tier.BL;

namespace UMS3Tier.DL
{
    class StudentDL
    {
        public static List<Student> studentlist = new List<Student>();

        public static void AddinList(Student s)
        {
            studentlist.Add(s);
        }
        public static void SortStudentByMerit()
        {
            
                for (int i = 0; i < studentlist.Count; i++)
                {
                    for (int j = 0; j < studentlist.Count; j++)
                    {
                        Student temp = new Student();
                        if (studentlist[i].Merit < studentlist[j].Merit)
                        {
                            temp = studentlist[i];
                            studentlist[i] = studentlist[j];
                            studentlist[j] = temp;
                        }
                    }
                }            
        }
        public static void CalculateMerit()
        {
            foreach(var merit in studentlist)
            {
                double findmerit = (merit.FscMarks * 60F / 1100F) + (merit.EcatMarks * 40F / 400F);
                merit.Merit = findmerit;
            }
        }
        
        public static void GiveAdmissions()
        {
            foreach (var i in DegreeProgramDL.DegreeList)
            {
                int seats = i.Seats;
                foreach (var j in studentlist)
                {
                    for (int a = 0; a < j.Preferences.Count; a++)
                    {
                        if (i.Degreename == j.Preferences[a].Degreename && seats != 0)
                        {
                            Console.WriteLine(j.Name + " got admission in " + i.Degreename);
                            seats--;
                            break;
                        }
                    }
                }
            }
        }

        public static Student StudentPresent(string name)
        {
            foreach(var s in studentlist)
            {
                if(name == s.Name)
                {
                    return s;
                }
            }
            return null;
        }

    }
}
