using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace shellXamarin.Module.Navigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailsPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public MasterDetailsPage()
        {
            InitializeComponent();
        }
        public bool IsPresentedAfterNavigation
        {
            get { return Device.Idiom != TargetIdiom.Phone; }
        }
    }
}
