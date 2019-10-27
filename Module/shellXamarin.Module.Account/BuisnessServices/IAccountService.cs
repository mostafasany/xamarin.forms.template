using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Account.Models;
using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Account.BuinessServices
{
    public interface IAccountService
    {
        Task<bool> LogoutAsync();

        Task<List<Gender>> GetGendersAsync();

        Task<List<INavigationElementEntity>> GetCitiesNavigationElementsAsync();

        Task<List<City>> GetCitiesAsync();
    }
}
