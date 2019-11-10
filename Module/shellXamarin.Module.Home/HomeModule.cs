using System;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Home.ViewModels;
using shellXamarin.Module.Home.BuinessServices;
using shellXamarin.Module.Home.Views;
using System.Globalization;
using shellXamarin.Module.Home.Resources;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;

namespace shellXamarin.Module.Home
{
    public class HomeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            ILanguageService localService = containerProvider.Resolve<ILanguageService>();
            localService.LanguageChanged += LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterSingleton<IHomeService, HomeService>();
        }

        private void LanguageChanged(Language language)
        {
            AppResources.Culture = new CultureInfo(language.Id);
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(HomeModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            if (loadModule)
                moduleManager.LoadModule(nameof(HomeModule));
        }
    }
}
