using System;

namespace ContainerHM
{
    class Program
    {
        [Flags]
        enum Litres : short
        {
            None = 0x0,
            Litres1 = 0x1,
            Litres5 = 0x1 << 1,
            Litres20 = 0x1 << 2
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How much litres of juice do u want?: ");
            double input = Convert.ToDouble(Console.ReadLine());
            var non = Litres.None;
            Litres lit = Litres.Litres1 | Litres.Litres5 | Litres.Litres20;
            double contain20 = input / 20;
            double contain20Smth = input % 20;
            double contain5 = contain20Smth / 5;
            double contain5Smth = contain20Smth % 5;
            double contain1 = contain5Smth / 1;

            Console.WriteLine($"20 Litres: {Math.Floor(contain20)}");
            Console.WriteLine($"5 Litres: {Math.Floor(contain5)}");
            Console.WriteLine($"1 Litre: {Math.Ceiling(contain1)}");

            Console.ReadKey();
        }
    }
}
