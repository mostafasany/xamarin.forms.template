using Prism.Commands;
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



        #region Commands

        #region LoginCommand

        public DelegateCommand<object> LoginCommand => new DelegateCommand<object>(Login);

        private async void Login(object obj)
        {
            await NavigationService.NavigateAsync("/HomePage");
        }

        #endregion

        #endregion
    }
}