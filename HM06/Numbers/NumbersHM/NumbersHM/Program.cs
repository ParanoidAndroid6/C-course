using System;

namespace NumbersHM
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;
            try
            {
                Console.WriteLine("Enter a number below 2 000 000");
                var number = Console.ReadLine();

                for (var i = 0; i < number.Length; i++)
                {
                    if (number[i] % 2 == 0)
                    {
                        counter++;
                    }
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Enter the number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error! Enter right value");
            }

            Console.WriteLine($"There are {counter} even numbers in entered value");

            Console.ReadKey();
        }
    }
}
