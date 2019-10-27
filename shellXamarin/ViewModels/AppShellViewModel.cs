using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        public AppShellViewModel(ILanguageService localService, IEventBusService eventBusService,
            IExceptionService exceptionService)
            : base(localService, eventBusService, exceptionService)
        {
        }
    }
}