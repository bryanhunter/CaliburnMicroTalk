namespace Wp7PageLifecycleLogging.ViewModels
{
    using System;
    using Caliburn.Micro;

    public class MainPageViewModel
    {
        readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void GotoPageTwo()
        {
            _navigationService.Navigate(new Uri("/Views/PageTwoView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}