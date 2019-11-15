using System;
using System.Collections.Generic;

namespace shellXamarin.Module.ElLa3eba.Models
{
    public class NewsFeedsModel : HomeModel
    {
        public List<NewsFeed> Feeds { get; set; }

    }
    public class NewsFeed{

        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

}
