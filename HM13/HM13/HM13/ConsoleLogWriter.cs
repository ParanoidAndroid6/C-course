using System;

namespace HM13
{
    public class ConsoleLogWriter : ILogWriter
    {
        void ILogWriter.LogError(string message)
        {
            Body(MessageType.Error, "Error!");
        }

        void ILogWriter.LogInfo(string message)
        {
            Body(MessageType.Info, "Information!");
        }

        void ILogWriter.LogWarning(string message)
        {
            Body(MessageType.Warning, "Warning!");
        }

      private void Body(MessageType messageType, string message)
        {
            Console.WriteLine($"{DateTime.Now}\t {messageType}\t {message}");
        }
    }
}
