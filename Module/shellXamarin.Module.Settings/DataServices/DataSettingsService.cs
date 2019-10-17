using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Settings.DataServices
{
    public class DataSettingsService : IDataSettingsService
    {
        public async Task<List<Language>> GetLanguages()
        {
            return new List<Language>
            {
                new Language { Id = "en", Name = "English",Flag="https://cdn.icon-icons.com/icons2/97/PNG/256/germany_flags_flag_17001.png" },
                new Language { Id = "ar", Name = "Arabic" },
                new Language { Id = "fr", Name = "French" }
            };
        }
    }
}
