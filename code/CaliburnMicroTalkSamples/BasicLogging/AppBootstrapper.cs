using System;
using Caliburn.Micro;

namespace BasicLogging
{
    public class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
        public AppBootstrapper()
        {
            // Define your logging early otherwise everything will get sent to the default NullLogger.
            
            // This is also a taste of how you override the defaults in Caliburn.Micro.             
            // Rather than inheriting from a base logger and asking LogManager to use our special derived logger 
            // Caliburn.Micro uses public static Func<> fields that you can set to a Func<> that does what you need.
            // Interesting stratgey-- it feels functional and lighter. 

            LogManager.GetLog = type => new ConsoleLogger(type);

            //  Same as:
            //  Func<Type, ILog> getLoggerFunc = type => new ConsoleLogger(type);
            //  LogManager.GetLog = getLoggerFunc;

            // You could easily write a logger func that chains multiple loggers or routes different types to different loggers.
        }
    }
}