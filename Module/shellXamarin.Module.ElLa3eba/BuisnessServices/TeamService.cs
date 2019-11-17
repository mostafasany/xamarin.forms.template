using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using shellXamarin.Module.ElLa3eba.DataServices;
using shellXamarin.Module.ElLa3eba.Models;

namespace shellXamarin.Module.ElLa3eba.BuinessServices
{
    public class TeamService : ITeamService
    {
        private readonly ITeamDataService _teamDataService;
        public TeamService(ITeamDataService TeamDataService)
        {
            _teamDataService = TeamDataService;
        }

        public async Task<List<TeamModel>> GetTeamsAsync()
        {
            try
            {
                var TeamsDto = await _teamDataService.GetTeamAsync();
                List<TeamModel> teams = new List<TeamModel>();
                foreach (var team in TeamsDto)
                {
                    teams.Add(new TeamModel
                    {
                        Picture = team.Picture,
                        Name = team.Name,
                        Position = team.Position
                    });
                }
                return teams;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }


    }
}
