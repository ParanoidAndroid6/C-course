using System;
using System.IO;

namespace HM13
{
    public class FileLogWriter : ILogWriter
    {
        public string path = @"D:\file.txt";

        public void LogError(string message)
        {
            Body(MessageType.Error, "File_Error!");
        }

        public void LogInfo(string message)
        {
            Body(MessageType.Info, "File_Information!");
        }

        public void LogWarning(string message)
        {
            Body(MessageType.Warning, "File_Warning!");
        }

        private void Body(MessageType messageType, string message)
        {
            using (var sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine($"{DateTime.Now}\t {messageType}\t {message}");
            }
        }
    }
}
