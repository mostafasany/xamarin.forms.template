using System;
using Prism.Events;
using Prism.Navigation;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;

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
        }

        #region Properties

        #endregion

        #region Methods

        private void UserLogout()
        {

        }


        private void UserLogin(UserLoginEvent userLoginEvent)
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

        #endregion
    }
}