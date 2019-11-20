using Newtonsoft.Json;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.ResourceService;
using shellXamarin.Module.ElLa3eba.DataServices.Dto;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace shellXamarin.Module.ElLa3eba.DataServices
{
    class LocationDataService : ILocationDataService
    {
        private readonly ILanguageService _languageService;
        private readonly IResourceService _resourceService;

        public LocationDataService(ILanguageService languageService, IResourceService resourceService)
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

        public async Task<List<CountryDto>> GetCountriesAsync()
        {
            try
            {
                string dbFile = "countries.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}.{1}",
                    _languageService.UsedLanague.Id, dbFile));
                List<CountryDto> countriesDtos = JsonConvert.DeserializeObject<List<CountryDto>>(json);
                return countriesDtos;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<StateDto>> GetStatesAsync()
        {
            try
            {
                string dbFile = "states.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}.{1}",
                    _languageService.UsedLanague.Id, dbFile));
                List<StateDto> stateDto = JsonConvert.DeserializeObject<List<StateDto>>(json);
                return stateDto;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}
