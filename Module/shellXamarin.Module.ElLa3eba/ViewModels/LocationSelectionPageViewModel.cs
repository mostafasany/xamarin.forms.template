using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;

//TODO: 2. Moataz Ahmed
namespace shellXamarin.Module.ElLa3eba.ViewModels
{
    public class LocationSelectionPageViewModel : BaseViewModel
    {
        public LocationSelectionPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
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