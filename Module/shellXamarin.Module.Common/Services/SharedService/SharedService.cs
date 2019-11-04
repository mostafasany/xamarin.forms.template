namespace shellXamarin.Module.Common.Services.SharedService
{
    public class SharedService : ISharedService
    {
        private readonly IPrefrencesService _prefrencesService;
        const string AccessTokenKey = "AccessTokenKey";
        const string UserNameKey = "UserNameKey";
        const string UserProfileKey = "UserProfileKey";
        public SharedService(IPrefrencesService prefrencesService)
        {
            _prefrencesService = prefrencesService;
        }

        public string GetAccessToken()
        {
            return _prefrencesService.Get(AccessTokenKey);
        }


        public string GetProfile()
        {
            return _prefrencesService.Get(UserProfileKey);
        }

        public string GetUsername()
        {
            return _prefrencesService.Get(UserNameKey);
        }

        public bool IsLoggedIn()
        {
            return GetAccessToken() != string.Empty;
        }

        public void SetUser(string username, string profile, string accessToken)
        {
            _prefrencesService.Set(UserNameKey, username);
            _prefrencesService.Set(UserProfileKey, profile);
            _prefrencesService.Set(AccessTokenKey, accessToken);
        }

        public void RemoveAllUserPreferences()
        {
            _prefrencesService.Remove(UserProfileKey);
            _prefrencesService.Remove(UserNameKey);
            _prefrencesService.Remove(AccessTokenKey);
        }
    }
}
