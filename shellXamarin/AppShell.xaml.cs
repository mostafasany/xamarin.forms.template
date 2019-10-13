using shellXamarin.ViewModels;

namespace shellXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            if(this.BindingContext==null)
               this.BindingContext = new AppShellViewModel();
        }
    }
}
