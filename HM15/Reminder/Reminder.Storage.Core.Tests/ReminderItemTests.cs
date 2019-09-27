using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemTests
	{
		public void RunOnce()
		{

		}

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
	}
}
