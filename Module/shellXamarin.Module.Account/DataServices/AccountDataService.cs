using System.Threading.Tasks;

namespace shellXamarin.Module.Account.DataServices
{
    public class AccountDataService : IAccountDataService
    {
        public async Task<bool> LogoutAsync()
        {
            return true;
        }
    }
   
}
