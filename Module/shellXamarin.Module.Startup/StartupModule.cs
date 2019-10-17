using System;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Startup.BuinessServices;
using shellXamarin.Module.Startup.ViewModels;
using shellXamarin.Module.Startup.Views;


namespace shellXamarin.Module.Startup
{
    public class StartupModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StartupPage,StartupViewModel>();
            containerRegistry.RegisterSingleton<IStartupService, StartupService>();
        }

        public static void LoadModule(IModuleCatalog moduleCatalog, IModuleManager managerManager)
        {
            Type sampleModuleType = typeof(StartupModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            managerManager.LoadModule("StartupModule");
        }
    }
}
