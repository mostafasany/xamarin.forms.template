using Prism.Mvvm;

namespace shellXamarin.Module.ElLa3eba.Models
{
    public class Player : BindableBase
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public bool AvailableForNextMatch { get; set; }
    }
}
