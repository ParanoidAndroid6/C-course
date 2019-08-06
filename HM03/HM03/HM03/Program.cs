using System;

namespace HM03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int result;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    result = numbers[i] * numbers[j];
                    Console.WriteLine($"{numbers[i]} * {numbers[j]} = {result}\t");
                }
            }

            Console.ReadKey();
        }
    }
}
