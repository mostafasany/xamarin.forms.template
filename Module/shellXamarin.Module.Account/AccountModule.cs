using System;
using System.Globalization;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Account.BuinessServices;
using shellXamarin.Module.Account.DataServices;
using shellXamarin.Module.Account.Resources;
using shellXamarin.Module.Account.ViewModels;
using shellXamarin.Module.Account.Views;
using shellXamarin.Module.Common.Services;

namespace shellXamarin.Module.Account
{
    public class AccountModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var localService = containerProvider.Resolve<ILocalService>();
            localService.LanguageChanged += LocalService_LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterSingleton<IAccountService, AccountService>();
            containerRegistry.RegisterSingleton<IAccountDataService, AccountDataService>();
        }

        private void LocalService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            AppResources.Culture = new CultureInfo(e.Langauge.Id);
        }

        public static void LoadModule(IModuleCatalog moduleCatalog, IModuleManager managerManager)
        {
            Type sampleModuleType = typeof(AccountModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            managerManager.LoadModule("AccountModule");
        }
    }
}
