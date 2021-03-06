using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }

        public string AuthorID { get; set; }

        public string Name { get; set; }

        public string TextContent { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}