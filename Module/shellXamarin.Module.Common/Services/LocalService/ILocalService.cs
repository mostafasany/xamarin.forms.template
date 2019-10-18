using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Common.Services
{
    public interface ILocalService
    {
        void ChangeLanguage(Language language);
        event LanguageChangedEventHandler LanguageChanged;
        void SetDefaultLocal();
        Language UsedLanague { get; set; }
    }
}