using System;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Settings.ViewModels;
using shellXamarin.Module.Settings.BuinessServices;
using shellXamarin.Module.Settings.Views;
using shellXamarin.Module.Settings.DataServices;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Settings.Resources;
using System.Globalization;

namespace shellXamarin.Module.Settings
{
    public class SettingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            ILanguageService localService = containerProvider.Resolve<ILanguageService>();
            localService.LanguageChanged += LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterSingleton<ISettingsService, SettingsService>();
            containerRegistry.RegisterSingleton<IDataSettingsService, DataSettingsService>();
        }

        private void LanguageChanged(Language language)
        {
            AppResources.Culture = new CultureInfo(language.Id);
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(SettingsModule);
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
