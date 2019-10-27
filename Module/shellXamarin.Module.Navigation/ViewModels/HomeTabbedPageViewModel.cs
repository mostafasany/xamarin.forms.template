using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Module.Navigation.ViewModels
{
    public class HomeTabbedPageViewModel : BaseViewModel
    {
        public HomeTabbedPageViewModel(ILanguageService localService,IEventBusService eventBusService,
            IExceptionService exceptionService)
            : base(localService, eventBusService, exceptionService)
        {
        }
    }
}