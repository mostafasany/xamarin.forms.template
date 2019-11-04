using Prism.Mvvm;
using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.Account.Models
{
    public class Country : BindableBase, INavigationElementEntity
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
