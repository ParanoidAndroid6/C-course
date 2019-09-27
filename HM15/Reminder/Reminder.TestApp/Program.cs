using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;

namespace Reminder.TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			InMemoryReminderStorage storage = new InMemoryReminderStorage();
			ReminderItem reminderItem = new ReminderItem(
				DateTimeOffset.MinValue,
				"test message",
				"test contact");

			storage.Add(reminderItem);
			ReminderItem reminderItem2 = storage.Get(reminderItem.Id);

			if (reminderItem.Message != reminderItem2.Message)
			{

			}
		}
	}
}
