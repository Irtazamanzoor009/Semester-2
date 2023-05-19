using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSTask4
{
    class Student
    {
        public string Name;
        public int Age;
        public double Fscmarks;
        public double Ecatmarks;
        public double Merit;
        public List<DegreeProgram> degreelist = new List<DegreeProgram>();
        public List<Subject> regSubject = new List<Subject>();
        public DegreeProgram regDegree = new DegreeProgram();

        public Student()
        {

        }
        public Student(string name, int age, double fscmarks, double ecatmarks, List<DegreeProgram> preferences)
        {
            Name = name;
            Age = age;
            Fscmarks = fscmarks;
            Ecatmarks = ecatmarks;
            degreelist = preferences;
        }
        //public Student(List<DegreeProgram> i)
        //{
        //    regSubject = i;
        //}
        public Student(List<Subject> subjects)
        {
            this.regSubject = subjects;
        }
        public bool regstudentssubjects(Subject S, List<Subject> subjectlist)
        {
            int Ch = getcredithours(subjectlist);
            if(regDegree != null && regDegree.IssubjectExist(S, subjectlist) && Ch + S.Credithours <= 9)
            {
                regSubject.Add(S);
                return true;
            }
            return false;
        }
        
        public int getcredithours(List<Subject> subjectlist)
        {
            int count = 0;
            foreach(Subject S in subjectlist)
            {
                count = count + S.Credithours;
            }
            return count;
        }
        public float CalculateFee(List<Subject> subjectlist)
        {
            float fee = 0;
            if(regDegree != null)
            {
                foreach(Subject S in subjectlist)
                {
                    fee = fee + S.SubjectFee;
                }
            }
            return fee;
        }
        public int ViewIndex(List<Student> student, string name)
        {
            int index = -1;
            for(int i=0; i<student.Count; i++)
            {
                if(name == student[i].Name)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        
        public int CalculateFees(List<Student> Stud)
        {
            int fees = 0;
            foreach (var S in Stud)
            {
                foreach(var s in S.regSubject)
                {
                    fees = fees + s.SubjectFee;
                }
            }
            return fees;
        }

    }
}
