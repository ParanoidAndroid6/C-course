using System;
using System.Net;
using MihaZupan;
using Reminder.Domain;
using Reminder.Parsing;
using Reminder.Receiver.Core;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace Reminder.App
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Telegram Bot Application!");

			var storage = new InMemoryReminderStorage();
			var domain = new ReminderDomain(storage);

			string token = "633428988:AAHLW_LaS7A47PDO2I8sbLkIIM9L0joPOSQ";
			IWebProxy proxy = new HttpToSocks5Proxy(
				"proxy.golyakov.net", 1080);

			var sender = new TelegramReminderSender(token, proxy);
			var receiver = new TelegramReminderReceiver(token, proxy);

			receiver.MessageReceived += (s, e) =>
			{
				Console.WriteLine($"Message received from contact ID {e.ContactId} with text '{e.Message}'");

				try
				{
					var parsedMessage = MessageParser.Parse(e.Message);

					var item = new ReminderItem(
					parsedMessage.Date,
					parsedMessage.Message,
					e.ContactId);

					storage.Add(item);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"The format of the message is wrong!\n{ex.Message}");
				}
			};

			receiver.Run();

			domain.SendReminder = (ReminderItem ri) =>
			{
				sender.Send(ri.ContactId, ri.Message);
			};

			domain.Run();

			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}
	}
}
