using System;
using System.Collections;
using System.Collections.Generic;

namespace HM13
{
    public class MultipleLogWriter : AbstractLogWriter, ILogWriter
    {
        public IEnumerable<ILogWriter> _list;

        public override void LogError(string message)
        {
            foreach (var l in _list)
            {
                l.LogError(message);
            }
        }

        public override void LogInfo(string message)
        {
            foreach (var l in _list)
            {
                l.LogInfo(message);
            }
        }

        public override void LogWarning(string message)
        {
            foreach (var l in _list)
            {
                l.LogWarning(message);
            }
        }

        public MultipleLogWriter(params ILogWriter[] list)
        {
            _list = list;
        }
    }
}
