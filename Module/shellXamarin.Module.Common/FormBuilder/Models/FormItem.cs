using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using shellXamarin.Module.Common.Models;
using Xamarin.Forms;

namespace shellXamarin.Module.Common.FormBuilder.Models
{
    public class FormItem : BaseModel
    {

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


        public string RequiredMessage { get; set; }

        public string InvalidMessage { get; set; }

    }

    public class DatePickerItem : FormItem
    {
        DateTime text;
        public DateTime Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }
    }


    public class ListItem<T> : FormItem
    {
        List<T> items;
        public List<T> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public T Selected
        {
            get
            {
                return items.FirstOrDefault(a => a.GetType().GetProperty(SelectedKey).GetValue(a) as string == SelectedValue);
            }
        }

        public string SelectedKey { get; set; }

        public string SelectedValue { get; set; }

    }

    public class FormEntryItem : FormItem
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

        public bool RegexInvalid() => !Regex.Match(text).Success;

        public bool RequiredInvalid() => string.IsNullOrEmpty(text);

    }
}
