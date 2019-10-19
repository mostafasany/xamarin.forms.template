using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Account.Resources;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Module.Account.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IPageDialogService _dialogService;
        public LoginPageViewModel(INavigationService _navigationService, IPageDialogService dialogService, ILocalService localService)
            :base(localService)
        {
            NavigationService = _navigationService;
            _dialogService = dialogService;
        }

        #region Commands

        #region LoginCommand

        public DelegateCommand<object> LoginCommand => new DelegateCommand<object>(Login);

        private async void Login(object obj)
        {

            await _dialogService.DisplayAlertAsync("", AppResources.account_form_email_invalid, AppResources.account_ok);
            await NavigationService.NavigateAsync("/HomePage");
        }

        #endregion

        #endregion
    }
}