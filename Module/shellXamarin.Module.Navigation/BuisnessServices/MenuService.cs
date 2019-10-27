using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shellXamarin.Module.Navigation.DataServices;
using shellXamarin.Module.Navigation.Models;

namespace shellXamarin.Module.Navigation.BuinessServices
{
    public class MenuService : IMenuService
    {
        private readonly IMenuDataService _menuDataService;
        public MenuService(IMenuDataService menuDataService)
        {
            _menuDataService = menuDataService;
        }

        public async Task<List<MenuElement>> GetMenuItemsAsync()
        {
            try
            {
                var menuItems = new List<MenuElement>();
                var menuItemsDto = await _menuDataService.GetMenuItemsAsync();
                foreach (var itemDto in menuItemsDto)
                {
                    var children = new List<MenuElement>();
                    if (itemDto.Children != null && itemDto.Children.Any())
                    {
                        foreach (var childrenDto in itemDto.Children)
                        {
                            children.Add(new MenuElement(childrenDto.Title, childrenDto.Page, childrenDto.Icon, childrenDto.CanNavigate, childrenDto.Modal));
                        }
                    }
                    menuItems.Add(new MenuElement(itemDto.Title, itemDto.Page, itemDto.Icon, itemDto.CanNavigate, itemDto.Modal, children));
                }
                return menuItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
