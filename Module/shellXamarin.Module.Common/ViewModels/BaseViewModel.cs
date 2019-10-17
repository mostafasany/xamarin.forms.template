using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using shellXamarin.Module.Common.Services.ExceptionService;

namespace shellXamarin.Module.Common.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        public INavigationService NavigationService { get; set; }
        public IDialogService DialogService { get; set; }
        public IExceptionService ExceptionService { get; set; }

        bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public virtual async Task Load()
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {
        }
    }
}
