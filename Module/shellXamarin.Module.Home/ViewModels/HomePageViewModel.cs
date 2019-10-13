using Prism.Navigation;
using shellXamarin.Module.Common.ViewModels;

namespace shellXamarin.Account.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public HomePageViewModel()
        {
            // navigationService = _navigationService;
            Title = "Home";
        }
    }
}