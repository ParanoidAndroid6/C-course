using System;

namespace HM11
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminders = new ReminderItem[3];

            reminders[0] = new ReminderItem(DateTimeOffset.Parse("09-09-2019 10:00:00"), "Wake up!");

            reminders[1] = new PhoneReminderItem("+7 915-130-34-16", DateTimeOffset.Parse("05-09-2019 10:00:00"), "HELLO!");

            reminders[2] = new ChatReminderItem("Chat1", "Yuri", DateTimeOffset.Parse("21-09-2019 06:30:00"), "YO!");
            
            foreach(var rem in reminders)
            {
                Console.WriteLine(rem.WriteProperties);
            }
            Console.ReadKey();
        }
    }
}
