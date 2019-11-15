using System;
using System.Collections.Generic;

namespace shellXamarin.Module.ElLa3eba.Models
{

    public enum TypeEnum
    {
        Ranking,
        Role,
        Feeds,
        CommingGame,
        Steps
    }
    public class HomeModel
    {
        
        public TypeEnum Type { get; set; }

    }
}
