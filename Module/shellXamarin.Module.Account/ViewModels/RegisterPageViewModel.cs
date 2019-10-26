using System;
using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Account.Models;
using shellXamarin.Module.Account.Resources;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.Account.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
        public RegisterPageViewModel(INavigationService _navigationService, IEventBusService eventBusService, ILocalService localService)
            : base(localService, eventBusService)
        {
            NavigationService = _navigationService;
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

        NavigationItem<City> cities;
        public NavigationItem<City> Cities
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

        private void LoadFormItems()
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
                Items = new System.Collections.Generic.List<Gender>
                {
                    new Gender { Id = "1", Title = AppResources.account_form_male },
                    new Gender { Id = "2", Title = AppResources.account_form_female }
                },
                SelectedKey = "Id",
                SelectedValue = "1",
                Required = true,
                InvalidMessage = String.Empty,
                Placeholder = "Gender",
                RequiredMessage = string.Empty,
            };

            Cities = new NavigationItem<City>
            {
                Items = new System.Collections.Generic.List<City>
                {
                    new City { Id = "1", Title = "Cairo" },
                    new City { Id = "2", Title = "Alexandria" },
                    new City { Id = "3", Title = "Giza" },
                    new City { Id = "4", Title = "Hurghada" }
                },
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

        #endregion

        #region Navigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                var navigationItemType = parameters.GetValue<Type>("NavigationItemType");
                if (navigationItemType == typeof(City))
                {
                    Cities = parameters.GetValue<NavigationItem<City>>("SelectedNavigationItem");
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
            // Type elementType = Type.GetType("shellXamarin.Module.Common.Models.Language");
            Type itemType = Type.GetType("shellXamarin.Module.Account.Models.City");
            // var type = typeof(NavigationItem<>).MakeGenericType(cityType);

            if (itemType == typeof(City))
            {
                NavigationItem<City> navigationItem = obj as NavigationItem<City>;
                Prism.Navigation.NavigationParameters parameters = new Prism.Navigation.NavigationParameters();
                parameters.Add("NavigationItemType", itemType);
                parameters.Add("NavigationItem", navigationItem);
                await NavigationService.NavigateAsync(navigationItem.NavigationContext.NavigationPage, parameters);
            }
        }

        #endregion

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

            await NavigateHome();
        }

        #endregion

        #endregion
    }
}
