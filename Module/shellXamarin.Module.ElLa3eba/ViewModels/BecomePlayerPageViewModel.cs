﻿using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;

//TODO: 2. Ahmed Salah 
namespace shellXamarin.Module.ElLa3eba.ViewModels
{
    public class BecomePlayerPageViewModel : BaseViewModel
    {
        public BecomePlayerPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            ILanguageService languageService, IExceptionService exceptionService)
            : base(languageService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
        }

        #region Properties

        #endregion

        #region Methods


        #endregion

        #region Navigation

        #endregion

        #region Commands

        #endregion
    }
}