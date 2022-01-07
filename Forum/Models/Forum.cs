using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum2._0.Models
{
    public class Forum
    {
        public int ForumID { get; set; }

        public int AuthorID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public virtual ICollection<Thread> Threads { get; set; } 

        public virtual ICollection<PinThread> PinThreads { get; set; }
		
		public virtual User User { get; set; }

    }
}