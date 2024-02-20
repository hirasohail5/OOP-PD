using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spacex_Mangement_System
{
    internal class Passenger
    {
        List<Passenger> passengers = new List<Passenger>();
        public string passengername;
        public string Shipname;

        public Passenger(string passengername, string Shipname) 
        { 
            this.passengername = passengername;
            this.Shipname = Shipname;

        }


        public void addpassengers(List<spaceship> ships)
        {
            if(ships.Count == 0)
            {
                Console.WriteLine("No ships available. Please add a ship first.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Available Ships:");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ships[i].shipname} - Destination: {ships[i].destination}");
                }
                
                while(true)
                {
                    Console.Write("Choose a ship number: ");
                    int option = int.Parse(Console.ReadLine());
                    if (option<1||option> ships.Count)
                    {
                        Console.WriteLine("Invalid ship selection.Try again");
                    }
                    else
                    {
                        Console.Write("Enter passenger name: ");
                        string passengerName = Console.ReadLine();
                        string shipnName = ships[option - 1].shipname;
                        Passenger newPassenger = new Passenger(passengerName, shipnName);
                        passengers.Add(newPassenger);
                        Console.WriteLine($"{passengerName} added to {ships[option - 1].shipname} successfully!");
                        Console.ReadKey();
                        break;
                    }
                }
                

            }
        }

        public void RemovePassenger(List<Passenger> passengers)
        {
            if (passengers.Count == 0)
            {
                Console.WriteLine("No passengers available.");
                Console.ReadKey();
            }
            else
            {

                Console.WriteLine("Available Passengers:");
                for (int i = 0; i < passengers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {passengers[i].passengername} - Ship: {passengers[i].Shipname}");
                }

                Console.Write("Choose a passenger number to remove: ");
                int passengerIndex = int.Parse(Console.ReadLine()) - 1;
                while (true)
                {
                    if (passengerIndex < 0 || passengerIndex >= passengers.Count)
                    {
                        Console.WriteLine("Invalid passenger selection.");
                        Console.ReadKey();
                    }
                    else
                    {
                        passengers.RemoveAt(passengerIndex);
                        Console.WriteLine("Passenger removed successfully!");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
        public void Viewpassengerslist(List<Passenger> passengers)
        {
            if(passengers.Count==0)
            {
                Console.WriteLine("Sorry there are no passengers!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Passenger's name\tPassenger's ship name");
                for(int i=0;i<passengers.Count;i++)
                {
                    Console.WriteLine($"{passengers[i].passengername}\t\t{passengers[i].Shipname}");
                }
                Console.ReadKey();
            }
        }
    }
    

}
