using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace shellXamarin.Module.Common.Services.ResourceService
{
    public interface IResourceService
    {
        Stream GetResourceStream(Assembly assembly, string fileName);

        Task<string> GetResourceStringAsync(Assembly assembly, string fileName);

        string GetResourceFullPath(Assembly assembly, string fileName);
    }
}
