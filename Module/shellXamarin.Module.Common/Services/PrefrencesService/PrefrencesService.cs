using Xamarin.Essentials;

namespace shellXamarin.Module.Common.Services
{
    public class PrefrencesService: IPrefrencesService
    {
        public string Get(string key)
        {
            if (Preferences.ContainsKey(key))
                return Preferences.Get(key, string.Empty);
            else
                return string.Empty;
        }

        public void Remove(string key)
        {
            Preferences.Remove(key);
        }

        public void RemoveAll()
        {
            Preferences.Clear();
        }

        public void Set(string key, string value)
        {
            Preferences.Set(key,value);
        }
    }
}
