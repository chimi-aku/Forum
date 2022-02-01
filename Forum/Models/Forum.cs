using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Forum
    {
        public string ForumID { get; set; }

        public string AuthorID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public virtual ICollection<Thread> Threads { get; set; } 

        public virtual ICollection<PinThread> PinThreads { get; set; }
		
		public virtual LoginViewModel Author { get; set; }

    }
}