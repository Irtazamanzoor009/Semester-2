using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<User> user = new List<User>();
            List<Admin> admin = new List<Admin>();
            string userpath = "E:\\Semester 2-\\PD\\PD2\\Task1\\Task1\\User.txt";
            string adminpath = "E:\\Semester 2-\\PD\\PD2\\Task1\\Task1\\Admin.txt";
            string choice = "";
            string name, password, role, cnic;
            string accounttype;
            int initialamount;
            ReadUserData(userpath, user);
            ReadAdminData(adminpath, admin);

            while (choice != "3")
            {
                ClearScreen();
                Header();
                choice = MainMenu();
                if (choice == "1") // sign in
                {
                    ClearScreen();
                    Header();
                    Console.WriteLine(" ");
                    Console.WriteLine("-----------------Sign In-----------------");
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    password = Console.ReadLine();
                    string returnRole = ReturnRole(name, password, user, admin);
                    if (user.Count == 0 && admin.Count == 0)
                    {
                        Console.WriteLine("No account created yet");
                        Getch();
                    }
                    else
                    {
                        if (returnRole == "Admin" || returnRole == "admin")
                        {
                            string option = "";
                            while (option != "4") // admin functionallities
                            {
                                ClearScreen();
                                Header();
                                option = AdminInterface();
                                if (option == "1") // view details
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine(" ");
                                    Console.WriteLine("-----------------View Details-----------------");
                                    ViewDetails(user);
                                    Getch();

                                }
                                else if (option == "2") // Delete Account
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine(" ");
                                    Console.WriteLine("----------------------Delete Account----------------------");
                                    string deleteaccountName;
                                    Console.WriteLine("Enter name of account you want to delete: ");
                                    deleteaccountName = Console.ReadLine();
                                    int index = ViewIndex(deleteaccountName, user);
                                    if (index >= 0)
                                    {
                                        DeleteAccount(user, name, index);
                                        StoreUsersData(userpath, user);
                                        Console.WriteLine("Account has been deleted successfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Not Found");
                                    }

                                    Getch();
                                }
                                else if (option == "3") // modify account
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine(" ");
                                    Console.WriteLine("----------------------Modify Account----------------------");
                                    string accountname;
                                    string newaccounttype;
                                    Console.WriteLine("Enter Account Name to modify: ");
                                    accountname = Console.ReadLine();
                                    int index = ViewIndex(accountname, user);
                                    if (index >= 0)
                                    {
                                        Console.WriteLine("Enter new Account Type: ");
                                        newaccounttype = Console.ReadLine();
                                        if (newaccounttype == "c" || newaccounttype == "s")
                                        {
                                            ModifyAccount(user, index, newaccounttype);
                                            Console.WriteLine("Account has been modified");
                                            StoreUsersData(userpath, user);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error! Invalid account type");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Account not found");
                                    }
                                    //StoreUsersData(userpath, user);
                                    Getch();
                                }
                            }
                        }
                        else if (returnRole == "user" || returnRole == "User")
                        {
                            string option = "";
                            while (option != "5")
                            {
                                ClearScreen();
                                Header();
                                option = UserInterface();
                                if (option == "1") // view info
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------View Info----------------");
                                    Console.WriteLine(" ");
                                    ViewInfo(name, user);
                                    Getch();
                                }
                                else if (option == "2") // deposit amount
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
                                        AmountDeposited(name, user, depositamount);
                                        StoreUsersData(userpath, user);
                                        Console.WriteLine("Your amount has been deposited");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Invalid Amount");
                                    }
                                    Getch();
                                }
                                else if (option == "3") // withdraw amount
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------Withdraw Amount----------------------");
                                    Console.WriteLine(" ");
                                    int withdraw;
                                    Console.WriteLine("Enter amount you want to withdraw: ");
                                    withdraw = int.Parse(Console.ReadLine());
                                    bool isValid = CheckWithdraw(ref withdraw, name, user);
                                    if (isValid)
                                    {
                                        WithdrawAmount(ref withdraw, name, user);
                                        StoreUsersData(userpath, user);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Invalid Amount");
                                    }
                                    Getch();
                                }
                                else if (option == "4") // check balance inquiry
                                {
                                    ClearScreen();
                                    Header();
                                    Console.WriteLine("----------------------Check Balance Inquiry----------------------");
                                    Console.WriteLine(" ");
                                    CheckBalanceInquiry(name, user);
                                    StoreUsersData(userpath, user);
                                    Getch();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error! User does not exist");
                            Getch();
                        }
                    }
                }
                else if (choice == "2") // sign up
                {
                    ClearScreen();
                    Header();
                    Console.WriteLine(" ");
                    Console.WriteLine("-----------------Sign Up-----------------");
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    password = Console.ReadLine();
                    Console.Write("Enter Role: ");
                    role = Console.ReadLine();
                    bool result = IsValidUsername(name, user, admin);
                    if (result == true)
                    {
                        if (role == "user" || role == "User") // user requirements
                        {
                            Console.Write("Enter CNIC: ");
                            cnic = Console.ReadLine();
                            bool checkcnic = checkCNIC(cnic);
                            if (checkcnic)
                            {
                                bool validcnic = CheckValidCNIC(cnic, user);
                                if (validcnic)
                                {
                                    Console.Write("Enter Initial Amount: ");
                                    initialamount = int.Parse(Console.ReadLine());
                                    if (initialamount > 0)
                                    {
                                        Console.Write("Enter Account Type: ");
                                        accounttype = Console.ReadLine();
                                        if (accounttype == "c" || accounttype == "s" || accounttype == "C" || accounttype == "S")
                                        {
                                            user.Add(UsersignUp(name, password, initialamount, accounttype, cnic, role));
                                            StoreUsersData(userpath, user);
                                            Console.WriteLine("User Signed Up Successfully");
                                            Getch();
                                        }
                                        else
                                        {
                                            Console.Write("Error! Invalid Account Type");
                                            Getch();
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Invalid amount.");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Error! CNIC already exist");
                                    Getch();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error! Invalid Entity");
                                Getch();
                            }


                        }
                        else if (role == "Admin" || role == "admin")
                        {
                            admin.Add(AdminsignUp(name, password, role));
                            StoreAdmindata(adminpath, admin);
                            Console.WriteLine("Admin Signed Up Successfully");
                            Getch();
                        }
                        else
                        {
                            Console.WriteLine("Error! Invalid role");
                            Getch();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error! User Already Exist");
                        Getch();
                    }
                }
            }
        }
        static void Header()
        {
            Console.WriteLine("    *********************************************************************    ");
            Console.WriteLine("    *********************** ALL CITIZENS BANK ***************************   ");
            Console.WriteLine("    *********************************************************************   ");
        }
        static void ClearScreen()
        {
            Console.Clear();
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
        static void ViewInfo(string name, List<User> user)
        {
            int index = ViewIndex(name, user);
            Console.WriteLine("Name: " + user[index].username);
            Console.WriteLine("CNIC: " + user[index].cnic);
            Console.WriteLine("Password: " + user[index].userpassword);
        }
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
        static void ViewDetails(List<User> user)
        {
            Console.WriteLine("Name\t\tAccountType\t\tAmount\t\tCNIC\t\t");
            Console.WriteLine("_____________________________________________________________________________");
            if (user.Count == 0)
            {
                Console.WriteLine("No account present");
            }
            else
            {
                for (int i = 0; i < user.Count; i++)
                {
                    Console.WriteLine(user[i].username + "\t\t" + user[i].accounttype + "\t\t" + user[i].initialamount + "\t\t" + user[i].cnic);
                }
            }
        }
        static int ViewIndex(string name, List<User> user)
        {
            int index = -1;

            for (int i = 0; i < user.Count; i++)
            {
                if (name == user[i].username)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static void DeleteAccount(List<User> user, string name, int index)
        {
            //int index = ViewIndex(name, user);
            user.RemoveAt(index);
        }
        static void ModifyAccount(List<User> user, int index, string accounttype)
        {
            user[index].accounttype = accounttype;
        }
        static void AmountDeposited(string name, List<User> user, int deposit_amount)
        {
            int index = -1;
            index = ViewIndex(name, user);
            user[index].initialamount += deposit_amount;
        }
        static bool CheckWithdraw(ref int withdraw_amount, string name, List<User> user)
        {
            bool flag = false;
            int index = -1;
            index = ViewIndex(name, user);
            if (withdraw_amount <= user[index].initialamount)
            {
                flag = true;
            }
            return flag;
        }
        static void WithdrawAmount(ref int withdraw_amount, string name, List<User> user)
        {
            int index = -1;
            index = ViewIndex(name, user);
            user[index].initialamount -= withdraw_amount;
            Console.WriteLine("Your amount " + withdraw_amount + " has been withdrawn");
        }
        static void CheckBalanceInquiry(string name, List<User> user)
        {
            int index = -1;
            index = ViewIndex(name, user);
            Console.WriteLine("Your balance is: " + user[index].initialamount);
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static bool IsValidUsername(string name, List<User> user, List<Admin> admin)
        {
            bool flag = true;
            for (int i = 0; i < user.Count; i++)
            {
                if (name == user[i].username)
                {
                    flag = false;
                }
            }
            for (int i = 0; i < admin.Count; i++)
            {
                if (name == admin[i].adminname)
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
        static bool CheckValidCNIC(string cnic, List<User> user)
        {
            bool flag = true;
            for (int i = 0; i < user.Count; i++)
            {
                if (cnic == user[i].cnic)
                {
                    flag = false;
                }
            }
            return flag;
        }
        static User UsersignUp(string name, string password, int initialamount, string accounttype, string cnic, string userrole)
        {
            User user = new User();
            user.username = name;
            user.userpassword = password;
            user.userrole = userrole;
            user.initialamount = initialamount;
            user.accounttype = accounttype;
            user.cnic = cnic;
            return user;
        }
        static Admin AdminsignUp(string name, string password, string adminrole)
        {
            Admin admin = new Admin();
            admin.adminname = name;
            admin.adminpassword = password;
            admin.adminrole = adminrole;
            return admin;
        }
        static string ReturnRole(string name, string password, List<User> user, List<Admin> admin)
        {
            string role = "";
            for (int i = 0; i < user.Count; i++)
            {
                if (name == user[i].username && password == user[i].userpassword)
                {

                    role = user[i].userrole;
                    break;
                }
            }
            for (int i = 0; i < admin.Count; i++)
            {
                if (name == admin[i].adminname && password == admin[i].adminpassword)
                {

                    role = admin[i].adminrole;
                    break;
                }
            }
            return role;

        }
        static void StoreUsersData(string path, List<User> user)
        {
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < user.Count; i++)
            {
                file.WriteLine(user[i].username + ',' + user[i].userpassword + ',' + user[i].userrole + ',' + user[i].cnic + ',' + user[i].initialamount + ',' + user[i].accounttype);
            }
            file.Close();
        }
        static void StoreAdmindata(string path, List<Admin> admin)
        {
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < admin.Count; i++)
            {
                file.WriteLine(admin[i].adminname + ',' + admin[i].adminpassword + ',' + admin[i].adminrole);

            }
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
        static void ReadUserData(string path, List<User> user)
        {
            string record;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                User add = new User();
                while ((record = file.ReadLine()) != null)
                {
                    add.username = ParseData(record, 1);
                    add.userpassword = ParseData(record, 2);
                    add.userrole = ParseData(record, 3);
                    add.cnic = ParseData(record, 4);
                    add.initialamount = int.Parse(ParseData(record, 5));
                    add.accounttype = ParseData(record, 6);
                    user.Add(add);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
        static void ReadAdminData(string path, List<Admin> admin)
        {
            string record;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                Admin add = new Admin();
                while ((record = file.ReadLine()) != null)
                {
                    add.adminname = ParseData(record, 1);
                    add.adminpassword = ParseData(record, 2);
                    add.adminrole = ParseData(record, 3);
                    admin.Add(add);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
    }
}
