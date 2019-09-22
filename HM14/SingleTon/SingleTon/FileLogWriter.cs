using System.IO;

namespace SingleTon
{
    partial class Program
    {
        public class FileLogWriter : AbstractLogWriter
        {
            private static FileLogWriter _fileLogWriter;

            public string path = @"D:\file.txt";

            public override void WriteSingleLog(MessageType messageType, string message)
            {
                using (var sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(GetFinalMessage(messageType, message));
                }
            }

            private FileLogWriter() { }

            public static FileLogWriter GetFileWriter()
            {
                if (_fileLogWriter == null)
                    _fileLogWriter = new FileLogWriter();

                return _fileLogWriter;
            }
        }
    }
}
