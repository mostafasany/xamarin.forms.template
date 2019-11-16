using System;
using System.Collections.Generic;

namespace shellXamarin.Module.ElLa3eba.Models
{
    public class StepsModel:HomeModel
    {
        public List<Step> Steps { get; set; }
    }
    public class Step
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Finished { get; set; }
        
    }
}
