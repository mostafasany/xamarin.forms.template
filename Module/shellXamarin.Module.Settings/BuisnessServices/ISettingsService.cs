using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Settings.BuinessServices
{
    public interface ISettingsService
    {
        Task<List<Language>> GetLanguagesAsync();
    }
}
