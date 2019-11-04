namespace shellXamarin.Module.Common.Services.SharedService
{
    public interface ISharedService
    {
        bool IsLoggedIn();

        string GetUsername();
        string GetAccessToken();
        string GetProfile();

        void SetUser(string username, string profile, string accessToken);

        void RemoveAllUserPreferences();
    }
}
