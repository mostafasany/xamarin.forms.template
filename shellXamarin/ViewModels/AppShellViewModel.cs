using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        public AppShellViewModel(ILocalService localService, IEventBusService eventBusService)
            : base(localService, eventBusService)
        {
        }
    }
}