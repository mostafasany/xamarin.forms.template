using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shellXamarin.Module.Account.DataServices;
using shellXamarin.Module.Account.Models;
using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Account.BuinessServices
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataService _accountDataService;
        public AccountService(IAccountDataService accountDataService)
        {
            _accountDataService = accountDataService;
        }

        public async Task<List<INavigationElementEntity>> GetCitiesNavigationElementsAsync()
        {
            try
            {
                var citiesDto = await _accountDataService.GetCitiesAsync();
                List<INavigationElementEntity> navigationElementEntities = new List<INavigationElementEntity>();
                foreach (var city in citiesDto)
                {
                    navigationElementEntities.Add(new City { Id = city.Id, Title = city.Title });
                }
                return navigationElementEntities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<City>> GetCitiesAsync()
        {
            try
            {
                var gendersDto = await _accountDataService.GetCitiesAsync();
                return gendersDto.Select(gender => new City { Id = gender.Id, Title = gender.Title }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
            try
            {
                var gendersDto = await _accountDataService.GetGendersAsync();
                return gendersDto.Select(gender => new Gender { Id = gender.Id, Title = gender.Title }).ToList();
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
                return await _accountDataService.LogoutAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }

}
