using System;

namespace HM13
{
    public class ConsoleLogWriter : ILogWriter
    {
       public void LogError(string message)
        {
            Body(MessageType.Error, "Error!");
        }

        public void LogInfo(string message)
        {
            Body(MessageType.Info, "Information!");
        }

        public void LogWarning(string message)
        {
            Body(MessageType.Warning, "Warning!");
        }

      private void Body(MessageType messageType, string message)
        {
            Console.WriteLine($"{DateTime.Now}\t {messageType}\t {message}");
        }
    }
}
