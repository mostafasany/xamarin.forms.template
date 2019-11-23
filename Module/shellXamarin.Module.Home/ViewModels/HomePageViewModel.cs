using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Home.Models;

namespace shellXamarin.Module.Home.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly Tuple<LogoutEvent, SubscriptionToken> userLogoutEventAndToken;
        private readonly Tuple<LoginEvent, SubscriptionToken> userLoginEventAndToken;
        public HomePageViewModel(INavigationService _navigationService, ILanguageService localService,
            IEventBusService eventBusService, IExceptionService exceptionService)
            : base(localService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            userLogoutEventAndToken = eventBusService.Subscribe<LogoutEvent>(UserLogout);
            userLoginEventAndToken = eventBusService.Subscribe<LoginEvent, UserLoginEvent>(UserLogin);
            LoadModules();
        }

        #region Properties

        List<AppModuleGroup> modules;
        public List<AppModuleGroup> Modules
        {
            get { return modules; }
            set { SetProperty(ref modules, value); }
        }

        #endregion

        #region Methods

        private void UserLogout()
        {

        }


        private void UserLogin(UserLoginEvent userLoginEvent)
        {

        }

        private void LoadModules()
        {
            Modules = new List<AppModuleGroup>();
            Modules.Add(new AppModuleGroup("Account", new List<AppPage>
            {
                new AppPage("Login","LoginPage"),
                new AppPage("Regitser","RegisterPage"),
                 new AppPage("Edit","EditProfilePage")
            }));
            Modules.Add(new AppModuleGroup("ElLa3eba", new List<AppPage>
            {
                  new AppPage("Home","ElLa3ebaHomePage"),
                  new AppPage("New Account","ElLa3ebaRegisterPage"),
                  new AppPage("Set Location","LocationSelectionPage"),
                  new AppPage("Create Team","CreateTeamPage"),
                  new AppPage("Set Fromation","SetFromationPage"),
                  new AppPage("Become Manager","BecomeManagerPage"),
                  new AppPage("Become Player","BecomePlayerPage"),
            }));

        }

        private void PageNavigation(AppPage page)
        {
            NavigationService.NavigateAsync($"{page.Page}");
        }

        #endregion

        #region Navigation


        public override void Destroy()
        {
            userLogoutEventAndToken.Item1.Unsubscribe(userLogoutEventAndToken.Item2);
            userLoginEventAndToken.Item1.Unsubscribe(userLoginEventAndToken.Item2);
            base.Destroy();
        }

        #endregion

        #region Commands

        public DelegateCommand<AppPage> ModuleNavigationCommand => new DelegateCommand<AppPage>(PageNavigation);

        #endregion
    }
}
