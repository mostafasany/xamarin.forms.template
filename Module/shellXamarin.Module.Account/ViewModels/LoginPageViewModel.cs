using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Account.BuinessServices;
using shellXamarin.Module.Common.Resources;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.Account.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IPageDialogService _dialogService;
        private readonly IEventBusService _eventBusService;
        private readonly IAccountService _accountService;
        public LoginPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            IAccountService accountService, IPageDialogService dialogService, ILanguageService languageService,
            IExceptionService exceptionService)
            : base(languageService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _dialogService = dialogService;
            _eventBusService = eventBusService;
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

        private void LoadForm()
        {
            try
            {
                Form = new Form();
                var formItems = new ObservableCollection<FormItem>();
                formItems.Add(new EntryItem
                {
                    Id = "1",
                    Text = string.Empty,
                    Placeholder = AppResources.account_form_email_placeholder,
                    Keyboard = Keyboard.Email,
                    Required = true,
                    Regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"),
                    RequiredMessage = AppResources.account_form_email_required,
                    InvalidMessage = AppResources.account_form_email_invalid,
                    ReturnType = ReturnType.Next,
                });

                formItems.Add(new EntryItem
                {
                    Id = "2",
                    Text = string.Empty,
                    IsPassword = true,
                    Placeholder = AppResources.account_form_password_placeholder,
                    Keyboard = Keyboard.Default,
                    Required = true,
                    Regex = new Regex(@"^.{6,12}$"),
                    MinChar = 6,
                    RequiredMessage = AppResources.account_form_password_required,
                    ReturnType = ReturnType.Default,
                });

                Form.Items = new ObservableCollection<FormItem>(formItems.Where(a => a.Visible));
            }
            catch (System.Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }

        }

        private async void Login(object obj)
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

                var email = Form.Items.FirstOrDefault(a => a.Id == "1") as EntryItem;
                var password = Form.Items.FirstOrDefault(a => a.Id == "2") as EntryItem;
                var user = await _accountService.LoginAsync(email.Text, password.Text);
                _eventBusService.Publish<LoginEvent, UserLoginEvent>(new UserLoginEvent
                {
                    Id = user.Id,
                    FirstName = user.FName,
                    LastName = user.LName
                });
                await NavigateHome();
            }
            catch (System.Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        #endregion

        #region Navigation

        #endregion

        #region Commands

        public DelegateCommand<object> LoginCommand => new DelegateCommand<object>(Login);

        #endregion
    }
}