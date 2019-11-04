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
using shellXamarin.Module.Navigation.BuinessServices;
using shellXamarin.Module.Navigation.Models;

namespace shellXamarin.Module.Navigation.ViewModels
{
    public class MasterDetailsPageViewModel : BaseViewModel
    {
        //TODO: Check how to retreive Account Details in Side Menu
        private readonly IMenuService _menuService;
        private readonly Tuple<LogoutEvent, SubscriptionToken> userLogoutEventAndToken;
        private readonly Tuple<LoginEvent, SubscriptionToken> userLoginEventAndToken;
        public MasterDetailsPageViewModel(INavigationService navigationService, ILanguageService localService,
            IMenuService menuService, IExceptionService exceptionService,
            IEventBusService eventBusService)
            : base(localService, eventBusService, exceptionService)
        {
            _menuService = menuService;
            NavigationService = navigationService;
            userLogoutEventAndToken = eventBusService.Subscribe<LogoutEvent>(UserLogout);
            userLoginEventAndToken = eventBusService.Subscribe<LoginEvent, UserLoginEvent>(UserLogin);
            Load();
        }

        #region Properties

        List<MenuElement> menuItems;
        public List<MenuElement> MenuItems
        {
            get { return menuItems; }
            set { SetProperty(ref menuItems, value); }
        }


        #endregion

        #region Methods

        async void Load()
        {
            MenuItems = await _menuService.GetMenuItemsAsync();
        }

        private void UserLogout()
        {
            Load();
        }

        private void UserLogin(UserLoginEvent userLoginEvent)
        {
            Load();
        }

        private async void Navigate(MenuElement page)
        {
            if (page == null || !page.CanNavigate || string.IsNullOrEmpty(page.Title))
                return;

            if (page.Modal)
                await NavigationService.NavigateAsync($"NavigationPage/{page.Page}", useModalNavigation: true);
            else
            {
                if (page.Page == "HomePage")
                {
                    await NavigateHome();
                }
                else
                {
                    await NavigationService.NavigateAsync(new Uri($"NavigationPage/{page.Page}", UriKind.Relative));
                }
            }
        }

        private async void Logout()
        {
            userLogoutEventAndToken.Item1.Publish();
            await NavigateHome();
        }

        #endregion

        #region Navigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        public override void Destroy()
        {
            userLogoutEventAndToken.Item1.Unsubscribe(userLogoutEventAndToken.Item2);
            userLoginEventAndToken.Item1.Unsubscribe(userLoginEventAndToken.Item2);
            base.Destroy();
        }

        #endregion

        #region Commands

        public DelegateCommand LogoutCommand => new DelegateCommand(Logout);

        public DelegateCommand<MenuElement> OnNavigateCommand => new DelegateCommand<MenuElement>(Navigate);

        #endregion
    }
}