using System;

namespace PersonHM
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            Person[] person = new Person[3];
            for(i = 0; i< 3; i++)
            {
                person[i] = new Person();

                Console.WriteLine("Enter a name: ");
                person[i].Name = Console.ReadLine();

                Console.WriteLine("Enter age: ");
                person[i].Age = int.Parse(Console.ReadLine());
            }

            foreach(var per in person)
            {
                Console.WriteLine(per.Description);
            }
            Console.ReadKey();
        }

        public class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public int AgeInFourYears
            {
                get
                {
                    return Age + 4;
                }
            }

            public string Description
            {
                get
                {
                    return $"Name: {Name} age in 4 years: {AgeInFourYears}";
                }
            }
        }
    }
}
