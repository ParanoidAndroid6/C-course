using System;

namespace HM11
{
    public class ChatReminderItem: ReminderItem
    {
        public string ChatName { get; set; }

        public string AccountName { get; set; }

        public ChatReminderItem(string chatName, string accountName, DateTimeOffset time, string message) : base(time, message)
        {
            ChatName = chatName;
            AccountName = accountName;
        }

        public override string WriteProperties
        {
            get
            {
                return $"{GetType().Name}\n" +
                    $"Alarm date: {AlarmDate}\n" +
                    $"Alarm message: {Message}\n" +
                    $"Time to alarm: {TimeToAlarm}\n" +
                    $"Account name: {AccountName}\n" +
                    $"Chat name: {ChatName}\n" +
                    $"Is outdated: {IsOutDated}\n";
            }
        }
    }
}
