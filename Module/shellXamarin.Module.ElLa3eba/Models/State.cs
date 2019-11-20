using Prism.Mvvm;
using shellXamarin.Module.Common.Models;

namespace shellXamarin.Module.ElLa3eba.Models
{
    public class State : BindableBase, INavigationElementEntity
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
