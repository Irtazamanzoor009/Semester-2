using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // User arrays
            int userSize = 10;
            int userCount = 0;
            string[] usernames = new string[userSize];
            string[] userpasswords = new string[userSize];
            string[] userRoles = new string[userSize];
            string[] accountType = new string[userSize];
            int[] InitialAmount = new int[userSize];
            string[] CNIC = new string[userSize];

            // Admin Arrays
            int adminSize = 10;
            int adminCount = 0;
            string[] adminNames = new string[adminSize];
            string[] adminpasswords = new string[adminSize];
            string[] adminRoles = new string[adminSize];

            // Paths
            string StoreUsersDataPath = "E:\\Semester 2-\\PD\\CRUDBuisnessProject\\users.txt";
            string StoreAdminsDataPath = "E:\\Semester 2-\\PD\\CRUDBuisnessProject\\admin.txt";
            ReadUserData(StoreUsersDataPath, usernames, userpasswords, userRoles, CNIC, InitialAmount, accountType, ref userCount);
            ReadAdminData(StoreAdminsDataPath, adminNames, adminpasswords, adminRoles, ref adminCount);



            ClearScreen();
            Header();
            string choice = "0";
            while (choice != "3")
            {
                ClearScreen();
                Header();
                choice = MainMenu();

                if (choice == "1") // sign in menu
                {
                    ClearScreen();
                    Header();
                    string name;
                    string password;
                    string role;
                    string cnic;
                    int initialamount;
                    string accounttype;
                    Console.WriteLine("----------------------Sign In Menu----------------------");
                    Console.WriteLine(" ");
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    password = Console.ReadLine();
                    string checkRole = ReturnRole(ref userCount, ref adminCount, name, usernames, password, userpasswords, userRoles, adminNames, adminpasswords, adminRoles);
                    if (adminCount == 0 && userCount == 0)
                    {
                        Console.WriteLine("No Account Created Yet");
                        Getch();
                    }
                    else
                    {
                        if (checkRole == "User" || checkRole == "user")
                        {
                            string userChoice = "";
                            while (userChoice != "5")
                            {
                                ClearScreen();
                                Header();
                                userChoice = UserInterface();
                                if (userChoice == "1") // view info
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------View Info----------------------");
                                    Console.WriteLine(" ");
                                    ViewInfo(ref userCount, name, usernames, CNIC, userpasswords);
                                    Getch();
                                }
                                if (userChoice == "2") // deposit amount
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------Deposit Amount----------------------");
                                    Console.WriteLine(" ");
                                    int depositamount;
                                    Console.WriteLine("Enter the amount you want to deposit: ");
                                    depositamount = int.Parse(Console.ReadLine());
                                    if (depositamount > 0)
                                    {
                                        AmountDeposited(ref userCount, InitialAmount, ref depositamount, name, usernames);
                                        //StoreUsersData(StoreUsersDataPath, name, password, role, cnic, initialamount, accounttype);
                                        StoreUsersData(StoreUsersDataPath, usernames, userpasswords, userRoles, CNIC, InitialAmount, accountType, ref userCount);
                                        Console.WriteLine("Your amount has been deposited");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Invalid Amount");
                                    }
                                    Getch();
                                }
                                if (userChoice == "3") // withdraw amount
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------Withdraw Amount----------------------");
                                    Console.WriteLine(" ");
                                    int withdraw;
                                    Console.WriteLine("Enter amount you want to withdraw: ");
                                    withdraw = int.Parse(Console.ReadLine());
                                    bool isValid = CheckWithdraw(ref userCount, name, InitialAmount, usernames, ref withdraw);
                                    if (isValid)
                                    {
                                        WithdrawAmount(ref userCount, InitialAmount, ref withdraw, name, usernames);
                                        //StoreUsersData(StoreUsersDataPath, name, password, role, cnic, initialamount, accounttype);
                                        StoreUsersData(StoreUsersDataPath, usernames, userpasswords, userRoles, CNIC, InitialAmount, accountType, ref userCount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Invalid Amount");
                                    }
                                    Getch();
                                }
                                if (userChoice == "4") // check balance inquiry
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------Check Balance Inquiry----------------------");
                                    Console.WriteLine(" ");
                                    CheckBalanceInquiry(ref userCount, name, usernames, InitialAmount);
                                    //StoreUsersData(StoreUsersDataPath, name, password, role, cnic, initialamount, accounttype);
                                    StoreUsersData(StoreUsersDataPath, usernames, userpasswords, userRoles, CNIC, InitialAmount, accountType, ref userCount);
                                    Getch();
                                }
                            }
                        }
                        else if (checkRole == "Admin" || checkRole == "admin")
                        {
                            string adminChoice = "";
                            while (adminChoice != "4")
                            {
                                ClearScreen();
                                Header();
                                adminChoice = AdminInterface();
                                if (adminChoice == "1") // view details of users
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------View Details----------------------");
                                    Console.WriteLine(" ");
                                    ViewDetails(ref userCount, usernames, accountType, InitialAmount, CNIC);
                                    Getch();
                                }
                                if (adminChoice == "2") // delete Account
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------Delete Account----------------------");
                                    Console.WriteLine(" ");
                                    string deleteaccountName;
                                    Console.WriteLine("Enter name of account you want to delete: ");
                                    deleteaccountName = Console.ReadLine();
                                    DeleteAccount(ref userCount, deleteaccountName, usernames, accountType, InitialAmount);
                                    StoreUsersData(StoreUsersDataPath, usernames, userpasswords, userRoles, CNIC, InitialAmount, accountType, ref userCount);

                                    Getch();
                                }
                                if (adminChoice == "3") // Modify Account
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------Modify Account----------------------");
                                    Console.WriteLine(" ");
                                    string accountname;
                                    Console.WriteLine("Enter Account Name to modify: ");
                                    accountname = Console.ReadLine();
                                    ModifyAccount(ref userCount, accountname, usernames, accountType);
                                    StoreUsersData(StoreUsersDataPath, usernames, userpasswords, userRoles, CNIC, InitialAmount, accountType, ref userCount);
                                    Getch();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error! Wrong Credentials");
                            Getch();
                        }
                    }
                }
                if (choice == "2") // sign up menu
                {
                    ClearScreen();
                    Header();
                    string name;
                    string password;
                    string role;
                    string cnic;
                    int initialamount;
                    string accounttype;
                    Console.WriteLine("----------------------Sign Up Menu----------------------");
                    Console.WriteLine(" ");
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    password = Console.ReadLine();
                    Console.Write("Enter Role: ");
                    role = Console.ReadLine();
                    bool result = IsValidUsername(name, usernames, ref userCount, ref adminCount, adminNames);
                    if (result == true)
                    {

                        if (role == "User" || role == "user") // user requirements
                        {
                            Console.Write("Enter CNIC: ");
                            cnic = Console.ReadLine();
                            bool CheckCnic = checkCNIC(cnic);
                            if (CheckCnic)
                            {
                                bool isValidCnic = CheckValidCNIC(cnic, ref userCount, CNIC);
                                if (isValidCnic)
                                {
                                    Console.Write("Enter your initial Amount: ");
                                    initialamount = int.Parse(Console.ReadLine());
                                    if (initialamount > 0)
                                    {
                                        Console.Write("Enter your Account Type: ");
                                        accounttype = Console.ReadLine();
                                        if (accounttype == "c" || accounttype == "C" || accounttype == "s" || accounttype == "S")
                                        {
                                            UserSignUp(usernames, userpasswords, userRoles, CNIC, accountType, InitialAmount, ref userCount, name, password, cnic, accounttype, initialamount, role);
                                            Console.WriteLine("User Signed Up Succesfully");
                                            StoreUsersData(StoreUsersDataPath, usernames, userpasswords, userRoles, CNIC, InitialAmount, accountType, ref userCount);
                                            Getch();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error! Invalid Account type");
                                            Getch();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Invalid Amount");
                                        Getch();
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("CNIC already exist");
                                    Getch();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid CNIC");
                                Getch();
                            }
                        }



                        else if (role == "Admin" || role == "admin") // admin requirements
                        {
                            AdminSignUp(adminNames, adminpasswords, adminRoles, ref adminCount, name, password, role);
                            Console.WriteLine("Admin Signed Up Successfully");
                            StoreAdminsData(StoreAdminsDataPath, name, password, role);
                            Getch();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Role");
                            Getch();
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR! User Already Exist...");
                        Getch();
                    }

                }

            }

        }
        static bool IsValidUsername(string name, string[] usernames, ref int userCount, ref int adminCount, string[] adminnames)
        {
            bool flag = true;
            for (int i = 0; i < userCount; i++)
            {
                if (name == usernames[i])
                {
                    flag = false;
                }
            }
            for (int i = 0; i < adminCount; i++)
            {
                if (name == adminnames[i])
                {
                    flag = false;
                }
            }
            return flag;
        }
        // File Handling
        static void StoreUsersData(string path, string[] name, string[] password, string[] role, string[] cnic, int[] initialAmount, string[] accountType, ref int userCount)
        {
            StreamWriter file = new StreamWriter(path);
            for (int i=0; i<userCount; i++)
            {

                file.WriteLine(name[i] + ',' + password[i] + ',' + role[i] + ',' + cnic[i] + ',' + initialAmount[i] + ',' + accountType[i]);
            }
            file.Close();
        }
        static void StoreAdminsData(string path, string name, string password, string role)
        {
            StreamWriter file = new StreamWriter(path);
            file.WriteLine(name + ',' + password + ',' + role);
            file.Flush();
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
        static void ReadUserData(string path, string[] usernames, string[] userpasswords, string[] userroles, string[] CNIC, int[] initialAmount, string[] accountType, ref int userCount)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    usernames[userCount] = ParseData(record, 1);
                    userpasswords[userCount] = ParseData(record, 2);
                    userroles[userCount] = ParseData(record, 3);
                    CNIC[userCount] = ParseData(record, 4);
                    initialAmount[userCount] = int.Parse(ParseData(record, 5));
                    accountType[userCount] = ParseData(record, 6);
                    userCount++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
        static void ReadAdminData(string path, string[] adminnames, string[] adminpasswords, string[] adminroles, ref int adminCount)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    adminnames[adminCount] = ParseData(record, 1);
                    adminpasswords[adminCount] = ParseData(record, 2);
                    adminroles[adminCount] = ParseData(record, 3);
                    adminCount++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
        static string MainMenu()
        {
            string option;
            Console.WriteLine("----------------------Main Menu----------------------");
            Console.WriteLine(" ");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Exit");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;
        }
        // User Functionalities
        static string UserInterface()
        {
            string option;
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. View Info");
            Console.WriteLine("2. Deposit Amount");
            Console.WriteLine("3. Withdraw Amount");
            Console.WriteLine("4. Check Balance Inquiry");
            Console.WriteLine("5. Go back");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;
        }
        static void ViewInfo(ref int userCount, string name, string[] usernames, string[] CNIC, string[] userPasswords)
        {
            int index = ViewIndex(ref userCount, name, usernames);
            Console.WriteLine("Name: " + usernames[index]);
            Console.WriteLine("CNIC: " + CNIC[index]);
            Console.WriteLine("Password: " + userPasswords[index]);

        }
        static int ViewIndex(ref int userCount, string name, string[] usernames)
        {
            int index = -1;
            for (int i = 0; i < userCount; i++)
            {
                if (name == usernames[i])
                {
                    index = i;
                }
            }
            return index;
        }
        static void AmountDeposited(ref int userCount, int[] InitialAmount, ref int deposit_amount, string name, string[] usernames)
        {
            int index = -1;
            index = ViewIndex(ref userCount, name, usernames);
            InitialAmount[index] += deposit_amount;
        }
        static void WithdrawAmount(ref int userCount, int[] InitialAmount, ref int withdraw_amount, string name, string[] usernames)
        {
            int index = -1;
            index = ViewIndex(ref userCount, name, usernames);
            InitialAmount[index] -= withdraw_amount;
            Console.WriteLine("Your amount " + withdraw_amount + " has been withdrawn");
        }
        static bool CheckWithdraw(ref int userCount, string name, int[] InitialAmount, string[] usernames, ref int withdraw_amount)
        {
            bool flag = false;
            int index = -1;
            index = ViewIndex(ref userCount, name, usernames);
            if (withdraw_amount <= InitialAmount[index])
            {
                flag = true;
            }
            return flag;
        }
        static void CheckBalanceInquiry(ref int userCount, string name, string[] usernames, int[] InitialAmount)
        {
            int index = -1;
            index = ViewIndex(ref userCount, name, usernames);
            Console.WriteLine("Your balance is: " + InitialAmount[index]);
        }

        // Admin Functionalities
        static string AdminInterface()
        {
            string option;
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. View Details");
            Console.WriteLine("2. Delete Account");
            Console.WriteLine("3. Modify Account");
            Console.WriteLine("4. Go back");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Select your option...");
            option = Console.ReadLine();
            return option;

        }
        static void ViewDetails(ref int userCount, string[] usernames, string[] accountType, int[] InitialAmount, string[] CNIC)
        {
            Console.WriteLine("Name\t\tAccountType\t\tAmount\t\tCNIC\t\t");
            Console.WriteLine("_____________________________________________________________________________");
            if (userCount == 0)
            {
                Console.WriteLine("No account present");
            }
            else
            {
                for (int i = 0; i < userCount; i++)
                {
                    Console.WriteLine(usernames[i] + "\t\t" + accountType[i] + "\t\t" + InitialAmount[i] + "\t\t" + CNIC[i]);
                }
            }
        }
        static void DeleteAccount(ref int userCount, string deleteaccountName, string[] usernames, string[] accountType, int[] InitialAmount)
        {
            int count = 0;
            for (int i = 0; i < userCount; i++)
            {
                if (deleteaccountName == usernames[i])
                {
                    for (int j = i; j < userCount; j++)
                    {
                        usernames[j] = usernames[j + 1];
                        accountType[j] = accountType[j + 1];
                        InitialAmount[j] = InitialAmount[j + 1];
                    }
                    userCount--;
                }
                else
                {
                    count = 1;
                    break;
                }
            }
            if (count == 1)
            {
                Console.WriteLine("Account not present");
            }
            else
            {
                Console.WriteLine("Account has been deleted successfully");
            }
        }
        static void ModifyAccount(ref int userCount, string modification, string[] usernames, string[] accountType)
        {
            int count = 0;
            string accounttype = "";
            for (int i = 0; i < userCount; i++)
            {
                if (modification == usernames[i])
                {
                    Console.WriteLine("Enter new Account Type(c/s): ");
                    accounttype = Console.ReadLine();
                    if (accounttype == "c" || accounttype == "s")
                    {
                        count = 1;
                        accountType[i] = accounttype;
                        break;
                    }
                }
                else
                {
                    count = 2;
                    break;
                }
            }
            if (count == 1)
            {
                Console.WriteLine("Account has been modified"); ;
                Getch();
            }
            else if (count != 1)
            {
                Console.WriteLine("Error! Invalid Account Type"); ;
                Getch();
            }
            else if (count == 2)
            {
                Console.WriteLine("Account Not Found");
                Getch();
            }
        }
        static string ReturnRole(ref int userCount, ref int adminCount, string name, string[] usernames, string password, string[] userPasswords, string[] userRoles, string[] adminnames, string[] adminPasswords, string[] adminRoles)
        {
            string role = "";
            for (int i = 0; i < userCount; i++)
            {
                if (name == usernames[i] && password == userPasswords[i])
                {

                    role = userRoles[i];
                    break;
                }
            }
            for (int i = 0; i < adminCount; i++)
            {
                if (name == adminnames[i] && password == adminPasswords[i])
                {

                    role = adminRoles[i];
                    break;
                }
            }
            return role;

        }
        static void UserSignUp(string[] usernames, string[] userpasswords, string[] userRoles, string[] CNIC, string[] accounttype, int[] InitialAmount, ref int userCount, string name, string password, string cnic, string accountType, int initialamount, string role)
        {
            usernames[userCount] = name;
            userpasswords[userCount] = password;
            userRoles[userCount] = role;
            accounttype[userCount] = accountType;
            InitialAmount[userCount] = initialamount;
            CNIC[userCount] = cnic;
            userCount++;
        }
        static void AdminSignUp(string[] adminnames, string[] adminPasswords, string[] adminRoles, ref int adminCount, string name, string password, string role)
        {
            adminnames[adminCount] = name;
            adminPasswords[adminCount] = password;
            adminRoles[adminCount] = role;
            adminCount++;
        }
        static bool CheckValidCNIC(string cnic, ref int userCount, string[] CNIC)
        {
            bool flag = true;
            for (int i = 0; i < userCount; i++)
            {
                if (cnic == CNIC[i])
                {
                    flag = false;
                }
            }
            return flag;
        }
        static bool checkCNIC(string cnic)
        {
            int count = 0;
            bool flag = false;
            int lengthofCNIC = cnic.Length;
            if (lengthofCNIC == 13)
            {
                for (int i = 0; i < 13; i++)
                {
                    if (cnic[i] >= 48 && cnic[i] <= 57)
                    {
                        count++;
                    }
                }
                if (count == 13)
                {
                    flag = true;
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }


        static void Header()
        {
            Console.WriteLine("    *********************************************************************    ");
            Console.WriteLine("    *********************** ALL CITIZENS BANK ***************************   ");
            Console.WriteLine("    *********************************************************************   ");
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void ClearScreen()
        {
            Console.Clear();
        }
    }
}