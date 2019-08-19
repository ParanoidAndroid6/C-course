using System;

namespace NumbersHM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое натуральное число не более 2 миллиардов: ");
            
            try
            {
                var count = 0;
                var input = Convert.ToInt32(Console.ReadLine());

                if (input > 0)
                {
                    while (input != 0)
                    {
                        if ((input % 10) % 2 == 0)
                        {
                            count++;
                        }

                       input /= 10;
                    }
                }
               
                else
                {
                    Console.WriteLine("Введите натуральное число!");
                }

                Console.WriteLine($"В числе содержится {count} четных чисел");
            }

            catch (FormatException)
            {
                Console.WriteLine("Нужно ввести число!");
            }

            catch (OverflowException)
            {
                Console.WriteLine("Слишком большое число, попробуйте снова");
            }

           

            Console.ReadKey();
        }
    }
}
