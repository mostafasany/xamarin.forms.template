using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services.SharedService;
using shellXamarin.Module.ElLa3eba.DataServices;
using shellXamarin.Module.ElLa3eba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shellXamarin.Module.ElLa3eba.BuisnessServices
{
    public class LocationService : ILocationService
    {
        private readonly ILocationDataService _locationDataService;
        private readonly ISharedService _sharedService;
        public LocationService(ILocationDataService accountDataService, ISharedService sharedService)
        {
            _locationDataService = accountDataService;
            _sharedService = sharedService;
        }

        public async Task<List<INavigationElementEntity>> GetCitiesNavigationElementsAsync()
        {
            try
            {
                var citiesDto = await _locationDataService.GetCitiesAsync();
                List<INavigationElementEntity> navigationElementEntities = new List<INavigationElementEntity>();
                foreach (var city in citiesDto)
                {
                    navigationElementEntities.Add(new City { Id = city.Id, Title = city.Title });
                }
                return navigationElementEntities;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<City>> GetCitiesAsync()
        {
            try
            {
                var gendersDto = await _locationDataService.GetCitiesAsync();
                return gendersDto.Select(gender => new City { Id = gender.Id, Title = gender.Title }).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<INavigationElementEntity>> GetStatesNavigationElementsAsync()
        {
            try
            {
                var statesDto = await _locationDataService.GetStatesAsync();
                List<INavigationElementEntity> navigationElementEntities = new List<INavigationElementEntity>();
                foreach (var state in statesDto)
                {
                    navigationElementEntities.Add(new State { Id = state.Id, Title = state.Title });
                }
                return navigationElementEntities;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<State>> GetStatesAsync()
        {
            try
            {
                var stateDto = await _locationDataService.GetStatesAsync();
                return stateDto.Select(state => new State { Id = state.Id, Title = state.Title }).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<INavigationElementEntity>> GetCountriesNavigationElementsAsync()
        {
            try
            {
                var countriesDto = await _locationDataService.GetCountriesAsync();
                List<INavigationElementEntity> navigationElementEntities = new List<INavigationElementEntity>();
                foreach (var country in countriesDto)
                {
                    navigationElementEntities.Add(new Country { Id = country.Id, Title = country.Title });
                }
                return navigationElementEntities;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            try
            {
                var countriesDto = await _locationDataService.GetCountriesAsync();
                return countriesDto.Select(country => new Country { Id = country.Id, Title = country.Title }).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}
