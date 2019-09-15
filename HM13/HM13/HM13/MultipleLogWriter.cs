using System;
using System.Collections;
using System.Collections.Generic;

namespace HM13
{
    public class MultipleLogWriter : ILogWriter
    {
        IEnumerable<ILogWriter> _list;

        void ILogWriter.LogError(string message)
        {
            foreach (var l in _list)
            {
                l.LogError(message);
            }
        }

        void ILogWriter.LogInfo(string message)
        {
            foreach (var l in _list)
            {
                l.LogInfo(message);
            }
        }

        void ILogWriter.LogWarning(string message)
        {
            foreach (var l in _list)
            {
                l.LogWarning(message);
            }
        }

        public MultipleLogWriter(List<ILogWriter> list)
        {
            _list = list;
        }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
