using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Account.Models;
using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Account.BuinessServices
{
    public interface IAccountService
    {
        Task<bool> LogoutAsync();

        Task<User> GetUser();

        Task<List<Gender>> GetGendersAsync();

        Task<List<INavigationElementEntity>> GetGendersNavigationElementsAsync();

        Task<List<City>> GetCitiesAsync();

        Task<List<INavigationElementEntity>> GetCitiesNavigationElementsAsync();

        Task<List<Country>> GetCountriesAsync();
        Task<List<INavigationElementEntity>> GetCountriesNavigationElementsAsync();
    }
}
