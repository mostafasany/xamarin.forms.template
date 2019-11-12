using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using shellXamarin.Module.Common.Services;
using shellXamarin.Module.Common.Services.EventBusService;
using shellXamarin.Module.Common.Services.ExceptionService;
using shellXamarin.Module.Common.ViewModels;
using shellXamarin.Module.ElLa3eba.Models;

//TODO: 1. Ahmed Salah 
namespace shellXamarin.Module.ElLa3eba.ViewModels
{
    public class ElLa3ebaHomePageViewModel : BaseViewModel
    {
        public ElLa3ebaHomePageViewModel(INavigationService _navigationService, IEventBusService eventBusService,
            ILanguageService languageService, IExceptionService exceptionService)
            : base(languageService, eventBusService, exceptionService)
        {
            NavigationService = _navigationService;

            List<NewsFeedModel> feeds = new List<NewsFeedModel>();
            feeds.Add(new NewsFeedModel { Title = "Ahly won zmalek in the super cup 3-2", Image = "Ahly.svg" });
            feeds.Add(new NewsFeedModel { Title = "Ahly won zmalek 6-1", Image = "Ahly.svg" });
            feeds.Add(new NewsFeedModel { Title = "Ahly won zmalek 6-1", Image = "Ahly.svg" });
            NextGameModel nextGame = new NextGameModel { MatchInfo = "England Premier Leaue,Match Week 12", FirstTeam = "Liverpool", SecondTeam = "Manchester City", Date = "10/11/2019", Time = "21:00", FirstTeamImage = "Liverpool_FC.svg", SecondTeamImage = "Manchester_City_FC.svg" };

            List<TeamRankModel> teamRanks = new List<TeamRankModel>();
            teamRanks.Add(new TeamRankModel { Rank = 1, Name = "Al Ahly", ScoredIn = 22, NumberOfDrawn = 0, NumberOfWin = 5, NumberOfLose = 0 });
            teamRanks.Add(new TeamRankModel { Rank = 2, Name = "Al Zamalek", ScoredIn = 22, NumberOfDrawn = 2, NumberOfWin = 2, NumberOfLose = 1 });
            teamRanks.Add(new TeamRankModel { Rank = 3, Name = "Pyramids", ScoredIn = 22, NumberOfDrawn = 1, NumberOfWin = 2, NumberOfLose = 2 });

            HomeModel = new ObservableCollection<HomeModel>();
            HomeModel.Add(new HomeModel { Type = TypeEnum.Role });

            HomeModel.Add(new HomeModel { Type = TypeEnum.CommingGame, nextGame = nextGame, Accepted = false, WaitingResponse = true });
            HomeModel.Add(new HomeModel { Type = TypeEnum.CommingGame, nextGame = nextGame, Accepted = true, WaitingResponse = false });
            HomeModel.Add(new HomeModel { Type = TypeEnum.Ranking, TeamsRanking = teamRanks });
            HomeModel.Add(new HomeModel { Type = TypeEnum.Feeds, Feeds = feeds });
        }

        #region Properties
        private ObservableCollection<HomeModel> homeModel;
        public ObservableCollection<HomeModel> HomeModel
        {
            get { return homeModel; }
            set { SetProperty(ref homeModel, value); }
        }
        #endregion

        #region Methods


        private void BecomePlayer()
        {

        }

        private void BecomeManager()
        {


        }

        private void Accept()
        {

        }
        private void Decline()
        {

        }

        private void SetFormation()
        {

        }

        #endregion

        #region Navigation

        #endregion

        #region Commands
        public DelegateCommand BecomePlayerCommand => new DelegateCommand(BecomePlayer);
        public DelegateCommand BecomeManagerCommand => new DelegateCommand(BecomeManager);
        public DelegateCommand AcceptCommand => new DelegateCommand(Accept);
        public DelegateCommand DeclineCommand => new DelegateCommand(Decline);
        public DelegateCommand SetFormationCommand => new DelegateCommand(SetFormation);
        #endregion
    }
}