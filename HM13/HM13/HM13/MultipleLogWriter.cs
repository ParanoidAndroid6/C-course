using System.Collections.Generic;
using System.Linq;
namespace HM13
{
    public class MultipleLogWriter : ILogWriter
    {
        IEnumerable<ILogWriter> _list;

        public MultipleLogWriter(params ILogWriter[] list)
        {
            _list = list;
        }

        public void LogError(string message)
        {
            foreach (var i in _list)
            {
                i.LogError(message);
            }
        }

        public void LogInfo(string message)
        {
            foreach (var i in _list)
            {
                i.LogInfo(message);
            }
        }

        public void LogWarning(string message)
        {
            foreach (var i in _list)
            {
                i.LogWarning(message);
            }
        }
    }
}
