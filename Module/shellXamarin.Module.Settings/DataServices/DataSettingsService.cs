using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Settings.Resources;

namespace shellXamarin.Module.Settings.DataServices
{
    public class DataSettingsService : IDataSettingsService
    {
        public async Task<List<Language>> GetLanguages()
        {
            return new List<Language>
            {
                new Language { Id = "en", Name =AppResources.settings_languages_english,Flag="https://bit.ly/2MtkYXy" },
                new Language { Id = "ar", Name = AppResources.settings_languages_arabic,Flag="https://bit.ly/2MJhr7H",RTL=true },
                new Language { Id = "de", Name = AppResources.settings_languages_germany,Flag="https://bit.ly/31yuCww" }
            };
        }
    }
}
