using System;
using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Account.Models;
using shellXamarin.Module.Account.Resources;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.Account.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        private readonly IPageDialogService _dialogService;
        private readonly Tuple<UserLoginEvent, SubscriptionToken> userLoginEventAndToken;
        public RegisterPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            IPageDialogService dialogService, ILocalService localService)
            : base(localService, eventBusService)
        {
            NavigationService = _navigationService;
            _dialogService = dialogService;
            userLoginEventAndToken = eventBusService.Subscribe<UserLoginEvent>(UserLogin);

            LoadFormItems();
        }

        #region Properties

        FormEntryItem firstName;
        public FormEntryItem FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        FormEntryItem lastName;
        public FormEntryItem LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        DatePickerItem dob;
        public DatePickerItem DOB
        {
            get { return dob; }
            set { SetProperty(ref dob, value); }
        }


        ListItem<Gender> genderList;
        public ListItem<Gender> GenderList
        {
            get { return genderList; }
            set { SetProperty(ref genderList, value); }
        }

        #endregion

        #region Methods

        private void LoadFormItems()
        {
            FirstName = new FormEntryItem
            {
                Text = string.Empty,
                Placeholder = AppResources.account_form_email_placeholder,
                Keyboard = Keyboard.Text,
                Required = true,
                Regex = new Regex(""),
                RequiredMessage = AppResources.account_form_email_required,
                InvalidMessage = AppResources.account_form_email_invalid,
                ReturnType = ReturnType.Next,
            };

            LastName = new FormEntryItem
            {
                Text = string.Empty,
                Placeholder = AppResources.account_form_email_placeholder,
                Keyboard = Keyboard.Text,
                Required = true,
                Regex = new Regex(""),
                RequiredMessage = AppResources.account_form_email_required,
                InvalidMessage = AppResources.account_form_email_invalid,
                ReturnType = ReturnType.Next,
            };

            DOB = new DatePickerItem
            {
                Text = DateTime.Now,
                InvalidMessage = "",
                Placeholder = "Data of birth",
                Required = true,
                RequiredMessage = "",
            };
            GenderList = new ListItem<Gender>
            {
                Items = new System.Collections.Generic.List<Gender>
                {
                    new Gender { Id = "1", Title = "Male" },
                    new Gender { Id = "2", Title = "Female" }
                },
                SelectedKey = "Id",
                SelectedValue = "1",
                Required = true,
                InvalidMessage = "",
                Placeholder = "Gender",
                RequiredMessage = ""
            };
        }

        private void UserLogin()
        {

        }

        #endregion

        #region Navigation

        #endregion

        #region Commands

        #region RegisterCommand

        public DelegateCommand<object> RegisterCommand => new DelegateCommand<object>(Register);

        private async void Register(object obj)
        {
            //if (Email.RequiredInvalid())
            //{
            //    await _dialogService.DisplayAlertAsync("", Email.RequiredMessage, AppResources.account_ok);
            //    return;
            //}
            //if (Email.RegexInvalid())
            //{
            //    await _dialogService.DisplayAlertAsync("", Email.InvalidMessage, AppResources.account_ok);
            //    return;
            //}
            //if (Password.RequiredInvalid())
            //{
            //    await _dialogService.DisplayAlertAsync("", Password.RequiredMessage, AppResources.account_ok);
            //    return;
            //}

            userLoginEventAndToken.Item1.Publish();
            await NavigateHome();
        }

        #endregion

        #endregion
    }
}