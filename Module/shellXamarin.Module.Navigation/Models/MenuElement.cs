using System.Collections.Generic;

namespace shellXamarin.Module.Navigation.Models
{
    public class MenuElementGroup : List<MenuElement>
    {
        public MenuElementGroup(
            string title,
            string page,
            string icon = "",
            bool canNavigate = true,
            bool modal = false,
            List<MenuElement> children = null
        )
        {
            if (children != null)
                this.AddRange(children);
            Title = title;
            Page = page;
            Icon = icon;
            Modal = modal;
            CanNavigate = canNavigate;
        }

        public bool RequireLogin { get; set; } = false;

        public bool Modal { get; set; }

        public bool CanNavigate { get; set; }

        public string Title { get; }

        public string Icon { get; }

        public int Badge { get; set; }

        public string Page { get; }
    }

    public class MenuElement
    {
        public MenuElement(
            string title,
            string page,
            string icon = "",
            bool canNavigate = true,
            bool modal = false
        )
        {
            
            Title = title;
            Page = page;
            Icon = icon;
            Modal = modal;
            CanNavigate = canNavigate;
        }

        public bool RequireLogin { get; set; } = false;

        public bool Modal { get; set; }

        public bool CanNavigate { get; set; }

        public string Title { get; }

        public string Icon { get; }

        public int Badge { get; set; }

        public string Page { get; }
    }
}
