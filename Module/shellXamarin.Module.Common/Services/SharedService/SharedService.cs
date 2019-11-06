using System;
using System.Threading.Tasks;
using shellXamarin.Module.Common.Database;
using shellXamarin.Module.Common.Services.DatabaseService;

namespace shellXamarin.Module.Common.Services.SharedService
{
    public class SharedService : ISharedService
    {
        private readonly IDatabaseService _databaseService;
        public SharedService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<Models.SharedUser> GetUser()
        {
            try
            {
                User user = await _databaseService.DatabaseConnection.Table<User>().FirstOrDefaultAsync();
                if (user == null)
                    return null;
                return new Models.SharedUser
                {
                    Accesstoken = user.Accesstoken,
                    City = user.City,
                    DOB = user.DOB,
                    FName = user.FName,
                    Gender = user.Gender,
                    Id = user.Id,
                    LName = user.LName,
                    Profile = user.Profile
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task SetUser(string firstName, string lastName, string profile, string accessToken)
        {
            try
            {
                int added = await _databaseService.DatabaseConnection.InsertAsync(new User
                {
                    FName = firstName,
                    LName = lastName,
                    Profile = profile,
                    Accesstoken = accessToken
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task RemoveAllUserPreferences()
        {
            try
            {
                await _databaseService.DatabaseConnection.DeleteAllAsync<User>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }

        }
    }
}
