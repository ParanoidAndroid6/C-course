using System;

namespace HM11
{
    public class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }

        public string Message { get; set; }

        public TimeSpan TimeToAlarm
        {
            get
            {
                return DateTimeOffset.Now - AlarmDate;
            }
        }

        public bool IsOutDated
        {
            get
            {
                return DateTime.Now >= AlarmDate;
            }
        }

        public ReminderItem(DateTimeOffset time, string message)
        {
            
            AlarmDate = time;
            Message = message;
        }

        public virtual string WriteProperties
        {
            get
            {
                return $"{GetType().Name}\n" +
                    $"Alarm date: {AlarmDate}\n" +
                    $"Alarm message: {Message}\n" +
                    $"Time to alarm: {TimeToAlarm}\n" +
                    $"Is outdated: {IsOutDated}\n";
            }
        }

        public void Result()
        {
            Console.WriteLine(WriteProperties);
        }
    }
}
