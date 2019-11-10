using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.ElLa3eba.Models;

namespace shellXamarin.Module.ElLa3eba.BuinessServices
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayersAsync();
    }
}
