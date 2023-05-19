using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            int choice=0;
            int size = 10;
            string[] names = new string[size];
            string[] passwords = new string[size];
            int userCount = 0;
            string path = "E:\\Semester 2\\OOP Tasks\\SignInMenu\\data.txt";
            Console.Clear();
                ReadData(path, names, passwords, ref userCount);
            while(choice != 4)
            {
                Console.Clear();
                choice = Menu();
                if(choice == 1)// Sign In menu
                {
                    Console.Clear();
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    bool isValid = SignIn(name, password, passwords, names, ref userCount);
                    if(isValid ) 
                    {
                        
                        Console.WriteLine("Welcome");
                        Clear();
                    }
                    else
                    {
                        
                        Console.WriteLine("Wrong Credentials");
                        Clear();
                        
                    }

                }
                if(choice == 2) // signup menu
                {
                    Console.Clear();
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    bool isValid = SignUp(name, password, names, passwords, ref userCount);
                    if(isValid ) 
                    {
                        
                        Console.WriteLine("Signed Up Succesfully");
                        StoreData(path, name, password);
                        Clear();
                    }
                    else
                    {
                        
                        Console.WriteLine("User already exist");
                        Clear();
                    }
                }
                if(choice == 3) //view users
                {
                    Console.Clear();
                    ViewUsers(names, passwords, ref userCount);
                    Clear();
                }

            }
        }
        static void ViewUsers(string[] names, string[] passwords, ref int userCount)
        {
            Console.WriteLine("Users\t\tPasswords");
            for(int i=0; i< userCount; i++)
            {
                Console.Write(names[i]);
                Console.WriteLine("\t\t"+passwords[i]);
            }               
            
        }
        static bool Check(string name, string password, string[] names, string[] passwords, ref int userCount)
        {
            bool flag = true;
            for (int i = 0; i < userCount; i++)
            {
                if (name == names[i] && password == passwords[i])
                {
                    flag = false;
                }
            }
            return flag;
        }
        static bool SignUp(string name, string password, string[] names, string[] passwords, ref int userCount)
        {
            bool flag = false;            
            bool isValid = Check(name,password, names, passwords, ref userCount);
            if (isValid )
            {
                names[userCount] = name;
                passwords[userCount] = password;
                userCount++;
                flag = true;
            }
            return flag;            
        }
        static void StoreData(string path, string name, string password)
        {
            StreamWriter file = new StreamWriter(path,true);
            file.WriteLine(name + ',' + password);
            file.Flush();
            file.Close();
        }
        static void Clear()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static int Menu()
        {
            int option;
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. View Users");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Select yout option...");
            option = int.Parse(Console.ReadLine());
            return option;

        }
        static string ParseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for(int i=0; i<record.Length; i++) 
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if(comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void ReadData(string path, string[] names, string[] passwords, ref int userCount)
        {
            int x = 0;
            if(File.Exists(path)) 
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record = fileVariable.ReadLine()) != null)
                {
                    names[userCount]=ParseData(record, 1);
                    passwords[userCount] = ParseData(record, 2);
                    userCount++;
                    Console.WriteLine(ParseData(record,1));
                    //x++;
                    /*if(x>=5)
                    {
                        break;
                    }*/


                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
        static bool SignIn(string name, string password, string[] passwords, string[] names, ref int userCount)
        {
            bool flag = false;
            for(int i=0; i<userCount; i++)
            {
                if(name == names[i] && password == passwords[i])
                {
                    flag = true;
                }
            }
            return flag;
        }

    }
    
}