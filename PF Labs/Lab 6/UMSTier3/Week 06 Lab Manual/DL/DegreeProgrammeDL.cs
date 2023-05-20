using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_06_Lab_Manual.BL;
using System.IO;

namespace Week_06_Lab_Manual.DL
{
    class DegreeProgrammeDL
    {
        public static List<DegreeProgramme> programmeList = new List<DegreeProgramme>();
        public static void addDegreeIntoList(DegreeProgramme d)
        {
            programmeList.Add(d);
        }
        public static DegreeProgramme isDegreeExit(string degreeName)
        {
            foreach (DegreeProgramme d in programmeList)
            {
                if (d.degreeName == degreeName)
                {
                    return d;

                }
            }
            return null;
        }
        public static void storeDegreeDataInFile(string path, DegreeProgramme d)
        {
            StreamWriter f = new StreamWriter(path, true);
            string subjectName = "";
            for (int x = 0; x < d.subjects.Count - 1; x++)
            {
                subjectName = subjectName + d.subjects[x].type + ";";
            }
            subjectName = subjectName + d.subjects[d.subjects.Count - 1].type;
            f.WriteLine(d.degreeName + "," + d.degreeDuration + "," + d.seats + "" + subjectName);
            f.Flush();
            f.Close();
        }
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path,true);
            string record;
            if (File.Exists(path))
            {
                while((record = f.ReadLine() )!= null)
                {
                    string[] splittedRecord = record.Split();
                    string degreeName = splittedRecord[0];
                    float degreeDuration = float.Parse(splittedRecord[1]);
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordForSubject = splittedRecord[3].Split(';');
                    DegreeProgramme d = new DegreeProgramme(degreeName, degreeDuration, seats);
                    for(int x=0;x<splittedRecordForSubject.Length;x++)
                    {
                        Subject s = SubjectDL.isSubjectExists(splittedRecordForSubject[x]);
                        if(s != null)
                        {
                            d.AddSubject(s);
                        }
                    }
                    addDegreeIntoList(d);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
   
}
