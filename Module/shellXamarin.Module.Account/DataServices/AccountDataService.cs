using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shellXamarin.Module.Account.DataServices.Dto;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.ResourceService;

namespace shellXamarin.Module.Account.DataServices
{
    public class AccountDataService : IAccountDataService
    {
        private readonly ILanguageService _languageService;
        private readonly IResourceService _resourceService;
        public AccountDataService(ILanguageService languageService, IResourceService resourceService)
        {
            _languageService = languageService;
            _resourceService = resourceService;
        }

        public async Task<List<CityDto>> GetCitiesAsync()
        {
            try
            {
                string dbFile = "cities.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}.{1}", _languageService.UsedLanague.Id, dbFile));
                List<CityDto> citiesDtos = JsonConvert.DeserializeObject<List<CityDto>>(json);
                return citiesDtos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<GenderDto>> GetGendersAsync()
        {
            try
            {
                string dbFile = "genders.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}.{1}", _languageService.UsedLanague.Id, dbFile));
                List<GenderDto> genderDtos = JsonConvert.DeserializeObject<List<GenderDto>>(json);
                return genderDtos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<UserDto> GetUserAsync()
        {
            try
            {
                string dbFile = "profile.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}.{1}", _languageService.UsedLanague.Id, dbFile));
                UserDto userDto = JsonConvert.DeserializeObject<UserDto>(json);
                return userDto;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<UserDto> LoginAsync(string email, string password)
        {
            try
            {
                string dbFile = "profile.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}.{1}", _languageService.UsedLanague.Id, dbFile));
                UserDto userDto = JsonConvert.DeserializeObject<UserDto>(json);
                return userDto;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }

}
