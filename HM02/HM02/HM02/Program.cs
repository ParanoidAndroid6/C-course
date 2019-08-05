using System;

namespace HM02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число от 1 до 10");
            int num01 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите второе число от 10 до 20");
            int num02 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите знак операции(+ , - , * , / , % , ^ )");
            var operation = Console.ReadLine();

            switch(operation)
            {
                case "+":
                    Console.WriteLine($"The result is: {num01 + num02}");
                break;

                case "-":
                    Console.WriteLine($"The result is: {num01 - num02}");
                    break;

                case "*":
                    Console.WriteLine($"The result is: {num01 * num02}");
                    break;

                case "/":
                    Console.WriteLine($"The result is: {num01 / num02}");
                    break;

                case "%":
                    Console.WriteLine($"The result is: {num01 % num02}");
                    break;

                case "^":
                    Console.WriteLine($"The result is: {Math.Pow(num01, num02)}");
                    break;
                
            }
            Console.ReadKey();
        }
    }
}
