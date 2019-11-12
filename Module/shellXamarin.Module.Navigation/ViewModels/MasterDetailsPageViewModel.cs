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

        List<MenuElementGroup> menuItems;
        public List<MenuElementGroup> MenuItems
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

        private async void MenuItemNavigate(MenuElement page)
        {
            if (page == null)
                return;

            Navigate(page.Page, page.Title, page.Modal, page.CanNavigate);
        }


        private async void MenuItemGroupNavigate(MenuElementGroup page)
        {
            if (page == null)
                return;

            Navigate(page.Page, page.Title, page.Modal, page.CanNavigate);
        }

        private async void Navigate(string page, string title, bool modal, bool canNavigate)
        {
            if (page == null || !canNavigate || string.IsNullOrEmpty(title))
                return;

            if (modal)
                NavigationService.NavigateAsync($"NavigationPage/{page}", useModalNavigation: true);
            else
            {
                if (page == "HomePage")
                {
                    NavigateHome();
                }
                else
                {
                    NavigationService.NavigateAsync(new Uri($"NavigationPage/{page}", UriKind.Relative));
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

        public DelegateCommand<MenuElement> MenuItemNavigateCommand => new DelegateCommand<MenuElement>(MenuItemNavigate);

        public DelegateCommand<MenuElementGroup> MenuItemGroupNavigateCommand => new DelegateCommand<MenuElementGroup>(MenuItemGroupNavigate);

        #endregion
    }
}