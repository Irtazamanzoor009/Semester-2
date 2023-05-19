using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cred[] user = new Cred[10];
            int count = 0;
            string option = "";
            string name, password;
            string path = "E:\\Semester 2-\\OOP Tasks\\Challenge2\\user.txt";
            ReadData(path, user, ref count);
            while (option != "4")
            {
                option = Menu();
                if(option == "1") // sign In
                {
                    Console.Clear();
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    password = Console.ReadLine();
                    bool isValid = SignIn(user, count, name, password);
                    if (count == 0)
                    {
                        Console.WriteLine("No account create yet");
                        Getch();
                    }
                    else
                    {
                        if (isValid == true)
                        {
                            Console.WriteLine("User Signed In Successfully");
                            Getch();
                        }
                        else
                        {
                            Console.WriteLine("Error! Invalid Entity");
                            Getch();
                        }
                    }
                }
                else if(option == "2") // sign Up
                {
                    Console.Clear();
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    password = Console.ReadLine();
                    bool isValid = CheckUser(user, count, name);
                    if (isValid == true)
                    {
                        user[count] = SignUp(name, password);
                        count++;
                        Console.WriteLine("User Signed Up Successfully");
                        StoreData(path, name, password);
                        Getch();
                    }
                    else
                    {
                        Console.WriteLine("Error! User Already Exist");
                        Getch();
                    }
                }
                else if(option == "3") // view users
                {
                    if(count == 0)
                    {
                        Console.WriteLine("No Account Found");
                    }
                    else
                    {
                        ViewUsers(user, count);
                    }
                    Getch();
                }
            }
        }
        static string Menu()
        {
            Console.Clear();
            string choice="";
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. View Users");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Select Your Option...");
            choice = Console.ReadLine();
            return choice;
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static Cred SignUp(string name, string password)
        {
            Cred user = new Cred();
            user.username = name;
            user.password = password;
            return user;
        }
        static bool CheckUser(Cred[] user, int count, string name)
        {
            bool flag = true;
            for(int i=0; i<count; i++)
            {
                if(name == user[i].username)
                {
                    flag = false;
                }
            }
            return flag;
        }
        static bool SignIn(Cred[] user, int count, string name, string password)
        {
            bool flag = false;
            for(int i=0; i<count; i++)
            {
                if(name == user[i].username && password== user[i].password)
                {
                    flag = true;
                }
            }
            return flag;
        }
        static void ViewUsers(Cred[] user, int count)
        {
            Console.Clear();
            Console.WriteLine("Name\t\tPassword");
            for(int i=0; i<count; i++)
            {
                Console.WriteLine("{0}\t\t{1}", user[i].username, user[i].password);
            }
        }
        static void StoreData(string path, string name, string password)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + ',' + password);
            file.Close();
        }
        static string ParseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }
        static void ReadData(string path, Cred[] user,ref int count)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Cred user1 = new Cred();    
                    user1.username = ParseData(record, 1);
                    user1.password = ParseData(record, 2);
                    user[count] = user1;
                    count++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
    }
}
