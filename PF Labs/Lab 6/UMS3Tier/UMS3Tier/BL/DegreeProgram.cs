using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS3Tier.BL
{
    class DegreeProgram
    {
        public string Degreename;
        public double Degreeduration;
        public int Seats;
        public List<Subject> subjects = new List<Subject>();

        public DegreeProgram(string degreename, double degreeduration, int seats, List<Subject> subjects)
        {
            Degreename = degreename;
            Degreeduration = degreeduration;
            Seats = seats;
            this.subjects = subjects;
        }
        public DegreeProgram(string preference)
        {
            Degreename = preference;
        }
    }
}
