using shellXamarin.Module.ElLa3eba.DataServices.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shellXamarin.Module.ElLa3eba.DataServices
{
   public interface ILocationDataService
    {
        Task<List<CityDto>> GetCitiesAsync();
        Task<List<CountryDto>> GetCountriesAsync();
        Task<List<StateDto>> GetStatesAsync();
    }
}
