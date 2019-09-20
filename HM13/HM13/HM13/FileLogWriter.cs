using System;
using System.IO;

namespace HM13
{
    public class FileLogWriter : AbstractLogWriter, ILogWriter
    {
        public string path = @"D:\file.txt";

        public override void LogError(string message)
        {
            WriteToFile(MessageType.Error, "File_Error!");
        }

        public override void LogInfo(string message)
        {
            WriteToFile(MessageType.Info, "File_Information!");
        }

        public override void LogWarning(string message)
        {
            WriteToFile(MessageType.Warning, "File_Warning!");
        }

        public void WriteToFile(MessageType messageType, string message)
        {
            using (var sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine($"{DateTime.Now}\t {messageType}\t {message}");
            }
        }
    }
}
