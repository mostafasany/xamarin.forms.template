using System.Globalization;
using System.Linq;
using Plugin.Multilingual;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Resources;

namespace shellXamarin.Module.Common.Services
{
    public class LocalService : ILocalService
    {
        private readonly IPrefrencesService _settingsService;
        private const string LanguageKey = "LanguageKey";

        public Language UsedLanague { get; set; }

        public LocalService(IPrefrencesService settingsService) => _settingsService = settingsService;

        public void SetDefaultLocal()
        {
            string lang = _settingsService.Get(LanguageKey);
            if (string.IsNullOrEmpty(lang))
            {
                lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                _settingsService.Set(LanguageKey, lang);
            }
            AppResources.Culture = CrossMultilingual.Current.CultureInfoList.FirstOrDefault((arg) => arg.Name == lang);
            UsedLanague = new Language { Id = AppResources.Culture.Name, RTL = AppResources.Culture.TextInfo.IsRightToLeft, Name = AppResources.Culture.DisplayName };
            CrossMultilingual.Current.CurrentCultureInfo = AppResources.Culture;

        }

        public event LanguageChangedEventHandler LanguageChanged;

        public void ChangeLanguage(Language language)
        {
            //TODO: Change Language cant happens on the fly, it need page to be refreshed.
            _settingsService.Set(LanguageKey, language.Id);
            SetDefaultLocal();
            LanguageChanged?.Invoke(this, new LanguageChangedEventArgs { Langauge = language });
        }
    }
}