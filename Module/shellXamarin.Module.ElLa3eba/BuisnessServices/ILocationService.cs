using shellXamarin.Module.Common.Models;
using shellXamarin.Module.ElLa3eba.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shellXamarin.Module.ElLa3eba.BuisnessServices
{
    public interface ILocationService
    {

        Task<List<City>> GetCitiesAsync();

        Task<List<INavigationElementEntity>> GetCountriesNavigationElementsAsync();

        Task<List<Country>> GetCountriesAsync();

        Task<List<INavigationElementEntity>> GetCitiesNavigationElementsAsync();

        Task<List<State>> GetStatesAsync();

        Task<List<INavigationElementEntity>> GetStatesNavigationElementsAsync();
    }
}
