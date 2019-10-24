using System;
using System.Globalization;
using System.Linq;
using Plugin.Multilingual;
using Prism.Events;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Resources;
using shellXamarin.Module.Common.Services.EventBusService;

namespace shellXamarin.Module.Common.Services
{
    public class LocalService : ILocalService
    {
        //TODO: Make sure all private members to start with `_`
        private readonly IPrefrencesService _settingsService;
        private readonly IEventBusService _eventBusService;
        private const string LanguageKey = "LanguageKey";
        public Language UsedLanague { get; set; }

        public LocalService(IPrefrencesService settingsService, IEventBusService eventBusService)
        {
            _settingsService = settingsService;
            _eventBusService = eventBusService;
        }

        public event LanguageChangedEventHandler LanguageChanged;
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
            var ci = CrossMultilingual.Current.CultureInfoList.FirstOrDefault((arg) => arg.Name == langId);
            AppResources.Culture = ci;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
            CultureInfo.CurrentCulture = ci;
            CultureInfo.CurrentUICulture = ci;
            CrossMultilingual.Current.CurrentCultureInfo = ci;
            UsedLanague = new Language { Id = AppResources.Culture.Name, RTL = AppResources.Culture.TextInfo.IsRightToLeft, Name = AppResources.Culture.DisplayName };

            LanguageChanged.Invoke(UsedLanague);

            //TODO: For unknow reason, eventbus not firing language changed events
            //So LanguageChanged inside localservice is created
            // _eventBusService.Publish<LanguageChangedEvent, Language>(UsedLanague);
        }
    }

    public delegate void LanguageChangedEventHandler(Language language);
}