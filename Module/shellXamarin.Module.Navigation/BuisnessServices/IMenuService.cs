using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Navigation.Models;

namespace shellXamarin.Module.Navigation.BuinessServices
{
    public interface IMenuService
    {
        Task<List<MenuElementGroup>> GetMenuItemsAsync(bool isLogin=true);
    }
}
