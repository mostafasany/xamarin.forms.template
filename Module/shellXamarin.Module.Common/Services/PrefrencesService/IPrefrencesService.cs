namespace shellXamarin.Module.Common.Services
{
    public interface IPrefrencesService
    {
        string Get(string key);
        void Remove(string key);
        void RemoveAll();
        void Set(string key, string value);
    }
}
