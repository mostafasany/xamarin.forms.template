using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using shellXamarin.Module.Common.Services.ResourceService;
using shellXamarin.Module.ElLa3eba.DataServices.Dto;

namespace shellXamarin.Module.ElLa3eba.DataServices
{
    public class PlayerDataService : IPlayerDataService
    {
        private readonly IResourceService _resourceService;
        public PlayerDataService(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public async Task<List<PlayerDto>> GetPlayersAsync()
        {
            try
            {
                string dbFile = "players.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Common.CommonModule)).Assembly;
                var json = await _resourceService.GetResourceStringAsync(assembly, string.Format("Assets.Mocks.{0}", dbFile));
                List<PlayerDto> playersDto = JsonConvert.DeserializeObject<List<PlayerDto>>(json);
                return playersDto;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
