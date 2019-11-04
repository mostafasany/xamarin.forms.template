using System;
using shellXamarin.Module.Navigation.Models;
using shellXamarin.Module.Navigation.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shellXamarin.Module.Navigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailsPage : MasterDetailPage
    {
        MasterDetailsPageViewModel vm;
        public MasterDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vm = this.BindingContext as MasterDetailsPageViewModel;
            base.OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigate(e.SelectedItem as MenuElement);
        }

        private void OnHeaderClicked(object sender, EventArgs args)
        {
            Navigate((args as TappedEventArgs).Parameter as MenuElement);
        }

        void Navigate(MenuElement menuElement)
        {
            if (menuElement == null)
                return;

            vm.OnNavigateCommand.Execute(menuElement);

            if (menuElement.CanNavigate)
                IsPresented = false;
        }
    }
}
