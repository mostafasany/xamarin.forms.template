using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Mvvm;
using shellXamarin.Module.Common.Models;
using Xamarin.Forms;

namespace shellXamarin.Module.Common.FormBuilder.Models
{
    public class Form : BindableBase
    {

        ObservableCollection<FormItem> items;
        public ObservableCollection<FormItem> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }
    }
    public class FormItem : BindableBase
    {
        public string Id { get; set; }

        string placeholder;
        public string Placeholder
        {
            get { return placeholder; }
            set { SetProperty(ref placeholder, value); }
        }

        bool required;
        public bool Required
        {
            get { return required; }
            set { SetProperty(ref required, value); }
        }

        bool visible = true;
        public bool Visible
        {
            get { return visible; }
            set { SetProperty(ref visible, value); }
        }

        public string RequiredMessage { get; set; }

        public string InvalidMessage { get; set; }

        public virtual bool IsInvalid()
        {
            return false;
        }

        public virtual bool IsRequried()
        {
            return false;
        }
    }

    public class DatePickerItem : FormItem
    {
        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public override bool IsInvalid()
        {
            return Date < StartDate || date > EndDate;
        }
    }

    public class PickerItem<T> : FormItem
    {
        List<T> items;
        public List<T> Items
        {
            get { return items; }
            set
            {
                SetProperty(ref items, value);
            }
        }

        public T Selected
        {
            get
            {
                return items != null ?
                    items.FirstOrDefault(a => a.GetType().GetProperty(SelectedKey).GetValue(a) as string == SelectedValue)
                    : default(T);
            }
        }

        public string SelectedKey { get; set; }

        public string SelectedValue { get; set; }

    }

    public class EntryItem : FormItem
    {
        string text;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }


        Keyboard keyboard;
        public Keyboard Keyboard
        {
            get { return keyboard; }
            set { SetProperty(ref keyboard, value); }
        }

        int maxChar;
        public int MaxChar
        {
            get { return maxChar; }
            set { SetProperty(ref maxChar, value); }
        }

        bool isPassword;
        public bool IsPassword
        {
            get { return isPassword; }
            set { SetProperty(ref isPassword, value); }
        }

        ReturnType returnType;
        public ReturnType ReturnType
        {
            get { return returnType; }
            set { SetProperty(ref returnType, value); }
        }

        public Regex Regex { get; set; }

        public int MinChar { get; set; } = 1;

        public string MinCharMessage { get; set; }

        public string MaxCharMessage { get; set; }

        public override bool IsInvalid()
        {
            if (Regex == null)
                return false;
            return !Regex.Match(text).Success;
        }

        public override bool IsRequried()
        {
            return string.IsNullOrEmpty(text);
        }
    }

    public class CheckItem : FormItem
    {
        bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set { SetProperty(ref isChecked, value); }
        }

        public override bool IsRequried()
        {
            return !isChecked && Required;
        }
    }

    public class NavigationItem<T> : PickerItem<T>
    {
        public NavigationContext NavigationContext { get; set; }
    }

    public class NavigationContext
    {
        public string NavigationPage { get; set; }

        //TODO: Check if it can be passed
        public DataTemplate PageTemplate { get; set; }

        public DelegateCommand<NavigationItem<INavigationElementEntity>> NavigationCommand { get; set; }
    }

    public class ButtonItem : FormItem
    {
        public DelegateCommand<FormItem> ActionCommand { get; set; }
        public string ActionType { get; set; }
    }

    public class SectionHeaderItem : FormItem
    {
        LayoutOptions horizontalLayoutOptions;
        public LayoutOptions HorizontalLayoutOptions
        {
            get { return horizontalLayoutOptions; }
            set { SetProperty(ref horizontalLayoutOptions, value); }
        }
    }
}
