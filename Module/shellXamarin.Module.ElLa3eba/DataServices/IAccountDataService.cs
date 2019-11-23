using shellXamarin.Module.ElLa3eba.DataServices.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shellXamarin.Module.ElLa3eba.DataServices
{
    public interface IAccountDataService
    {
        Task<UserDto> LoginAsync(string email,string password);

        Task<bool> LogoutAsync();

        Task<List<GenderDto>> GetGendersAsync();

        Task<UserDto> GetUserAsync();

    
    }
}
