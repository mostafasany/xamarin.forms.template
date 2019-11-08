using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.ResourceService;
using shellXamarin.Module.Navigation.DataServices.Dto;

namespace shellXamarin.Module.Navigation.DataServices
{
    public class MenuDataService : IMenuDataService
    {
        private readonly ILanguageService _languageService;
        private readonly IResourceService _resourceService;
        public MenuDataService(ILanguageService languageService, IResourceService resourceService)
        {
            _languageService = languageService;
            _resourceService = resourceService;
        }

        public async Task<List<MenuElementDto>> GetMenuItemsAsync()
        {
            try
            {
                string dbFile = "menu.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}.{1}", _languageService.UsedLanague.Id, dbFile));
                List<MenuElementDto> menuItemsDto = JsonConvert.DeserializeObject<List<MenuElementDto>>(json);
                return menuItemsDto;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }

}
