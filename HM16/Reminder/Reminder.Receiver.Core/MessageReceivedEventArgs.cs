namespace Reminder.Receiver.Core
{
	public class MessageReceivedEventArgs
	{
		public string ContactId { get; set; }

		public string Message { get; set; }
	}
}
