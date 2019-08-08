using System;

namespace HM03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int result;

            for (var i = 0; i < numbers.Length; i++)
            {
                Console.Write($"  {numbers[i]}\t");
            }

            Console.WriteLine("\n----------------------------------------------------------------------------");

            for (var j = 0; j < numbers.Length; j++)
            {
                Console.Write($"  {result = numbers[0] * numbers[j]}\t  " +
                    $"{result = numbers[1] * numbers[j]}\t  " +
                    $"{result = numbers[2] * numbers[j]}\t  " +
                    $"{result = numbers[3] * numbers[j]}\t  " +
                    $"{result = numbers[4] * numbers[j]}\t  " +
                    $"{result = numbers[5] * numbers[j]}\t  " +
                    $"{result = numbers[6] * numbers[j]}\t  " +
                    $"{result = numbers[7] * numbers[j]}\t  " +
                    $"{result = numbers[8] * numbers[j]}\t  " +
                    $"{result = numbers[9] * numbers[j]}\t\n");


            }
            Console.ReadKey();
        }
    }
}

