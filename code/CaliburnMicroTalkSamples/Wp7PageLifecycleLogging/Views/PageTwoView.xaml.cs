using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Caliburn.Micro;
using Microsoft.Phone.Controls;

namespace Wp7PageLifecycleLogging.Views
{
    public partial class PageTwoView : PhoneApplicationPage
    {
        
        protected static readonly ILog Log = LogManager.GetLog(typeof(PageTwoView));

        public PageTwoView()
        {
            Log.Info("Constructor");

            InitializeComponent();

            this.BeginLayoutChanged += PageTwoView_BeginLayoutChanged;
            this.LayoutUpdated += PageTwoView_LayoutUpdated;
            this.Loaded += PageTwoView_Loaded;
            this.Unloaded += PageTwoView_Unloaded;   
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            Log.Info("OnNavigatedTo");
            base.OnNavigatedTo(e);
        }

        static void PageTwoView_Unloaded(object sender, RoutedEventArgs e)
        {
            Log.Info("PageTwoView_Unloaded");
        }

        static void PageTwoView_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Info("PageTwoView_Loaded");
        }

        static void PageTwoView_BeginLayoutChanged(object sender, OrientationChangedEventArgs e)
        {
            Log.Info("PageTwoView_BeginLayoutChanged");
        }

        static void PageTwoView_LayoutUpdated(object sender, EventArgs e)
        {
            Log.Info("PageTwoView_LayoutUpdated");
        }
    }
}