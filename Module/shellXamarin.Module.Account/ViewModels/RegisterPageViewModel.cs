using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Account.BuinessServices;
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

        ObservableCollection<FormItem> formItems;
        public ObservableCollection<FormItem> FormItems
        {
            get { return formItems; }
            set { SetProperty(ref formItems, value); }
        }

        
        #endregion

        #region Methods

        private async void LoadFormItems()
        {
            try
            {
                var user = await _accountService.GetUser();
                FormItems = new ObservableCollection<FormItem>();
                FormItems.Add(new EntryItem
                {
                    Id = "1",
                    Text = user.FName,
                    Placeholder = AppResources.account_form_firstname_placeholder,
                    Keyboard = Keyboard.Text,
                    Required = true,
                    Regex = new Regex(""),
                    RequiredMessage = AppResources.account_form_firstname_required,
                    InvalidMessage = AppResources.account_form_firstname_invalid,
                    ReturnType = ReturnType.Next,
                });

                FormItems.Add(new EntryItem
                {
                    Id = "2",
                    Text = user.LName,
                    Placeholder = AppResources.account_form_lastname_placeholder,
                    Keyboard = Keyboard.Text,
                    Required = true,
                    Regex = new Regex(""),
                    RequiredMessage = AppResources.account_form_lastname_required,
                    InvalidMessage = AppResources.account_form_lastname_invalid,
                    ReturnType = ReturnType.Next,
                });

                FormItems.Add(new DatePickerItem
                {
                    Id = "3",
                    Date = user.DOB,
                    StartDate = new DateTime(1900, 1, 1),
                    EndDate = DateTime.Now,
                    InvalidMessage = AppResources.account_form_dob_invalid,
                    Placeholder = AppResources.account_form_dob_placeholder,
                    Required = true,
                    RequiredMessage = AppResources.account_form_dob_required,
                });

                FormItems.Add(new PickerItem<INavigationElementEntity>
                {
                    Id = "4",
                    Items = await _accountService.GetGendersNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = user.Gender,
                    Required = true,
                    InvalidMessage = String.Empty,
                    Placeholder = "Gender",
                    RequiredMessage = string.Empty,
                });

                FormItems.Add(new NavigationItem<INavigationElementEntity>
                {
                    Id = "5",
                    Items = await _accountService.GetCountriesNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = user.Country,
                    Required = true,
                    InvalidMessage = string.Empty,
                    Placeholder = AppResources.account_form_country_placeholder,
                    RequiredMessage = AppResources.account_form_country_required,
                    NavigationContext = new NavigationContext
                    {
                        NavigationPage = "GenericListViewPage",
                        PageTemplate = new DataTemplate(),
                        NavigationCommand = new DelegateCommand<NavigationItem<INavigationElementEntity>>(NavigationButton),
                    }
                });

                FormItems.Add(new NavigationItem<INavigationElementEntity>
                {
                    Id = "6",
                    Items = await _accountService.GetStatesNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = user.State,
                    Required = true,
                    InvalidMessage = string.Empty,
                    Placeholder = AppResources.account_form_state_placeholder,
                    RequiredMessage = AppResources.account_form_state_required,
                    NavigationContext = new NavigationContext
                    {
                        NavigationPage = "GenericListViewPage",
                        PageTemplate = new DataTemplate(),
                        NavigationCommand = new DelegateCommand<NavigationItem<INavigationElementEntity>>(NavigationButton),
                    }
                });



                FormItems.Add(new NavigationItem<INavigationElementEntity>
                {
                    Id = "7",
                    Items = await _accountService.GetCitiesNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = user.City,
                    Required = true,
                    InvalidMessage = string.Empty,
                    Placeholder = "Cities",
                    RequiredMessage = string.Empty,
                    NavigationContext = new NavigationContext
                    {
                        NavigationPage = "GenericListViewPage",
                        PageTemplate = new DataTemplate(),
                        NavigationCommand = new DelegateCommand<NavigationItem<INavigationElementEntity>>(NavigationButton),
                    }
                });

                FormItems.Add(new EntryItem
                {
                    Id = "8",
                    Text = user.MobileNumber,
                    Placeholder = AppResources.account_form_mobileNumber_placeholder,
                    Keyboard = Keyboard.Numeric,
                    Required = true,
                    Regex = new Regex(""),
                    RequiredMessage = AppResources.account_form_mobileNumber_required,
                    InvalidMessage = AppResources.account_form_mobileNumber_invalid,
                    ReturnType = ReturnType.Next,
                });

                FormItems.Add(new CheckItem
                {
                    Id = "100",
                    InvalidMessage = "",
                    IsChecked = true,
                    Placeholder = AppResources.account_form_newsletter_required,
                    Required = true,
                    RequiredMessage = AppResources.account_form_newsletter_required
                });

            }
            catch (Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        #endregion

        #region Navigation

        //public override void OnNavigatedTo(INavigationParameters parameters)
        //{
        //    if (parameters.GetNavigationMode() == NavigationMode.Back)
        //    {
        //        var selectedNavigationItem = parameters.GetValue<NavigationItem<INavigationElementEntity>>("SelectedNavigationItem");
        //        if (selectedNavigationItem != null)
        //        {
        //            cities = selectedNavigationItem;
        //            RaisePropertyChanged(nameof(Cities));
        //        }
        //    }

        //    base.OnNavigatedTo(parameters);
        //}

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
