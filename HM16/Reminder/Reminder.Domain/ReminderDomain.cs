using System;
using System.Threading;
using Reminder.Domain.Models;
using Reminder.Storage.Core;

namespace Reminder.Domain
{
	public class ReminderDomain: IDisposable
	{
		private IReminderStorage _storage;

		private readonly TimeSpan _awaitingRemindersCheckingPeriod;
		private readonly TimeSpan _readyRemindersSendingPeriod;

		private Timer _awaitingRemindersCheckingTimer;
		private Timer _readyRemindersSendingTimer;

		public Action<ReminderItem> SendReminder { get; set; }

		public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
		public event EventHandler<SendingFailedEventArgs> SendingFailed;

		public ReminderDomain(
			IReminderStorage storage,
			TimeSpan awaitingRemindersCheckingPeriod,
			TimeSpan readyRemindersSendingPeriod)
		{
			_storage = storage;
			_awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
			_readyRemindersSendingPeriod = readyRemindersSendingPeriod;
		}

		public ReminderDomain(IReminderStorage storage)
			: this(storage, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
		{
		}

		public void Run()
		{
			_awaitingRemindersCheckingTimer = new Timer(
				CheckAwaitingReminders,
				null,
				TimeSpan.Zero,
				_awaitingRemindersCheckingPeriod);

			_readyRemindersSendingTimer = new Timer(
				SendReadyReminders,
				null,
				TimeSpan.FromSeconds(1),
				_readyRemindersSendingPeriod);
		}

		private void SendReadyReminders(object state)
		{
			// find ready reminders
			// try "send"
			// if success update status to Sent
			// else update status to Failed
			
			var readyReminders = _storage.Get(ReminderItemStatus.Ready);
			foreach (var readyReminder in readyReminders)
			{
				try
				{
					// try "send"
					SendReminder(readyReminder);

					// update status to Sent
					_storage.Update(
						readyReminder.Id,
						ReminderItemStatus.Sent);

					// send event
					SendingSucceeded?.Invoke(
						this,
						new SendingSucceededEventArgs
						{
							SendingItem = readyReminder
						});
				}
				catch(Exception e)
				{
					// update status to Failed
					_storage.Update(
						readyReminder.Id,
						ReminderItemStatus.Failed);

					// send event
					SendingFailed?.Invoke(
						this,
						new SendingFailedEventArgs
						{
							SendingItem = readyReminder,
							SendingException = e
						});
				}
			}
		}

		private void CheckAwaitingReminders(object state)
		{
			// here we will check storage for awaiting items
			// check each for its date
			// if it is time to send, change the status to Ready

			var awaitingReminders = _storage.Get(ReminderItemStatus.Awaiting);
			foreach (var awaitingReminder in awaitingReminders)
			{
				if (awaitingReminder.IsReadyToSend)
				{
					_storage.Update(awaitingReminder.Id, ReminderItemStatus.Ready);
				}
			}
		}

		public void Dispose()
		{
			_awaitingRemindersCheckingTimer?.Dispose();
			_readyRemindersSendingTimer?.Dispose();
		}
	}
}
