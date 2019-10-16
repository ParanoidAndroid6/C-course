using System;
using System.Net;
using MihaZupan;
using Reminder.Domain;
using Reminder.Domain.Models;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Domain.Models;
using MessageReceivedEventArgs = Reminder.Domain.Models.MessageReceivedEventArgs;

namespace Reminder.App
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Telegram Bot Application!");

			var storage = new InMemoryReminderStorage();

			string token = "633428988:AAHLW_LaS7A47PDO2I8sbLkIIM9L0joPOSQ";

			IWebProxy proxy = new HttpToSocks5Proxy(
				"proxy.golyakov.net", 1080);

			var receiver = new TelegramReminderReceiver(token, proxy);

			var domain = new ReminderDomain(storage, receiver);
			var sender = new TelegramReminderSender(token, proxy);


			domain.SendReminder = (ReminderItem ri) =>
			{
				sender.Send(ri.ContactId, ri.Message);
			};

			domain.MessageReceived += Domain_MessageReceived;
			domain.MessageParsingSuccedded += Domain_MessageParsingSuccedded;
			domain.MessageParsingFailed += Domain_MessageParsingFailed;
            domain.AddingToStorageSucceeded += Domain_AddingToStorageSucceeded;
            domain.AddingToStorageFailed += Domain_AddingToStorageFailed;

			domain.Run();

			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

        private static void Domain_AddingToStorageFailed(object sender, AddingToStorageFailedEventArgs e)
        {
            Console.WriteLine($"Message from contact ID = {e.ContactId} parsing failed. Text \"{e.Message}\"");
        }

        private static void Domain_AddingToStorageSucceeded(object sender, AddingToStorageSucceddedEventArgs e)
        {
            Console.WriteLine($"Item from contact Id = {e.ContactId} successfully parsed. Text = \"{e.Message}\"");
        }

        private static void Domain_MessageParsingFailed(object sender, MessageParsingFailedEventArgs e)
		{
			Console.WriteLine(
				$"Message from contact ID = {e.ContactId} parsing failed. Text = \"{e.Message}\"");
		}

		private static void Domain_MessageParsingSuccedded(object sender, MessageParsingSucceddedEventArgs e)
		{
			Console.WriteLine(
				$"Message from contact ID = {e.ContactId} successfully parsed. Date = \"{e.Date}\" Text = \"{e.Message}\"");
		}

		private static void Domain_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			Console.WriteLine(
				$"Message from contact ID = {e.ContactId} received. Text = \"{e.Message}\"");
		}
	}
}
