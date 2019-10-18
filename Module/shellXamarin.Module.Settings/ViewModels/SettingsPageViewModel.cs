﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Settings.BuinessServices;

namespace shellXamarin.Module.Settings.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private readonly ISettingsService _settingsService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ILocalService _localService;
        public SettingsPageViewModel(ISettingsService settingsService,
            IEventAggregator eventAggregator,
            ILocalService localService, INavigationService navigationService)
        {
            _settingsService = settingsService;
            _eventAggregator = eventAggregator;
            _localService = localService;
            NavigationService = navigationService;
            //TODO: Move This to OnLoad Event
            Load();
        }

        #region Methods

        private async Task LoadLanguages()
        {
            var langs = await _settingsService.GetLanguages();
            if (langs != null && langs.Any())
            {
                languages = new ObservableCollection<Language>(langs);
                usedLanguage = languages.FirstOrDefault(lang => lang.Id == _localService?.UsedLanague?.Id);
                languages.Remove(usedLanguage);
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


        Language usedLanguage;
        public Language UsedLanguage
        {
            get { return usedLanguage; }
            set { SetProperty(ref usedLanguage, value); }
        }

        #endregion


        #region Commands

        #region LanguageChangedCommand

        public DelegateCommand<Language> LanguageChangedCommand => new DelegateCommand<Language>(LanguageChanged);

        private void LanguageChanged(Language language)
        {
            if (language != null)
            {
                _localService.ChangeLanguage(language);
                NavigationService.NavigateAsync("/HomePage");
            }
        }

        #endregion


        #region LogoutCommand

        public DelegateCommand LogoutCommand => new DelegateCommand(Logout);

        private void Logout()
        {
            _eventAggregator.GetEvent<UserLogoutEvent>().Publish();
            NavigationService.NavigateAsync("/HomePage");
        }

        #endregion

        #endregion
    }
}