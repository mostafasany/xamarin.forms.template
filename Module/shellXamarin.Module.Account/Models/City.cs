using Prism.Mvvm;

namespace shellXamarin.Module.Account.Models
{
    public class City: BindableBase
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
