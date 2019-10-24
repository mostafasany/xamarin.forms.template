using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Common.Services
{
    public interface ILocalService
    {
        void SetDefaultLanguage(Language language = null);
        Language UsedLanague { get; set; }
        event LanguageChangedEventHandler LanguageChanged;
    }
}