using System.Threading.Tasks;
using FakeItEasy;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Startup.BuinessServices;
using shellXamarin.Module.Startup.ViewModels;
using Xunit;

namespace shellXamarin.Module.Tests.Account
{
    public class StartupViewModelTest
    {
        StartupViewModel startupViewModel;
        INavigationService navigationService = A.Fake<INavigationService>();
        IEventBusService eventBusService = A.Fake<IEventBusService>();
        IStartupService startupService = A.Fake<IStartupService>();
        ILanguageService languageService = A.Fake<ILanguageService>();
        IExceptionService exceptionService = A.Fake<IExceptionService>();

        [Fact]
        public async void GivenCanProceedHomePageShouldBePresented()
        {
            //Arrange
            A.CallTo(() => startupService.CanProceed()).Returns(Task.FromResult(true));
            startupViewModel = new StartupViewModel(startupService, navigationService, eventBusService, exceptionService, languageService);

            //Act
            startupViewModel.OnNavigatedTo(null);

            //Assert
            A.CallTo(() => navigationService.NavigateAsync("/MasterDetailsPage/HomeTabbedPage")).MustHaveHappened();
        }

        [Fact]
        public async void GivenCantProceedHomePageShouldNotBePresented()
        {
            //Arrange
            A.CallTo(() => startupService.CanProceed()).Returns(Task.FromResult(false));
            startupViewModel = new StartupViewModel(startupService, navigationService, eventBusService, exceptionService, languageService);

            //Act
            startupViewModel.OnNavigatedTo(null);

            //Assert
            Assert.False(startupViewModel.IsBusy);
        }
    }
}
