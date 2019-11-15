using System.Threading.Tasks;

namespace shellXamarin.Module.Startup.BuinessServices
{
    public interface IStartupService
    {
        Task<bool> CanProceedAsync();
    }
}
