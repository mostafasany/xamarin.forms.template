using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Navigation;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Settings.BuinessServices;

namespace shellXamarin.Module.Settings.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private readonly ISettingsService settingsService;
        public SettingsPageViewModel(ISettingsService _settingsService)
        {
            settingsService = _settingsService;
            Load();
        }

        #region Methods

        private async Task LoadLanguages()
        {
            var langs = await settingsService.GetLanguages();
            if (langs != null && langs.Any())
            {
                languages = new ObservableCollection<Language>(langs);
                selectedLanguage = languages.FirstOrDefault();
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


        #endregion

        #region Properties


        ObservableCollection<Language> languages;
        public ObservableCollection<Language> Languages
        {
            get { return languages; }
            set { SetProperty(ref languages, value); }
        }


        Language selectedLanguage;
        public Language SelectedLanguage
        {
            get { return selectedLanguage; }
            set { SetProperty(ref selectedLanguage, value); }
        }

        #endregion
    }
}
