using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS3Tier.BL;

namespace UMS3Tier.DL
{
    class DegreeProgramDL
    {
        public static List<DegreeProgram> DegreeList = new List<DegreeProgram>();

        public static void ShowDegreePrograms()
        {
            foreach(var degree in DegreeList)
            {
                Console.WriteLine(degree.Degreename + " ");
            }
            Console.WriteLine();
        }

        public static void StoreInDegreeList(DegreeProgram d)
        {
            DegreeList.Add(d);
        }
    }
}
