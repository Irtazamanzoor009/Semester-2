using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06_Lab_Manual.BL
{
    class DegreeProgramme
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subject> subjects;
        public int seats;
        internal static IEnumerable<DegreeProgramme> programmeList;

        public DegreeProgramme(string DegreeName, float degreeDuration, int seats)
        {
            this.degreeName = DegreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        public int CalculateCreditHour()
        {
            int Count = 0;
            for (int x = 0; x < subjects.Count; x++)
            {
                Count = Count + subjects[x].creditHours;
            }
            return Count;
        }
        public bool AddSubject(Subject s)
        {
            int creditHours = CalculateCreditHour();
            if (creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                Console.WriteLine("The Limit For the Credit Hours Completed ");
                return false;
            }
        }
        public bool IsSubjectExit(Subject Sub)
        {
            foreach (Subject s in subjects)
            {
                if (s.code == Sub.code)
                {
                    return true;
                }
            }
            return false;
        }
     
    }
}
