using System;

namespace CharAHM
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            while (true)
            {
                string input = Console.ReadLine();
                string[] words = input.Split(" ");

                if (words.Length < 2)
                {
                    Console.WriteLine("Введите минимум два слова!");
                    continue;
                }

                if (words.Length > 1)
                {
                    for (i = 0; i < words.Length; i++)
                    {
                        if(words[i].StartsWith('A'))
                        {
                            i++;
                        }
                    }
                    break;
                }
            }
            Console.WriteLine($"{i}");
            Console.ReadKey();
        }
    }
}
