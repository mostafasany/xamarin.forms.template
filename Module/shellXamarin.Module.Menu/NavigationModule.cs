using System;
using System.Globalization;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Navigation.Resources;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Navigation.BuinessServices;
using shellXamarin.Module.Navigation.DataServices;
using shellXamarin.Module.Navigation.ViewModels;
using shellXamarin.Module.Navigation.Views;
using Xamarin.Forms;

namespace shellXamarin.Module.Navigation
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var localService = containerProvider.Resolve<ILocalService>();
            localService.LanguageChanged += LocalService_LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeTabbedPage, HomeTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterDetailsPage, MasterDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
            containerRegistry.RegisterSingleton<IMenuDataService, MenuDataService>();
        }

        private void LocalService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            AppResources.Culture = new CultureInfo(e.Langauge.Id);
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(NavigationModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            if (loadModule)
                moduleManager.LoadModule(nameof(NavigationModule));
        }
    }
}
