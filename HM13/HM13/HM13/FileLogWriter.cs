using System;
using System.IO;
using System;
using System.IO;
using System.Text;

namespace HM13
{
    public class FileLogWriter : ILogWriter
    {
        public string path = @"D:\file.txt";

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
            using (var streamWriter = new StreamWriter(path, true, Encoding.UTF8))
            {
                streamWriter.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff")}\t{messageType}\t{message}");
            }
        }
    }
}
