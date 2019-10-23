using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Startup.BuinessServices;

namespace shellXamarin.Module.Startup.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        private readonly IStartupService startupService;
        public StartupViewModel(INavigationService _navigationService,
            IStartupService _startupService, ILocalService localService)
            : base(localService)
        {
            NavigationService = _navigationService;
            startupService = _startupService;
            IsBusy = true;
        }

        #region Properties

        #endregion


        #region Methods

        #endregion

        #region Navigation

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            bool canProceed = await startupService.CanProceed();
            if (canProceed)
                await NavigateHome();
            else
                IsBusy = false;
        }

        #endregion

        #region Commands

        #region RetryCommand

        public DelegateCommand NavigateLoginPageCommand => new DelegateCommand(Navigate);

        private async void Navigate()
        {
            await NavigateHome();
        }

        #endregion

        #endregion
    }
}