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

        
    }
}
