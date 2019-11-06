using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using shellXamarin.Module.Account.DataServices;
using shellXamarin.Module.Account.Models;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services.SharedService;

namespace shellXamarin.Module.Account.BuinessServices
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataService _accountDataService;
        private readonly ISharedService _sharedService;
        public AccountService(IAccountDataService accountDataService, ISharedService sharedService)
        {
            _accountDataService = accountDataService;
            _sharedService = sharedService;
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<List<INavigationElementEntity>> GetGendersNavigationElementsAsync()
        {
            try
            {
                var genderDtos = await _accountDataService.GetGendersAsync();
                List<INavigationElementEntity> navigationElementEntities = new List<INavigationElementEntity>();
                foreach (var gender in genderDtos)
                {
                    navigationElementEntities.Add(new City { Id = gender.Id, Title = gender.Title });
                }
                return navigationElementEntities;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<User> GetUser()
        {
            try
            {
                //TODO: 31/10/1989 is not rendered correcly 
                var userDto = await _accountDataService.GetUserAsync();
                return new User
                {
                    City = userDto.City,
                    DOB = DateTime.ParseExact(userDto.DOB, "dd/MM/yyyy",
                                           CultureInfo.InvariantCulture),
                    FName = userDto.FName,
                    Gender = userDto.Gender,
                    Id = userDto.Id,
                    LName = userDto.LName
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            try
            {
                var userDto = await _accountDataService.LoginAsync(email, password);
                await _sharedService.SetUser(userDto.FName, userDto.LName, userDto.Profile, Guid.NewGuid().ToString());

                return new User
                {
                    City = userDto.City,
                    DOB = DateTime.ParseExact(userDto.DOB, "dd/MM/yyyy",
                                           CultureInfo.InvariantCulture),
                    FName = userDto.FName,
                    Gender = userDto.Gender,
                    Id = userDto.Id,
                    LName = userDto.LName
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<bool> Logout()
        {
            try
            {
                await _accountDataService.LogoutAsync();
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
