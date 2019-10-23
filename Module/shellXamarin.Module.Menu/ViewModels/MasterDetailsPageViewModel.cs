using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Navigation.BuinessServices;
using shellXamarin.Module.Navigation.Models;

namespace shellXamarin.Module.Navigation.ViewModels
{
    public class MasterDetailsPageViewModel : BaseViewModel
    {
        private readonly IMenuService _menuService;
        private readonly IEventAggregator _eventAggregator;
        public MasterDetailsPageViewModel(INavigationService navigationService, ILocalService localService, IMenuService menuService,
            IEventAggregator eventAggregator)
            : base(localService)
        {
            _menuService = menuService;
            NavigationService = navigationService;
            _eventAggregator = eventAggregator;
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
        #endregion

        #region Navigation

        #endregion


        #region Commands

        #region LogoutCommand

        public DelegateCommand LogoutCommand => new DelegateCommand(Logout);

        private async void Logout()
        {
            _eventAggregator.GetEvent<UserLogoutEvent>().Publish();

            await NavigateHome();
        }

        #endregion


        #region OnNavigateCommand

        public DelegateCommand<MenuElement> OnNavigateCommand => new DelegateCommand<MenuElement>(Navigate);

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
                    await NavigateHome(false);
                }
                else
                {
                    await NavigationService.NavigateAsync(new Uri($"NavigationPage/{page.Page}", UriKind.Relative));
                }
            }
        }

        #endregion

        #endregion
    }
}