using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06_Lab_Manual.BL
{
    class Student
    {
        public string Name;
        public int age;
        public double inter_Marks;
        public double ecat_MArks;
        public double merit;
        public List<DegreeProgramme> preferences;
        public List<Subject> regSubject;
        public DegreeProgramme regDegree;

        public Student()
        {

        }
        public Student(string Name, int age, double Inter, double Ecat, List<DegreeProgramme> preference)
        {
            this.Name = Name;
            this.age = age;
            this.inter_Marks = Inter;
            this.ecat_MArks = Ecat;
            this.preferences = preference;
            regSubject = new List<Subject>();
        }
        public void Calculatemerit()
        {
            this.merit = (((inter_Marks / 1100) * 0.45F) + ((ecat_MArks / 400) * 0.55F)) * 100;
        }
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.IsSubjectExit(s) && stCH + s.creditHours <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
            {
                Console.WriteLine("You are Unable to register a Subject");
                return false;
            }
        }
        public int getCreditHours()
        {
            int Count = 0;
            foreach (Subject sub in regSubject)
            {
                Count = Count + sub.creditHours;
            }
            return Count;
        }
        public float calculateFee()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (Subject sub in regSubject)
                {
                    fee = fee + sub.subjectFees;
                }
            }
            return fee;
        }

    }
}
