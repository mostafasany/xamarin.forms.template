using System;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Account.ViewModels;
using shellXamarin.Module.Home.BuinessServices;
using shellXamarin.Module.Home.Views;

namespace shellXamarin.Module.Home
{
    public class HomeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var localService = containerProvider.Resolve<ILocalService>();
            //localService.LanguageChanged += LocalService_LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterSingleton<IHomeService, HomeService>();
        }

        //private void LocalService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        //{
        //    // Handle post initialization tasks like resolving IEventAggregator to subscribe events
        //    AppResources.Culture = new CultureInfo(e.Langauge);
        //}

        public static void LoadModule(IModuleCatalog moduleCatalog, IModuleManager managerManager)
        {
            Type sampleModuleType = typeof(HomeModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            managerManager.LoadModule("HomeModule");
        }
    }
}
