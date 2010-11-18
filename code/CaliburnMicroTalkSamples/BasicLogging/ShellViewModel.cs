using System;
using Caliburn.Micro;

namespace BasicLogging
{
    public class ShellViewModel : Screen
    {
        public string NotOnTheView { get; set; }

        public void LogAWarning()
        {
            // Screen includes a protected static readonly Log field
            Log.Warn("Barabarians are at the gate!");
        }

    }
}