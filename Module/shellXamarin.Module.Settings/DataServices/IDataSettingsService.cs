using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.Common.Models;


namespace shellXamarin.Module.Settings.DataServices
{
    public interface IDataSettingsService
    {
        Task<List<Language>> GetLanguages();
    }
}
