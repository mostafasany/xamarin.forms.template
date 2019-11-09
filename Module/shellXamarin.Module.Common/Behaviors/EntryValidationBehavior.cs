using Xamarin.Forms;

namespace shellXamarin.Module.Common.Behaviors
{
    public class EntryValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty IsValidProperty =
            BindableProperty.CreateAttached("IsValid", typeof(bool), typeof(EntryValidationBehavior), false);
        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }
            set
            {
                SetValue(IsValidProperty, value);
            }
        }


        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += Bindable_TextChanged;
            base.OnAttachedTo(bindable);
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (sender as Entry);
            if(IsValid)
            {
                entry.PlaceholderColor = Color.Black;
                entry.TextColor = Color.Black;
            }
            else
            {
                entry.PlaceholderColor = Color.Red;
                entry.TextColor = Color.Red;
            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= Bindable_TextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}

