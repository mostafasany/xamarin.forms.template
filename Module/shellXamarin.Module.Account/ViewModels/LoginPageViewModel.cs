using System;
using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Account.Resources;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.Account.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IPageDialogService _dialogService;
        private readonly Tuple<UserLoginEvent, SubscriptionToken> userLoginEventAndToken;
        public LoginPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            IPageDialogService dialogService, ILocalService localService)
            : base(localService, eventBusService)
        {
            NavigationService = _navigationService;
            _dialogService = dialogService;
            userLoginEventAndToken = eventBusService.Subscribe<UserLoginEvent>(UserLogin);

            LoadFormItems();
        }

        #region Properties

        EntryItem email;
        public EntryItem Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        EntryItem password;
        public EntryItem Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        #endregion

        #region Methods

        private void LoadFormItems()
        {
            Email = new EntryItem
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

            Password = new EntryItem
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

        private void UserLogin()
        {

        }

        #endregion

        #region Navigation

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

            userLoginEventAndToken.Item1.Publish();
            await NavigateHome();
        }

        #endregion

        #endregion
    }
}