using shellXamarin.Module.Home.Views;
using shellXamarin.Module.Settings.Views;
using shellXamarin.Module.Startup.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shellXamarin
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailsPage : MasterDetailPage
    {
        public MasterDetailsPage()
        {
            InitializeComponent();
            //HomePage masterPage = new HomePage();
            //Master = masterPage;
            // MenuPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as MasterDetailsPageMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    MasterPage.ListView.SelectedItem = null;
        //}
    }
}
