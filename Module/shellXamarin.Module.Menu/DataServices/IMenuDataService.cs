using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Navigation.Models;

namespace shellXamarin.Module.Navigation.DataServices
{
    public interface IMenuDataService
    {
        Task<List<MenuElement>> GetMenuItemsAsync();
    }
}
