using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum2._0.Models
{
    public class Post
    {
        public int PostID { get; set; }

        public int ThreadID { get; set; }

        public int AuthorID { get; set; }

        public string TextContent { get; set; }
         
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
		
		public virtual Thred Thred { get; set; }
		
		public virtual User User { get; set; }
    }
}