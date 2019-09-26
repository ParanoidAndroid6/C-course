using System.IO;

namespace SingleTon
{
    partial class Program
    {
        public class FileLogWriter : AbstractLogWriter
        {
            private static FileLogWriter _fileLogWriter;

            public static string Fullpath = @"D:\file.txt";

            private FileLogWriter(string path)
            {
                Fullpath = path;
            }

            public override void WriteSingleLog(MessageType messageType, string message)
            {
                using (var sw = new StreamWriter(Fullpath, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(GetFinalMessage(messageType, message));
                }
            }

            private FileLogWriter() { }

            public static FileLogWriter GetFileWriter(string path)
            {
                if (_fileLogWriter == null)
                    _fileLogWriter = new FileLogWriter(path);

                return _fileLogWriter;
            }
        }
    }
}
