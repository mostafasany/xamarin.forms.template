using System.Collections.ObjectModel;
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


        ObservableCollection<Language> languages;
        public ObservableCollection<Language> Languages
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

        #endregion

        #region Methods

        private async Task LoadLanguages()
        {
            var langs = await _settingsService.GetLanguagesAsync();
            if (langs != null && langs.Any())
            {
                Languages = new ObservableCollection<Language>(langs);
                UsedLanguage = languages.FirstOrDefault(lang => lang.Id == LocalService?.UsedLanague?.Id);
                Languages.Remove(usedLanguage);
            }
        }

        private async void LanguageChanged(Language language)
        {
            if (language != null)
            {
                LocalService.SetDefaultLanguage(language);

                await NavigateHome();
            }
        }

        #endregion

        #region Navigation

        public override async Task Load()
        {
            await LoadLanguages();

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

        public override void Destroy()
        {
            base.Destroy();
        }

        private async void Logout()
        {
            _sharedService.RemoveAllUserPreferences();
            await NavigateHome();
        }

        #endregion

        #region Commands

        public DelegateCommand<Language> LanguageChangedCommand => new DelegateCommand<Language>(LanguageChanged);

        public DelegateCommand LogoutCommand => new DelegateCommand(Logout);

        #endregion
    }
}
