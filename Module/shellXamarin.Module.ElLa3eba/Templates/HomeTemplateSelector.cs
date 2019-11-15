﻿using System;
using shellXamarin.Module.ElLa3eba.Models;
using Xamarin.Forms;

namespace shellXamarin.Module.ElLa3eba.Templates
{
    public class HomeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TeamRankingTemplate { get; set; }
        public DataTemplate ChooseRoleTemplate { get; set; }
        public DataTemplate FeedsTemplate { get; set; }
        public DataTemplate CommingGameTemplate { get; set; }
        public DataTemplate StepsTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is HomeModel && (item as HomeModel).Type == TypeEnum.Role)
            {
                return ChooseRoleTemplate;
            }
            else if (item is HomeModel && (item as HomeModel).Type == TypeEnum.Feeds)
            {
                return FeedsTemplate;
            }
            else if (item is HomeModel && (item as HomeModel).Type == TypeEnum.CommingGame)
            {
                return CommingGameTemplate;
            }
            else if (item is HomeModel && (item as HomeModel).Type == TypeEnum.Ranking)
            {
                return TeamRankingTemplate;
            }
            else if (item is HomeModel && (item as HomeModel).Type == TypeEnum.Steps)
            {
                return StepsTemplate;
            }
            return DefaultTemplate;
        }
    }
}
