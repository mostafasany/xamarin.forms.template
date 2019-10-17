using System.Globalization;

namespace shellXamarin.Module.Common.Services
{
    public enum Languages { Arabic,English};
    public class LocalService : ILocalService
    {
        private readonly IPrefrencesService _settingsService;
        private const string LanguageKey = "LanguageKey";
        private const string LanguageArKey = "ar";
        private const string LanguageEnKey = "en";
        public Languages CurrentLanague
        {
            get
            {
                var language = GetLanguage();
                return language == "ar" ? Languages.Arabic:Languages.English;
            }
        }

        public LocalService(IPrefrencesService settingsService) => _settingsService = settingsService;

        public void SetDefaultLocal()
        {
            string deviceCulture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            string lang = _settingsService.Get(LanguageKey);
            //if (string.IsNullOrEmpty(lang))
            //{
            //    if (deviceCulture == LanguageArKey)
            //        AppResources.Culture = CrossMultilingual.Current.CultureInfoList[1];
            //    else if (deviceCulture == LanguageEnKey)
            //        AppResources.Culture = CrossMultilingual.Current.CultureInfoList[10];
            //}
            //else
            //{
            //    AppResources.Culture = lang == LanguageArKey ? CrossMultilingual.Current.CultureInfoList[1] : CrossMultilingual.Current.CultureInfoList[10];
            //}

           // CrossMultilingual.Current.CurrentCultureInfo = AppResources.Culture;
            if (string.IsNullOrEmpty(lang))
                _settingsService.Set(LanguageKey, deviceCulture);
        }

        public event LanguageChangedEventHandler LanguageChanged;

        public void ChangeLanguage(string language)
        {
            _settingsService.Set(LanguageKey, language);
            LanguageChanged?.Invoke(this, new LanguageChangedEventArgs {Langauge = language});
        }

        public string GetLanguage()
        {
            string lang = _settingsService.Get(LanguageKey);
            return lang;
        }
    }
}