using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Common.Services
{
    public interface ILocalService
    {
        void ChangeLanguage(Language language);
        string GetLanguage();
        event LanguageChangedEventHandler LanguageChanged;
        void SetDefaultLocal();
        Languages CurrentLanague { get; }
    }
}