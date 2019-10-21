using Prism.Unity;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Account;
using shellXamarin.Module.Startup;
using shellXamarin.Module.Startup.BuinessServices;
using shellXamarin.Module.Home;
using shellXamarin.Module.Settings;
using shellXamarin.Module.Common;
using shellXamarin.Module.Common.Services;
using Xamarin.Forms;
using shellXamarin.ViewModels;

namespace shellXamarin
{
    public partial class App : PrismApplication
    {
        IModuleManager _moduleManager;
        IModuleCatalog _moduleCatalog;
        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            var localService = Container.Resolve<ILocalService>();
            localService.LanguageChanged += LanguageService_LanguageChanged;

            var startupService = Container.Resolve<IStartupService>();
            startupService.AppConfigureStarted += StartupService_AppConfigureStarted;
            await NavigationService.NavigateAsync("/StartupPage");
        }

        private void LanguageService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            //var appStyles = new AppStyles();
            //appStyles.ApplyTheme();

            // Application.Current.Resources.MergedDictionaries.Clear();
            //Application.Current.Resources.MergedDictionaries.Add(appStyles);
        }


        //TODO: We might not need this event if Prism Navigation Service Support AppShell
        private async void StartupService_AppConfigureStarted(object sender, AppConfigureStartedEventArgs e)
        {
            await NavigationService.NavigateAsync("/HomePage");
            //MainPage = new AppShell(Container, NavigationService);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MasterDetailsPage, MasterDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            _moduleCatalog = moduleCatalog;
            _moduleManager = Container.Resolve<IModuleManager>();
            CommonModule.AddModule(moduleCatalog, _moduleManager, true);
            StartupModule.AddModule(moduleCatalog, _moduleManager, true);
            HomeModule.AddModule(_moduleCatalog, _moduleManager, true);
            AccountModule.AddModule(_moduleCatalog, _moduleManager, true);
            SettingsModule.AddModule(_moduleCatalog, _moduleManager, true);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
