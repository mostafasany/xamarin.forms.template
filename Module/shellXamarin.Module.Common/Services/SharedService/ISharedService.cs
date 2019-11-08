using System.Threading.Tasks;

namespace shellXamarin.Module.Common.Services.SharedService
{
    public interface ISharedService
    {
        Task<Models.SharedUser> GetUser();

        Task SetUser(string firstName, string lastName, string profile, string accessToken);

        Task RemoveAllUserPreferences();
    }
}
