using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Settings.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.Settings.Views
{
    public partial class SettingsPage : ContentPage
    {
        private SettingsPageViewModel _settingsPageViewModel;
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_settingsPageViewModel == null)
                _settingsPageViewModel = this.BindingContext as SettingsPageViewModel;
        }

        //TODO: Try to move this logic to SettingsPageViewModel
        void languageLV_SelectedIndexChanged(object sender, SelectedItemChangedEventArgs e)
        {
            _settingsPageViewModel?.LanguageChangedCommand.Execute(e?.SelectedItem as Language);
        }
    }
}
