using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS3Tier.BL
{
    class Subject
    {
        public string Code;
        public string Type;
        public int Credithours;
        public int SubjectFee;

        public Subject(Subject s)
        {
            this.Code = s.Code;
            this.Type = s.Type;
            this.Credithours = s.Credithours;
            this.SubjectFee = s.SubjectFee;
        }
        public Subject(string code, string type, int credithours, int subjectfee)
        {
            Code = code;
            Type = type;
            Credithours = credithours;
            SubjectFee = subjectfee;
        }
    }
}
