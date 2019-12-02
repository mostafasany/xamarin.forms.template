using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.ElLa3eba.BuinessServices;
using shellXamarin.Module.ElLa3eba.DataServices;
using shellXamarin.Module.ElLa3eba.Models;

//TODO: 2. Ahmed Salah 
namespace shellXamarin.Module.ElLa3eba.ViewModels
{
    public class BecomePlayerPageViewModel : BaseViewModel
    {
        private readonly ITeamService _TeamService;
        public BecomePlayerPageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            ILanguageService languageService, IExceptionService exceptionService, ITeamService teamService)
            : base(languageService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;
            _TeamService = teamService;

            LoadTeams();
        }

        #region Properties


        List<TeamModel> teams;
        public List<TeamModel> Teams
        {
            get { return teams; }
            set { SetProperty(ref teams, value); }
        }
        #endregion

        #region Methods
        async Task LoadTeams()
        {
            try
            {
                Teams = await _TeamService.GetTeamsAsync();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void filterByPosition()
        {

        }


        private void filterByTeam()
        {
        }
        private async void initialize()
        {
            await LoadTeams();
        }


        #endregion

        #region Navigation

        #endregion

        #region Commands
        public DelegateCommand FilterPlayerCommand => new DelegateCommand(filterByPosition);
        public DelegateCommand FilterTeamCommand => new DelegateCommand(filterByTeam);
        public DelegateCommand OnIntialize => new DelegateCommand(initialize);
        #endregion
    }
}