using System;
using System.Collections;
using System.Collections.Generic;

namespace HM13
{
    public class MultipleLogWriter : ILogWriter
    {
        IEnumerable<ILogWriter> _list;

        public void LogError(string message)
        {
            foreach (var l in _list)
            {
                l.LogError(message);
            }
        }

        public void LogInfo(string message)
        {
            foreach (var l in _list)
            {
                l.LogInfo(message);
            }
        }

       public void LogWarning(string message)
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

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
