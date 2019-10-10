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
        public void Method_Add_Should_Add_New_Item_To_Internal_Dictionary()
        {

            // prepare test data
            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            

            DateTimeOffset date = DateTimeOffset.Parse(
                "2010-01-01T00:00:00");
            const string contactId = "0123ABC";
            const string message = "Test message";


            // do test
            var reminderItem = new ReminderItem(
                date, message, contactId);

            inMemoryReminderStorage.Add(reminderItem);


            // check results
            Assert.IsTrue(inMemoryReminderStorage.Reminders.ContainsKey(reminderItem.Id));
            Assert.AreEqual(message, inMemoryReminderStorage.Reminders[reminderItem.Id].Message);
            Assert.AreEqual(date, inMemoryReminderStorage.Reminders[reminderItem.Id].Date);
            Assert.AreEqual(contactId, inMemoryReminderStorage.Reminders[reminderItem.Id].ContactId);

        }

        [TestMethod]
        public void Method_Get_By_Id_Should_Return_Value_If_Dictionary_Contains_Items()
        {
            // prepare test data

            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            

            DateTimeOffset date = DateTimeOffset.Parse(
                "2010-01-01T00:00:00");
            const string contactId = "0123ABC";
            const string message = "Test message";

            // do test
            var reminderItem = new ReminderItem(
                date, message, contactId);

            inMemoryReminderStorage.Reminders.Add(reminderItem.Id, reminderItem);
            var result = inMemoryReminderStorage.Get(reminderItem.Id);

            // check results
            
            Assert.IsNotNull(result);
           
        }

        [TestMethod]
        public void Method_Get_By_Id_Should_Return_Null_If_Dictionary_Contains_No_Items()
        {
            // prepare test data

            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();

            // do test

            var result = inMemoryReminderStorage.Get(Guid.NewGuid());

            // check results

            Assert.IsNull(result);

        }

        [TestMethod]
        public void Method_Get_By_Status_Should_Return_Null_If_Dictionary_Contains_No_Items()
        {
            // prepare test data

            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();

            // do test

            List<ReminderItem> reminderItems = inMemoryReminderStorage.Get(ReminderItemStatus.Sent);

            // check results

            Assert.IsNotNull(reminderItems);
            Assert.IsNotNull(reminderItems.Count);
        }

        [TestMethod]
        public void Method_Get_By_Status_Should_Return_Value_If_Dictionary_Contains_Items()
        {
            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();


            DateTimeOffset date = DateTimeOffset.Parse(
                "2010-01-01T00:00:00");
            const string contactId = "0123ABC";
            const string message = "Test message";

            // do test
            var reminderItem = new ReminderItem(
                date, message, contactId);

            inMemoryReminderStorage.Add(reminderItem);
            List<ReminderItem> list = inMemoryReminderStorage.Get(ReminderItemStatus.Awaiting);
            // check results

            Assert.AreEqual(ReminderItemStatus.Awaiting, reminderItem.Status);

        }

        [TestMethod]
        public void Method_Update_Is_Working()
        {
            // prepare test data

            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();
            

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

        [TestMethod]
        public void Method_Update_Is_Working_With_Empty_Storage()
        {
            // prepare test data

            InMemoryReminderStorage inMemoryReminderStorage = new InMemoryReminderStorage();

            // do test
           
            // check results

            inMemoryReminderStorage.Update(Guid.NewGuid(), ReminderItemStatus.Sent);

        }
    }
}
