using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Common.Resources;
using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Models;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using Xamarin.Forms;
using shellXamarin.Module.ElLa3eba.BuisnessServices;

//TODO: 2. Moataz Ahmed
namespace shellXamarin.Module.ElLa3eba.ViewModels
{
    public class LocationSelectionPageViewModel : BaseViewModel
    {
        public LocationSelectionPageViewModel(INavigationService _navigationService,
            IEventBusService eventBusService, ILanguageService localService, IPageDialogService dialogService,
            ILocationService accountService, IExceptionService exceptionService)
            : base(localService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _dialogService = dialogService;
            _locationService = accountService;
            LoadForm();
        }

        #region Properties
        private readonly ILocationService _locationService;
        private readonly IPageDialogService _dialogService;
        Form form;
        public Form Form
        {
            get { return form; }
            set { SetProperty(ref form, value); }
        }

        #endregion

        #region Methods
        private async void LoadForm()
        {
            try
            {
                Form = new Form();
                var formItems = new ObservableCollection<FormItem>();
                formItems.Add(new SectionHeaderItem
                {
                    Id = "0",
                    Placeholder = AppResources.account_form_header_location,
                    HorizontalLayoutOptions = LayoutOptions.Start
                });

                formItems.Add(new NavigationItem<INavigationElementEntity>
                {
                    Id = "1",
                    Items = await _locationService.GetCountriesNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = "1",
                    Required = true,
                    InvalidMessage = string.Empty,
                    Placeholder = "AppResources.account_form_countries_placeholder",
                    RequiredMessage = "AppResources.account_form_countries_required",
                    NavigationContext = new NavigationContext
                    {
                        NavigationPage = "GenericListViewPage",
                        NavigationCommand = new DelegateCommand<NavigationItem<INavigationElementEntity>>(NavigationButton),
                    }
                });


                formItems.Add(new NavigationItem<INavigationElementEntity>
                {
                    Id = "2",
                    Items = await _locationService.GetStatesNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = "1",
                    Required = true,
                    InvalidMessage = string.Empty,
                    Placeholder = "AppResources.account_form_states_placeholder",
                    RequiredMessage = "AppResources.account_form_states_required",
                    NavigationContext = new NavigationContext
                    {
                        NavigationPage = "GenericListViewPage",
                        NavigationCommand = new DelegateCommand<NavigationItem<INavigationElementEntity>>(NavigationButton),
                    }
                });


                formItems.Add(new NavigationItem<INavigationElementEntity>
                {
                    Id = "3",
                    Items = await _locationService.GetCitiesNavigationElementsAsync(),
                    SelectedKey = "Id",
                    SelectedValue = "1",
                    Required = true,
                    InvalidMessage = string.Empty,
                    Placeholder = AppResources.account_form_cities_placeholder,
                    RequiredMessage = "AppResources.account_form_cities_required",
                    NavigationContext = new NavigationContext
                    {
                        NavigationPage = "GenericListViewPage",
                        NavigationCommand = new DelegateCommand<NavigationItem<INavigationElementEntity>>(NavigationButton),
                    }
                });


                Form.Items = new ObservableCollection<FormItem>(formItems.Where(a => a.Visible));
            }
            catch (Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        private async void NavigationButton(NavigationItem<INavigationElementEntity> navigationItem)
        {
            try
            {
                if (navigationItem != null)
                {
                    NavigationParameters parameters = new NavigationParameters();
                    parameters.Add("NavigationItem", navigationItem);
                    await NavigationService.NavigateAsync(navigationItem.NavigationContext.NavigationPage, parameters);
                }
            }
            catch (Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        private async void Submit()
        {
            try
            {
                foreach (var item in Form.Items)
                {
                    if (item.IsRequried())
                    {
                        await _dialogService.DisplayAlertAsync("", item.RequiredMessage, AppResources.account_ok);
                        return;
                    }
                    if (item.IsInvalid())
                    {
                        await _dialogService.DisplayAlertAsync("", item.InvalidMessage, AppResources.account_ok);
                        return;
                    }
                }
                await NavigateHome();
            }
            catch (Exception ex)
            {
                ExceptionService.LogAndShowDialog(ex);
            }
        }

        #endregion

        #region Navigation

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                var selectedNavigationItem = parameters.GetValue<NavigationItem<INavigationElementEntity>>("SelectedNavigationItem");
                if (selectedNavigationItem != null)
                {
                    var item = form.Items.FirstOrDefault(a => a.Id == selectedNavigationItem.Id);
                    int index = form.Items.IndexOf(item);
                    form.Items[index] = selectedNavigationItem;
                    RaisePropertyChanged(nameof(form));
                }
            }

            base.OnNavigatedTo(parameters);
        }

        #endregion

        #region Commands

        public DelegateCommand SubmitCommand => new DelegateCommand(Submit);

        #endregion
    }
}