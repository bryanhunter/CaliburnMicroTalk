using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using RecipeAppCommon.Framework;

namespace ShellShowsListWhichShowsDetails
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LogManager.GetLog = x => new ConsoleLog(x);
        }
    }
}
