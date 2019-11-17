using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shellXamarin.Module.Common.Services.ResourceService;
using shellXamarin.Module.ElLa3eba.DataServices.Dto;

namespace shellXamarin.Module.ElLa3eba.DataServices
{
    public class TeamDataService : ITeamDataService
    {

        private readonly IResourceService _resourceService;
        public TeamDataService(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }
        public async Task<List<TeamDto>> GetTeamAsync()
        {
            try
            {
                string dbFile = "Team.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}", dbFile));
                List<TeamDto> TeamsDto = JsonConvert.DeserializeObject<List<TeamDto>>(json);
                return TeamsDto;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
