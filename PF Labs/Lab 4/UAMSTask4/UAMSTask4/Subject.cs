using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSTask4
{
    class Subject
    {
        public string Code;
        public string Type;
        public int Credithours;
        public int SubjectFee;

        public Subject(string code, string type, int credithours, int subjectfee)
        {
            Code = code;
            Type = type;
            Credithours = credithours;
            SubjectFee = subjectfee;
        }
        public Subject(Subject S)
        {
            Code = S.Code;
            Type = S.Type;
            Credithours = S.Credithours;
            SubjectFee = S.SubjectFee;

        }
        public void DisplaySubjects()
        {
            Console.WriteLine(Code + "\t\t" + Type + "\t\t" + Credithours + "\t\t" + SubjectFee);
        }
        public void CalculateMerit()
        {

        }

        /*public int GetcreditHours()
        {

        }
        public float CalculateFee()
        {

        }*/
    }
}
