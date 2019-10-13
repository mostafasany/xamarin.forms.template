using System.Threading.Tasks;

namespace shellXamarin.Module.Account.DataServices
{
    public interface IAccountDataService
    {
        Task<bool> LogoutAsync();
    }
}
