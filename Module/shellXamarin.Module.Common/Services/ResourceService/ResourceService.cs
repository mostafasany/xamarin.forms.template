using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace shellXamarin.Module.Common.Services.ResourceService
{
    public class ResourceService : IResourceService
    {
        public string GetResourceFullPath(Assembly assembly, string fileName)
        {
            try
            {
                return string.Format("{0}.{1}", assembly.GetName().Name, fileName);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public Stream GetResourceStream(Assembly assembly, string fileName)
        {
            try
            {
                string resourcePath = GetResourceFullPath(assembly, fileName);
                return assembly.GetManifestResourceStream(resourcePath);
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
                string resourcePath = GetResourceFullPath(assembly, fileName);
                using (var stream = assembly.GetManifestResourceStream(resourcePath))
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
