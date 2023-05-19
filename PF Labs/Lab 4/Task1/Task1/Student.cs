using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Student
    {
        public string Name;
        public int Rollno;
        public float Cgpa;
        public int Matricmarks;
        public int Fscmarks;
        public int Ecatmarks;
        public string Hometown;
        public bool IsHostelite;
        public bool IsTakingScholarship;

        public Student(string name, int rollno, float cgpa, int matricmarks, int fscmarks, int ecatmarks, string hometown, bool ishostelite, bool takingscholarship)
        {
            this.Name = name;
            this.Rollno = rollno;
            this.Cgpa = cgpa;
            this.Matricmarks = matricmarks;
            this.Fscmarks = fscmarks;
            this.Ecatmarks = ecatmarks;
            this.Hometown = hometown;
            this.IsHostelite = ishostelite;
            IsTakingScholarship = takingscholarship;
        }
        public Student()
        {

        }
        public void ViewInformation(List<Student> student)
        {
            Console.WriteLine("Name\tRollNo\tCGPA\tMatric Marks\t Fsc Marks\t Ecat Marks\t Adress");
            foreach(var info in student)
            {
                Console.WriteLine(info.Name + '\t' + info.Rollno + '\t' + info.Cgpa + '\t' + info.Matricmarks + '\t' + info.Fscmarks + '\t' + info.Ecatmarks + '\t' + info.Hometown);
            }
        }
        public float CalculateMerit()
        {
            float merit = ((Fscmarks * 60.0F / 1100F) + (Ecatmarks * 40F / 400F));
            return merit;
            
            
        }
        public bool AvailScholarship(float merit)
        {
            if(merit >= 80 && IsHostelite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
