﻿using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.Startup.BuinessServices;

namespace shellXamarin.Module.Startup.ViewModels
{
    public class StartupViewModel : BaseViewModel
    {
        private readonly IStartupService startupService;
        public StartupViewModel(INavigationService _navigationService,
            IStartupService _startupService)
        {
            NavigationService = _navigationService;
            startupService = _startupService;
            IsBusy = true;
        }


        #region Commands

        #region RetryCommand

        public DelegateCommand NavigateLoginPageCommand => new DelegateCommand(Navigate);

        private async void Navigate()
        {
            startupService.AppStarted();
        }

        #endregion

        #endregion
    }
}