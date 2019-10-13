using Prism.Navigation;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Module.Account.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public LoginPageViewModel()
        {
            Title = "Login";
        }
    }
}