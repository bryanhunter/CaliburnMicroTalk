using System;
using Caliburn.Micro;

namespace BasicLogging
{
    public class ConsoleLogger : ILog
    {
        private readonly Type _type;

        public ConsoleLogger(Type type)
        {
            _type = type;
        }

        public void Error(Exception exception)
        {
            Console.WriteLine(CreateLogMessage("Error", exception.ToString()));
        }

        public void Info(string format, params object[] args)
        {
            Console.WriteLine(CreateLogMessage("Info", format, args));
        }

        public void Warn(string format, params object[] args)
        {
            Console.WriteLine(CreateLogMessage("Warn", format, args));
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