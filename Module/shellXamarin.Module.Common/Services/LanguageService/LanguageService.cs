using System.Globalization;
using System.Linq;
using Plugin.Multilingual;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Resources;

namespace shellXamarin.Module.Common.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IPrefrencesService _settingsService;
        private const string LanguageKey = "LanguageKey";
        private const string ThemeKey = "ThemeKey";
        public Language UsedLanague { get; set; }
        public string UsedTheme { get; set; }

        public LanguageService(IPrefrencesService settingsService)
        {
            _settingsService = settingsService;
        }

        public event LanguageChangedEventHandler LanguageChanged;
        public event ThemeChangedEventHandler ThemeChanged;

        public void SetDefaultLanguage(Language language = null)
        {
            string langId = string.Empty;
            if (language == null)
            {
                langId = _settingsService.Get(LanguageKey);
            }
            else
            {
                langId = language.Id;
            }

            if (string.IsNullOrEmpty(langId))
            {
                langId = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            }

            _settingsService.Set(LanguageKey, langId);

            //MainThread.BeginInvokeOnMainThread(() =>
            //{
            var ci = CrossMultilingual.Current.CultureInfoList.FirstOrDefault((arg) => arg.Name == langId);
            AppResources.Culture = ci;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
            CultureInfo.CurrentCulture = ci;
            CultureInfo.CurrentUICulture = ci;
            CrossMultilingual.Current.CurrentCultureInfo = ci;
            UsedLanague = new Language { Id = AppResources.Culture.Name, RTL = AppResources.Culture.TextInfo.IsRightToLeft, Name = AppResources.Culture.DisplayName };
            // });

            LanguageChanged?.Invoke(UsedLanague);
        }

        public void ChangeTheme(string theme)
        {
            string usedTheme = string.Empty;
            if (theme == null)
            {
                usedTheme = _settingsService.Get(ThemeKey);
            }
            else
            {
                usedTheme = theme;
            }

            if (string.IsNullOrEmpty(usedTheme))
            {
                usedTheme = "Dark";
            }
            _settingsService.Set(ThemeKey, usedTheme);
            UsedTheme = usedTheme;
            ThemeChanged?.Invoke(theme);
        }
    }

    public delegate void LanguageChangedEventHandler(Language language);

    public delegate void ThemeChangedEventHandler(string theme);
}