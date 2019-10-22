using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Account.Resources;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.Account.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IPageDialogService _dialogService;
        public LoginPageViewModel(INavigationService _navigationService, IPageDialogService dialogService, ILocalService localService)
            : base(localService)
        {
            NavigationService = _navigationService;
            _dialogService = dialogService;
            LoadFormItems();
        }

        #region Properties

        FormEntryItem email;
        public FormEntryItem Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        FormEntryItem password;
        public FormEntryItem Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        #endregion


        #region Methods

        private void LoadFormItems()
        {
            Email = new FormEntryItem
            {
                Text = string.Empty,
                Placeholder = AppResources.account_form_email_placeholder,
                Keyboard = Keyboard.Email,
                Required = true,
                Regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"),
                RequiredMessage = AppResources.account_form_email_required,
                InvalidMessage = AppResources.account_form_email_invalid,
                ReturnType = ReturnType.Next,
            };

            Password = new FormEntryItem
            {
                Text = string.Empty,
                IsPassword = true,
                Placeholder = AppResources.account_form_password_placeholder,
                Keyboard = Keyboard.Default,
                Required = true,
                MinChar = 6,
                RequiredMessage = AppResources.account_form_password_required,
                ReturnType = ReturnType.Default,
            };
        }

        #endregion

        #region Commands

        #region LoginCommand

        public DelegateCommand<object> LoginCommand => new DelegateCommand<object>(Login);

        private async void Login(object obj)
        {
            if (Email.RequiredInvalid())
            {
                await _dialogService.DisplayAlertAsync("", Email.RequiredMessage, AppResources.account_ok);
                return;
            }
            if (Email.RegexInvalid())
            {
                await _dialogService.DisplayAlertAsync("", Email.InvalidMessage, AppResources.account_ok);
                return;
            }
            if (Password.RequiredInvalid())
            {
                await _dialogService.DisplayAlertAsync("", Password.RequiredMessage, AppResources.account_ok);
                return;
            }

            await NavigateHome();
        }

        #endregion

        #endregion
    }
}