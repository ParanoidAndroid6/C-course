using System;

namespace CharAHM
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s;
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    s = input.Split(' ');
                }

                catch (NullReferenceException)
                {
                    Console.WriteLine("Вы ничего не ввели!");
                    continue;
                }

                catch (FormatException)
                {
                    Console.WriteLine("Введите слова!");
                    continue;
                }

                if (s.Length < 2)
                {
                    Console.WriteLine("Введите минимум два слова!");
                    continue;
                }

                else
                    break;
            }

            int count = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i].StartsWith('A'))
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество слов, начинающися с буквы 'А': {count}");
            Console.ReadKey();
        }

    }
}

