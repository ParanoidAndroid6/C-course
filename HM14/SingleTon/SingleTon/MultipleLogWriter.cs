using System;
using System.Collections.Generic;
using static SingleTon.Program;

namespace SingleTon
{
    partial class Program
    {
        public class MultipleLogWriter : AbstractLogWriter
        {
            private static MultipleLogWriter _multipleLogWriter;

            IEnumerable<ILogWriter> _list;

            public MultipleLogWriter(params ILogWriter[] list)
            {
                _list = list;
            }

            public override void WriteSingleLog(MessageType messageType, string message)
            {
                GetFinalMessage(messageType, message);

                foreach (var writer in _list)
                {
                    switch (messageType)
                    {
                        case MessageType.Error:
                            writer.LogError(message);
                            break;
                        case MessageType.Info:
                            writer.LogInfo(message);
                            break;
                        case MessageType.Warning:
                            writer.LogWarning(message);
                            break;
                    }
                }
            }

            private MultipleLogWriter() { }

            public static MultipleLogWriter GetMultipleLog()
            {
                if (_multipleLogWriter == null)
                    _multipleLogWriter = new MultipleLogWriter();

                return _multipleLogWriter;
            }
        }
    }
}
