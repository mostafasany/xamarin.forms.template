using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Startup.BuinessServices;

namespace shellXamarin.Module.Startup.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        private readonly IStartupService _startupService;
        public StartupViewModel(INavigationService _navigationService, IEventBusService eventBusService, IExceptionService exceptionService,
            IStartupService startupService, ILanguageService localService)
            : base(localService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _startupService = startupService;
            IsBusy = true;
        }

        #region Properties

        #endregion

        #region Methods

        private async void Navigate()
        {
            await NavigateHome();
        }

        #endregion

        #region Navigation

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            bool canProceed = await _startupService.CanProceed();
            if (canProceed)
                await NavigateHome();
            else
                IsBusy = false;
        }

        #endregion

        #region Commands

        public DelegateCommand NavigateLoginPageCommand => new DelegateCommand(Navigate);

        #endregion
    }
}