using System;
namespace shellXamarin.Module.ElLa3eba.Models
{
    public class NextGameModel:HomeModel
    {
        public string MatchInfo { get; set; }
        public bool Accepted { get; set; }
        public string FirstTeam { get; set; }
        public string FirstTeamImage { get; set; }
        public string SecondTeam { get; set; }
        public string SecondTeamImage { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public bool WaitingResponse { get; set; }
    }
}
