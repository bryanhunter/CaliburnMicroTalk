using System;
using Caliburn.Micro;

namespace Wp7PageLifecycleLogging.ViewModels
{
    public class PageTwoViewModel : Screen
    {
        public PageTwoViewModel()
        {
            Log.Info("Constructor");

            Activated += PageTwoViewModel_Activated;
            Deactivated += PageTwoViewModel_Deactivated;
            ViewAttached += PageTwoViewModel_ViewAttached;
        }


        private static void PageTwoViewModel_ViewAttached(object sender, ViewAttachedEventArgs e)
        {
            Log.Info("PageTwoViewModel_ViewAttached");
        }

        private static void PageTwoViewModel_Deactivated(object sender, DeactivationEventArgs e)
        {
            Log.Info("PageTwoViewModel_Deactivated");
        }

        private static void PageTwoViewModel_Activated(object sender, ActivationEventArgs e)
        {
            Log.Info("PageTwoViewModel_Activated");
        }

        protected override void OnInitialize()
        {
            Log.Info("OnInitialize");
            base.OnInitialize();
        }

        protected override void OnActivate()
        {
            Log.Info("OnActivate");
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            Log.Info("OnDeactivate");
            base.OnDeactivate(close);
        }

        public override void CanClose(Action<bool> callback)
        {
            Log.Info("CanClose");
            base.CanClose(callback);
        }

        public override void AttachView(object view, object context)
        {
            Log.Info("AttachView");
            base.AttachView(view, context);
        }

        protected override void OnViewLoaded(object view)
        {
            Log.Info("OnViewLoaded");
            base.OnViewLoaded(view);
        }

        public override object GetView(object context)
        {
            Log.Info("GetView");
            return base.GetView(context);
        }
    }
}