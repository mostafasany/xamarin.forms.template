using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Settings.DataServices.Dto;

namespace shellXamarin.Module.Settings.DataServices
{
    public interface IDataSettingsService
    {
        Task<List<LanguageDto>> GetLanguagesAsync();
    }
}
