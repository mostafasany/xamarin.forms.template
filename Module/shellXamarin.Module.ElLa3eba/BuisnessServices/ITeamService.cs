using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.ElLa3eba.Models;

namespace shellXamarin.Module.ElLa3eba.BuinessServices
{
    public interface ITeamService
    {
        Task<List<TeamModel>> GetTeamsAsync();
    }
}
