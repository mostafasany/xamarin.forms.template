using System.Threading.Tasks;

namespace shellXamarin.Module.Account.BuinessServices
{
    public interface IAccountService
    {
        Task<bool> LogoutAsync();
    }
}
