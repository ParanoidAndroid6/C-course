using System;

namespace SingleTon
{
    partial class Program
    {
        public abstract class AbstractLogWriter : ILogWriter
        {

            public void LogError(string message)
            {
                WriteSingleLog(MessageType.Error, message);
            }

            public void LogInfo(string message)
            {
                WriteSingleLog(MessageType.Info, message);
            }

            public void LogWarning(string message)
            {
                WriteSingleLog(MessageType.Warning, message);
            }

            public string GetFinalMessage(MessageType messageType, string message)
            {
                return $"{DateTime.Now}\t{messageType}\t{message}";
            }

            public abstract void WriteSingleLog(MessageType messageType, string message);

        }
    }
}
