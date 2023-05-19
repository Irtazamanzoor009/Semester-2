using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            ClearScreen();
            Ship ship = new Ship();
            List<Ship> shiplist = new List<Ship>();
            string option = "";
            while(option != "5")
            {
                ClearScreen();
                option = Menu();
                if(option == "1") // add ship
                {
                    ClearScreen();
                    ship = Addship();
                    shiplist.Add(ship);
                    Console.WriteLine("Record Saved Successfully");                    
                    Getch();

                }
                else if(option == "2") // view ship position
                {
                    ClearScreen();
                    Console.WriteLine("Enter Ship Serial Number: ");
                    string number = Console.ReadLine();
                    ship.FindShipPosition(number,shiplist);
                    Getch();
                }
                else if(option == "3") // view ship serial number
                {
                    ClearScreen();
                    Console.WriteLine("Enter Ship Latitude: ");
                    string latitude = Console.ReadLine();
                    int latdegree = ship.ConvertDegree(latitude);
                    int latminute = ship.ConvertMinute(latitude);
                    char latdirection = ship.ConvertDirection(latitude);
                    
                    Console.WriteLine("Enter Ship Longitude: ");
                    string longitude = Console.ReadLine();
                    int longdegree = ship.ConvertDegree(longitude);
                    int longminute = ship.ConvertMinute(longitude);
                    char longdirection = ship.ConvertDirection(longitude);
                    
                    ship.ReturnShipNumber(latdegree, latminute, latdirection, longdegree, longminute, longdirection, shiplist);
                    
                    Getch();
                }
                else if(option == "4") // change ship position
                {
                    ClearScreen();
                    Console.WriteLine("Enter Ship Number to change its position: ");
                    string shipnumber = Console.ReadLine();
                    bool checkship = ship.CheckShip(shipnumber, shiplist);
                    if(checkship)
                    {
                        int index = ship.ViewIndex(shipnumber, shiplist);
                        InputNewPosition(index,shiplist);
                        Console.WriteLine("Position has been updated");
                        Getch();
                    }
                    else
                    {
                        Console.WriteLine("Error! Ship not found");
                        Getch();
                    }
                }
            }
        }
        static void InputNewPosition(int index, List<Ship> shiplist)
        {
            //Angle change = new Angle();
            //Angle Latitude = new Angle();
            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Latitude's Degree: ");
            int latdegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minutes: ");
            float latminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char latdirection = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Lonngitude's Degree: ");
            int longdegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minutes: ");
            float longminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction: ");
            char longdirection = char.Parse(Console.ReadLine());

            shiplist[index].Latitude.Degree = latdegree;
            shiplist[index].Latitude.Minutes = latminutes;
            shiplist[index].Latitude.Direction = latdirection;

            shiplist[index].Longitude.Degree = longdegree;
            shiplist[index].Longitude.Minutes = longminutes;
            shiplist[index].Longitude.Direction = longdirection;
        }
        static void ClearScreen()
        {
            Console.Clear();
        }
        static void Getch()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static string Menu()
        {
            string choice;
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            Console.WriteLine("--------------------------");
            choice = Console.ReadLine();
            return choice;
        }
        static Ship Addship()
        {
            Console.Write("Enter Ship Number: ");
            string number = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude: ");
            Console.Write("Enter Latitude's Degree: ");
            int latdegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minutes: ");
            float latminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char latdirection = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Ship Longitude: ");
            Console.Write("Enter Lonngitude's Degree: ");
            int longdegree = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minutes: ");
            float longminutes = float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction: ");
            char longdirection = char.Parse(Console.ReadLine());

            if(number != null && latdegree != null && latminutes != null && latdirection != null && longdegree != null && longminutes != null && longdirection != null)
            {
                Angle Latitude = new Angle(latdegree, latminutes, latdirection);
                Angle Longitude = new Angle(longdegree, longminutes, longdirection);
                Ship add = new Ship(number, Latitude, Longitude);
                return add;
            }
            return null;
        }
    }
}
