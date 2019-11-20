using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.ElLa3eba.Models;

namespace shellXamarin.Module.ElLa3eba.BuinessServices
{
    public interface IAccountService
    {
        Task<User> LoginAsync(string email, string password);

        Task<bool> Logout();

        Task<User> GetUser();

        Task<List<Gender>> GetGendersAsync();

        Task<List<INavigationElementEntity>> GetGendersNavigationElementsAsync();
    }
}
