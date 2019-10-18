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
                new Language { Id = "en", Name = "English",Flag="https://bit.ly/2MtkYXy" },
                new Language { Id = "ar", Name = "Arabic",Flag="https://bit.ly/2BurIOp" },
                new Language { Id = "de", Name = "Germany",Flag="https://bit.ly/31yuCww" }
            };
        }
    }
}
