using System;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Module.Home.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        //UserLogoutEvent _userLogoutEvent;
        //SubscriptionToken _token;
        public HomePageViewModel(INavigationService _navigationService, IEventAggregator eventAggregator)
        {
            NavigationService = _navigationService;
            //_userLogoutEvent = eventAggregator.GetEvent<UserLogoutEvent>();
            //_token = _userLogoutEvent.Subscribe(UserLogoutChaged);
        }

        private void UserLogoutChaged()
        {

        }

        #region Navigation


        //public override void Destroy()
        //{
        //    _userLogoutEvent.Unsubscribe(_token);
        //    base.Destroy();
        //}

        #endregion


        #region Commands

        #region NavigateToSettingsPageCommand

        public DelegateCommand NavigateToSettingsPageCommand => new DelegateCommand(NavigateToSettingsPage);

        private async void NavigateToSettingsPage()
        {
            await NavigationService.NavigateAsync("/SettingsPage");
        }

        #endregion


        #region NavigateToLoginPageCommand

        public DelegateCommand NavigateToLoginPageCommand => new DelegateCommand(NavigateToLoginPage);

        private async void NavigateToLoginPage()
        {
            await NavigationService.NavigateAsync("/LoginPage");
        }

        #endregion

        #endregion
    }
}