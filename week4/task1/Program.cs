using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Task_1
{
    internal class Program
    {
        static List<Ship> ship = new List<Ship>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add Ship");
                Console.WriteLine("2. View Ship Position");
                Console.WriteLine("3. View Ship Serial Number");
                Console.WriteLine("4. Change Ship Position");
                Console.WriteLine("5. Exit");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.Clear();
                    addShip();
                    Console.ReadKey();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    print();
                    Console.ReadKey();
                }
                else if(option == 3)
                {
                    Console.Clear();
                    ViewSerialNumber();
                    Console.ReadKey();
                }
                else if(option == 4)
                {
                    Console.Clear();
                    ChangeShipPosition();
                    Console.ReadKey();
                }
                else if(option == 5)
                {
                    break;
                }

            }
        }
        static void addShip()
        {
            Console.WriteLine("Enter Ship Number: ");
            string snum = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude: ");
            Console.WriteLine("Enter Latitude’s Degree: ");
            int degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Minute: ");
            float min = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Direction: ");
            char direction = char.Parse(Console.ReadLine());
            Angle latitude = new Angle(degree, min, direction);
            Console.WriteLine("Enter Ship Longitude: ");
            Console.WriteLine("Enter Longitude’s Degree: ");
            int degree1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Minute: ");
            float min1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Direction: ");
            char dir1 = char.Parse(Console.ReadLine());
            Angle longitude = new Angle(degree1, min1, dir1);
            Ship s = new Ship(snum,latitude,longitude);
            ship.Add(s);
        }
        static void print()
        {
            Console.WriteLine("Enter Ship Serial Number to find its position: ");
            string snum = Console.ReadLine();
            foreach (var s in ship)
            {
              if(snum == s.Shipnumber)
                {
                    Console.WriteLine($"Ship is at {s.latitude.degrees}\u00b0{s.latitude.minutes}{s.latitude.direction} and {s.longitude.degrees}\u00b0{s.longitude.minutes}{s.longitude.direction}.");
                }
                else
                {
                    Console.WriteLine("Ship not found");
                }
            }
        }
        static void ChangeShipPosition()
        {
            Console.WriteLine("Enter Ship’s serial number whose position you want to change: ");
            string snum = Console.ReadLine();
            foreach (var s in ship)
            {
                if (snum == s.Shipnumber)
                {
                    Console.WriteLine("Enter Ship Latitude: ");
                    Console.WriteLine("Enter Latitude’s Degree: ");
                    s.latitude.degrees = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude’s Minute: ");
                    s.latitude.minutes = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude’s Direction: ");
                    s.latitude.direction = char.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Ship Longitude: ");
                    Console.WriteLine("Enter Longitude’s Degree: ");
                    s.longitude.degrees = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude’s Minute: ");
                    s.longitude.minutes = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude’s Direction: ");
                    s.longitude.direction = char.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Ship not found");
                }

            }

        }
        static void ViewSerialNumber()
        {
            Console.WriteLine("Enter Ship Latitude: ");
            Console.WriteLine("Enter Latitude’s Degree: ");
            int d1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Minute: ");
            float min1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Direction: ");
            char dir1 = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ship Longitude: ");
            Console.WriteLine("Enter Longitude’s Degree: ");
            int d2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Minute: ");
            float min2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Direction: ");
            char dir2 = char.Parse(Console.ReadLine());

            foreach (var s in ship)
            {
                if(s.latitude.degrees == d1 && s.latitude.minutes == min1 && s.latitude.direction == dir1 && s.longitude.degrees == d2 && s.longitude.minutes == min2 && s.longitude.direction == dir2)
                {
                    Console.WriteLine($"Ship's serial number is {s.Shipnumber}");
                }
            }
        }
            

    }
}
