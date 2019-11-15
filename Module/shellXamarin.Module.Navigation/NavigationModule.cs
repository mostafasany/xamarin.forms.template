using System;
using System.Globalization;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Common.Resources;
using shellXamarin.Module.Navigation.BuinessServices;
using shellXamarin.Module.Navigation.DataServices;
using shellXamarin.Module.Navigation.ViewModels;
using shellXamarin.Module.Navigation.Views;
using Xamarin.Forms;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;

namespace shellXamarin.Module.Navigation
{
    public class NavigationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            ILanguageService localService = containerProvider.Resolve<ILanguageService>();
            localService.LanguageChanged += LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeTabbedPage, HomeTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterDetailsPage, MasterDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
            containerRegistry.RegisterSingleton<IMenuDataService, MenuDataService>();
        }
        private void LanguageChanged(Language language)
        {
            AppResources.Culture = new CultureInfo(language.Id);
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(NavigationModule);
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
