using System;
using System.Globalization;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.ElLa3eba.Resources;
using shellXamarin.Module.ElLa3eba.ViewModels;
using shellXamarin.Module.ElLa3eba.Views;

namespace shellXamarin.Module.ElLa3eba
{
    public class ElLa3ebaModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            ILanguageService localService = containerProvider.Resolve<ILanguageService>();
            localService.LanguageChanged += LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BecomeManagerPage, BecomeManagerPageViewModel>();
            containerRegistry.RegisterForNavigation<BecomePlayerPage, BecomePlayerPageViewModel>();
            containerRegistry.RegisterForNavigation<ElLa3ebaHomePage, ElLa3ebaHomePageViewModel>();
            containerRegistry.RegisterForNavigation<FaceVerficationPage, FaceVerficationPageViewModel>();
            containerRegistry.RegisterForNavigation<LocationSelectionPage, LocationSelectionPageViewModel>();
            containerRegistry.RegisterForNavigation<MobileVerficationPage, MobileVerficationPageViewModel>();
            containerRegistry.RegisterForNavigation<PositionSelectionPage, PositionSelectionPageViewModel>();
            containerRegistry.RegisterForNavigation<ElLa3ebaRegisterPage, ElLa3ebaRegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<SetFromationPage, SetFromationPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateTeamPage, CreateTeamPageViewModel>();
        }

        private void LanguageChanged(Language language)
        {
            AppResources.Culture = new CultureInfo(language.Id);
        }

        public static void AddModule(IModuleCatalog moduleCatalog, IModuleManager moduleManager, bool loadModule)
        {
            Type sampleModuleType = typeof(ElLa3ebaModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            if (loadModule)
                moduleManager.LoadModule(nameof(ElLa3ebaModule));
        }
    }
}
