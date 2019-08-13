using System;

namespace Colors01
{
    class Program
    {
        [Flags]
        enum Colors: byte
        {   
            
            Black = 1,
            White = 1<<1,
            Yellow = 1<<2,
            Green = 1<<3,
            Magenta = 1<<4,
            Grey = 1<<5,
            Red = 1<<6,
            Blue = 1<<7,
        }
        static void Main(string[] args)
        {
            Colors allColors = Colors.Black | Colors.Blue | Colors.Green | Colors.Grey | Colors.Magenta | Colors.Red | Colors.White | Colors.Yellow;

            foreach (var item in Enum.GetValues(typeof(Colors)))
            {
                Console.WriteLine($"{item}: {Convert.ToInt32(item)}");
            }

            Console.WriteLine("Choose four colors to add them in favorites (type their numbers in console): ");

            var input1 = (Colors)Enum.Parse(typeof(Colors), Console.ReadLine());
            var input2 = (Colors)Enum.Parse(typeof(Colors), Console.ReadLine());
            var input3 = (Colors)Enum.Parse(typeof(Colors), Console.ReadLine());
            var input4 = (Colors)Enum.Parse(typeof(Colors), Console.ReadLine());

            Colors favoriteColors = input1 | input2 | input3 | input4;

            Console.WriteLine($"Your favorite colors are: {favoriteColors}");

            Console.WriteLine($"Your unfavorite colors are: {allColors ^ favoriteColors}");

            Console.ReadKey();
        }
    }
}
