namespace Wp7PageLifecycleLogging.Framework
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Phone.Tasks;
    using Caliburn.Micro;
    using Wp7PageLifecycleLogging.ViewModels;

    public class Wp7PageLifecycleLoggingBootstrapper : PhoneBootstrapper
    {
        PhoneContainer container;

        public Wp7PageLifecycleLoggingBootstrapper()
        {
            LogManager.GetLog = type => new DebugLogger(type);
        }

        protected override void Configure()
        {
            container = new PhoneContainer(this);

            container.RegisterSingleton(typeof(MainPageViewModel), "MainPageViewModel", typeof(MainPageViewModel));
            container.RegisterSingleton(typeof(PageTwoViewModel), "PageTwoViewModel", typeof(PageTwoViewModel));
            
            container.RegisterInstance(typeof(INavigationService), null, new FrameAdapter(RootFrame));
            container.RegisterInstance(typeof(IPhoneService), null, new PhoneApplicationServiceAdapter(PhoneService));

            container.Activator.InstallChooser<PhoneNumberChooserTask, PhoneNumberResult>();
            container.Activator.InstallLauncher<EmailComposeTask>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}