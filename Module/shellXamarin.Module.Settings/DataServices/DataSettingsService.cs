using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.ResourceService;
using shellXamarin.Module.Settings.DataServices.Dto;

namespace shellXamarin.Module.Settings.DataServices
{
    public class DataSettingsService : IDataSettingsService
    {
        private readonly ILanguageService _languageService;
        private readonly IResourceService _resourceService;
        public DataSettingsService(ILanguageService languageService, IResourceService resourceService)
        {
            _languageService = languageService;
            _resourceService = resourceService;
        }
        public async Task<List<LanguageDto>> GetLanguagesAsync()
        {
            try
            {
                string dbFile = "languages.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}.{1}", _languageService.UsedLanague.Id, dbFile));
                List<LanguageDto> languageDtos = JsonConvert.DeserializeObject<List<LanguageDto>>(json);
                return languageDtos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
