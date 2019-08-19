using System;

namespace BankHM
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    var days = 0;
                    decimal calc = 0;

                    Console.WriteLine("Введите сумму первоначального взноса: ");
                    var deposit = Convert.ToDecimal(Console.ReadLine());
                    if (deposit <= 0)
                    {
                        Console.WriteLine("Ошибка! Введите число больше 0.");
                        break;
                    }
                    Console.WriteLine("Введите ежедневный процент дохода в виде десятичной дроби(1 % = 0.01): ");
                    var percent = Convert.ToDecimal(Console.ReadLine());

                    if (percent <= 0)
                    {
                        Console.WriteLine("Ошибка! Введите число больше 0.");
                        break;
                    }

                    Console.WriteLine("Введите желаемую сумму накопления в рублях: ");
                    var desiredDep = Convert.ToDecimal(Console.ReadLine());

                    if (desiredDep <= 0)
                    {
                        Console.WriteLine("Ошибка! Введите число больше 0.");
                        break;
                    }

                    calc = deposit * percent;

                    while (deposit < desiredDep)
                    {
                        deposit += calc;
                        days++;
                    }

                    Console.WriteLine($"Необходимое количество дней для накопления желаемой суммы: {days}");
                }
               
            }

            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Введите число!");
            }

            Console.ReadKey();
        }
    }
}
