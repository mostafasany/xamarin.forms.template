using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Common.Resources;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using Xamarin.Forms;
//TODO: 1. Moataz Ahmed
namespace shellXamarin.Module.ElLa3eba.ViewModels
{
    public class ElLa3ebaRegisterPageViewModel : BaseViewModel
    {

        public ElLa3ebaRegisterPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            ILanguageService languageService, IPageDialogService dialogService,
            IExceptionService exceptionService)
            : base(languageService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _dialogService = dialogService;
            LoadForm();
        }

        #region Properties
        private readonly IPageDialogService _dialogService;

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

                Form.Items = new ObservableCollection<FormItem>(formItems.Where(a => a.Visible));
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