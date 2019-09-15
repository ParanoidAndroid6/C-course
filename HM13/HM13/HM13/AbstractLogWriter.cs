using System;
using System.Collections.Generic;
using System.IO;

namespace HM13
{
    public abstract class AbstractLogWriter : ILogWriter
    {
        public abstract void LogError(string message);

        public abstract void LogInfo(string message);

        public abstract void LogWarning(string message);

        public virtual void WriteToConsole(MessageType messageType, string message)
        {
            Console.WriteLine($"{DateTime.Now}\t {messageType}\t {message}");
        }

        public string path = @"D:\file.txt";

        public virtual void WriteToFile(MessageType messageType, string message)
        {
            using (var sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine($"{DateTime.Now}\t {messageType}\t {message}");
            }
        }
    }

}
