using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Settings.DataServices;

namespace shellXamarin.Module.Settings.BuinessServices
{
    public class SettingsService : ISettingsService
    {
        private readonly IDataSettingsService _dataSettingsService;

        public SettingsService(IDataSettingsService dataSettingsService)
        {
            _dataSettingsService = dataSettingsService;
        }

        public async Task<List<Language>> GetLanguages()
        {
            return await _dataSettingsService.GetLanguages();
        }

    }
   
}
