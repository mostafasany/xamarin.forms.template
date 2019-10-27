using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Settings.DataServices.Dto;
using Xamarin.Essentials;

namespace shellXamarin.Module.Settings.DataServices
{
    public class DataSettingsService : IDataSettingsService
    {
        private readonly ILanguageService _languageService;
        public DataSettingsService(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        public async Task<List<LanguageDto>> GetLanguagesAsync()
        {
            try
            {
                string mockFilePath = string.Format("Mocks/{0}/languages.json", _languageService.UsedLanague.Id);
                using (var stream = await FileSystem.OpenAppPackageFileAsync(mockFilePath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var json = await reader.ReadToEndAsync();
                        List<LanguageDto> languageDtos = JsonConvert.DeserializeObject<List<LanguageDto>>(json);
                        return languageDtos;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
