using System;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Navigation;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Module.Home.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly Tuple<UserLogoutEvent, SubscriptionToken> userLogoutEventAndToken;
        private readonly Tuple<UserLoginEvent, SubscriptionToken> userLoginEventAndToken;
        public HomePageViewModel(INavigationService _navigationService, ILocalService localService,
            IEventBusService eventBusService)
            : base(localService, eventBusService)
        {
            NavigationService = _navigationService;
            userLogoutEventAndToken = eventBusService.Subscribe<UserLogoutEvent>(UserLogout);
            userLoginEventAndToken = eventBusService.Subscribe<UserLoginEvent>(UserLogin);
        }

        #region Properties

        #endregion

        #region Methods

        private void UserLogout()
        {

        }


        private void UserLogin()
        {

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

        #region NavigateToSettingsPageCommand

        public DelegateCommand NavigateToSettingsPageCommand => new DelegateCommand(NavigateToSettingsPage);

        private async void NavigateToSettingsPage()
        {
            await NavigationService.NavigateAsync("SettingsPage");
        }

        #endregion


        #region NavigateToLoginPageCommand

        public DelegateCommand NavigateToLoginPageCommand => new DelegateCommand(NavigateToLoginPage);

        private async void NavigateToLoginPage()
        {
            await NavigationService.NavigateAsync("LoginPage");
        }

        #endregion

        #endregion
    }
}