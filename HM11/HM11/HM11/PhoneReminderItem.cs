using System;

namespace HM11
{
    public class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(string phoneNumber, DateTimeOffset time, string message) : base(time, message)
        {
            PhoneNumber = phoneNumber;
        }

        public override string WriteProperties
        {
            get
            {
                return $"{GetType().Name}\n" +
                    $"Alarm date: {AlarmDate}\n" +
                    $"Alarm message: {Message}\n" +
                    $"Time to alarm: {TimeToAlarm}\n" +
                    $"Phone number: {PhoneNumber}\n" +
                    $"Is outdated: {IsOutDated}\n";
            }
        }


    }
}
