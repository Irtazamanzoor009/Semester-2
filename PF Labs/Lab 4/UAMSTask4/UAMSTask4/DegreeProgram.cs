using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSTask4
{
    class DegreeProgram
    {
        public string Degreename;
        public double Degreeduration;
        public int Seats;
        public List<Subject> subjectlist = new List<Subject>();

        public DegreeProgram()
        {

        }
        
        public DegreeProgram(string degreename, double degreeduration, int seats)
        {
            Degreename = degreename;
            Degreeduration = degreeduration;
            Seats = seats;
        }
        public DegreeProgram(string preference)
        {
            Degreename = preference;
        }

        public void AddSubjects(Subject subject, List<Subject> subjectlist)
        {
           /* if(Gettotalcredithours() > 20)
            {
                Console.WriteLine("You can not add more subjects");

            }
            else*/
            {
                subjectlist.Add(subject);
                
            }
        }
        public bool IssubjectExist(Subject S, List<Subject> subjectlist)
        {
            foreach (Subject Sub in subjectlist)
            {
                if (Sub.Code == S.Code)
                {
                    return true;
                }
            }
            return false;
        }
        public int Gettotalcredithours()
        {
            int sum = 0;
            foreach(var credit in subjectlist)
            {
                sum = sum + credit.Credithours;
            }
            return sum;
        }
        public void RemoveSubject(Subject subject)
        {

        }
        public void DisplaySubject(List<Subject> subjectlist)
        {
            Console.WriteLine("Code\t\tType\t\tCredit hours\t\tFee");
            Console.WriteLine("________________________________________");
            foreach(var display in subjectlist)
            {
                display.DisplaySubjects();
            }
        }
        public void ViewDegreePrograms(List<DegreeProgram> degreelist)
        {
            Console.WriteLine("Degree Name\t\tDuration\t\tSeats");
            Console.WriteLine("-----------------------------------------");
            foreach(var display in degreelist)
            {

                Console.WriteLine(display.Degreename + "\t\t" + display.Degreeduration + "\t\t" + display.Seats);
            }
        }
        public void ViewDegreename(List<DegreeProgram> degreelist)
        {
            foreach(var name in degreelist)
            {
                Console.Write(name.Degreename + " ");
            }
            Console.WriteLine();
        }
    }
}
