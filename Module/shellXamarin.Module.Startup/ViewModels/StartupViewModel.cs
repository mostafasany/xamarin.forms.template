using Prism.Commands;
using Prism.Modularity;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Startup.BuinessServices;
using shellXamarin.Module.Home;
using shellXamarin.Module.Settings;
using shellXamarin.Module.Account;
using shellXamarin.Module.Navigation;
using shellXamarin.Module.ElLa3eba;

namespace shellXamarin.Module.Startup.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        private readonly IStartupService _startupService;
        private readonly IModuleCatalog _moduleCatalog;
        private readonly IModuleManager _moduleManager;
        public StartupViewModel(IStartupService startupService, INavigationService _navigationService,
            IEventBusService eventBusService, IExceptionService exceptionService,
            ILanguageService localService, IModuleCatalog moduleCatalog, IModuleManager moduleManager)
            : base(localService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _startupService = startupService;
            _moduleCatalog = moduleCatalog;
            _moduleManager = moduleManager;
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
            {
                NavigationModule.AddModule(_moduleCatalog, _moduleManager, true);
                HomeModule.AddModule(_moduleCatalog, _moduleManager, true);
                AccountModule.AddModule(_moduleCatalog, _moduleManager, true);
                SettingsModule.AddModule(_moduleCatalog, _moduleManager, true);
                ElLa3ebaModule.AddModule(_moduleCatalog, _moduleManager, true);
                await NavigateHome();
            }

            else
                IsBusy = false;
        }

        #endregion

        #region Commands

        public DelegateCommand NavigateLoginPageCommand => new DelegateCommand(Navigate);

        #endregion
    }
}