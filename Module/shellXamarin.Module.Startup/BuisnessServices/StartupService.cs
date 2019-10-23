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
        public async Task<bool> CanProceed()
        {
            await Task.Delay(50);
            return true;
        }
    }
}
