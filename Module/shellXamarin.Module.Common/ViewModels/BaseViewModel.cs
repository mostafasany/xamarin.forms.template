using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.ExceptionService;
using Xamarin.Forms;

namespace shellXamarin.Module.Common.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDestructible
    {
        public INavigationService NavigationService { get; set; }
        public IDialogService DialogService { get; set; }
        public IExceptionService ExceptionService { get; set; }
        public ILocalService LocalService { get; set; }
        public BaseViewModel(ILocalService localService)
        {
            LocalService = localService;
            flowDirection = localService.UsedLanague.RTL ?
                FlowDirection = FlowDirection.RightToLeft :
                FlowDirection = FlowDirection.LeftToRight;

            localService.LanguageChanged += LocalService_LanguageChanged;
        }

        private void LocalService_LanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            flowDirection = e.Langauge.RTL ?
                FlowDirection = FlowDirection.RightToLeft :
                FlowDirection = FlowDirection.LeftToRight;
        }

        bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        FlowDirection flowDirection;
        public FlowDirection FlowDirection
        {
            get { return flowDirection; }
            set { SetProperty(ref flowDirection, value); }
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



