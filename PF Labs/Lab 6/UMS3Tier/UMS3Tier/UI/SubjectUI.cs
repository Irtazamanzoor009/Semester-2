using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS3Tier.BL;
using UMS3Tier.DL;

namespace UMS3Tier.UI
{
    class SubjectUI
    {
        public static Subject TakeInputForSubject()
        {
            Console.Write("Enter subject code: ");
            string code = Console.ReadLine();
            Console.Write("Enter Subject Name: ");
            string type = Console.ReadLine();
            Console.Write("Enter Subject Credit Hours: ");
            int hours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fees: ");
            int fee = int.Parse(Console.ReadLine());
            Subject s = new Subject(code, type, hours, fee);
            return s;
        }
    }

    
}
