using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Module.Home.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigationService _navigationService)
        {
            NavigationService = _navigationService;
        }


        #region Commands

        #region NavigateToSettingsPageCommand

        public DelegateCommand NavigateToSettingsPageCommand => new DelegateCommand(NavigateToSettingsPage);

        private async void NavigateToSettingsPage()
        {
            await NavigationService.NavigateAsync("/SettingsPage");
        }

        #endregion


        #region NavigateToLoginPageCommand

        public DelegateCommand NavigateToLoginPageCommand => new DelegateCommand(NavigateToLoginPage);

        private async void NavigateToLoginPage()
        {
            await NavigationService.NavigateAsync("/LoginPage");
        }

        #endregion

        #endregion
    }
}