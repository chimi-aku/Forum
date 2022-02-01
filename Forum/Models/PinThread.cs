using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class PinThread
    {
        public int PinThreadID { get; set; }

        public int ForumID { get; set; }

        public string AuthorID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<PinPost> PinPosts { get; set; }

        public virtual Forum Forum { get; set; }

        public virtual LoginViewModel Author { get; set; }
    }
}