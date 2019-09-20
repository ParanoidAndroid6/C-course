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

    }
}
