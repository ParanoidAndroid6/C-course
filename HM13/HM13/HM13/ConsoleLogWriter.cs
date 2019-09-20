using System;

namespace HM13
{
    public class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        public override void LogError(string message)
        {
            WriteToConsole(MessageType.Error, "Error!");
        }

        public override void LogInfo(string message)
        {
            WriteToConsole(MessageType.Info, "Information!");
        }

        public override void LogWarning(string message)
        {
            WriteToConsole(MessageType.Warning, "Warning!");
        }

        public void WriteToConsole(MessageType messageType, string message)
        {
            Console.WriteLine($"{DateTime.Now}\t {messageType}\t {message}");
        }
    }
}
}
