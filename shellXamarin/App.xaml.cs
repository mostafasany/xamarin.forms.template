using Prism.Unity;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Startup;
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

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("/StartupPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            IModuleManager moduleManager = Container.Resolve<IModuleManager>();
            CommonModule.AddModule(moduleCatalog, moduleManager, true);
            StartupModule.AddModule(moduleCatalog, moduleManager, true);
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
