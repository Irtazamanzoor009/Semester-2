using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_06_Lab_Manual.BL;
using System.IO;

namespace Week_06_Lab_Manual.DL
{
    class StudentDL
    {
        public static List<Student> studentsList = new List<Student>();
        public static void addStudentIntoList(Student s)
        {
            studentsList.Add(s);
        }

        public static Student studentPresent(string name)
        {
            foreach (Student s in studentsList)
            {
                if (name == s.Name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }


        public  static List<Student> sortStudentsByMerit()
        {
            List<Student> storedStudentsList = new List<Student>();
            foreach (Student s in studentsList)
            {
                s.Calculatemerit();
            }
            storedStudentsList = studentsList.OrderByDescending(o => o.merit).ToList();
            return storedStudentsList;
        }

        public  static void giveAdmission(List<Student> storedStudentsList)
        {
            foreach (Student s in studentsList)
            {
                foreach (DegreeProgramme d in s.preferences)
                {
                    if (d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        public static void storeIntoFile(string path, Student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string degreeNames = "";
            for (int x = 0; x < s.preferences.Count; x++)
            {
                degreeNames = degreeNames + s.preferences[x].degreeName + ";";
            }
            degreeNames = degreeNames + s.preferences[s.preferences.Count - 1].degreeName;
            f.WriteLine(s.Name + "," + s.age + "," + s.inter_Marks + "," + s.ecat_MArks + "," + degreeNames);
            f.Flush();
            f.Close();

        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split();
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    double inter_Marks = double.Parse(splittedRecord[2]);
                    double Ecat = double.Parse(splittedRecord[3]);
                    string[] splitedRecordForPreference = splittedRecord[4].Split(';');
                    List<DegreeProgramme> preference = new List<DegreeProgramme>();

                    for(int x=0;x<splitedRecordForPreference.Length;x++)
                    {
                        DegreeProgramme d = DegreeProgrammeDL.isDegreeExit(splitedRecordForPreference[x]);
                        if (d != null)
                        {
                            if(!(preference.Contains(d)))
                            {
                                preference.Add(d);
                            }
                        }
                    }
                    Student s = new Student(name, age, inter_Marks, Ecat, preference);
                    studentsList.Add(s);
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
