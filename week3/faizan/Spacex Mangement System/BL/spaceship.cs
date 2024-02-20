using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spacex_Mangement_System
{
    internal class spaceship
    {
        
        public string shipname;
        public string drivername;
        public string destination;

        public spaceship(string shipname,string drivername,string destination) 
        {
            this.shipname = shipname;
            this.drivername = drivername;
            this.destination = destination;
        }

        public void viewships(List<spaceship> ships, List<Passenger> passengers)
        {
            if (ships.Count == 0)
            {
                Console.WriteLine("No ships available. Please add a ship first.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Available Ships:");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ships[i].shipname}");
                }
                Console.Write("Choose a ship number to view its details: ");
                int option = int.Parse(Console.ReadLine());
                while (true)
                {
                    if (option < 1 || option > ships.Count)
                    {
                        Console.WriteLine("Invalid selection.Try again");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"SHIP'S NAME\tSHIP'S DRIVER NAME\tDESTINATION");
                        Console.WriteLine($"{ships[option-1].shipname}\t\t{ships[option - 1].drivername}\t\t{ships[option - 1].destination}");
                        Console.WriteLine("List of passengers is as under: ");
                        for (int i=0;i<passengers.Count;i++)
                        {
                            if (passengers[i].Shipname== ships[option - 1].shipname)
                            {
                                Console.WriteLine($"{passengers[i].passengername}");
                            }
                        }
                        Console.ReadKey();
                        break;
                    }
                    
                }


            }
        }

        public void RemoveShip(List<spaceship> ships, List<Passenger> passengers)
        {
            if (ships.Count == 0)
            {
                Console.WriteLine("No ships available to remove.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Available Ships:");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ships[i].shipname} - Destination: {ships[i].destination}");
                }

                Console.Write("Choose a ship number to remove: ");
                int shipIndex = int.Parse(Console.ReadLine()) - 1;
                while (true)
                {
                    if (shipIndex < 0 || shipIndex >= ships.Count)
                    {
                        Console.WriteLine("Invalid ship selection.");
                        Console.ReadKey();
                    }
                    else
                    {
                        string ship = ships[shipIndex].shipname;
                        ships.RemoveAt(shipIndex);
                        for (int i = 0; i < passengers.Count; i++)
                        {
                            if (passengers[i].Shipname == ship)
                            {
                                passengers.RemoveAt(i);
                            }
                        }
                        Console.WriteLine("Ship removed successfully!");
                        Console.ReadKey();
                        break;
                    }
                }
            }
        }
    }

}
