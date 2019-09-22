using System;

namespace SingleTon
{
    partial class Program
    {
        public class ConsoleLogWriter : AbstractLogWriter
        {
            private static ConsoleLogWriter _consoleLogWriter;

            public override void WriteSingleLog(MessageType messageType, string message)
            {
                Console.WriteLine(GetFinalMessage(messageType, message));
            }

            private ConsoleLogWriter() { }

            public static ConsoleLogWriter GetConsole()
            {
                if(_consoleLogWriter == null)
                _consoleLogWriter = new ConsoleLogWriter();

                return _consoleLogWriter;
            }
        }
    }
}
