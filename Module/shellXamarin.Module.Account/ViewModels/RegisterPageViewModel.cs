using System;
using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Account.BuinessServices;
using shellXamarin.Module.Account.Models;
using shellXamarin.Module.Account.Resources;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.Account.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        public RegisterPageViewModel(INavigationService _navigationService,
            IEventBusService eventBusService, ILanguageService localService,
            IAccountService accountService, IExceptionService exceptionService)
            : base(localService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _accountService = accountService;
            LoadFormItems();
        }

        #region Properties

        EntryItem firstName;
        public EntryItem FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        EntryItem lastName;
        public EntryItem LastName
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

        NavigationItem<INavigationElementEntity> cities;
        public NavigationItem<INavigationElementEntity> Cities
        {
            get { return cities; }
            set { SetProperty(ref cities, value); }
        }

        CheckItem readNewsLetter;
        public CheckItem ReadNewsLetter
        {
            get { return readNewsLetter; }
            set { SetProperty(ref readNewsLetter, value); }
        }


        #endregion

        #region Methods

        private async void LoadFormItems()
        {
            try
            {
                FirstName = new EntryItem
                {
                    Text = string.Empty,
                    Placeholder = AppResources.account_form_firstname_placeholder,
                    Keyboard = Keyboard.Text,
                    Required = true,
                    Regex = new Regex(""),
                    RequiredMessage = AppResources.account_form_firstname_required,
                    InvalidMessage = AppResources.account_form_firstname_invalid,
                    ReturnType = ReturnType.Next,
                };

                LastName = new EntryItem
                {
                    Text = string.Empty,
                    Placeholder = AppResources.account_form_lastname_placeholder,
                    Keyboard = Keyboard.Text,
                    Required = true,
                    Regex = new Regex(""),
                    RequiredMessage = AppResources.account_form_lastname_required,
                    InvalidMessage = AppResources.account_form_lastname_invalid,
                    ReturnType = ReturnType.Next,
                };

                DOB = new DatePickerItem
                {
                    Text = DateTime.Now,
                    InvalidMessage = AppResources.account_form_dob_invalid,
                    Placeholder = AppResources.account_form_dob_placeholder,
                    Required = true,
                    RequiredMessage = AppResources.account_form_dob_required,
                };

                GenderList = new ListItem<Gender>
                {
                    Items = await _accountService.GetGendersAsync(),
                    SelectedKey = "Id",
                    SelectedValue = "1",
                    Required = true,
                    InvalidMessage = String.Empty,
                    Placeholder = "Gender",
                    RequiredMessage = string.Empty,
                };

                Cities = new NavigationItem<INavigationElementEntity>
                {
                    Items = await _accountService.GetCitiesNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = "2",
                    Required = true,
                    InvalidMessage = string.Empty,
                    Placeholder = "Cities",
                    RequiredMessage = string.Empty,
                    NavigationContext = new NavigationContext
                    {
                        NavigationPage = "GenericListViewPage",
                        PageTemplate = new DataTemplate(),
                        NavigationCommand = "",
                    }
                };

                ReadNewsLetter = new CheckItem
                {
                    InvalidMessage = "",
                    IsChecked = true,
                    Placeholder = AppResources.account_form_newsletter_required,
                    Required = true,
                    RequiredMessage = AppResources.account_form_newsletter_required
                };
            }
            catch (Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        #endregion

        #region Navigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                var selectedNavigationItem = parameters.GetValue<NavigationItem<INavigationElementEntity>>("SelectedNavigationItem");
                if (selectedNavigationItem != null)
                {
                    cities = selectedNavigationItem;
                    RaisePropertyChanged(nameof(Cities));
                }
            }

            base.OnNavigatedTo(parameters);
        }

        #endregion

        #region Commands

        #region NavigationButton

        public DelegateCommand<object> NavigationButtonCommand => new DelegateCommand<object>(NavigationButton);

        private async void NavigationButton(object obj)
        {
            NavigationItem<INavigationElementEntity> navigationItem = obj as NavigationItem<INavigationElementEntity>;
            if (navigationItem != null)
            {
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add("NavigationItem", navigationItem);
                await NavigationService.NavigateAsync(navigationItem.NavigationContext.NavigationPage, parameters);
            }
        }

        #endregion

        #region RegisterCommand

        public DelegateCommand<object> RegisterCommand => new DelegateCommand<object>(Register);

        private async void Register(object obj)
        {
            try
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

                await NavigateHome();
            }
            catch (Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        #endregion

        #endregion
    }
}
