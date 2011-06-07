using System;
using Caliburn.Micro;

namespace BasicLogging
{
    public class ShellViewModel : Screen
    {
        static readonly ILog Log = LogManager.GetLog(typeof(ShellViewModel));

        public string NotOnTheView { get; set; }

        public void LogAWarning()
        {
            Log.Warn("Barabarians are at the gate!");
        }

    }
}