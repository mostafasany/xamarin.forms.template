//using System;
//using Prism.Navigation;
//using shellXamarin.Module.Common.Models;
//using shellXamarin.Module.Common.FormBuilder.Models;
//using shellXamarin.Module.Common.Services;
//using shellXamarin.Module.Common.Services.EventBusService;
//using shellXamarin.Module.Common.ViewModels;

//namespace shellXamarin.Module.Commonn.ViewModels
//{
//    public class GenericListViewPageViewModel : BaseViewModel
//    {
//        Type navigationItemType;
//        public GenericListViewPageViewModel(INavigationService _navigationService,
//            IEventBusService eventBusService, ILocalService localService)
//            : base(localService, eventBusService)
//        {
//            NavigationService = _navigationService;
//        }

//        #region Properties

//        NavigationItem<City> navigationItem;
//        public NavigationItem<City> NavigationItem
//        {
//            get { return navigationItem; }
//            set { SetProperty(ref navigationItem, value); }
//        }


//        City selectedItem;
//        public City SelectedItem
//        {
//            get { return selectedItem; }
//            set
//            {
//                SetProperty(ref selectedItem, value);
//                SelectedChange(value);
//            }
//        }


//        #endregion

//        #region Methods

//        private async void SelectedChange(City city)
//        {
//            if (city == null)
//                return;

//            Prism.Navigation.NavigationParameters parameters = new Prism.Navigation.NavigationParameters();
//            parameters.Add("NavigationItemType", navigationItemType);
//            NavigationItem.SelectedValue = city.Id;
//            parameters.Add("SelectedNavigationItem", NavigationItem);
//            await NavigationService.GoBackAsync(parameters);
//        }

//        #endregion

//        #region Navigation

//        public override void OnNavigatedTo(INavigationParameters parameters)
//        {
//            navigationItemType = parameters.GetValue<Type>("NavigationItemType");
//            if (navigationItemType == typeof(City))
//            {
//                NavigationItem = parameters.GetValue<NavigationItem<City>>("NavigationItem");
//            }

//            base.OnNavigatedTo(parameters);
//        }

//        #endregion

//        #region Commands


//        #endregion
//    }
//}