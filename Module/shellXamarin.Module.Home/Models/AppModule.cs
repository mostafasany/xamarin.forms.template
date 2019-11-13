using System.Collections.Generic;

namespace shellXamarin.Module.Home.Models
{
    public class AppModuleGroup:List<AppPage>
    {
        public AppModuleGroup(string name,List<AppPage> pages)
        {
            Name = name;
            if(pages!=null)
                this.AddRange(pages);
        }
        public string Name { get; set; }

    }

    public class AppPage
    {
        public AppPage(string name, string page)
        {
            Name = name;
            Page = page;
        }
        public string Name { get; set; }
        public string Page { get; set; }
    }
}
