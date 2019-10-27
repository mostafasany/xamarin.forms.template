using shellXamarin.Module.Common.FormBuilder.Models;
using shellXamarin.Module.Common.Models;
using Xamarin.Forms;

namespace shellXamarin.Module.Common.Views
{
    public class GenericFormTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EntryTemplate { get; set; }
        public DataTemplate DatePickerTemplate { get; set; }
        public DataTemplate PickerTemplate { get; set; }
        public DataTemplate NavigationTemplate { get; set; }
        public DataTemplate CheckTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is EntryItem)
            {
                return EntryTemplate;
            }
            else if (item is DatePickerItem)
            {
                return DatePickerTemplate;
            }
            else if (item is NavigationItem<INavigationElementEntity>)
            {
                return NavigationTemplate;
            }
            else if (item is PickerItem<INavigationElementEntity>)
            {
                return PickerTemplate;
            }
            else if (item is CheckItem)
            {
                return CheckTemplate;
            }
            return DefaultTemplate;
        }
    }
}

