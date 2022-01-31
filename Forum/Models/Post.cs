﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Post
    {
        public int PostID { get; set; }

        public int ThreadID { get; set; }

        public int AuthorID { get; set; }

        public string TextContent { get; set; }
		
		public virtual Thread Thread { get; set; }
		
		public virtual LoginViewModel Author { get; set; }
    }
}