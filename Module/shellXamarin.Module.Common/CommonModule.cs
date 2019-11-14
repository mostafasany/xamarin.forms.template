using System;
using System.Globalization;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Resources;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.DatabaseService;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.Services.ResourceService;
using shellXamarin.Module.Common.Services.SharedService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Common.Views;

namespace shellXamarin.Module.Common
{
    public class CommonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var localService = containerProvider.Resolve<ILanguageService>();
            localService.SetDefaultLanguage();
            localService.LanguageChanged += LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GenericListViewPage, GenericListViewPageViewModel>();
            containerRegistry.RegisterSingleton<IEventBusService, EventBusService>();
            containerRegistry.RegisterSingleton<IPrefrencesService, PrefrencesService>();
            containerRegistry.RegisterSingleton<ILanguageService, LanguageService>();
            containerRegistry.RegisterSingleton<IExceptionService, ExceptionService>();
            containerRegistry.RegisterSingleton<ISharedService, SharedService>();
            containerRegistry.RegisterSingleton<IDatabaseService, DatabaseService>();
            containerRegistry.RegisterSingleton<IResourceService, ResourceService>();
        }

        private void LanguageChanged(Language language)
        {
            AppResources.Culture = new CultureInfo(language.Id);
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(CommonModule);
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
