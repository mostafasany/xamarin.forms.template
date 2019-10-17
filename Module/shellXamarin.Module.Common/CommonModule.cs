using System;
using System.Globalization;
using Prism.Ioc;
using Prism.Modularity;
using shellXamarin.Module.Common.Resources;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.ExceptionService;

namespace shellXamarin.Module.Common
{
    public class CommonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var localService = containerProvider.Resolve<ILocalService>();
            localService.SetDefaultLocal();
            localService.LanguageChanged += LocalService_LanguageChanged;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IPrefrencesService, PrefrencesService>();
            containerRegistry.RegisterSingleton<ILocalService, LocalService>();
            containerRegistry.RegisterSingleton<IExceptionService, ExceptionService>();
        }

        private void LocalService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            AppResources.Culture = new CultureInfo(e.Langauge.Id);
        }

        public static void LoadModule(IModuleCatalog moduleCatalog, IModuleManager managerManager)
        {
            Type sampleModuleType = typeof(CommonModule);
            moduleCatalog.AddModule(
                new ModuleInfo(sampleModuleType)
                {
                    InitializationMode = InitializationMode.OnDemand
                });

            managerManager.LoadModule("CommonModule");
        }
    }
}
