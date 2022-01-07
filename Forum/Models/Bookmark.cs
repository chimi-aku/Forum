using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum2._0.Models
{
    public class Bookmark
    {
        public int BookmarkID { get; set; }

        public int PostID { get; set; } 
		
		public virtual User User { get; set; }
		
		public virtual Post Post{ get; set; }
    }
}