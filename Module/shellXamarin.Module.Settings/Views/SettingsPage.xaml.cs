using shellXamarin.Module.Settings.BuinessServices;
using shellXamarin.Module.Settings.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.Settings.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            //if (this.BindingContext == null)
            //    this.BindingContext = new SettingsPageViewModel(settingsService);
        }
    }
}
