using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.ElLa3eba.Models;

//TODO: 4. Ahmed Salah 
namespace shellXamarin.Module.ElLa3eba.ViewModels
{
    public class PositionSelectionPageViewModel : BaseViewModel
    {
        public PositionSelectionPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            ILanguageService languageService, IExceptionService exceptionService)
            : base(languageService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            initialize();
        }

        #region Properties
        private ObservableCollection<Position> positions;
        public ObservableCollection<Position> Positions
        {
            get { return positions; }
            set { SetProperty(ref positions, value); }
        }
        #endregion

        #region Methods

        async Task LoadPositions()
        {
            try
            {
                positions = new ObservableCollection<Position>();
                positions.Add(new Position { Picture = "Manager.svg", PositionNName = "Manager", Checked = false });
                positions.Add(new Position { Picture = "goalkeeper.svg", PositionNName = "GK", Checked = false });
                positions.Add(new Position { Picture = "Defence.svg", PositionNName = "CB", Checked = false });
                positions.Add(new Position { Picture = "Defence.svg", PositionNName = "LB", Checked = false });
                positions.Add(new Position { Picture = "Defence.svg", PositionNName = "RB", Checked = false });
                positions.Add(new Position { Picture = "Defence.svg", PositionNName = "CDM", Checked = false });
                positions.Add(new Position { Picture = "soccer-player.svg", PositionNName = "RW", Checked = false });
                positions.Add(new Position { Picture = "soccer-player.svg", PositionNName = "LW", Checked = false });
                positions.Add(new Position { Picture = "tshirt.svg", PositionNName = "ST", Checked = false });
                positions.Add(new Position { Picture = "tshirt.svg", PositionNName = "CF", Checked = false });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void initialize()
        {
            await LoadPositions();
        }

        #endregion

        #region Navigation

        #endregion

        #region Commands

        #endregion
    }
}