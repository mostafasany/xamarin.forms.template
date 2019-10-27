using System.Collections.Generic;

namespace shellXamarin.Module.Navigation.DataServices.Dto
{
    public class MenuElementDto
    {
        public bool Modal { get; set; }

        public bool CanNavigate { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public int Badge { get; set; }

        public string Page { get; set; }

        public List<MenuElementDto> Children { get; set; }
    }
}
