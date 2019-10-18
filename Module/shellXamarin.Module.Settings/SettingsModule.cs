using System;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Settings.ViewModels;
using shellXamarin.Module.Settings.BuinessServices;
using shellXamarin.Module.Settings.Views;
using shellXamarin.Module.Settings.DataServices;
using System.Globalization;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Settings.Resources;

namespace shellXamarin.Module.Settings
{
    public class SettingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var settingsService = containerProvider.Resolve<ISettingsService>();
            //Xamarin.Forms.DependencyService.Register<ISettingsService, SettingsService>();
            var localService = containerProvider.Resolve<ILocalService>();
            localService.LanguageChanged += LocalService_LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterSingleton<ISettingsService, SettingsService>();
            containerRegistry.RegisterSingleton<IDataSettingsService, DataSettingsService>();
        }

        private void LocalService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            //AppResources.Culture = new CultureInfo(e.Langauge.Id);
            //var ci = new CultureInfo(e.Langauge.Id);
            //CultureInfo.DefaultThreadCurrentCulture = ci;
            //CultureInfo.DefaultThreadCurrentUICulture = ci;
            //CultureInfo.CurrentCulture = ci;
            //CultureInfo.CurrentUICulture = ci;

            //var culture = new CultureInfo(e.Langauge.Id);
            //AppResources.Culture = culture;
            //CultureInfo.CurrentCulture = culture;

            AppResources.Culture = new CultureInfo(e.Langauge.Id);
        }

        public static void LoadModule(IModuleCatalog moduleCatalog, IModuleManager managerManager)
        {
            Type sampleModuleType = typeof(SettingsModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            managerManager.LoadModule("SettingsModule");
        }
    }
}
