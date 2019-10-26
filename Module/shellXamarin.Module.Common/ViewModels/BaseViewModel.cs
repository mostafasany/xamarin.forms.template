using System;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using shellXamarin.Module.Common.Events;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
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
        private readonly Tuple<UserLogoutEvent, SubscriptionToken> userLogoutEventAndToken;
        private readonly Tuple<UserLoginEvent, SubscriptionToken> userLoginEventAndToken;
        private readonly Tuple<LanguageChangedEvent, SubscriptionToken> languageChangedEventAndToken;
        public BaseViewModel(ILocalService localService, IEventBusService eventBusService)
        {
            LocalService = localService;
            flowDirection = localService.UsedLanague.RTL ?
                FlowDirection = FlowDirection.RightToLeft :
                FlowDirection = FlowDirection.LeftToRight;

            userLogoutEventAndToken = eventBusService.Subscribe<UserLogoutEvent>(UserLogout);
            userLoginEventAndToken = eventBusService.Subscribe<UserLoginEvent>(UserLogin);
            localService.LanguageChanged += LanguageChanged;

            //TODO: For unknow reason, eventbus not firing language changed events
            //So LanguageChanged inside localservice is created
            // languageChangedEventAndToken = eventBusService.Subscribe<LanguageChangedEvent, Language>(LanguageChanged);
        }

        private void LanguageChanged(Language language)
        {
            flowDirection = language.RTL ?
                FlowDirection = FlowDirection.RightToLeft :
                FlowDirection = FlowDirection.LeftToRight;

            //var ci = new CultureInfo(language.Id);
            //CultureInfo.DefaultThreadCurrentCulture = ci;
            //CultureInfo.DefaultThreadCurrentUICulture = ci;
            //CultureInfo.CurrentCulture = ci;
            //CultureInfo.CurrentUICulture = ci;
        }

        private void UserLogout()
        {

        }

        private void UserLogin()
        {

        }

        bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                SetProperty(ref isBusy, value);
                RaisePropertyChanged(nameof(NotBusy));
            }
        }

        public bool NotBusy => !isBusy;

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

        //TODO:Check if clearHistory needed
        protected async Task NavigateHome(bool clearHistory = true)
        {
            if (NavigationService == null)
            {
                throw new Exception("NavigationService not set");
            }
            if (clearHistory)
                await NavigationService.NavigateAsync("/MasterDetailsPage/HomeTabbedPage");
            else
                await NavigationService.NavigateAsync("MasterDetailsPage/HomeTabbedPage");

            // await NavigationService.NavigateAsync("/MasterDetailsPage/NavigationPage/HomePage");

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
            if (userLogoutEventAndToken != null)
                userLogoutEventAndToken.Item1.Unsubscribe(userLogoutEventAndToken.Item2);

            if (userLoginEventAndToken != null)
                userLoginEventAndToken.Item1.Unsubscribe(userLoginEventAndToken.Item2);

            if (languageChangedEventAndToken != null)
                languageChangedEventAndToken.Item1.Unsubscribe(languageChangedEventAndToken.Item2);
        }
    }
}



