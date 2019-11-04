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
    public class EditProfilePageViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly IPageDialogService _dialogService;
        public EditProfilePageViewModel(INavigationService _navigationService,
            IEventBusService eventBusService, ILanguageService localService,
            IPageDialogService dialogService, IAccountService accountService, IExceptionService exceptionService)
            : base(localService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _dialogService = dialogService;
            _accountService = accountService;
            LoadForm();
        }

        #region Properties

        Form form;
        public Form Form
        {
            get { return form; }
            set { SetProperty(ref form, value); }
        }

        #endregion

        #region Methods

        private async void LoadForm()
        {
            try
            {
                var user = await _accountService.GetUser();
                Form = new Form();
                var formItems = new ObservableCollection<FormItem>();
                formItems.Add(new SectionHeaderItem
                {
                    Id = "0",
                    Placeholder = "Personal Details:",
                    HorizontalLayoutOptions = LayoutOptions.Start
                });
                formItems.Add(new EntryItem
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

                formItems.Add(new EntryItem
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

                formItems.Add(new DatePickerItem
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

                formItems.Add(new PickerItem<INavigationElementEntity>
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

                formItems.Add(new SectionHeaderItem
                {
                    Id = "5",
                    Placeholder = "Location:",
                    HorizontalLayoutOptions = LayoutOptions.Start
                });

                formItems.Add(new NavigationItem<INavigationElementEntity>
                {
                    Id = "6",
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

                formItems.Add(new CheckItem
                {
                    Id = "6",
                    InvalidMessage = "",
                    IsChecked = true,
                    Placeholder = AppResources.account_form_newsletter_required,
                    Required = true,
                    RequiredMessage = AppResources.account_form_newsletter_required
                });

                Form.Items = new ObservableCollection<FormItem>(formItems.Where(a => a.Visible));
            }
            catch (Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        private async void NavigationButton(NavigationItem<INavigationElementEntity> navigationItem)
        {
            if (navigationItem != null)
            {
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add("NavigationItem", navigationItem);
                await NavigationService.NavigateAsync(navigationItem.NavigationContext.NavigationPage, parameters);
            }
        }

        private async void EditProfile()
        {
            try
            {
                foreach (var item in Form.Items)
                {
                    if (item.IsRequried())
                    {
                        await _dialogService.DisplayAlertAsync("", item.RequiredMessage, AppResources.account_ok);
                        return;
                    }
                    if (item.IsInvalid())
                    {
                        await _dialogService.DisplayAlertAsync("", item.InvalidMessage, AppResources.account_ok);
                        return;
                    }
                }
                await NavigateHome();
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
                    var item = form.Items.FirstOrDefault(a => a.Id == selectedNavigationItem.Id);
                    int index = form.Items.IndexOf(item);
                    form.Items[index] = selectedNavigationItem;
                    RaisePropertyChanged(nameof(form));
                }
            }

            base.OnNavigatedTo(parameters);
        }

        #endregion

        #region Commands

        public DelegateCommand EditCommand => new DelegateCommand(EditProfile);

        #endregion
    }
}
