using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_06_Lab_Manual.BL
{
    class Subject
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;
        public Subject(string code, string type, int creditHours, int subjectFees)
        {
            this.code = code;
            this.type = type;
            this.creditHours = creditHours;
            this.subjectFees = subjectFees;
        }
    }
}
