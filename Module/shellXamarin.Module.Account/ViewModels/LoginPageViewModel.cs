using Prism.Navigation;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Module.Account.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel(INavigationService _navigationService)
        {
            NavigationService = _navigationService;
        }
    }
}