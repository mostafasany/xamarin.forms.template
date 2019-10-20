using Prism.Events;
using Prism.Ioc;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Home.ViewModels;
using shellXamarin.Module.Home.Views;
using shellXamarin.Module.Settings.BuinessServices;
using shellXamarin.Module.Settings.ViewModels;
using shellXamarin.Module.Settings.Views;
using shellXamarin.ViewModels;
using Xamarin.Forms;

namespace shellXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell(IContainerProvider containerProvider, INavigationService navigationService)
        {
            InitializeComponent();
            var localService = containerProvider.Resolve<ILocalService>();
            var eventAggregator = containerProvider.Resolve<IEventAggregator>();
            var settingsService = containerProvider.Resolve<ISettingsService>();

            var homePage = new HomePage();
            homePage.BindingContext = new HomePageViewModel(navigationService, localService);
            home.ContentTemplate = new DataTemplate(() => { return homePage; });


            var settingsPage = new SettingsPage();
            settingsPage.BindingContext = new SettingsPageViewModel(settingsService, eventAggregator, localService, navigationService);
            settings.ContentTemplate = new DataTemplate(() => { return settingsPage; });

            if (this.BindingContext == null)
                this.BindingContext = new AppShellViewModel(localService);
        }
    }
}
