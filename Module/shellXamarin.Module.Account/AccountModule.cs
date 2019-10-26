using System;
using System.Globalization;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Account.BuinessServices;
using shellXamarin.Module.Account.DataServices;
using shellXamarin.Module.Account.Resources;
using shellXamarin.Module.Account.ViewModels;
using shellXamarin.Module.Account.Views;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;

namespace shellXamarin.Module.Account
{
    public class AccountModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //TODO: For unknow reason, eventbus not firing language changed events
            //So LanguageChanged inside localservice is created

            //IEventBusService eventBusService = containerProvider.Resolve<IEventBusService>();
            //eventBusService.Subscribe<LanguageChangedEvent, Language>(LanguageChanged);
            ILanguageService localService = containerProvider.Resolve<ILanguageService>();
            localService.LanguageChanged += LanguageChanged;
        }


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<GenericListViewPage, GenericListViewPageViewModel>();
            containerRegistry.RegisterSingleton<IAccountService, AccountService>();
            containerRegistry.RegisterSingleton<IAccountDataService, AccountDataService>();
        }

        private void LanguageChanged(Language language)
        {
            AppResources.Culture = new CultureInfo(language.Id);
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(AccountModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            if (loadModule)
                moduleManager.LoadModule(nameof(AccountModule));
        }
    }
}
