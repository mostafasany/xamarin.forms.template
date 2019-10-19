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

namespace shellXamarin
{
    public partial class App : PrismApplication
    {
        public App() : this(null)
        {
        }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            var startupService = Container.Resolve<IStartupService>();
            startupService.AppConfigureStarted += StartupService_AppConfigureStarted;
            await NavigationService.NavigateAsync("/StartupPage");
        }

        private async void StartupService_AppConfigureStarted(object sender, AppConfigureStartedEventArgs e)
        {
            await NavigationService.NavigateAsync("/HomePage");
            //MainPage = new AppShell();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var  moduleManager= Container.Resolve<IModuleManager>();
            CommonModule.LoadModule(moduleCatalog, moduleManager);
            StartupModule.LoadModule(moduleCatalog, moduleManager);
            HomeModule.LoadModule(moduleCatalog, moduleManager);
            AccountModule.LoadModule(moduleCatalog, moduleManager);
            SettingsModule.LoadModule(moduleCatalog, moduleManager);
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
