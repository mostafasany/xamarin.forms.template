using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Navigation.DataServices.Dto;

namespace shellXamarin.Module.Navigation.DataServices
{
    public interface IMenuDataService
    {
        Task<List<MenuElementDto>> GetMenuItemsAsync();
    }
}
