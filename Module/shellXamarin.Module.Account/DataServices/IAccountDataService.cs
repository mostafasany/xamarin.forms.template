using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Account.DataServices.Dto;

namespace shellXamarin.Module.Account.DataServices
{
    public interface IAccountDataService
    {
        Task<UserDto> LoginAsync(string email,string password);

        Task<bool> LogoutAsync();

        Task<List<GenderDto>> GetGendersAsync();

        Task<List<CityDto>> GetCitiesAsync();

        Task<UserDto> GetUserAsync();
    }
}
