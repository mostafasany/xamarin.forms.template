using System;
using System.Collections.Generic;
using shellXamarin.Module.ElLa3eba.ViewModels;
using Xamarin.Forms;

namespace shellXamarin.Module.ElLa3eba.Templates
{
    public partial class HomeTemplates
    {
        public HomeTemplates()
        {
            InitializeComponent();
        }
        void OnPlayerTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            if (((ListView)((ViewCell)((Grid)((Frame)sender).Parent).Parent).Parent).BindingContext is ElLa3ebaHomePageViewModel)
            {
                ((ElLa3ebaHomePageViewModel)((ListView)((ViewCell)((Grid)((Frame)sender).Parent).Parent).Parent).BindingContext).BecomePlayerCommand.Execute();

            }
        }
        void OnManagerTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            if (((ListView)((ViewCell)((Grid)((Frame)sender).Parent).Parent).Parent).BindingContext is ElLa3ebaHomePageViewModel)
            {
                ((ElLa3ebaHomePageViewModel)((ListView)((ViewCell)((Grid)((Frame)sender).Parent).Parent).Parent).BindingContext).BecomeManagerCommand.Execute();
            }
        }
    }
}
