using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Settings.DataServices;

namespace shellXamarin.Module.Settings.BuinessServices
{
    public class SettingsService : ISettingsService
    {
        private readonly IDataSettingsService dataSettingsService;

        public SettingsService(IDataSettingsService _dataSettingsService)
        {
            dataSettingsService = _dataSettingsService;
        }

        public async Task<List<Language>> GetLanguages()
        {
            return await dataSettingsService.GetLanguages();
        }

    }
   
}
