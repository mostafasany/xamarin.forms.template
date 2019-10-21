using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.ViewModels
{
    public class MasterDetailsPageViewModel : BaseViewModel
    {
        public MasterDetailsPageViewModel(ILocalService localService)
            : base(localService)
        {
        }
    }
}