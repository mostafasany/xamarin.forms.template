using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shellXamarin.Module.Account.DataServices.Dto;
using shellXamarin.Module.Common.Services;
using Xamarin.Essentials;

namespace shellXamarin.Module.Account.DataServices
{
    public class AccountDataService : IAccountDataService
    {
        private readonly ILanguageService _languageService;
        public AccountDataService(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public async Task<List<CityDto>> GetCitiesAsync()
        {
            try
            {
                string mockFilePath = string.Format("Mocks/{0}/cities.json", _languageService.UsedLanague.Id);
                using (var stream = await FileSystem.OpenAppPackageFileAsync(mockFilePath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var json = await reader.ReadToEndAsync();
                        List<CityDto> citiesDtos = JsonConvert.DeserializeObject<List<CityDto>>(json);
                        return citiesDtos;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<GenderDto>> GetGendersAsync()
        {
            try
            {
                string mockFilePath = string.Format("Mocks/{0}/genders.json", _languageService.UsedLanague.Id);
                using (var stream = await FileSystem.OpenAppPackageFileAsync(mockFilePath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var json = await reader.ReadToEndAsync();
                        List<GenderDto> genderDtos = JsonConvert.DeserializeObject<List<GenderDto>>(json);
                        return genderDtos;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<bool> LogoutAsync()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }

}
