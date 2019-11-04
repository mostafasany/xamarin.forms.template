using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Account.DataServices.Dto;

namespace shellXamarin.Module.Account.DataServices
{
    public interface IAccountDataService
    {
        Task<bool> LogoutAsync();

        Task<List<GenderDto>> GetGendersAsync();

        Task<List<CityDto>> GetCitiesAsync();
        Task<List<CountryDto>> GetCountriesAsync();

        Task<UserDto> GetUser();
    }
}
