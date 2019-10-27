using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Language>> GetLanguagesAsync()
        {
            try
            {
                var languageDtos = await _dataSettingsService.GetLanguagesAsync();
                return languageDtos.Select(language => new Language
                {
                    Id = language.Id,
                    Name = language.Name,
                    Flag = language.Flag,
                    RTL = language.RTL
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }

}
