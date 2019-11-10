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
        private readonly IPageDialogService _dialogService;
        public RegisterPageViewModel(INavigationService _navigationService,
            IEventBusService eventBusService, ILanguageService localService, IPageDialogService dialogService,
            IAccountService accountService, IExceptionService exceptionService)
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
                Form = new Form();
                var formItems = new ObservableCollection<FormItem>();
                formItems.Add(new SectionHeaderItem
                {
                    Id = "0",
                    Placeholder = AppResources.account_form_header_personal,
                    HorizontalLayoutOptions = LayoutOptions.Start
                });
                formItems.Add(new EntryItem
                {
                    Id = "1",
                    Text = "",
                    Placeholder = AppResources.account_form_firstname_placeholder,
                    Keyboard = Keyboard.Text,
                    Required = true,
                    Regex = new Regex(@"^.{2,24}$"),
                    RequiredMessage = AppResources.account_form_firstname_required,
                    InvalidMessage = AppResources.account_form_firstname_invalid,
                    ReturnType = ReturnType.Next,
                });

                formItems.Add(new EntryItem
                {
                    Id = "2",
                    Text = "",
                    Placeholder = AppResources.account_form_lastname_placeholder,
                    Keyboard = Keyboard.Text,
                    Required = true,
                    Regex = new Regex(@"^.{2,24}$"),
                    RequiredMessage = AppResources.account_form_lastname_required,
                    InvalidMessage = AppResources.account_form_lastname_invalid,
                    ReturnType = ReturnType.Next,
                });

                formItems.Add(new DatePickerItem
                {
                    Id = "3",
                    Date = DateTime.Now,
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
                    SelectedValue = "1",
                    Required = false,
                    InvalidMessage = String.Empty,
                    Placeholder = AppResources.account_form_gender_placeholder,
                    RequiredMessage = string.Empty,
                });

                formItems.Add(new SectionHeaderItem
                {
                    Id = "5",
                    Placeholder = AppResources.account_form_header_location,
                    HorizontalLayoutOptions = LayoutOptions.Start
                });

                formItems.Add(new NavigationItem<INavigationElementEntity>
                {
                    Id = "6",
                    Items = await _accountService.GetCitiesNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = "1",
                    Required = true,
                    InvalidMessage = string.Empty,
                    Placeholder = AppResources.account_form_cities_placeholder,
                    RequiredMessage = string.Empty,
                    NavigationContext = new NavigationContext
                    {
                        NavigationPage = "GenericListViewPage",
                        NavigationCommand = new DelegateCommand<NavigationItem<INavigationElementEntity>>(NavigationButton),
                    }
                });

                formItems.Add(new CheckItem
                {
                    Id = "6",
                    InvalidMessage = "",
                    IsChecked = false,
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
            try
            {
                if (navigationItem != null)
                {
                    NavigationParameters parameters = new NavigationParameters();
                    parameters.Add("NavigationItem", navigationItem);
                    await NavigationService.NavigateAsync(navigationItem.NavigationContext.NavigationPage, parameters);
                }
            }
            catch (Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        private async void Register()
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

        public DelegateCommand RegisterCommand => new DelegateCommand(Register);

        #endregion

    }
}
