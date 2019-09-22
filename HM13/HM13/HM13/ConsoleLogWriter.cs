using System;

namespace HM13
{
    public class ConsoleLogWriter : ILogWriter
    {
        public void LogError(string message)
        {
            Body(MessageType.Error, message);
        }

        public void LogInfo(string message)
        {
            Body(MessageType.Info, message);
        }

        public void LogWarning(string message)
        {
            Body(MessageType.Warning, message);
        }

        private void Body(MessageType messageType, string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff")}\t{messageType}\t{message}");
        }
    }
}
