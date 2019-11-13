using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.ElLa3eba.BuinessServices;
using shellXamarin.Module.ElLa3eba.Models;

namespace shellXamarin.Module.ElLa3eba.ViewModels
{
    public class SetFromationPageViewModel : BaseViewModel
    {
        private readonly IPlayerService _playerService;
        private readonly IPageDialogService _pageDialogService;
        public SetFromationPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            IPageDialogService pageDialogService,
            ILanguageService languageService, IExceptionService exceptionService, IPlayerService playerService)
            : base(languageService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _playerService = playerService;
            _pageDialogService = pageDialogService;
        }

        #region Properties


        List<Player> players;
        public List<Player> Players
        {
            get { return players; }
            set { SetProperty(ref players, value); }
        }

        List<PlayersByPosition> playersByPosition;
        public List<PlayersByPosition> PlayersByPosition
        {
            get { return playersByPosition; }
            set { SetProperty(ref playersByPosition, value); }
        }

        #endregion

        #region Methods

        async Task LoadPlayers()
        {
            try
            {
                Players = await _playerService.GetPlayersAsync();
                var groupedPlayers = players.GroupBy(player => player.Position).ToList();
                PlayersByPosition = new List<PlayersByPosition>();
                foreach (var group in groupedPlayers)
                {
                    PlayersByPosition.Add(new PlayersByPosition(group.Key, group));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void PlayerCheckedChanged(Player obj)
        {

        }

        private void SetReminder()
        {
            _pageDialogService.DisplayAlertAsync("", "Reminder set", "ok");
        }


        private void OpenMaps()
        {
            _pageDialogService.DisplayAlertAsync("", "Maps Opens", "ok");
        }

        private void SetNextMatchFormation()
        {
            _pageDialogService.DisplayAlertAsync("", "Formation set", "ok");
        }

        #endregion

        #region Navigation

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                base.OnNavigatedTo(parameters);
                await LoadPlayers();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        #endregion

        #region Commands

        public DelegateCommand<Player> PlayerCheckedChangedCommand => new DelegateCommand<Player>(PlayerCheckedChanged);
        public DelegateCommand SetReminderCommand => new DelegateCommand(SetReminder);
        public DelegateCommand OpenMapsCommand => new DelegateCommand(OpenMaps);
        public DelegateCommand SetNextMatchFormationCommand => new DelegateCommand(SetNextMatchFormation);

        #endregion
    }
}
