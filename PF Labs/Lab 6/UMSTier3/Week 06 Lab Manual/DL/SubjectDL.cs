using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_06_Lab_Manual.BL;
using System.IO;

namespace Week_06_Lab_Manual.DL
{
    class SubjectDL
    {
        public static List<Subject> subjectList = new List<Subject>();
        public static void addSubjectIntoList(Subject s)
        {
            subjectList.Add(s);
        }
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path,true);
            string record;
            if(File.Exists(path))
            {
                while((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int creditHours = int.Parse(splittedRecord[2]);
                    int subjectFees = int.Parse(splittedRecord[3]);
                    Subject s = new Subject(code, type, creditHours, subjectFees);
                    addSubjectIntoList(s);
           
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeDataInFile(string path, Subject s)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(s.code + "," + s.type + "," + s.creditHours + "," + s.subjectFees);
            f.Flush();
            f.Close();

 
        }
        public static Subject isSubjectExists(string type)
        {
            foreach (Subject s in subjectList)
            {
                if(s.type == type)
                {
                    return s;

                }
            }
            return null;
           
        }
    }
}
