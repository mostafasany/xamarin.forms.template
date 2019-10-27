using System.Threading.Tasks;
using Prism.Navigation;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;

namespace shellXamarin.Module.Common.ViewModels
{
    public class GenericListViewPageViewModel : BaseViewModel
    {
        public GenericListViewPageViewModel(INavigationService _navigationService,
            IEventBusService eventBusService, ILanguageService localService)
            : base(localService, eventBusService)
        {
            NavigationService = _navigationService;
        }

        #region Properties

        NavigationItem<INavigationElementEntity> navigationItem;
        public NavigationItem<INavigationElementEntity> NavigationItem
        {
            get { return navigationItem; }
            set { SetProperty(ref navigationItem, value); }
        }


        INavigationElementEntity selectedItem;
        public INavigationElementEntity SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
                SelectionChanged(value);
            }
        }


        #endregion

        #region Methods

        private async Task SelectionChanged(INavigationElementEntity _selectedItem)
        {
            if (_selectedItem == null)
                return;

            NavigationParameters parameters = new NavigationParameters();
            NavigationItem.SelectedValue = _selectedItem.Id;
            parameters.Add("SelectedNavigationItem", NavigationItem);
            await NavigationService.GoBackAsync(parameters);
        }

        #endregion

        #region Navigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationItem = parameters.GetValue<NavigationItem<INavigationElementEntity>>("NavigationItem");
            base.OnNavigatedTo(parameters);
        }

        #endregion

        #region Commands


        #endregion
    }
}