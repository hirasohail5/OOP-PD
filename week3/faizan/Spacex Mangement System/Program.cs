using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spacex_Mangement_System
{
    internal class Program
    {
        static int Main(string[] args)
        {
            List<Passenger> passengers = new List<Passenger>();
            List<spaceship> ships = new List<spaceship>();
            int choice;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Space Management System Menu:");
                Console.WriteLine("1. Add Ship");
                Console.WriteLine("2. Add Passenger");
                Console.WriteLine("3. Remove Ship");
                Console.WriteLine("4. Remove Passenger");
                Console.WriteLine("5. View Ships");
                Console.WriteLine("6. View all Passengers");
                Console.WriteLine("7. Exit");
                Console.WriteLine("");

                Console.Write("Please enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the ship name: ");
                        string name= Console.ReadLine();
                        Console.WriteLine("Enter the ship's driver name: ");
                        string driver=Console.ReadLine();
                        Console.WriteLine("Enter the ships destination: ");
                        string destination=Console.ReadLine();
                        spaceship Ship = new spaceship(name,driver,destination);
                        ships.Add(Ship);
                        Console.WriteLine("Ship added successfully!");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        passengers.addpassengers(ships);
                        break;
                    case 3:
                        Console.Clear();
                        ships.RemoveShip(ships, passengers);
                        break;
                    case 4:
                        Console.Clear();
                        passengers.RemovePassenger(passengers);
                        break;
                    case 5:
                        Console.Clear();
                        ships.viewships(ships , passengers);
                        break;
                    case 6:
                        Console.Clear();
                        passengers.Viewpassengerslist(passengers);
                        break;
                    case 7:
                        return 0;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                        Console.ReadKey();
                        break;
                }
            }

        }
    }
}
