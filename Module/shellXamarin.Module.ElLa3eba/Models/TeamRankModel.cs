using System;
using System.Collections.Generic;

namespace shellXamarin.Module.ElLa3eba.Models
{
    public class TeamRanksModel : HomeModel
    {
        public List<TeamRank> TeamsRanking { get; set; }

    }
    public class TeamRank
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public int ScoredIn { get; set; }
        public int NumberOfWin { get; set; }
        public int NumberOfLose { get; set; }
        public int NumberOfDrawn { get; set; }
    }
}

