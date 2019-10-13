using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Startup.BuinessServices;

namespace shellXamarin.Module.Startup.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IStartupService startupService;
        public StartupViewModel(INavigationService _navigationService,
            IStartupService _startupService)
        {
            navigationService = _navigationService;
            startupService = _startupService;
            Title = "Go To Home Page";
            IsBusy = true;
        }


        #region Commands

        #region RetryCommand

        public DelegateCommand NavigateLoginPage => new DelegateCommand(Navigate);

        private async void Navigate()
        {
            startupService.AppStarted();
        }

        #endregion

        #endregion
    }
}