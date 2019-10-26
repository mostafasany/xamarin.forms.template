﻿using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Navigation.DataServices;
using shellXamarin.Module.Navigation.Models;
using shellXamarin.Module.Navigation.Resources;

namespace shellXamarin.Module.Navigation.BuinessServices
{
    public class MenuService : IMenuService
    {
        private readonly IMenuDataService menuDataService;
        public MenuService(IMenuDataService _menuDataService)
        {
            menuDataService = _menuDataService;
        }

        public async Task<List<MenuElement>> GetMenuItemsAsync()
        {
            var menuItems = new List<MenuElement>();
            menuItems.Add(new MenuElement(AppResources.navigation_menu_home, "HomePage", "home.svg", true, false, null));
            menuItems.Add(new MenuElement(AppResources.navigation_menu_account, "", "myaccount.svg", false, false, new List<MenuElement>()
            {
                new MenuElement(AppResources.navigation_menu_login, "LoginPage", "myaccount.svg",  true, false, null),
                new MenuElement(AppResources.navigation_menu_register, "RegisterPage",  "myaccount.svg", true, false, null)
            }));
            menuItems.Add(new MenuElement(AppResources.navigation_menu_settings, "SettingsPage", "settings.svg", true, false, null));

            return menuItems;
        }
    }

}