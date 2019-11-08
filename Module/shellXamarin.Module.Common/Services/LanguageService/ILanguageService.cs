using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Common.Services
{
    public interface ILanguageService
    {
        void SetDefaultLanguage(Language language = null);
        Language UsedLanague { get; set; }
        event LanguageChangedEventHandler LanguageChanged;

        void ChangeTheme(string theme = null);
        string UsedTheme { get; set; }
        event ThemeChangedEventHandler ThemeChanged;
    }
}