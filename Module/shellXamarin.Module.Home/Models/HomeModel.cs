using System;
using System.Collections.Generic;

namespace shellXamarin.Module.Home.Models
{

    public enum TypeEnum
    {
        Ranking,
        Role,
        Feeds,
        CommingGame
    }
    public class HomeModel
    {
        public List<TeamRankModel> TeamsRanking { get; set; }
        public List<NewsFeedModel> Feeds { get; set; }
        public bool Accepted { get; set; }
        public bool WaitingResponse { get; set; }
        public TypeEnum Type { get; set; }
        public NextGameModel nextGame { get; set; }
    }
}
