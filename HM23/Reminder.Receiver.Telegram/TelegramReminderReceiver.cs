using System;
using System.Net;
using Telegram.Bot;
using Reminder.Receiver.Core;

namespace Reminder.Receiver.Telegram
{
	public class TelegramReminderReceiver: IReminderReceiver
	{
		private TelegramBotClient _botClient;

		public event EventHandler<MessageReceivedEventArgs> MessageReceived;

		public TelegramReminderReceiver(string token, IWebProxy proxy)
		{
			_botClient = new TelegramBotClient(token, proxy);
		}

		public void Run()
		{
			_botClient.OnMessage += _botClient_OnMessage;
			_botClient.StartReceiving();
		}

		private void _botClient_OnMessage(object sender, global::Telegram.Bot.Args.MessageEventArgs e)
		{
			if (e.Message.Type != global::Telegram.Bot.Types.Enums.MessageType.Text)
				return;

			MessageReceived?.Invoke(
				this,
				new MessageReceivedEventArgs
				{
					ContactId = e.Message.Chat.Id.ToString(),
					Message = e.Message.Text
				});
		}
	}
}
