using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemTests
	{
		[TestMethod]
		public void Constructor_Paremeters_Should_Fill_Properties_Correctly()
		{
			// prepare test data
			DateTimeOffset date = DateTimeOffset.Parse(
				"2010-01-01T00:00:00");
			const string contactId = "0123ABC";
			const string message = "Test message";

			// do test
			var reminderItem = new ReminderItem(
				date, message, contactId);

			// check results
			Assert.IsNotNull(reminderItem);
			Assert.AreEqual(date, reminderItem.Date);
			Assert.AreEqual(message, reminderItem.Message);
			Assert.AreEqual(contactId, reminderItem.ContactId);
		}

		[TestMethod]
		public void Constructor_Should_Fill_Id_Other_Than_Guid_Empty()
		{
			// prepare test data
			DateTimeOffset date = DateTimeOffset.Parse(
				"2010-01-01T00:00:00");
			const string contactId = "0123ABC";
			const string message = "Test message";

			// do test
			var reminderItem = new ReminderItem(
				date, message, contactId);

			// check results
			Assert.AreNotEqual(Guid.Empty, reminderItem.Id);
		}

		[TestMethod]
		public void IsReadyToSend_Property_Should_Return_Flase_For_Future_Date()
		{
			// prepare test data
			var reminderItem = new ReminderItem(
				DateTimeOffset.UtcNow.AddDays(1), null, null);

			// do test
			bool actual = reminderItem.IsReadyToSend;

			// check results
			Assert.IsFalse(actual);
		}

		[TestMethod]
		public void IsReadyToSend_Property_Should_Return_True_For_Past_Date()
		{
			// prepare test data
			var reminderItem = new ReminderItem(
				DateTimeOffset.UtcNow.AddDays(-1), null, null);

			// do test
			bool actual = reminderItem.IsReadyToSend;

			// check results
			Assert.IsTrue(actual);
		}


		[TestMethod]
		public void TimeToAlarm_Property_Should_Return_Positive_Time_For_Future_Date()
		{
			// prepare test data
			var reminderItem = new ReminderItem(
				DateTimeOffset.UtcNow.AddDays(1), null, null);

			// do test
			TimeSpan actual = reminderItem.TimeToAlarm;

			// check results
			Assert.IsTrue(actual.TotalMilliseconds > 0);
		}

		[TestMethod]
		public void TimeToAlarm_Property_Should_Return_Negative_Time_For_Past_Date()
		{
			// prepare test data
			var reminderItem = new ReminderItem(
				DateTimeOffset.UtcNow.AddDays(-1), null, null);

			// do test
			TimeSpan actual = reminderItem.TimeToAlarm;

			// check results
			Assert.IsTrue(actual.TotalMilliseconds < 0);
		}
	}
}
