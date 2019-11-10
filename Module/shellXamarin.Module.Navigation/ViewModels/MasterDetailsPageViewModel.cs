using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.Services.SharedService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Navigation.BuinessServices;
using shellXamarin.Module.Navigation.Models;

namespace shellXamarin.Module.Navigation.ViewModels
{
    public class MasterDetailsPageViewModel : BaseViewModel
    {
        private readonly IMenuService _menuService;
        private readonly ISharedService _sharedService;
        public MasterDetailsPageViewModel(INavigationService navigationService, ILanguageService localService,
            IMenuService menuService, IExceptionService exceptionService, ISharedService sharedService,
            IEventBusService eventBusService)
            : base(localService, eventBusService, exceptionService)
        {
            _menuService = menuService;
            _sharedService = sharedService;
            NavigationService = navigationService;
        }

        #region Properties

        List<MenuElement> menuItems;
        public List<MenuElement> MenuItems
        {
            get { return menuItems; }
            set { SetProperty(ref menuItems, value); }
        }


        bool isLoggedIn;
        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set { SetProperty(ref isLoggedIn, value); }
        }


        string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        string profile;
        public string Profile
        {
            get { return profile; }
            set { SetProperty(ref profile, value); }
        }


        #endregion

        #region Methods

        async void Load()
        {
            var user = await _sharedService.GetUser();
            IsLoggedIn = user != null;
            MenuItems = await _menuService.GetMenuItemsAsync(IsLoggedIn);
            if (user != null)
            {
                Username = string.Format("{0} {1}", user.FName, user.LName);
                Profile = user.Profile;
            }
            else
            {
                Profile = "https://bit.ly/2JZgt5z";
            }
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
            await _sharedService.RemoveAllUserPreferences();
            await NavigateHome();
        }

        #endregion

        #region Navigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Load();
        }

        #endregion

        #region Commands

        public DelegateCommand LogoutCommand => new DelegateCommand(Logout);

        public DelegateCommand<MenuElement> OnNavigateCommand => new DelegateCommand<MenuElement>(Navigate);

        #endregion
    }
}