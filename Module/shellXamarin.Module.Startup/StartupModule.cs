using System;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Startup.BuinessServices;
using shellXamarin.Module.Startup.DataServices;
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
            containerRegistry.RegisterSingleton<IDataStartupService, DataStartupService>();
            containerRegistry.RegisterSingleton<IStartupService, StartupService>();
            containerRegistry.RegisterForNavigation<StartupPage, StartupViewModel>();
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(StartupModule);
            string moduleName = sampleModuleType.Name;
            if (moduleCatalog.Exists(moduleName))
                return;

            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            if (loadModule)
                moduleManager.LoadModule(moduleName);
        }
    }
}
