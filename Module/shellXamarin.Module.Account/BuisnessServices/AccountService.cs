using System.Threading.Tasks;
using shellXamarin.Module.Account.DataServices;

namespace shellXamarin.Module.Account.BuinessServices
{
    public class AccountService: IAccountService
    {
        private readonly IAccountDataService _accountDataService;
        public AccountService(IAccountDataService accountDataService)
        {
            _accountDataService = accountDataService;
        }
        public async Task<bool> LogoutAsync()
        {
            return true;
        }
    }
   
}
