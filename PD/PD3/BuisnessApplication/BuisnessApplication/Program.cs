using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessApplication
{
    class User
    {
        public string username;
        public string userpassword;
        public string role;
        public string cnic;
        public int initialamount;
        public string accounttype;

        public User(string name, string password, string role, string cnic, int amount, string account) // for user
        {
            username = name;
            userpassword = password;
            this.role = role;
            this.cnic = cnic;
            initialamount = amount;
            accounttype = account;
        }
        public User(string name, string password, string role) // for admin
        {
            username = name;
            userpassword = password;
            this.role = role;
        }
        public User(string name, string password) // for sign in
        {
            username = name;
            userpassword = password;
        }
        public User(string name, string acctype, int amount, string cnic)
        {
            username = name;
            accounttype = acctype;
            initialamount = amount;
            this.cnic = cnic;
        }
        public bool isAdmin()
        {
            if (role == "Admin" || role == "admin")
            {
                return true;
            }
            return false;
        }
        public bool isUser()
        {
            if (role == "User" || role == "user")
            {
                return true;
            }
            return false;
        }
        //------------------
        public void ViewDetails(List<User> user)
        {
            Console.WriteLine("Name\t\tAccountType\t\tAmount\t\tCNIC\t\t");
            Console.WriteLine("_____________________________________________________________________");
            foreach (var details in user)
            {
                if (details.role == "User" || details.role == "user")
                {
                    Console.WriteLine(details.username + "\t\t" + details.accounttype + "\t\t" + details.initialamount + "\t\t" + details.cnic);
                }
            }
        }
        public int ViewIndex(string name, List<User> user)
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
        public bool ReturnUserrole(string name, List<User> user)
        {
            bool flag = false;
            //string role;
            for (int i = 0; i < user.Count; i++)
            {
                if (name == user[i].username && (user[i].role == "user" || user[i].role == "User"))
                {
                    flag = true;
                }
            }
            return flag;
        }
        public void ViewInfo(string name, List<User> user)
        {
            int index = ViewIndex(name, user);
            Console.WriteLine("Name: " + user[index].username);
            Console.WriteLine("CNIC: " + user[index].cnic);
            Console.WriteLine("Password: " + user[index].userpassword);
        }
        public bool checkCNIC(string cnic)
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
        public bool CheckValidCNIC(string cnic, List<User> user)
        {
            bool flag = true;
            foreach (User check in user)
            {
                if (cnic == check.cnic)
                {
                    flag = false;
                }
            }
            return flag;
        }
        public bool IsValidUsername(string name, List<User> user)
        {
            bool flag = true;
            foreach (User check in user)
            {
                if (name == check.username)
                {
                    flag = false;
                }
            }
            return flag;
        }
        public bool CheckAccounttype(List<User> user, string accounttype)
        {
            if (accounttype == "c" || accounttype == "s" || accounttype == "C" || accounttype == "S")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int EnterDepositAmount()
        {
            int depositamount;
            Console.WriteLine("Enter amount you want to deposit: ");
            depositamount = int.Parse(Console.ReadLine());
            return depositamount;
        }
        public bool CheckDepositAmount(int amount)
        {
            if (amount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AmountDeposited(string name, List<User> user, int deposit_amount)
        {
            int index = -1;
            index = ViewIndex(name, user);
            user[index].initialamount += deposit_amount;
        }
        public void CheckBalanceInquiry(string name, List<User> user)
        {
            int index = -1;
            index = ViewIndex(name, user);
            Console.WriteLine("Your balance is: " + user[index].initialamount);
        }
        public int EnterWithdrawAmount()
        {
            int withdrawamount;
            Console.WriteLine("Enter withdraw amount: ");
            withdrawamount = int.Parse(Console.ReadLine());
            return withdrawamount;
        }
        public bool checkwithdrawAmount(int amount, int initialamount)
        {
            if (amount > 0 && amount <= initialamount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void WithdrawAmount(int withdraw_amount, string name, List<User> user)
        {
            int index = -1;
            index = ViewIndex(name, user);
            user[index].initialamount -= withdraw_amount;
            Console.WriteLine("Your amount " + withdraw_amount + " has been withdrawn");
        }
        public string EnterdeleteAccountName()
        {
            string deleteaccountName;
            Console.WriteLine("Enter name of account you want to delete: ");
            deleteaccountName = Console.ReadLine();
            return deleteaccountName;
        }
        public void DeleteAccount(List<User> user, int index)
        {
            user.RemoveAt(index);
        }
        public void ModifyAccount(List<User> user, int index, string accounttype)
        {
            user[index].accounttype = accounttype;
        }
        public string EnterAccountNameToModify()
        {
            string accountname;
            Console.WriteLine("Enter Account Name to modify: ");
            accountname = Console.ReadLine();
            return accountname;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string userpath = "user.txt";
            List<User> users = new List<User>();
            bool check = ReadUserData(userpath, users);
            if (check)
                Console.WriteLine("Data Loaded Successfully");
            else
                Console.WriteLine("Data Not Loaded");
            Getch();
            Clearscreeen();
            Header();
            string choice = "";
            while (choice != "3")
            {
                Clearscreeen();
                Header();
                choice = Menu();
                if (choice == "1") // Sign in
                {
                    Clearscreeen();
                    Header();
                    Console.WriteLine("-----------Sign In------------");
                    User user = takeInputWithoutRole();
                    if (user != null)
                    {
                        user = SignIn(users, user);
                        if (user == null)
                        {
                            Console.WriteLine("Error! Wrong Credentials");
                            Getch();
                        }
                        else if (user.isAdmin())
                        {
                            Clearscreeen();
                            Header();
                            Console.WriteLine("--------------Admin Menu---------------");
                            while (choice != "4")
                            {
                                Clearscreeen();
                                Header();
                                choice = AdminInterface();
                                if (choice == "1") // view details
                                {
                                    Clearscreeen();
                                    Header();
                                    Console.WriteLine("--------------View Details---------------");
                                    user.ViewDetails(users);
                                    Getch();
                                }
                                else if (choice == "2") // delete account
                                {
                                    Clearscreeen();
                                    Header();
                                    Console.WriteLine("--------------Delete Account---------------");

                                    string deleteaccountName = user.EnterdeleteAccountName();
                                    int index = user.ViewIndex(deleteaccountName, users);
                                    bool checkuserrole = user.ReturnUserrole(deleteaccountName, users);
                                    if (index >= 0 && checkuserrole)
                                    {
                                        user.DeleteAccount(users, index);
                                        StoreUsersData(userpath, users);
                                        Console.WriteLine("Account has been deleted successfully");
                                        Getch();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Not Found");
                                        Getch();
                                    }
                                }
                                else if (choice == "3") //modify account
                                {
                                    Clearscreeen();
                                    Header();
                                    Console.WriteLine("--------------Modify Account---------------");
                                    string accountname = user.EnterdeleteAccountName();
                                    int index = user.ViewIndex(accountname, users);
                                    if (index >= 0)
                                    {
                                        Console.WriteLine("Enter new Account Type: ");
                                        string newaccounttype = Console.ReadLine();
                                        bool checkaccounttype = user.CheckAccounttype(users, newaccounttype);
                                        if (checkaccounttype)
                                        {
                                            user.ModifyAccount(users, index, newaccounttype);
                                            StoreUsersData(userpath, users);
                                            Console.WriteLine("Account has been modified");
                                            Getch();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error! Invalid account type");
                                            Getch();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Account not found");
                                        Getch();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Clearscreeen();
                            Header();
                            Console.WriteLine("--------------User Menu-------------");
                            while (choice != "5")
                            {
                                Clearscreeen();
                                Header();
                                choice = UserInterface();
                                if (choice == "1") // view info
                                {
                                    Clearscreeen();
                                    Header();
                                    Console.WriteLine("----------------------View Info----------------------");
                                    user.ViewInfo(user.username, users);
                                    Getch();
                                }
                                else if (choice == "2") // deposit amount
                                {
                                    Clearscreeen();
                                    Header();
                                    Console.WriteLine("----------------------Deposit Amount----------------------");
                                    Console.WriteLine(" ");
                                    int depositamount = user.EnterDepositAmount();
                                    bool checkamount = user.CheckDepositAmount(depositamount);
                                    if (checkamount)
                                    {
                                        user.AmountDeposited(user.username, users, depositamount);
                                        StoreUsersData(userpath, users);
                                        Console.WriteLine("Your amount has been deposited");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Invalid Amount");
                                    }
                                    Getch();
                                }
                                else if (choice == "3") // withdraw amount
                                {
                                    Clearscreeen();
                                    Header();
                                    Console.WriteLine("----------------------Withdraw Amount----------------------");
                                    int withdrawamount = user.EnterWithdrawAmount();
                                    bool checkamount = user.checkwithdrawAmount(withdrawamount, user.initialamount);
                                    if (checkamount)
                                    {
                                        user.WithdrawAmount(withdrawamount, user.username, users);
                                        StoreUsersData(userpath, users);
                                        Getch();
                                    }
                                }
                                else if (choice == "4") // check balance inquiry
                                {
                                    Clearscreeen();
                                    Header();
                                    Console.WriteLine("----------------------Check Balance----------------------");
                                    user.CheckBalanceInquiry(user.username, users);
                                    Getch();
                                }

                            }
                        }
                    }
                }
                else if (choice == "2")// signup
                {
                    Clearscreeen();
                    Header();
                    Console.WriteLine("-----------Sign Up------------");
                    User user = Takeinputwithrole();
                    if (user != null)
                    {
                        if (user.isAdmin())
                        {
                            StoreinList(users, user);
                            Console.WriteLine("Admin Signed Up successfully");
                            StoreUsersData(userpath, users);
                            Getch();
                        }
                        else
                        {
                            bool IsvalidUsername = user.IsValidUsername(user.username, users);
                            bool checkCNIC = user.checkCNIC(user.cnic);
                            bool IsvalidCNIC = user.CheckValidCNIC(user.cnic, users);
                            bool checkaccounttype = user.CheckAccounttype(users, user.accounttype);
                            if (IsvalidUsername && checkCNIC && IsvalidCNIC && checkaccounttype)
                            {
                                StoreinList(users, user);
                                Console.WriteLine("User Signed Up successfully");
                                StoreUsersData(userpath, users);
                                Getch();
                            }
                            else if (!IsvalidUsername)
                            {
                                Console.WriteLine("Error! Invalid Name. User Already Exist");
                                Getch();
                            }
                            else if (!checkCNIC)
                            {
                                Console.WriteLine("Error! CNIC has invalid Entity");
                                Getch();
                            }
                            else if (!IsvalidCNIC)
                            {
                                Console.WriteLine("Error! CNIC already exist");
                                Getch();
                            }
                            else if (!checkaccounttype)
                            {
                                Console.WriteLine("Error! Invalid Account type");
                                Getch();
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error! Invalid Credentials");
                        Getch();
                    }
                }
            }


        }
        static void StoreUsersData(string path, List<User> user)
        {
            StreamWriter file = new StreamWriter(path);
            for (int i = 0; i < user.Count; i++)
            {
                file.WriteLine(user[i].username + ',' + user[i].userpassword + ',' + user[i].role + ',' + user[i].cnic + ',' + user[i].initialamount + ',' + user[i].accounttype);
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
        static bool ReadUserData(string path, List<User> user)
        {
            string record;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((record = file.ReadLine()) != null)
                {
                    string name = ParseData(record, 1);
                    string password = ParseData(record, 2);
                    string role = ParseData(record, 3);
                    string cnic = ParseData(record, 4);
                    int initialamount = int.Parse(ParseData(record, 5));
                    string accounttype = ParseData(record, 6);
                    User users = new User(name, password, role, cnic, initialamount, accounttype);
                    StoreinList(user, users);

                }
                file.Close();
                return true;
            }
            else
            {
                return false;
            }
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
        static User SignIn(List<User> users, User user)
        {
            foreach (var use in users)
            {
                if (user.username == use.username && user.userpassword == use.userpassword)
                {
                    return use;
                }
            }
            return null;
        }
        static void StoreinList(List<User> users, User user)
        {
            users.Add(user);
        }
        static User Takeinputwithrole()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Role: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                if (role == "Admin" || role == "admin")
                {
                    User user = new User(name, password, role);
                    return user;
                }
                else if (role == "User" || role == "user")
                {
                    Console.Write("Enter CNIC: ");
                    string cnic = Console.ReadLine();
                    Console.Write("Enter Initial Amount: ");
                    int amount = int.Parse(Console.ReadLine());
                    Console.Write("Enter Account type: ");
                    string accounttype = Console.ReadLine();
                    if (cnic != null && amount != null && accounttype != null)
                    {
                        User user = new User(name, password, role, cnic, amount, accounttype);
                        return user;
                    }
                }
            }
            return null;
        }
        static User takeInputWithoutRole()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                User user = new User(name, password);
                return user;
            }
            return null;

        }
        static string Menu()
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
        static void Header()
        {
            Console.WriteLine("    *********************************************************************    ");
            Console.WriteLine("    *********************** ALL CITIZENS BANK ***************************   ");
            Console.WriteLine("    *********************************************************************   ");
        }
        static void Clearscreeen()
        {
            Console.Clear();
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

