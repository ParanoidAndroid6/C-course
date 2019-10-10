using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;

namespace Reminder.Domain.Tests
{
	[TestClass]
	public class ReminderDomainTests
	{
		[TestMethod]
		public void Method_Run_Should_Update_Ready_To_Send_Reminders_To_Status_Ready_From_Awiating()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));

			using (var domain = new ReminderDomain(
				storage,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromSeconds(1)))
			{
				domain.Run();
				System.Threading.Thread.Sleep(200);
			}

			var readyList = storage.Get(ReminderItemStatus.Ready);
			Assert.IsNotNull(readyList);
			Assert.AreEqual(1, readyList.Count);
		}

		[TestMethod]
		public void Method_Run_Should_Call_Failed_Event_When_Sending_Thrown_Exception()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));

			bool failedEventCalled = false;

			using (var domain = new ReminderDomain(
				storage,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromSeconds(50)))
			{
				domain.SendReminder += (reminder) =>
				{
					throw new Exception("test exception");
				};

				domain.SendingFailed += (s, e) =>
				{
					if (e.SendingException.Message == "test exception")
					{
						failedEventCalled = true;
					}
				};

				domain.Run();
				System.Threading.Thread.Sleep(1200);
			}

			Assert.IsTrue(failedEventCalled);
		}

		[TestMethod]
		public void Method_Run_Should_Call_Succeedded_Event_When_Sending_Thrown_Exception()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));

			bool succeededEventCalled = false;

			using (var domain = new ReminderDomain(
				storage,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromSeconds(50)))
			{
				domain.SendReminder += (reminder) => { };

				domain.SendingSucceeded += (s, e) =>
				{
					succeededEventCalled = true;
				};

				domain.Run();
				System.Threading.Thread.Sleep(1200);
			}

			Assert.IsTrue(succeededEventCalled);
		}

		[TestMethod]
		public void Method_Run_Should_Call_SendReminder_Method_For_Particular_Item()
		{
			var storage = new InMemoryReminderStorage();
			storage.Add(new ReminderItem(DateTimeOffset.Now, "test message", null));

			bool sendReminderDelegateCalled = false;

			using (var domain = new ReminderDomain(
				storage,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromSeconds(50)))
			{
				domain.SendReminder += (ReminderItem r) => 
				{
					if (r.Message == "test message")
					{
						sendReminderDelegateCalled = true;
					}
				};

				domain.Run();
				System.Threading.Thread.Sleep(1200);
			}

			Assert.IsTrue(sendReminderDelegateCalled);
		}
	}
}
