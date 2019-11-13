using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.ElLa3eba.DataServices.Dto;

namespace shellXamarin.Module.ElLa3eba.DataServices
{
    public interface IPlayerDataService
    {
        Task<List<PlayerDto>> GetPlayersAsync();
    }
}
