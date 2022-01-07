using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Thread
    {
        public int ThreadID { get; set; }

        public int ForumID { get; set; }

        public int AuthorID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Post>  Posts { get; set; }

        public virtual ICollection<PinPost> PinPosts { get; set; }


    }
}