using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using Caliburn.Micro;

namespace GameLibrary.Framework
{
    [Export(typeof (ILog))]
    public class DebugLog : ILog
    {
        private readonly Type _type;

        public DebugLog(Type type)
        {
            _type = type;
        }

        #region ILog Members

        public void Info(string format, params object[] args)
        {
            Debug.WriteLine("INFO: " + format, args);
        }

        public void Warn(string format, params object[] args)
        {
            Debug.WriteLine("WARN: " + format, args);
        }

        public void Error(Exception exception)
        {
            Debug.WriteLine("ERROR: {0}\n{1}", _type.Name, exception);
        }

        #endregion
    }
}