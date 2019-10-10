using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory.Tests
{
	[TestClass]
	public class InMemoryReminderStorageTests
	{
		[TestMethod]
		public void Method_Add_Should_Add_New_Item_To_Internal_Dictionary()
		{
			// prepare test data
			DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
			const string contactId = "ABCD123";
			const string message = "test message";

			var item = new ReminderItem(date, message, contactId);
			var storage = new InMemoryReminderStorage();

			// do test
			storage.Add(item);

			// check results
			Assert.IsTrue(storage.Reminders.ContainsKey(item.Id));
			Assert.AreEqual(message, storage.Reminders[item.Id].Message);
			Assert.AreEqual(date, storage.Reminders[item.Id].Date);
			Assert.AreEqual(contactId, storage.Reminders[item.Id].ContactId);
		}

		[TestMethod]
		public void Method_Get_By_Id_Should_Return_Item_If_It_Exists()
		{
			// prepare test data
			DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
			const string contactId = "ABCD123";
			const string message = "test message";

			var expectedItem = new ReminderItem(date, message, contactId);
			var storage = new InMemoryReminderStorage();
			storage.Reminders.Add(expectedItem.Id, expectedItem);

			// do test
			var actualItem = storage.Get(expectedItem.Id);

			// check results
			Assert.IsNotNull(actualItem);
			Assert.AreEqual(expectedItem.Message, actualItem.Message);
			Assert.AreEqual(expectedItem.Date, actualItem.Date);
			Assert.AreEqual(expectedItem.ContactId, actualItem.ContactId);
			Assert.AreEqual(expectedItem.Status, actualItem.Status);
		}

		[TestMethod]
		public void Method_Get_By_Id_Should_Return_Null_If_Item_Not_Found()
		{
			// prepare test data
			DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
			const string contactId = "ABCD123";
			const string message = "test message";

			var expectedItem = new ReminderItem(date, message, contactId);
			var storage = new InMemoryReminderStorage();
			storage.Reminders.Add(expectedItem.Id, expectedItem);

			// do test
			var actualItem = storage.Get(Guid.NewGuid());

			// check results
			Assert.IsNull(actualItem);
		}

		[TestMethod]
		public void Method_Get_By_Status_Should_Return_List_Of_Items_If_They_Exists()
		{
			// prepare test data
			var expectedItem1 = new ReminderItem(DateTimeOffset.Now, "message 1", "ABCD123");
			var expectedItem2 = new ReminderItem(DateTimeOffset.Now, "message 2", "ABCD123");
			var expectedItem3 = new ReminderItem(DateTimeOffset.Now, "message 3", "ABCD123");
			var expectedItem4 = new ReminderItem(DateTimeOffset.Now, "message 4", "ABCD123");

			var storage = new InMemoryReminderStorage();

			expectedItem2.Status = ReminderItemStatus.Ready;
			expectedItem3.Status = ReminderItemStatus.Ready;
			expectedItem4.Status = ReminderItemStatus.Failed;

			storage.Reminders.Add(expectedItem1.Id, expectedItem1);
			storage.Reminders.Add(expectedItem2.Id, expectedItem2);
			storage.Reminders.Add(expectedItem3.Id, expectedItem3);
			storage.Reminders.Add(expectedItem4.Id, expectedItem4);

			// do test
			var actualItemList = storage.Get(ReminderItemStatus.Ready);

			// check results
			Assert.IsNotNull(actualItemList);
			Assert.AreEqual(2, actualItemList.Count);
			Assert.IsTrue(actualItemList.Contains(expectedItem2));
			Assert.IsTrue(actualItemList.Contains(expectedItem3));
		}

		[TestMethod]
		public void Method_Get_By_Status_Should_Return_Empty_List_If_Items_Not_Found()
		{
			// prepare test data
			var expectedItem1 = new ReminderItem(DateTimeOffset.Now, "message 1", "ABCD123");
			var expectedItem2 = new ReminderItem(DateTimeOffset.Now, "message 2", "ABCD123");
			var expectedItem3 = new ReminderItem(DateTimeOffset.Now, "message 3", "ABCD123");
			var expectedItem4 = new ReminderItem(DateTimeOffset.Now, "message 4", "ABCD123");

			var storage = new InMemoryReminderStorage();

			expectedItem2.Status = ReminderItemStatus.Ready;
			expectedItem3.Status = ReminderItemStatus.Ready;
			expectedItem4.Status = ReminderItemStatus.Failed;

			storage.Reminders.Add(expectedItem1.Id, expectedItem1);
			storage.Reminders.Add(expectedItem2.Id, expectedItem2);
			storage.Reminders.Add(expectedItem3.Id, expectedItem3);
			storage.Reminders.Add(expectedItem4.Id, expectedItem4);

			// do test
			var actualItemList = storage.Get(ReminderItemStatus.Sent);

			// check results
			Assert.IsNotNull(actualItemList);
			Assert.AreEqual(0, actualItemList.Count);
		}

		[TestMethod]
		public void Method_Update_Should_Update_Status_If_Item_Exists()
		{
			// prepare test data
			var expectedItem1 = new ReminderItem(DateTimeOffset.Now, "message 1", "ABCD123");
			var expectedItem2 = new ReminderItem(DateTimeOffset.Now, "message 2", "ABCD123");
			var expectedItem3 = new ReminderItem(DateTimeOffset.Now, "message 3", "ABCD123");
			var expectedItem4 = new ReminderItem(DateTimeOffset.Now, "message 4", "ABCD123");

			var storage = new InMemoryReminderStorage();

			expectedItem2.Status = ReminderItemStatus.Ready;
			expectedItem3.Status = ReminderItemStatus.Ready;
			expectedItem4.Status = ReminderItemStatus.Failed;

			storage.Reminders.Add(expectedItem1.Id, expectedItem1);
			storage.Reminders.Add(expectedItem2.Id, expectedItem2);
			storage.Reminders.Add(expectedItem3.Id, expectedItem3);
			storage.Reminders.Add(expectedItem4.Id, expectedItem4);

			// do test
			storage.Update(expectedItem1.Id, ReminderItemStatus.Sent);

			// check results
			Assert.AreEqual(
				ReminderItemStatus.Sent,
				storage.Reminders[expectedItem1.Id].Status);

			Assert.AreEqual(
				ReminderItemStatus.Ready,
				storage.Reminders[expectedItem2.Id].Status);

			Assert.AreEqual(
				ReminderItemStatus.Ready,
				storage.Reminders[expectedItem3.Id].Status);

			Assert.AreEqual(
				ReminderItemStatus.Failed,
				storage.Reminders[expectedItem4.Id].Status);
		}

		[TestMethod]
		public void Method_Update_Should_Not_Throw_Exception_If_Item_Does_Not_Exist()
		{
			// prepare test data
			var storage = new InMemoryReminderStorage();
			
			// do test and check results (all correct if no exception thrown)
			storage.Update(Guid.NewGuid(), ReminderItemStatus.Sent);
		}
	}
}
