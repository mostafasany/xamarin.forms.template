using System;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Home.ViewModels;
using shellXamarin.Module.Home.BuinessServices;
using shellXamarin.Module.Home.Views;
using System.Globalization;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Home.Resources;

namespace shellXamarin.Module.Home
{
    public class HomeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var localService = containerProvider.Resolve<ILocalService>();
            localService.LanguageChanged += LocalService_LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterSingleton<IHomeService, HomeService>();
        }

        private void LocalService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            AppResources.Culture = new CultureInfo(e.Langauge.Id);
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
