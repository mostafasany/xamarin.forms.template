using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Account.BuinessServices;
using shellXamarin.Module.Account.ViewModels;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using Xunit;

namespace shellXamarin.Module.Tests.Account
{
    public class LoginPageViewModelTest
    {
        LoginPageViewModel loginPageViewModel;
        INavigationService navigationService = A.Fake<INavigationService>();
        IPageDialogService pageDialogService = A.Fake<IPageDialogService>();
        IEventBusService eventBusService = A.Fake<IEventBusService>();
        IAccountService accountService = A.Fake<IAccountService>();
        ILanguageService languageService = A.Fake<ILanguageService>();
        IExceptionService exceptionService = A.Fake<IExceptionService>();

        [Fact]
        public void Test1()
        {
            string email = "mostafa@test.com";
            string password = "123456";
            A.CallTo(() => accountService.LoginAsync(email, password)).Returns(Task.FromResult(new Module.Account.Models.User { FName = "mostafa", LName = "khodeir" }));
            loginPageViewModel = new LoginPageViewModel(navigationService, eventBusService, accountService, pageDialogService, languageService, exceptionService);

            var emailEntry = loginPageViewModel.Form.Items.FirstOrDefault(a => a.Id == "1") as EntryItem;
            emailEntry.Text = email;

            var passwordEntry = loginPageViewModel.Form.Items.FirstOrDefault(a => a.Id == "2") as EntryItem;
            passwordEntry.Text = password;

            loginPageViewModel.LoginCommand.Execute(null);

            A.CallTo(() => accountService.LoginAsync(email, password)).MustHaveHappened();
        }
    }
}
