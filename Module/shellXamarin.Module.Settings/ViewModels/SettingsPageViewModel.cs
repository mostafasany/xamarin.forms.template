using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Settings.BuinessServices;

namespace shellXamarin.Module.Settings.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;
        private readonly IEventBusService _eventBusService;
        public SettingsPageViewModel(ISettingsService settingsService,
            IEventBusService eventBusService, ILocalService localService, INavigationService navigationService)
            : base(localService, eventBusService)
        {
            _settingsService = settingsService;
            _eventBusService = eventBusService;
            NavigationService = navigationService;
            //TODO: Move This to OnLoad Event
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
            var langs = await _settingsService.GetLanguages();
            if (langs != null && langs.Any())
            {
                languages = new ObservableCollection<Language>(langs);
                usedLanguage = languages.FirstOrDefault(lang => lang.Id == LocalService?.UsedLanague?.Id);
                languages.Remove(usedLanguage);
            }
        }

        private void UserLogout()
        {

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


        #endregion

        #region Commands

        #region LanguageChangedCommand

        public DelegateCommand<Language> LanguageChangedCommand => new DelegateCommand<Language>(LanguageChanged);

        private async void LanguageChanged(Language language)
        {
            if (language != null)
            {
                LocalService.SetDefaultLanguage(language);

                await NavigateHome();
            }
        }

        #endregion


        #region LogoutCommand

        public DelegateCommand LogoutCommand => new DelegateCommand(Logout);

        private async void Logout()
        {
            _eventBusService.Publish<UserLogoutEvent>();

            await NavigateHome();
        }

        #endregion

        #endregion
    }
}
