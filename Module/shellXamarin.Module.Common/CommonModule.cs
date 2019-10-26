using System;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;

namespace shellXamarin.Module.Common
{
    public class CommonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var localService = containerProvider.Resolve<ILanguageService>();
            localService.SetDefaultLanguage();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IEventBusService, EventBusService>();
            containerRegistry.RegisterSingleton<IPrefrencesService, PrefrencesService>();
            containerRegistry.RegisterSingleton<ILanguageService, LanguageService>();
            containerRegistry.RegisterSingleton<IExceptionService, ExceptionService>();
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(CommonModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            if (loadModule)
                moduleManager.LoadModule(nameof(CommonModule));
        }
    }
}
