using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum2._0.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }

        public int AuthorID { get; set; }

        public string Name { get; set; }

        public string TextContent { get; set; }

    }
}