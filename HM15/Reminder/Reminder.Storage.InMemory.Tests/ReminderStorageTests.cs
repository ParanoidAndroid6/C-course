using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using Reminder.Storage.InMemory;

namespace Reminder.Storage.InMemory.Tests
{
    [TestClass]
    public class ReminderStorageTests
    {
        public void RunOnce()
        {

        }

        [TestMethod]
        public void Method_Add_Is_Working_Correctly()
        {

            // prepare test data
            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Reminders = new Dictionary<Guid, ReminderItem>();

            DateTimeOffset date = DateTimeOffset.Parse(
                "2010-01-01T00:00:00");
            const string contactId = "0123ABC";
            const string message = "Test message";


            // do test
            var reminderItem = new ReminderItem(
                date, message, contactId);

            inMemoryReminderStorage.Add(reminderItem);


            // check results

            Assert.AreNotEqual(inMemoryReminderStorage.Equals(null), inMemoryReminderStorage);

        }

        [TestMethod]
        public void Method_Get_Is_Working()
        {
            // prepare test data

            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Reminders = new Dictionary<Guid, ReminderItem>();

            DateTimeOffset date = DateTimeOffset.Parse(
                "2010-01-01T00:00:00");
            const string contactId = "0123ABC";
            const string message = "Test message";

            // do test
            var reminderItem = new ReminderItem(
                date, message, contactId);

            inMemoryReminderStorage.Add(reminderItem);
            inMemoryReminderStorage.Get(reminderItem.Id);
            


            // check results

            Assert.AreEqual(reminderItem.Status, ReminderItemStatus.Awaiting);
           
        }

        [TestMethod]
        public void Method_Update_Is_Working()
        {
            // prepare test data

            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            inMemoryReminderStorage.Reminders = new Dictionary<Guid, ReminderItem>();

            DateTimeOffset date = DateTimeOffset.Parse(
                "2010-01-01T00:00:00");
            const string contactId = "0123ABC";
            const string message = "Test message";

            // do test
            var reminderItem = new ReminderItem(
                date, message, contactId);

            inMemoryReminderStorage.Add(reminderItem);
            inMemoryReminderStorage.Update(reminderItem.Id, ReminderItemStatus.Ready);



            // check results

            Assert.AreEqual(reminderItem.Status, ReminderItemStatus.Ready);


        }
    }
}
