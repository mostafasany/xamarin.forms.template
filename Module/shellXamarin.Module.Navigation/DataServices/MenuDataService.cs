using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Navigation.DataServices.Dto;
using Xamarin.Essentials;

namespace shellXamarin.Module.Navigation.DataServices
{
    public class MenuDataService : IMenuDataService
    {
        private readonly ILanguageService _languageService;
        public MenuDataService(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        public async Task<List<MenuElementDto>> GetMenuItemsAsync()
        {
            try
            {
                string mockFilePath = string.Format("Mocks/{0}/menu.json", _languageService.UsedLanague.Id);
                using (var stream = await FileSystem.OpenAppPackageFileAsync(mockFilePath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var json = await reader.ReadToEndAsync();
                        List<MenuElementDto> menuItemsDto = JsonConvert.DeserializeObject<List<MenuElementDto>>(json);
                        return menuItemsDto;
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
