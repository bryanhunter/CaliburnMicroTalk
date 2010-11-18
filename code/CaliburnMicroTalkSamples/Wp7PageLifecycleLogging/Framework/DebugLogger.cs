using System;
using System.Diagnostics;
using Caliburn.Micro;

namespace Wp7PageLifecycleLogging.Framework
{
    public class DebugLogger : ILog
    {
        private readonly Type _type;

        public DebugLogger(Type type)
        {
            _type = type;
        }

        public void Error(Exception exception)
        {
            Debug.WriteLine(CreateLogMessage("Error", exception.ToString()));
        }

        public void Info(string format, params object[] args)
        {
            Debug.WriteLine(CreateLogMessage("Info", format, args));
        }

        public void Warn(string format, params object[] args)
        {
            Debug.WriteLine(CreateLogMessage("Warn", format, args));
        }

        private string CreateLogMessage(string logLevel, string format, params object[] args)
        {
            return string.Format("[{0}] [{1}]:[{2}] - {3}",
                                 DateTime.Now.ToString("o"),
                                 logLevel,
                                 _type.FullName,
                                 string.Format(format, args));
        }
    }
}