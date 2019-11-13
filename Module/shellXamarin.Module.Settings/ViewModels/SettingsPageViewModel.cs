using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.Services.SharedService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Settings.BuinessServices;

namespace shellXamarin.Module.Settings.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;
        private readonly ISharedService _sharedService;
        public SettingsPageViewModel(ISettingsService settingsService, IExceptionService exceptionService, ISharedService sharedService,
            IEventBusService eventBusService, ILanguageService localService, INavigationService navigationService)
            : base(localService, eventBusService, exceptionService)
        {
            _settingsService = settingsService;
            _sharedService = sharedService;
            NavigationService = navigationService;

            //TODO: Settings Page is in Home tab bar, so data has to be constructed a head
            Load();
        }

        #region Properties


        List<Language> languages;
        public List<Language> Languages
        {
            get { return languages; }
            set { SetProperty(ref languages, value); }
        }


        Language usedLanguage;
        public Language UsedLanguage
        {
            get { return usedLanguage; }
            set { SetProperty(ref usedLanguage, value); }
        }


        List<string> themes;
        public List<string> Themes
        {
            get { return themes; }
            set { SetProperty(ref themes, value); }
        }


        string usedTheme;
        public string UsedTheme
        {
            get { return usedTheme; }
            set
            {
                SetProperty(ref usedTheme, value);
                if (usedTheme != null)
                {
                    LocalService.ChangeTheme(usedTheme);
                }
            }
        }

        #endregion

        #region Methods

        private async Task LoadLanguages()
        {
            try
            {
                var langs = await _settingsService.GetLanguagesAsync();
                if (langs != null && langs.Any() && LocalService?.UsedLanague?.Id != UsedLanguage?.Id)
                {
                    Languages = langs;
                    UsedLanguage = languages.FirstOrDefault(lang => lang.Id == LocalService?.UsedLanague?.Id);
                    if (UsedLanguage != null)
                        Languages.Remove(usedLanguage);
                }
            }
            catch (System.Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }


        private async Task LoadThemes()
        {
            try
            {
                Themes = new List<string>();
                Themes.Add("Dark");
                Themes.Add("Light");
                UsedTheme = Themes.FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }

        }


        private async void LanguageChanged(Language language)
        {
            try
            {
                if (language != null)
                {
                    LocalService.SetDefaultLanguage(language);

                    await NavigateHome();
                }
            }
            catch (System.Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        #endregion

        #region Navigation

        public override async Task Load()
        {
            await LoadLanguages();

            //await LoadThemes();

            await base.Load();
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode navigationMode = parameters.GetNavigationMode();
            if (navigationMode == NavigationMode.Back)
                return;

            await Load();

            base.OnNavigatedTo(parameters);
        }

        private async void Logout()
        {
            await _sharedService.RemoveAllUserPreferences();
            await NavigateHome();
        }

        #endregion

        #region Commands

        public DelegateCommand<Language> LanguageChangedCommand => new DelegateCommand<Language>(LanguageChanged);

        public DelegateCommand LogoutCommand => new DelegateCommand(Logout);

        #endregion
    }
}
