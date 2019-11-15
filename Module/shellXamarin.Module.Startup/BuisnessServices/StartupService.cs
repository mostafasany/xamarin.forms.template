using System.Threading.Tasks;
using shellXamarin.Module.Startup.DataServices;

namespace shellXamarin.Module.Startup.BuinessServices
{
    public class StartupService : IStartupService
    {
        private readonly IDataStartupService dataStartupService;
        public StartupService(IDataStartupService _dataStartupService)
        {
            dataStartupService = _dataStartupService;
        }
        /// <summary>
        /// This usually used if apps need to do some logic before app opens:
        /// Like: Calling config api, check if app need to force update.
        /// This logic could be removed if no special business needs to be done.
        /// </summary>
        /// <returns>wether app can proceed to Home page or not</returns>
        public async Task<bool> CanProceedAsync()
        {
            return true;
        }
    }
}
