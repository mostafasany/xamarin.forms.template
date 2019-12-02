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

            List<NewsFeed> feeds = new List<NewsFeed>();
            feeds.Add(new NewsFeed { Title = "Ahly won zmalek in the super cup 3-2", Image = "Ahly.svg" });
            feeds.Add(new NewsFeed { Title = "Ahly won zmalek 6-1", Image = "Ahly.svg" });
            feeds.Add(new NewsFeed { Title = "Ahly won zmalek 6-1", Image = "Ahly.svg" });
            NextGameModel nextGame = new NextGameModel { Type = TypeEnum.CommingGame, MatchInfo = "England Premier Leaue,Match Week 12", FirstTeam = "Liverpool", SecondTeam = "Manchester City", Date = "10/11/2019", Time = "21:00", FirstTeamImage = "Liverpool_FC.svg", SecondTeamImage = "Manchester_City_FC.svg", Accepted = true, WaitingResponse = false };
            NextGameModel nextGameFormation = new NextGameModel { Type = TypeEnum.CommingGame, MatchInfo = "England Premier Leaue,Match Week 12", FirstTeam = "Liverpool", SecondTeam = "Manchester City", Date = "10/11/2019", Time = "21:00", FirstTeamImage = "Liverpool_FC.svg", SecondTeamImage = "Manchester_City_FC.svg", Accepted = false, WaitingResponse = true };
            List<TeamRank> teamRanks = new List<TeamRank>();
            teamRanks.Add(new TeamRank { Rank = 1, Name = "Al Ahly", ScoredIn = 22, NumberOfDrawn = 0, NumberOfWin = 5, NumberOfLose = 0 });
            teamRanks.Add(new TeamRank { Rank = 2, Name = "Al Zamalek", ScoredIn = 22, NumberOfDrawn = 2, NumberOfWin = 2, NumberOfLose = 1 });
            teamRanks.Add(new TeamRank { Rank = 3, Name = "Pyramids", ScoredIn = 22, NumberOfDrawn = 1, NumberOfWin = 2, NumberOfLose = 2 });

            List<Step> stepsList = new List<Step>();
            stepsList.Add(new Step { Finished = true, Name = "First Step", Image = "number.svg" });
            stepsList.Add(new Step { Finished = true, Name = "Second Step", Image = "number-2.svg" });
            stepsList.Add(new Step { Finished = true, Name = "Third Step", Image = "number-3.svg" });
            stepsList.Add(new Step { Finished = false, Name = "Fourth Step", Image = "number-4.svg" });

            HomeModel = new ObservableCollection<HomeModel>();
            HomeModel.Add(new HomeModel { Type = TypeEnum.Role });
            HomeModel.Add(new StepsModel { Type = TypeEnum.Steps, Steps = stepsList });
            HomeModel.Add(nextGameFormation);
            HomeModel.Add(nextGame);
            HomeModel.Add(new TeamRanksModel { Type = TypeEnum.Ranking, TeamsRanking = teamRanks });
            HomeModel.Add(new NewsFeedsModel { Type = TypeEnum.Feeds, Feeds = feeds });
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
            NavigationService.NavigateAsync("BecomePlayerPage");

        }

        private void BecomeManager()
        {
            NavigationService.NavigateAsync("BecomeManagerPage");
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