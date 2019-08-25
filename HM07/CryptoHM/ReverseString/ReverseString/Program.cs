using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;

            while(true)
            {
                try
                {
                    text = Console.ReadLine();

                    if (text == string.Empty)
                    {
                        Console.WriteLine("Ошибка! Введите строку!");
                        continue;
                    }

                    if (text.Length > 0)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введите текст!");
                    continue;
                }
            }

            string reverse = string.Empty;

            for(int i = text.Length - 1; i > -1; i--)
            {
                reverse += text[i];
            }

            Console.WriteLine(reverse.ToLower());

            Console.ReadKey();
            
        }
    }
}
