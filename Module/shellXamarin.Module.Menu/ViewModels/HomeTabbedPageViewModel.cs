using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Module.Navigation.ViewModels
{
    public class HomeTabbedPageViewModel : BaseViewModel
    {
        public HomeTabbedPageViewModel(ILocalService localService)
            : base(localService)
        {
        }
    }
}