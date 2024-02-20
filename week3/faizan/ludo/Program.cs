
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ludo> list = new List<Ludo>();
            string name="", color="";
            float value=0;
            int option;
            
            Console.WriteLine("How many players want to play: ");
            option=int.Parse(Console.ReadLine());
            for(int i=0; i<option; i++)
            {
                Console.Clear();
                Console.WriteLine("Enter your name: ");
                name= Console.ReadLine();
                Console.WriteLine("Enter your color: ");
                color = Console.ReadLine();
                Console.WriteLine("Press enter to roll your dice.");
                Console.ReadKey();
                value= GetRandomNumber(1, 6);
                Console.Write(value);
                Ludo l = new Ludo(color, name, value);
                list.Add(l);
                Console.ReadKey();
            }
            float highestnumber = 0;
            string winner = "";
            for (int i=0; i<list.Count;i++)
            {
                if (list[i].value> highestnumber)
                {
                    highestnumber = list[i].value;
                    winner = list[i].name;
                }
            }
            Console.WriteLine($"winner is {winner}");
            Console.ReadKey();
        }
        static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        
    }
}
