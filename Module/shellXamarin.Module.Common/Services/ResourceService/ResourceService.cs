using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace shellXamarin.Module.Common.Services.ResourceService
{
    public class ResourceService : IResourceService
    {
        public Stream GetResourceStream(Assembly assembly, string fileName)
        {
            try
            {
                string dbResourcePath = string.Format("{0}.{1}", assembly.GetName().Name, fileName);
                return assembly.GetManifestResourceStream(dbResourcePath);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<string> GetResourceStringAsync(Assembly assembly, string fileName)
        {
            try
            {
                string dbResourcePath = string.Format("{0}.{1}", assembly.GetName().Name, fileName);
                using (var stream = assembly.GetManifestResourceStream(dbResourcePath))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        var json = await reader.ReadToEndAsync();
                        return json;

                    }
                };
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}