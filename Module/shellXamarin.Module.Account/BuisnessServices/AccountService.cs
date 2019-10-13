using System.Threading.Tasks;
using shellXamarin.Module.Account.DataServices;

namespace shellXamarin.Module.Account.BuinessServices
{
    public class AccountService: IAccountService
    {
        private readonly IAccountDataService accountDataService;
        public AccountService(IAccountDataService _accountDataService)
        {
            accountDataService = _accountDataService;
        }
        public async Task<bool> LogoutAsync()
        {
            return true;
        }
    }
   
}
