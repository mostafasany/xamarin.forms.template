using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.ElLa3eba.DataServices;
using shellXamarin.Module.ElLa3eba.Models;

namespace shellXamarin.Module.ElLa3eba.BuinessServices
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerDataService _playerDataService;
        public PlayerService(IPlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            try
            {
                var playersDto = await _playerDataService.GetPlayersAsync();
                List<Player> players = new List<Player>();
                foreach (var playerDto in playersDto)
                {
                    players.Add(new Player
                    {
                        Age = playerDto.Age,
                        AvailableForNextMatch = playerDto.AvailableForNextMatch,
                        Name = playerDto.Name,
                        Picture = playerDto.Picture,
                        Position = playerDto.Position
                    });
                }
                return players;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
