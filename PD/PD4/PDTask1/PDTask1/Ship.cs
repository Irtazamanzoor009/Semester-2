using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTask1
{
    class Ship
    {
        public string Shipnumber;
        public Angle Latitude;
        public Angle Longitude;

        public Ship(string shipnumber, Angle latitude, Angle longitude)
        {
            Shipnumber = shipnumber;
            Latitude = latitude;
            Longitude = longitude;
        }
        public Ship( Angle latitude, Angle longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public Ship()
        {

        }

        public void PrintShipPosition()
        {
            char degreeformat = '\u00b0';
            Console.WriteLine("Ship is at " + Latitude.Degree + degreeformat + Latitude.Minutes + " " + Latitude.Direction + " " + Longitude.Degree + degreeformat + Longitude.Minutes + " " + Longitude.Direction);
            
        }
        public void FindShipPosition(string serialnumber, List<Ship> ship)
        {
            foreach (var position in ship)
            {
                if(serialnumber == position.Shipnumber)
                {
                    position.PrintShipPosition();
                }
            }
        }
        public bool CheckShip(string serialnumber, List<Ship> ship)
        {
            bool flag = false;
            foreach(var check in ship)
            {
                if(serialnumber == check.Shipnumber)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public int ViewIndex(string shipnumber, List<Ship> ship)
        {
            int index = -1;
            for(int i=0; i<ship.Count; i++)
            {
                if(shipnumber == ship[i].Shipnumber)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public int ConvertDegree(string input)
        {
            int degree = 0;
            for(int i=0; i<input.Length; i++)
            {
                if(input[i] == ' ')
                {
                    break;
                }
                else
                {
                    degree = degree * 10 + (input[i] - '0');
                }
            }
            return degree;
        }
        public int ConvertMinute(string input)
        {
            int minutes = 0;
            int space = 0;
            bool foundspace = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {

                    foundspace = true;
                    space++;
                    if (space == 2)
                        break;
                }
                else if (foundspace)
                {
                    minutes = minutes * 10 + (input[i] - '0');
                }
            }
            return minutes;
        }
        public char ConvertDirection(string input)
        {
            char direction='\0';
            bool foundspace = false;
            int space = 0;
            for(int i=0; i<input.Length; i++)
            {
                if(input[i] == ' ')
                {
                    foundspace = true;
                    space++;
                }
                else if(foundspace && space == 2)
                {
                    direction = input[i];
                    break;
                }
            }
            return direction;
        }
        public void ReturnShipNumber(int latdegree, int latminutes, char latdirection,  int longdegree, int longminutes, char longdirection, List<Ship> ship)
        {
            foreach (var position in ship)
            {
                if (latdegree == position.Latitude.Degree && latminutes == position.Latitude.Minutes && latdirection == position.Latitude.Direction && longdegree == position.Longitude.Degree && longminutes == position.Longitude.Minutes && longdirection == position.Longitude.Direction)
                {
                    Console.WriteLine("Ship Number is: " + position.Shipnumber);
                }
                /*else
                {
                    Console.WriteLine("Error");
                }*/
            }
        }
        public void ConvertDirection(string latitude, List<Ship> ship)
        {
            int space = 0;
            int degree = 0;
            int minutes = 0;
            for(int i=0; i<latitude.Length; i++)
            {
                if(latitude[i] == ' ')
                {
                    break;
                }
                else
                {
                    degree = degree * 10 + (latitude[i] - '0');
                }
            }
            bool foundspace = false;
            for(int i=0; i<latitude.Length; i++)
            {
                if(latitude[i] == ' ')
                {
                    foundspace = true;
                }
                else if(foundspace)
                {
                    minutes = minutes * 10 + (latitude[i] - '0');
                }
            } 
            foreach(var position in ship)
            {
                if(degree == position.Latitude.Degree && minutes == position.Latitude.Minutes)
                {
                    Console.WriteLine("Number: " + position.Shipnumber);
                    
                }
            }
            
        }
        
    }
}
