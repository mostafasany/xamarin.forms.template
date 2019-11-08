using Prism.Unity;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Account;
using shellXamarin.Module.Startup;
using shellXamarin.Module.Home;
using shellXamarin.Module.Settings;
using shellXamarin.Module.Common;
using shellXamarin.Module.Navigation;
using shellXamarin.Module.ElLa3eba;

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
            await NavigationService.NavigateAsync("/StartupPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //TODO: May be not loadig all modules
            IModuleManager moduleManager = Container.Resolve<IModuleManager>();
            CommonModule.AddModule(moduleCatalog, moduleManager, true);
            StartupModule.AddModule(moduleCatalog, moduleManager, true);
            NavigationModule.AddModule(moduleCatalog, moduleManager, true);
            HomeModule.AddModule(moduleCatalog, moduleManager, true);
            AccountModule.AddModule(moduleCatalog, moduleManager, true);
            SettingsModule.AddModule(moduleCatalog, moduleManager, true);
            ElLa3ebaModule.AddModule(moduleCatalog, moduleManager, true);
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
