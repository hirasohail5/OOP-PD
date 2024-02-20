using System;
using System.Linq;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0, num2 = 0, result = 0, option = 0;
            Calculator C = new Calculator(num1, num2, result);
            while (true)
            {
                Console.Clear();

                Console.WriteLine("     CALCUATOR");
                Console.WriteLine("1.Perform Operations");
                Console.WriteLine("2.Show previous calculatios");
                Console.WriteLine(" Enter your option: ");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Which operation do you want to perform:");
                        Console.WriteLine("1.Add");
                        Console.WriteLine("2.Subtract");
                        Console.WriteLine("3.Multiply");
                        Console.WriteLine("4.Division");
                        Console.WriteLine("5.Exit");
                        Console.WriteLine(" Enter your option: ");
                        option = int.Parse(Console.ReadLine());
                        if (option == 1)
                        {
                            Console.Clear();

                            Console.WriteLine(" Enter first number: ");
                            C.number1 = int.Parse(Console.ReadLine());
                            Console.WriteLine(" Enter second number ");
                            C.number2 = int.Parse(Console.ReadLine());
                            int r = C.add();
                            Console.Write("Result is: ");

                            
                            Console.WriteLine(r);
                            C.calculations.Add($"Sum of {C.number1} and {C.number2} is {r}");
                            Console.ReadKey();
                        }
                        else if (option == 2)
                        {
                            Console.Clear();
                            Console.WriteLine(" Enter first number: ");
                            C.number1 = int.Parse(Console.ReadLine());
                            Console.WriteLine(" Enter second number ");
                            C.number2 = int.Parse(Console.ReadLine());
                            int r = C.sub();
                            Console.Write("Result is: ");
                            Console.WriteLine(r);
                            C.calculations.Add($"Subtraction of {C.number1} and {C.number2} is {r}");
                            Console.ReadKey();
                        }
                        else if (option == 3)
                        {
                            Console.Clear();
                            Console.WriteLine(" Enter first number: ");
                            C.number1 = int.Parse(Console.ReadLine());
                            Console.WriteLine(" Enter second number ");
                            C.number2 = int.Parse(Console.ReadLine());
                            int r = C.mul();
                            Console.Write("Result is: ");
                            Console.WriteLine(r);
                            string t = $"Multiply of {C.number1} and {C.number2} is {r}";
                            C.calculations.Add(t);
                            Console.ReadKey();
                        }
                        else if (option == 4)
                        {
                            Console.Clear();
                            Console.WriteLine(" Enter first number: ");
                            C.number1 = int.Parse(Console.ReadLine());
                            Console.WriteLine(" Enter second number ");
                            C.number2 = int.Parse(Console.ReadLine());
                            int r = C.div();
                            Console.Write("Result is: ");                           
                            Console.WriteLine(r);
                            C.calculations.Add($"Division of {C.number1} and {C.number2} is {r}");
                            Console.WriteLine(C.calculations.Count());
                            Console.ReadKey();
                        }
                        else if (option == 5)
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("Wrong option.Try again.");
                        }
                    }
                }
                else if (option == 2)
                {

                    Console.Clear();

                    for (int i = 0; i < C.calculations.Count(); i++)
                    {
                        Console.WriteLine(C.calculations[i]);
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("Wrong option.Try again.");
                }

            }

        }
    }
}
